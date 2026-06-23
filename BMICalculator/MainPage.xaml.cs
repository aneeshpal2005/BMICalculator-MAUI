using Microsoft.Extensions.Logging;
using System.Xml.Serialization;

namespace BMICalculator
{

    public partial class MainPage : ContentPage
    {
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

        private async void Button_Clicked(object sender, EventArgs e)
        {
            double weight = WeightEntry.Value;
            double height = HeightEntry.Value;

            await Navigation.PushAsync(
                new ResultPage(height, weight, _genderChoice));
        }
    }
}
