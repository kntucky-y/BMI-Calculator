namespace BMICalculator;

public partial class MainPage : ContentPage
{
	private bool isMale = true;
	private bool isMetric = true;
	private double height = 0;
	private const int DefaultHeightCm = 0;
	private const int DefaultHeightInch = 0;

	public MainPage()
	{
		InitializeComponent();
		UpdateGenderUI();
		UpdateUnitUI();
	}

	private void OnMaleSelected(object sender, EventArgs e)
	{
		isMale = true;
		UpdateGenderUI();
		CloseResultPopup();
	}

	private void OnFemaleSelected(object sender, EventArgs e)
	{
		isMale = false;
		UpdateGenderUI();
		CloseResultPopup();
	}

	private void OnMetricSelected(object sender, EventArgs e)
	{
		if (!isMetric)
		{
			isMetric = true;
			ConvertToMetric();
			UpdateUnitUI();
			CloseResultPopup();
		}
	}

	private void OnImperialSelected(object sender, EventArgs e)
	{
		if (isMetric)
		{
			isMetric = false;
			ConvertToImperial();
			UpdateUnitUI();
			CloseResultPopup();
		}
	}

	private void UpdateUnitUI()
	{
		if (isMetric)
		{
			MetricBorder.BackgroundColor = Colors.White;
			MetricLabel.TextColor = Colors.Black;
			ImperialBorder.BackgroundColor = Colors.Transparent;
			ImperialLabel.TextColor = Color.FromArgb("#808080");

			HeightUnitLabel.Text = "HEIGHT (CM)";
			HeightUnitSmallLabel.Text = "cm";
			WeightUnitLabel.Text = "WEIGHT (KG)";
			
			HeightSlider.Minimum = 0;
			HeightSlider.Maximum = 250;
		}
		else
		{
			MetricBorder.BackgroundColor = Colors.Transparent;
			MetricLabel.TextColor = Color.FromArgb("#808080");
			ImperialBorder.BackgroundColor = Colors.White;
			ImperialLabel.TextColor = Colors.Black;

			HeightUnitLabel.Text = "HEIGHT (IN)";
			HeightUnitSmallLabel.Text = "in";
			WeightUnitLabel.Text = "WEIGHT (LBS)";
			
			HeightSlider.Minimum = 0;
			HeightSlider.Maximum = 98;
		}
	}

	private void ConvertToMetric()
	{
		if (double.TryParse(HeightValueLabel.Text, out double currentHeight))
		{
			height = currentHeight * 2.54;
			HeightValueLabel.Text = ((int)height).ToString();
			HeightSlider.Value = (int)height;
		}
		else
		{
			height = DefaultHeightCm;
			HeightValueLabel.Text = DefaultHeightCm.ToString();
			HeightSlider.Value = DefaultHeightCm;
		}

		if (!string.IsNullOrWhiteSpace(WeightEntry.Text) && double.TryParse(WeightEntry.Text, out double weightLbs))
		{
			int weightKg = (int)(weightLbs / 2.205);
			WeightEntry.Text = weightKg.ToString();
		}
	}

	private void ConvertToImperial()
	{
		if (double.TryParse(HeightValueLabel.Text, out double currentHeight))
		{
			height = currentHeight / 2.54;
			HeightValueLabel.Text = ((int)height).ToString();
			HeightSlider.Value = (int)height;
		}
		else
		{
			height = DefaultHeightInch;
			HeightValueLabel.Text = DefaultHeightInch.ToString();
			HeightSlider.Value = DefaultHeightInch;
		}

		if (!string.IsNullOrWhiteSpace(WeightEntry.Text) && double.TryParse(WeightEntry.Text, out double weightKg))
		{
			int weightLbs = (int)(weightKg * 2.205);
			WeightEntry.Text = weightLbs.ToString();
		}
	}

	private void UpdateGenderUI()
	{
		if (isMale)
		{
			MaleBorder.BackgroundColor = Color.FromArgb("#A7C7E7");
			MaleIcon.TextColor = Colors.White;
			MaleLabel.TextColor = Colors.White;
			
			FemaleBorder.BackgroundColor = Color.FromArgb("#2C2C2C");
			FemaleIcon.TextColor = Color.FromArgb("#606060");
			FemaleLabel.TextColor = Color.FromArgb("#606060");
		}
		else
		{
			MaleBorder.BackgroundColor = Color.FromArgb("#2C2C2C");
			MaleIcon.TextColor = Color.FromArgb("#606060");
			MaleLabel.TextColor = Color.FromArgb("#606060");
			
			FemaleBorder.BackgroundColor = Color.FromArgb("#FFB6C1");
			FemaleIcon.TextColor = Colors.White;
			FemaleLabel.TextColor = Colors.White;
		}
	}

