using ImageMagick;
using ImageMagick.Drawing;

namespace XivplanIconGenerator;

class Configuration
{
    /// <summary>
    /// Crop off this many pixels from all sides
    /// </summary>
    public uint? Shave { get; set; } = null;

    /// <summary>
    /// Resize to this size
    /// </summary>
    public IMagickGeometry? Resize { get; set; } = null;

    public bool IsDirectCopy => Shave is null && Resize is null;
}

internal class Editor
{
    public static void OptimizeImages(string directory)
    {
        ProcessHelper.Run("oxipng", [directory, "--recursive", "--opt", "max", "-sa"]);
    }

    public static void EditImage(string source, string dest, Configuration config)
    {
        if (config.IsDirectCopy)
        {
            File.Copy(source, dest, overwrite: true);
            return;
        }

        using var image = new MagickImage(source);

        if (config.Shave.HasValue)
        {
            image.Shave(config.Shave.Value);
            image.ResetPage();
        }

        if (config.Resize is not null)
        {
            image.Resize(config.Resize);
        }

        if (Path.GetDirectoryName(dest) is string directory)
        {
            Directory.CreateDirectory(directory);
        }

        image.Write(dest);
    }

    public static void CreateSplitIcon(string leftSource, string rightSource, string dest)
    {
        using var leftImage = new MagickImage(leftSource);
        using var rightImage = new MagickImage(rightSource);

        // Create a mask with a split along the bottom-left to top-right diagonal.
        using var mask = new MagickImage(MagickColors.Black, leftImage.Width, leftImage.Height);

        new Drawables()
            .StrokeWidth(0.5)
            .StrokeColor(MagickColors.White)
            .FillColor(MagickColors.White)
            .EnableStrokeAntialias()
            .Polygon(
                new PointD(mask.Width, 0),
                new PointD(mask.Width, mask.Height),
                new PointD(0, mask.Height)
            )
            .Draw(mask);

        // Composite the images so each side of the split has a different image.
        rightImage.SetWriteMask(mask);
        rightImage.Composite(leftImage, CompositeOperator.Over, Channels.RGB);

        rightImage.Write(dest);
    }
}
