# XIVPlan Icon Generator

A tool for extracting icons from Final Fantasy XIV and modifying them for use in [XIVPlan](https://github.com/joelspadin/xivplan).

## Installation

Install the following:

- [Final Fantasy XIV](https://finalfantasyxiv.com/)
- [.NET Runtime 10.0](https://dotnet.microsoft.com/en-us/download/dotnet/10.0).
- [Oxipng](https://github.com/oxipng/oxipng)

## Usage

Clone this repo and run the program:

```
dotnet run
```

This assumes that Final Fantasy XIV is installed to its default path at `C:\Program Files (x86)\SquareEnix\FINAL FANTASY XIV - A Realm Reborn`. If you have installed it to a custom path, use the `--sqpack` option and provide the path to the game's `game\sqpack` folder.

```sh
dotnet run --sqpath 'D:\Final Fantasy XIV - A Realm Reborn\game\sqpack'
```

This will extract the icons to `out/ui`, then modify them and optimize them for size, placing the final images in `out/xivplan`. The contents of `out/xivplan` can then be pasted into XIVPlan's `public` folder.

## Ading New Icons

First, use [FfxivImageDump](https://github.com/joelspadin/FfxivImageDump) to dump the UI icons and identify the icon number.

Next, edit the `Icons` array in [Program.cs](./Program.cs) to add the icon. Each entry is a tuple of the icon number, the destination path, and a `Configuration` object describing any modifications that need to be done, such as resizing the image.
