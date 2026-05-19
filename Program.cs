using System.CommandLine;
using ImageMagick;
using XivplanIconGenerator;

var Copy = new Configuration();

var PartyCropResize = new Configuration { Shave = 13, Resize = new MagickGeometry(64, 64) };

var Resize256 = new Configuration { Resize = new MagickGeometry(256, 256) };

// Icons to generate
List<(int Id, string Path, Configuration Config)> Icons =
[
    // Markers (80x80)
    (61201, "marker/attack1.png", Copy),
    (61202, "marker/attack2.png", Copy),
    (61203, "marker/attack3.png", Copy),
    (61204, "marker/attack4.png", Copy),
    (61205, "marker/attack5.png", Copy),
    (61206, "marker/attack6.png", Copy),
    (61207, "marker/attack7.png", Copy),
    (61208, "marker/attack8.png", Copy),
    (61211, "marker/bind1.png", Copy),
    (61212, "marker/bind2.png", Copy),
    (61213, "marker/bind3.png", Copy),
    (61214, "marker/bind4.png", Copy),
    (61215, "marker/bind5.png", Copy),
    (61216, "marker/bind6.png", Copy),
    (61217, "marker/bind7.png", Copy),
    (61218, "marker/bind8.png", Copy),
    (61221, "marker/ignore1.png", Copy),
    (61222, "marker/ignore2.png", Copy),
    (61223, "marker/ignore3.png", Copy),
    (61224, "marker/ignore4.png", Copy),
    (61225, "marker/ignore5.png", Copy),
    (61226, "marker/ignore6.png", Copy),
    (61227, "marker/ignore7.png", Copy),
    (61228, "marker/ignore8.png", Copy),
    (61231, "marker/square.png", Copy),
    (61232, "marker/circle.png", Copy),
    (61233, "marker/cross.png", Copy),
    (61234, "marker/triangle.png", Copy),
    (61241, "marker/waymark_a.png", Copy),
    (61242, "marker/waymark_b.png", Copy),
    (61243, "marker/waymark_c.png", Copy),
    (61244, "marker/waymark_1.png", Copy),
    (61245, "marker/waymark_2.png", Copy),
    (61246, "marker/waymark_3.png", Copy),
    (61247, "marker/waymark_d.png", Copy),
    (61248, "marker/waymark_4.png", Copy),
    // Party (64x64)
    (62146, "actor/any.png", Copy),
    // Enemies (80x80)
    (88003, "actor/enemy_small.png", Copy),
    (88006, "actor/enemy_medium.png", Copy),
    (88041, "actor/enemy_large.png", Copy),
    (88085, "actor/enemy_huge.png", Copy),
    (88203, "actor/enemy_circle.png", Copy),
    // Party (256x256)
    (230901, "actor/tank.png", PartyCropResize),
    (230902, "actor/healer.png", PartyCropResize),
    (230903, "actor/dps.png", PartyCropResize),
    (230922, "actor/PLD.png", PartyCropResize),
    (230923, "actor/MNK.png", PartyCropResize),
    (230924, "actor/WAR.png", PartyCropResize),
    (230925, "actor/DRG.png", PartyCropResize),
    (230926, "actor/BRD.png", PartyCropResize),
    (230927, "actor/WHM.png", PartyCropResize),
    (230928, "actor/BLM.png", PartyCropResize),
    (230930, "actor/SMN.png", PartyCropResize),
    (230931, "actor/SCH.png", PartyCropResize),
    (230933, "actor/NIN.png", PartyCropResize),
    (230934, "actor/MCH.png", PartyCropResize),
    (230935, "actor/DRK.png", PartyCropResize),
    (230936, "actor/AST.png", PartyCropResize),
    (230937, "actor/SAM.png", PartyCropResize),
    (230938, "actor/RDM.png", PartyCropResize),
    (230939, "actor/BLU.png", PartyCropResize),
    (230940, "actor/GNB.png", PartyCropResize),
    (230941, "actor/DNC.png", PartyCropResize),
    (230942, "actor/RPR.png", PartyCropResize),
    (230943, "actor/SGE.png", PartyCropResize),
    (230944, "actor/VPR.png", PartyCropResize),
    (230945, "actor/PCT.png", PartyCropResize),
    (230946, "actor/tank1.png", PartyCropResize),
    (230947, "actor/tank2.png", PartyCropResize),
    (230948, "actor/healer1.png", PartyCropResize),
    (230949, "actor/healer2.png", PartyCropResize),
    (230950, "actor/dps1.png", PartyCropResize),
    (230951, "actor/dps2.png", PartyCropResize),
    (230952, "actor/dps3.png", PartyCropResize),
    (230953, "actor/dps4.png", PartyCropResize),
    (230954, "actor/melee.png", PartyCropResize),
    (230955, "actor/melee1.png", PartyCropResize),
    (230956, "actor/melee2.png", PartyCropResize),
    (230957, "actor/ranged.png", PartyCropResize),
    (230958, "actor/ranged1.png", PartyCropResize),
    (230959, "actor/ranged2.png", PartyCropResize),
    (230960, "actor/physical_ranged.png", PartyCropResize),
    (230961, "actor/magic_ranged.png", PartyCropResize),
    (230962, "actor/pure_healer.png", PartyCropResize),
    (230963, "actor/barrier_healer.png", PartyCropResize),
    (230964, "actor/BST.png", PartyCropResize),
    // Markers (192x192)
    (240032, "marker/target_red.png", Copy),
    (240033, "marker/target_blue.png", Copy),
    (240034, "marker/target_purple.png", Copy),
    (240035, "marker/target_green.png", Copy),
    (240036, "marker/shape_circle.png", Copy),
    (240037, "marker/shape_cross.png", Copy),
    (240038, "marker/shape_square.png", Copy),
    (240039, "marker/shape_triangle.png", Copy),
    // Markers (1024x1024)
    (240201, "marker/eye.png", Resize256),
    (240206, "marker/proximity.png", Resize256),
    (240207, "marker/tankbuster.png", Resize256),
    (240211, "marker/target_crosshairs.png", Resize256),
    // Enemy icons (256x256)
    (240101, "actor/enemy1.png", Copy),
    (240102, "actor/enemy2.png", Copy),
    (240103, "actor/enemy3.png", Copy),
];

