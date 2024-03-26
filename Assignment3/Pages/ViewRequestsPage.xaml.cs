namespace Assignment3.Pages;
using Assignment3.BusinessLogic;


public partial class ViewRequestsPage : ContentPage
{
    private MeetingRoom _selectedRoom;
    public ViewRequestsPage(MeetingRoom selectedRoom)
	{
		InitializeComponent();
        _selectedRoom = selectedRoom;
    }

    private void OnBackToRooms(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PickRoomPage());
    }
}