using Assignment3.BusinessLogic;

namespace Assignment3.Pages;

public partial class AddRequestPage : ContentPage
    //perform validation checks here as well , askk
{
    private MeetingRoom _selectedRoom;
	public AddRequestPage(SelectedRoom)//takes the info about the selected room to the next page
	{
		InitializeComponent();
        
        
	}

    private void OnAddRequest(object sender, EventArgs e)
    {
        //takes all the user info, makes an object of Reservation request and add's it to a running list of reservations for that specific room
        DisplayAlert("Success", "Congrats, your reservation is made", "ok");

        //make the reservation objects here

    }

    private void OnBackToRooms(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PickRoomPage());

    }
}