# Sonic Audio Tools

A set of tools to modify CRIWARE file formats (specifically Sonic Unleashed, but it can be for other games from more or less the same time period).

## Releases

You can get the latest development builds on the [AppVeyor page.](https://ci.appveyor.com/project/blueskythlikesclouds/sonicaudiotools/build/artifacts)  
Stable builds are published on the [Releases page.](https://github.com/blueskythlikesclouds/SonicAudioTools/releases)

## Building

If you still wish to build the solution yourself, do as follows:

1. Clone from [GitHub](https://github.com/blueskythlikesclouds/SonicAudioTools.git) `git clone https://github.com/blueskythlikesclouds/SonicAudioTools.git`
2. Open the solution in Visual Studio. (Visual Studio 2017 or later is required.)
3. Install the missing NuGet packages.
4. Build the solution.

## Projects

If you wish to see more detailed information about the projects, visit the [wiki](https://github.com/blueskythlikesclouds/SonicAudioTools/wiki) page.

### [Sonic Audio Library](https://github.com/blueskythlikesclouds/SonicAudioTools/tree/master/Source/SonicAudioLib)

This is the main library of the solution.  Contains classes for IO and file formats.

### [CSB Builder](https://github.com/blueskythlikesclouds/SonicAudioTools/tree/master/Source/CsbBuilder)

This tool allows you to create or edit CSB files. You can do things like adding/removing cues, editing real-time sound parameters, and more.

### [CSB Editor](https://github.com/blueskythlikesclouds/SonicAudioTools/tree/master/Source/CsbEditor)

This tool allows you to edit the audio content of a CSB file.  
It works like ACB Editor, and it is a lot simpler to use than CSB Builder.

## License

See [LICENSE.md](https://github.com/blueskythlikesclouds/SonicAudioTools/blob/master/LICENSE.md) for details.