	private void OnHeightSliderChanged(object sender, ValueChangedEventArgs e)
	{
		height = (int)e.NewValue;
		HeightValueLabel.Text = height.ToString();
		CloseResultPopup();
	}

	private async void OnHeightTapped(object sender, EventArgs e)
	{
		string unit = isMetric ? "cm" : "inches";
		string result = await DisplayPromptAsync("Height", $"Enter your height in {unit}:", 
			initialValue: height.ToString(), keyboard: Keyboard.Numeric);
		
		if (!string.IsNullOrWhiteSpace(result) && double.TryParse(result, out double newHeight))
		{
			int min = 0;
			int max = isMetric ? 250 : 98;
			
			if (newHeight >= min && newHeight <= max)
			{
				height = newHeight;
				HeightValueLabel.Text = ((int)height).ToString();
				HeightSlider.Value = (int)height;
				CloseResultPopup();
			}
			else
			{
				await DisplayAlert("Invalid Height", $"Please enter a height between {min} and {max} {unit}.", "OK");
			}
		}
	}

	private void OnInputChanged(object sender, TextChangedEventArgs e)
	{
		CloseResultPopup();
	}

	private void OnCloseResultClicked(object sender, EventArgs e)
	{
		CloseResultPopup();
	}

	private void CloseResultPopup()
	{
		ResultFrame.IsVisible = false;
		OverlayBackground.IsVisible = false;
	}

	private void OnResetClicked(object sender, EventArgs e)
	{
		height = isMetric ? DefaultHeightCm : DefaultHeightInch;
		isMale = true;
		
		HeightValueLabel.Text = ((int)height).ToString();
		HeightSlider.Value = (int)height;
		WeightEntry.Text = string.Empty;
		AgeEntry.Text = string.Empty;
		
		UpdateGenderUI();
		CloseResultPopup();
	}

