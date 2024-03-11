using FlightTrackerTemp.Models;

namespace FlightTrackerTemp;

public partial class Search : ContentPage
{
	public Search()
	{
		InitializeComponent();
	}

    private void Flight_button_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(Flights));
    }

    private void Home_button_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(MainPage));  
    }

    private void FindReservation_Clicked(object sender, EventArgs e)
    {

        //initialising a list that will Sstore the content of reservations list returned by the Findreservation method
        List<Reservations> ReservationsFound = new List<Reservations>();

        ReservationsFound = ReservationManager.Findreservation(CodeEntry.Text, AirlineEntry.Text, NameEntry.Text);
        foreach (Reservations reservation in ReservationsFound)
        {
            picker.Items.Add(reservation.ToString());
        }
    }
}