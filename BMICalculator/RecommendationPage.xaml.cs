namespace BMICalculator;

public partial class RecommendationPage : ContentPage
{
	public RecommendationPage( string category, string gender )
	{
		InitializeComponent();

		recommendationLabel.Text = GetRecommendation(category, gender);

    }

	private string GetRecommendation(string category, string gender)
	{
        switch (category)
        {
            case "Underweight": return "Increase calorie intake with nutrient-rich foods (e.g., nutes, lean protein, whole grains). Incorporate strength training to build muscle mass. Consult a nutritionist if needed.";
            case "Normal weight": return "Maintain a balanced diet with proteins, healthy fats, and fiber. Stay physically active with at least 150 minutes of exercise per week. Keep regular check-ups to monitor overall health.";
            case "Overweight": return "Reduce processed foods and focus on portion control. Engage in regular aerobic exercises (e.g. jogging, swimming) and strength training. Drink plenty of water and track your progress.";
            case "Obese": return "Consult a doctor for personalized guidance. Start with low-impact exercises (e.g. walking, cycling). Follow a structured weight-loss meal plan and consider behavioral therapy for lifestyle changes. Avoid sugary drinks and maintain a consistent sleep schedule.";
            default: return "No recommendation available.";
        }
    }

    private async void BackToResultPage_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void BackToMainPage_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }

}
