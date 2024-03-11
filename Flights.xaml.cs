using FlightTrackerTemp.Models;
using System.Formats.Tar;
using System.Reflection.Metadata;

namespace FlightTrackerTemp;

public partial class Flights : ContentPage
{
	public Flights()
	{
		InitializeComponent();
	}
    List<Flight> foundFlights = new List<Flight>();
    int selectedIndex;
    private void Home_button_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(MainPage));
    }

    
    private void FindFlightBtn_Clicked(object sender, EventArgs e)
    {

        string airportFrom = FromEntry.Text;
        string airportTo = ToEntry.Text;
        string dayOfWeek = DayEntry.Text;

        foundFlights = FlightRepository.FindFlightsCombined(originingAirport: airportFrom, destinationAirport: airportTo, dayofweek: dayOfWeek);
        foreach (Flight flight in foundFlights)
        {
            if (flight != null)
            {
                MyPicker.Items.Add(flight.ToDisplay());
            }

            else
            {
                MyPicker.Items.Add($"No flights found");
            }
        }
                 
    }

    private void Search_button_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(Search));
    }

    private void ReserveButton_Clicked(object sender, EventArgs e)
    {
        if (foundFlights[0].Seat == 0)
        {
            MyPicker.Items.Add("The flight is full");
        }
        else
        {
            ReservationCode.Text = ReservationManager.RandomCode();
            ReservationManager.MakeReservation(foundFlights[selectedIndex], NameEntry.Text, CitizenshipEntry.Text, ReservationCode.Text);

            MyPicker.Items.Clear();
            foundFlights.Clear();
        }
    }

    //Adds the flight details to the entry, whenver the user selects a flight.
    private void MyPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        selectedIndex= picker.SelectedIndex;
        if (selectedIndex < 0)
        {

        }
        else
        {
            CodeEntry.Text = foundFlights[selectedIndex].flightCode;
            AirlineEntry.Text = foundFlights[selectedIndex].Airline;
            DayEntry1.Text = foundFlights[selectedIndex].DayOfWeek;
            TimeEntry.Text = foundFlights[selectedIndex].DepartureTime;
            CostEntry.Text = foundFlights[selectedIndex].TicketPrice.ToString();
        }

    }
}