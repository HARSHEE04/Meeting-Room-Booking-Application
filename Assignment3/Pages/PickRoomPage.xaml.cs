using Assignment3.BusinessLogic;


namespace Assignment3.Pages;

public partial class PickRoomPage : ContentPage
{
    private ReservationRequestManager _requestmanager;
    private MeetingRoom selectedRoom;
    public PickRoomPage()
	{
		InitializeComponent();
        _requestmanager= new ReservationRequestManager();
        RoomTypesListview.ItemsSource = _requestmanager.MeetingRooms;
}

    private void OnAddRequest(object sender, EventArgs e)
    {
       
        //ensure a room is selected
        if (selectedRoom == null)
        {
            throw new Exception("Your selected room cannot be null");
        }
        else
        {
            //use the this keyword for to get info about the specific instance, basically gets the info about the room

            Navigation.PushAsync(new AddRequestPage(this.selectedRoom,_requestmanager));
        }

        
        
        //This means take the room number eg A102, Layout style, capacity and real room image with you on next page
    }

    private void OnViewRequest(object sender, EventArgs e)
    {


        //ensure a room is selected
        if (selectedRoom == null)
        {
            throw new Exception("Your selected room cannot be null");
        }
        else
        {
            Navigation.PushAsync(new ViewRequestsPage(this.selectedRoom, _requestmanager));
            //just navigates to the requests page with the list of requests, need to take the chosen room's number with it
        }

       
    }

    //need to use data binding to do this,
    private void OnListviewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        //EXPLAIN WHAT E IS, explain this portion in detail
        selectedRoom = (MeetingRoom)e.SelectedItem;


        if (selectedRoom.LayoutType== RoomLayoutType.hollowsquare)
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
            RealRoomImage.Source = "auditorium.png";
        }
    }
}

