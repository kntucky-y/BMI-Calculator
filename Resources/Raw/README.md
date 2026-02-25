# Raw Assets

This directory can contain raw assets that will be included in the app bundle.

Raw assets are files that are copied directly to the app bundle without any processing.

Examples:
- JSON configuration files  
- Text files
- Data files
- HTML files

These files can be accessed at runtime using the `FileSystem.OpenAppPackageFileAsync()` method.
