# BMI Calculator

A BMI calculator app built with .NET MAUI for my mobile development project.

## Features

- Calculate BMI based on height, weight, age, and gender
- Switch between Metric (cm/kg) and Imperial (in/lbs) units
- Shows your actual BMI vs ideal BMI comparison
- Age-based BMI categories (children, adults, seniors)
- Gender-specific BMI ranges
- Dark theme UI with pastel accent colors
- Popup results with smooth animations

## How It Works

1. Select your gender (Male/Female)
2. Choose unit system (Metric/Imperial)
3. Input your height using the slider or tap to type
4. Enter your weight and age
5. Tap "CALCULATE BMI" to see results

The app will show you:
- Your current BMI
- Your ideal BMI for your age/gender
- How many points away from ideal
- BMI category (Underweight, Normal, Overweight, Obese)

## Tech Stack

- .NET MAUI 9.0
- C# & XAML
- Targets Android (tested on Pixel 8 emulator)

## Running the App

Make sure you have .NET 9 SDK installed, then run:

```bash
dotnet build -f net9.0-android -t:Run
```

Or open in VS Code with MAUI extension and press F5.

## BMI Categories

**Adults (18-64):**
- Male: Normal is 18.5-24.9, Ideal is 21.7
- Female: Healthy is 18.5-23.9, Ideal is 21.2

**Seniors (65+):** Healthy range is 22-27, Ideal is 24.5

**Children (<18):** Healthy range is 18.5-25, Ideal is 21.75

## Notes

Default values start at 0. The app converts units automatically when you switch between metric and imperial.
