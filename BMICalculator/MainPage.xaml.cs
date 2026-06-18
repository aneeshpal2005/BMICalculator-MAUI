using Microsoft.Extensions.Logging;
using System.Xml.Serialization;

namespace BMICalculator
{

    public partial class MainPage
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            
            return builder.Build();
        }

        private string _genderChoice = "Male";

        private readonly Shadow _defaultShadow = new Shadow
        {
            Brush = Colors.Transparent,
            Offset = new Point(0.1, 0.1),
            Opacity = 0.5f,
            Radius = 1
        };

        private readonly Shadow _selectedShadow = new Shadow
        {
            Brush = Colors.Black,
            Offset = new Point(0.1, 0.1),
            Opacity = 0.5f,
            Radius = 4
        };

        private readonly Dictionary<string, string> _bmiCategoryAdvice = new Dictionary<string, string>
        {
            { "Underweight", "Increase calorie intake with nutrient-rich foods (e.g., nutes, lean protein, whole grains). Incorporate strength training to build muscle mass. Consult a nutritionist if needed." },
            { "Normal weight", "Maintain a balanced diet with proteins, healthy fats, and fiber. Stay physically active with at least 150 minutes of exercise per week. Keep regular check-ups to monitor overall health." },
            { "Overweight", "Reduce processed foods and focus on portion control. Engage in regular aerobic exercises (e.g. jogging, swimming) and strength training. Drink plenty of water and track your progress." },
            { "Obesity", "Consult a doctor for personalized guidance. Start with low-impact exercises (e.g. walking, cycling). Follow a structured weight-loss meal plan and consider behavioral therapy for lifestyle changes. Avoid sugary drinks and maintain a consistent sleep schedule." }
        };


        public MainPage()
        {
            InitializeComponent();
            MaleGestureRecognizer_Tapped(null, null);
        }


        private void FemaleGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            _genderChoice = "Female";
            BorderFemale.Shadow = _selectedShadow;
            BorderMale.Shadow = _defaultShadow;
        }

        private void MaleGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            _genderChoice = "Male";
            BorderMale.Shadow = _selectedShadow;
            BorderFemale.Shadow = _defaultShadow;
        }
        private void HeightEntry_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            HeightValue.Text = HeightEntry.Value < 0 ? "0" : $"{HeightEntry.Value:F0}";
        }

        private void WeightEntry_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            WeightValue.Text = WeightEntry.Value < 0 ? "0" : $"{WeightEntry.Value:F0}";
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (HeightEntry.Value <= 0 || WeightEntry.Value <= 0)
            {
                ShowBMIResultInAlert("Invalid Input", "Please enter valid height and weight values.", "OK");
                return;
            }

            double calculatedBMI = CalculateBmiValue();

            String BMIOutput = FormatBmiOutput(calculatedBMI);

            ShowBMIResultInAlert("Your calculated BMI Results are:", BMIOutput, "OK");

        }

        private async Task ShowBMIResultInAlert(string title, string message, string cancel)
        {
            await DisplayAlertAsync(title, message, cancel);
        }

        private double CalculateBmiValue()
        {
            return HeightEntry.Value > 0
                ? WeightEntry.Value * 703 / (HeightEntry.Value * HeightEntry.Value)
                : 0;
        }

        private string FormatBmiOutput(double bmi)
        {
            return $"Gender: {_genderChoice}\n " +
                   $"Height: {HeightValue.Text}\n " +
                   $"Weight: {WeightValue.Text}\n\n" +
                   $"Total BMI: {bmi:F2}\n" +
                   GetBmiCategory(bmi);
        }

        private string GetBmiCategory(double bmi)
        {
            string category = _genderChoice == "Male"
                ? GetMaleBmiCategory(bmi)
                : GetFemaleBmiCategory(bmi);
            return $"Category: {category}\n\n" + _bmiCategoryAdvice[category];
        }

        private string GetMaleBmiCategory(double bmi)
        {
            return bmi switch
            {
                < 18.5 => "Underweight",
                < 25 => "Normal weight",
                < 30 => "Overweight",
                _ => "Obesity"
            };
        }

        private string GetFemaleBmiCategory(double bmi)
        {
            return bmi switch
            {
                < 18 => "Underweight",
                < 24 => "Normal weight",
                < 29 => "Overweight",
                _ => "Obesity"
            };

        }
    }
}
