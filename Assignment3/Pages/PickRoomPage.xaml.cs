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
        //make sure a room is selected


        //use the this keyword for to get info about the specific instance, basically gets the info about the room
  
        Navigation.PushAsync(new AddRequestPage());
        
        //This means take the room number eg A102, Layout style, capacity and real room image with you on next page
    }

    private void OnViewRequest(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ViewRequestsPage());
        //just navigates to the requests page with the list of requests, need to take the chosen room's number with it
    }

    //need to use data binding to do this,
    private void OnListviewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        //EXPLAIN WHAT E IS, explain this portion in detail

        var selectedRoom=(MeetingRoom)e.SelectedItem;

        if(selectedRoom.LayoutType== RoomLayoutType.hollowsquare)
        {
            RealRoomImage.Source = "hollowsquare.png";
        }
        if (selectedRoom.LayoutType == RoomLayoutType.classroom)
        {
            RealRoomImage.Source = "classroom.png";
        }
        if (selectedRoom.LayoutType == RoomLayoutType.ushape)
        {
            RealRoomImage.Source = "ushape.png";
        }
        if (selectedRoom.LayoutType == RoomLayoutType.auditorium)
        {
            RealRoomImage.Source = "auditoriumm.png";
        }
    }
}

