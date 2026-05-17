namespace XivplanIconGenerator;

internal class Dumper
{
    public required DirectoryInfo OutputPath { get; set; }
    public DirectoryInfo? SqpackPath { get; set; } = null;

    public void DumpImages(IEnumerable<int> icons)
    {
        // The dumper process takes a while to load. Consolidate the list of icons into
        // a list of ranges of icons.
        List<(int, int)> ranges = [];
        int start = -1;
        int end = -1;

        foreach (var icon in icons.Order())
        {
            if (start < 0)
            {
                start = icon;
                end = icon;
                continue;
            }

            // Dumping a few images we don't need takes less time than starting a new instance.
            // So merge together non-contiguous ranges with small gaps.
            if (icon <= end + 200)
            {
                end = icon;
                continue;
            }

            ranges.Add((start, end));

            start = icon;
            end = icon;
        }

        if (start >= 0)
        {
            ranges.Add((start, end));
        }

        foreach (var (first, last) in ranges)
        {
            DumpImages(first, last);
        }
    }

    public void DumpImages(int first, int last)
    {
        List<string> args =
        [
            "Spadin.FfxivImageDump",
            "--",
            first.ToString(),
            last.ToString(),
            "--out",
            OutputPath.FullName,
        ];

        if (SqpackPath is not null)
        {
            args.AddRange("--sqpack", SqpackPath.FullName);
        }

        var dnx = ProcessHelper.Which("dnx") ?? throw new Exception("Could not find \"dnx\" tool");

        ProcessHelper.Run(dnx, args);
    }

    public string GetImagePath(int icon)
    {
        var group = $"{icon / 1000:000}000";
        var name = $"{icon:000000}_hr1.png";

        return Path.Join(OutputPath.FullName, "ui", "icon", group, name);
    }
}