var sqpackPathOption = new Option<DirectoryInfo>("--sqpack", "-q")
{
    Description = @"Path to the ""game\sqpack"" directory",
    HelpName = "path",
};
sqpackPathOption.AcceptExistingOnly();

var outputPathOption = new Option<DirectoryInfo>("--out", "-o")
{
    Description = "Ouptut directory [default: ./out]",
    HelpName = "path",
};

var skipDumpOption = new Option<bool>("--skip-dump") { Description = "Skip dumping images" };

var skipOptimizeOption = new Option<bool>("--skip-optimize")
{
    Description = "Skip optimizing images",
};

var rootCommand = new RootCommand("Generate XIVPlan icons")
{
    sqpackPathOption,
    outputPathOption,
    skipDumpOption,
    skipOptimizeOption,
};
rootCommand.SetAction(GenerateIcons);

var result = rootCommand.Parse(args);
return result.Invoke();

int GenerateIcons(ParseResult result)
{
    var sqpackPath = result.GetValue(sqpackPathOption);
    var outputPath = result.GetValue(outputPathOption) ?? new DirectoryInfo("out");
    var xivplanOutputPath = Path.Join(outputPath.FullName, "xivplan");

    var skipDump = result.GetValue(skipDumpOption);
    var skipOptimize = result.GetValue(skipOptimizeOption);

    if (!skipOptimize && ProcessHelper.Which("oxipng") is null)
    {
        Console.Error.WriteLine(
            "Optimizing images requires oxipng: https://github.com/oxipng/oxipng"
        );
        Console.Error.WriteLine();
        Console.Error.WriteLine("Make sure oxipng is on your PATH or use --skip-optimize");
        return 1;
    }

    var dumper = new Dumper() { OutputPath = outputPath, SqpackPath = sqpackPath };

    if (!skipDump)
    {
        Console.WriteLine("Dumping images...");
        dumper.DumpImages(Icons.Select(item => item.Id));
    }

    Console.WriteLine("Generating icons...");
    Directory.CreateDirectory(xivplanOutputPath);

    foreach (var (id, name, config) in Icons)
    {
        var source = dumper.GetImagePath(id);
        var dest = Path.Join(xivplanOutputPath, name);

        Editor.EditImage(source, dest, config);
    }

    Editor.CreateSplitIcon(
        leftSource: Path.Join(xivplanOutputPath, "actor/healer.png"),
        rightSource: Path.Join(xivplanOutputPath, "actor/tank.png"),
        dest: Path.Join(xivplanOutputPath, "actor/support.png")
    );

    Console.WriteLine("Optimizing icons...");
    Editor.OptimizeImages(xivplanOutputPath);

    return 0;
}
