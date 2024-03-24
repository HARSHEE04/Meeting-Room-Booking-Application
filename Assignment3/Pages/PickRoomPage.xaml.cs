using Assignment3.BusinessLogic;

namespace Assignment3.Pages;

public partial class PickRoomPage : ContentPage
{
    private ReservationRequestManager _requestmanager = new ReservationRequestManager();
    public PickRoomPage()
	{
		InitializeComponent();
        RoomTypesListview.ItemsSource = _requestmanager._meetingRooms;




}

    private void OnAddRequest(object sender, EventArgs e)
    {

    }

    private void OnViewRequest(object sender, EventArgs e)
    {

    }

    private void SelectedRoom(object sender, SelectedItemChangedEventArgs e)
    {

    }
}