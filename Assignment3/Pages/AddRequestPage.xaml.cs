namespace Assignment3.Pages;

public partial class AddRequestPage : ContentPage
{
	public AddRequestPage()
	{
		InitializeComponent();
	}

    private void OnAddRequest(object sender, EventArgs e)
    {
        //takes all the user info, makes an object of Reservation request and add's it to a running list of reservations for that specific room
        DisplayAlert("Success", "Congrats, your reservation is made", "ok");
    }

    private void OnBackToRooms(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PickRoomPage());

    }
}