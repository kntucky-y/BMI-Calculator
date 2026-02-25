# BMI Calculator - .NET MAUI

A modern and intuitive BMI (Body Mass Index) Calculator built using .NET MAUI (Multi-platform App UI). This cross-platform application allows users to calculate their BMI and view their health category.

## Features

- 🎯 **Simple Input**: Enter your height (cm) and weight (kg)
- 📊 **Instant Calculation**: Calculate BMI with a single tap
- 🎨 **Visual Feedback**: Color-coded results based on BMI category
- 📱 **Cross-Platform**: Runs on Android, iOS, macOS, and Windows
- 💫 **Smooth Animations**: Beautiful UI transitions and effects
- ✅ **Input Validation**: Ensures valid data entry

## BMI Categories

The app categorizes BMI into four ranges:

- **Underweight**: BMI < 18.5 (Orange)
- **Normal Weight**: BMI 18.5 - 24.9 (Green)
- **Overweight**: BMI 25 - 29.9 (Orange)
- **Obese**: BMI ≥ 30 (Red)

## Prerequisites

To build and run this project, you need:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Visual Studio 2022 (v17.8 or later) with .NET MAUI workload installed
  - OR Visual Studio Code with C# Dev Kit extension
- For platform-specific development:
  - **Android**: Android SDK
  - **iOS/macOS**: Xcode (macOS only)
  - **Windows**: Windows 10/11 SDK

## Installation & Setup

1. **Clone the repository:**
   ```bash
   git clone <your-github-repository-url>
   cd BMI Calculator
   ```

2. **Restore NuGet packages:**
   ```bash
   dotnet restore
   ```

3. **Build the project:**
   ```bash
   dotnet build
   ```

4. **Run the application:**
   
   For Windows:
   ```bash
   dotnet build -t:Run -f net8.0-windows10.0.19041.0
   ```
   
   For Android:
   ```bash
   dotnet build -t:Run -f net8.0-android
   ```
   
   For iOS (macOS only):
   ```bash
   dotnet build -t:Run -f net8.0-ios
   ```
   
   For macCatalyst (macOS only):
   ```bash
   dotnet build -t:Run -f net8.0-maccatalyst
   ```

## Using Visual Studio

1. Open `BMICalculator.csproj` or the solution file in Visual Studio 2022
2. Select your target platform from the debug dropdown
3. Press F5 or click the "Run" button

## Project Structure

```
BMI Calculator/
├── App.xaml                 # Application resources
├── App.xaml.cs             # Application initialization
├── AppShell.xaml           # Shell navigation structure
├── AppShell.xaml.cs        # Shell code-behind
├── MainPage.xaml           # Main UI page
├── MainPage.xaml.cs        # BMI calculation logic
├── MauiProgram.cs          # App configuration
├── BMICalculator.csproj    # Project file
├── Resources/
│   ├── Styles/
│   │   ├── Colors.xaml     # Color definitions
│   │   └── Styles.xaml     # UI styles
│   ├── Fonts/              # Custom fonts
│   ├── Images/             # App images
│   └── AppIcon/            # App icon
└── README.md
```

## How to Use

1. Launch the application
2. Enter your height in centimeters (e.g., 170)
3. Enter your weight in kilograms (e.g., 70)
4. Tap the "Calculate BMI" button
5. View your BMI value and health category

## Technologies Used

- **.NET 8**: Latest .NET framework
- **.NET MAUI**: Cross-platform UI framework
- **XAML**: UI markup language
- **C#**: Programming language

## BMI Calculation Formula

```
BMI = weight (kg) / (height (m))²
```

## Screenshots

*(Add screenshots of your app here when running)*

## Contributing

Feel free to fork this project and submit pull requests for any improvements.

## License

This project is open source and available for educational purposes.

## Author

Created as a .NET MAUI learning project.

## Notes

- The app uses metric units (centimeters and kilograms)
- BMI is a general indicator and should not replace professional medical advice
- Always consult healthcare professionals for health-related concerns

## Troubleshooting

If you encounter build issues:

1. Ensure you have the latest .NET 8 SDK installed
2. Verify .NET MAUI workload is installed:
   ```bash
   dotnet workload install maui
   ```
3. Clean and rebuild the solution:
   ```bash
   dotnet clean
   dotnet build
   ```

## Support

For issues or questions, please open an issue in the GitHub repository.