	private async void OnCalculateClicked(object sender, EventArgs e)
	{
		if (string.IsNullOrWhiteSpace(WeightEntry.Text))
		{
			await DisplayAlert("Invalid Input", "Please enter your weight.", "OK");
			return;
		}

		if (string.IsNullOrWhiteSpace(AgeEntry.Text))
		{
			await DisplayAlert("Invalid Input", "Please enter your age.", "OK");
			return;
		}

		if (!double.TryParse(WeightEntry.Text, out double weightInput) || weightInput <= 0)
		{
			await DisplayAlert("Invalid Weight", "Please enter a valid weight.", "OK");
			return;
		}

		if (!int.TryParse(AgeEntry.Text, out int age) || age <= 0 || age > 150)
		{
			await DisplayAlert("Invalid Age", "Please enter a valid age between 1 and 150.", "OK");
			return;
		}

		if (height <= 0)
		{
			await DisplayAlert("Invalid Input", "Please enter a valid height.", "OK");
			return;
		}

		double heightCm = isMetric ? height : height * 2.54;
		double weightKg = isMetric ? weightInput : weightInput / 2.205;

		double heightM = heightCm / 100.0;
		double bmi = weightKg / (heightM * heightM);

		double idealBmi;
		if (age < 18)
		{
			idealBmi = 21.75;
		}
		else if (age >= 65)
		{
			idealBmi = 24.5;
		}
		else
		{
			if (isMale)
			{
				idealBmi = 21.7;
			}
			else
			{
				idealBmi = 21.2;
			}
		}

		double difference = bmi - idealBmi;
		string differenceText;
		Color differenceColor;

		if (Math.Abs(difference) < 0.5)
		{
			differenceText = "You are at your ideal BMI!";
			differenceColor = Color.FromArgb("#81C784");
		}
		else if (difference > 0)
		{
			differenceText = $"{Math.Abs(difference):F1} points above ideal";
			differenceColor = Color.FromArgb("#FFB74D");
		}
		else
		{
			differenceText = $"{Math.Abs(difference):F1} points below ideal";
			differenceColor = Color.FromArgb("#FFB74D");
		}

		string category;
		string info;
		Color categoryColor;

		if (age < 18)
		{
			if (bmi < 18.5)
			{
				category = "Underweight";
				info = "You may need to gain weight. Consult with a healthcare provider for personalized advice.";
				categoryColor = Color.FromArgb("#FFB74D");
			}
			else if (bmi < 25)
			{
				category = "Healthy Weight";
				info = "You have a healthy body weight for your age. Keep it up!";
				categoryColor = Color.FromArgb("#81C784");
			}
			else if (bmi < 30)
			{
				category = "Overweight";
				info = "You may be slightly above healthy weight. Consider consulting a healthcare provider.";
				categoryColor = Color.FromArgb("#FFB74D");
			}
			else
			{
				category = "Obese";
				info = "Your BMI indicates obesity. Please consult with a healthcare provider.";
				categoryColor = Color.FromArgb("#E57373");
			}
		}
		else if (age >= 65)
		{
			if (bmi < 22)
			{
				category = "Underweight";
				info = "You may be underweight. Maintaining adequate nutrition is important.";
				categoryColor = Color.FromArgb("#FFB74D");
			}
			else if (bmi < 27)
			{
				category = "Healthy Weight";
				info = "You have a healthy body weight for your age group.";
				categoryColor = Color.FromArgb("#81C784");
			}
			else if (bmi < 32)
			{
				category = "Overweight";
				info = "You're slightly above healthy weight. Moderate physical activity can help.";
				categoryColor = Color.FromArgb("#FFB74D");
			}
			else
			{
				category = "Obese";
				info = "Your BMI indicates obesity. Please consult with a healthcare provider.";
				categoryColor = Color.FromArgb("#E57373");
			}
		}
		else
		{
			if (isMale)
			{
				if (bmi < 18.5)
				{
					category = "Underweight";
					info = "You're below the healthy weight range. Consider consulting a nutritionist.";
					categoryColor = Color.FromArgb("#FFB74D");
				}
				else if (bmi < 25)
				{
					category = "Normal Weight";
					info = "You have a normal body weight. Keep maintaining your healthy lifestyle!";
					categoryColor = Color.FromArgb("#81C784");
				}
				else if (bmi < 30)
				{
					category = "Overweight";
					info = "You're above the healthy weight range. Regular exercise and balanced diet recommended.";
					categoryColor = Color.FromArgb("#FFB74D");
				}
				else
				{
					category = "Obese";
					info = "Your BMI indicates obesity. Please consult with a healthcare provider for guidance.";
					categoryColor = Color.FromArgb("#E57373");
				}
			}
			else
			{
				if (bmi < 18.5)
				{
					category = "Underweight";
					info = "You're below the healthy weight range. Consider consulting a nutritionist.";
					categoryColor = Color.FromArgb("#FFB74D");
				}
				else if (bmi < 24)
				{
					category = "Healthy Weight";
					info = "You have a healthy body weight. Keep maintaining your balanced lifestyle!";
					categoryColor = Color.FromArgb("#81C784");
				}
				else if (bmi < 29)
				{
					category = "Overweight";
					info = "You're above the healthy weight range. Regular exercise and balanced diet recommended.";
					categoryColor = Color.FromArgb("#FFB74D");
				}
				else
				{
					category = "Obese";
					info = "Your BMI indicates obesity. Please consult with a healthcare provider for guidance.";
					categoryColor = Color.FromArgb("#E57373");
				}
			}
		}

		BmiValueLabel.Text = bmi.ToString("F1");
		IdealBmiLabel.Text = idealBmi.ToString("F1");
		DifferenceLabel.Text = differenceText;
		DifferenceLabel.TextColor = differenceColor;
		CategoryLabel.Text = category;
		CategoryFrame.BackgroundColor = categoryColor;
		CategoryInfoLabel.Text = info;

		OverlayBackground.IsVisible = true;
		OverlayBackground.Opacity = 0;
		
		ResultFrame.IsVisible = true;
		ResultFrame.Opacity = 0;
		ResultFrame.Scale = 0.7;

		await OverlayBackground.FadeTo(1, 200);

		await Task.WhenAll(
			ResultFrame.FadeTo(1, 300),
			ResultFrame.ScaleTo(1, 300, Easing.CubicOut)
		);
	}
}
