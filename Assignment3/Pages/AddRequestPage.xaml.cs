using Assignment3.BusinessLogic;

namespace Assignment3.Pages;

public partial class AddRequestPage : ContentPage
    //perform validation checks here as well , ask
{
    private MeetingRoom _selectedRoom;
	public AddRequestPage(MeetingRoom selectedRoom)//takes the info about the selected room to the next page
	{
		InitializeComponent();
        this.BindingContext = selectedRoom;
        /// to show info for the object,you just need to use the property.
        
        
	}

    private void OnAddRequest(object sender, EventArgs e)
    {

        //ensure a room is selected

        //takes all the user info, makes an object of Reservation request and add's it to a running list of reservations for that specific room
        DisplayAlert("Success", "Congrats, your reservation is made", "ok");

        //make the reservation objects here

    }

    private void OnBackToRooms(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PickRoomPage());

    }
}