namespace FlightTrackerTemp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }
        private void Flight_button_Clicked(object sender, EventArgs e)
        {

            Shell.Current.GoToAsync(nameof(Flights));

        }

        private void Search_button_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(Search));
        }
    }

}
