using System.Xml.Serialization;

namespace BMICalculator
{
    public partial class MainPage : ContentPage
    {
        new String GenderChoice = "Male";

        Shadow DefaultShadow = new Shadow
        {
            Brush = Colors.Transparent,
            Offset = new Point(0.1, 0.1),
            Opacity = 0.5f,
            Radius = 1
        };

        Shadow SelectedShadow = new Shadow
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
            GenderChoice = "Female";
            BorderFemale.Shadow = SelectedShadow;
            BorderMale.Shadow = DefaultShadow;
        }

        private void MaleGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            GenderChoice = "Male";
            BorderMale.Shadow = SelectedShadow;
            BorderFemale.Shadow = DefaultShadow;
        }
    }
}
