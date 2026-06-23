namespace BMICalculator;

public partial class ResultPage : ContentPage
{
	private double bmi;
	private string category;
	private string gender;

    public ResultPage(double height,
					double weight, 
					string gender)
	{
		InitializeComponent();

		this.gender = gender;

        bmi = (weight * 703) / (height * height);

		category = GetBmiCategory(bmi, gender);

        bmiLabel.Text = $"Your BMI is {bmi:F1}";
    }

    private string GetBmiCategory(double bmi, string gender)
    {
        if (gender == "Male")
        {
            if (bmi < 20) return "Underweight";
            if (bmi < 25) return "Normal";
            if (bmi < 30) return "Overweight";
            return "Obese";
        }
        else
        {
            if (bmi < 19) return "Underweight";
            if (bmi < 24) return "Normal";
            if (bmi < 29) return "Overweight";
            return "Obese";
        }
    }

    private async void Recommendations_Clicked(object sender,
        EventArgs e)
    {
        await Navigation.PushAsync(
            new RecommendationPage(category, gender));
    }

    private async void Back_Clicked(object sender,
        EventArgs e)
    {
        await Navigation.PopAsync();
    }

}