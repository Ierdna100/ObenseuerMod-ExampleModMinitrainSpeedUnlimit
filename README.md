# Minitrain Speed Unlimiter

I needed a repository to test the GitHub API from an external app, so I made this.

It allows you to bump the speed limit of Minitrain speed cameras from the default 12 km/h. You can modify the speed limit by opening the F10 menu. The value won't save and the F10 menu is only usable with the escape menu open, again this is mostly for the GitHub API test.

## Template

Made using the mod template for BepInEx found here: https://github.com/ObenseuerModding/BepInExModTemplate

## Compilation

You'll need to clone the build.props.template file, remove the .template extension, and fill the Project.PropertyGroup.GameDir property with your game's directory for the project to load correctly.
