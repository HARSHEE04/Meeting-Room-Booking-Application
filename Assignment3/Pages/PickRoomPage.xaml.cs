using Assignment3.BusinessLogic;
using Windows.System;

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
        Navigation.PushAsync(new AddRequestPage());
        //this is done by passing these things into the constructor of the AddRequestsPage
        //needs to take info about the room selected with it to the next page
        //This means take the room number eg A102, Layout style, capacity and real room image with you on next page
    }

    private void OnViewRequest(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ViewRequestsPage());
        //just navigates to the requests page with the list of requests, need to take the chosen room's number with it
    }
}

