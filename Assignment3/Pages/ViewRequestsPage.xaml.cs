namespace Assignment3.Pages;
using Assignment3.BusinessLogic;


public partial class ViewRequestsPage : ContentPage
{
    private MeetingRoom _selectedRoom;

    //notes to self: 
    /*Steps to show the objects list properly in listview
     * 1) ensure that the list of all the requests is getting passed to this page properly
     * 2) Ensure that I bind the selected room's room number to the top 
     * 3) Enusre that I bind the list of requests for this page to the listview
     */

    //make a method to get the list from the ReservationRequestsManager


    public ViewRequestsPage(MeetingRoom selectedRoom, ReservationRequestManager requests  )
    {  
        InitializeComponent();
        _selectedRoom = selectedRoom;
        this.BindingContext = new ViewRequestsViewModel(selectedRoom, requests);


    }
    public class ViewRequestsViewModel
    {
        public string RoomNumber { get; }

        public List<ReservationRequest> ReservationRequests { get; }

        public ViewRequestsViewModel(MeetingRoom selectedRoom, ReservationRequestManager requestManager)
        {
            RoomNumber = selectedRoom.RoomNumber;
            ReservationRequests = requestManager.ReservationRequests;
        }
    }


    private void OnBackToRooms(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PickRoomPage());
    }


}





      
   
