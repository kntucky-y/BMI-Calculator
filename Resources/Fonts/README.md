# Fonts Directory

This directory should contain the Open Sans font files required by the application.

## Required Fonts

The application expects the following font files:

1. **OpenSans-Regular.ttf**
2. **OpenSans-Semibold.ttf**

## How to add fonts

### Option 1: Download from Google Fonts

1. Visit [Google Fonts - Open Sans](https://fonts.google.com/specimen/Open+Sans)
2. Download the Open Sans font family
3. Extract the downloaded ZIP file
4. Copy `OpenSans-Regular.ttf` and `OpenSans-Semibold.ttf` to this directory

### Option 2: Use .NET MAUI Template Fonts

When you create a new .NET MAUI project from the template, these fonts are included by default. You can copy them from a template project.

### Alternative: Use System Fonts

If you prefer not to include custom fonts, you can modify the `MauiProgram.cs` file to remove font configuration and update XAML files to use system fonts instead.

## Note

The project will not build without these fonts unless you modify the font references in:
- `MauiProgram.cs`
- `Resources/Styles/Styles.xaml`
