namespace Assignment3.Pages;
using Assignment3.BusinessLogic;
using System.Collections.ObjectModel;

public partial class ViewRequestsPage : ContentPage
{
    private MeetingRoom _selectedRoom;
     private ReservationRequestManager _requestManager;
    private ObservableCollection<ReservationRequest> _reservationRequestsforViewPage=new ObservableCollection<ReservationRequest>();

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
        _requestManager = requests;
        this.BindingContext = selectedRoom;

        //popultae the observarble collection for the selectedroom
        RequestsLoader();

        //Use obserable collection and use the ItemSource to show collection
        AllRequestListview.ItemsSource = _reservationRequestsforViewPage;

    }

    private void RequestsLoader()
    {
        _reservationRequestsforViewPage.Clear();

        
        foreach (var request in _requestManager.ReservationRequests)
        {
            
            if (request.MeetingRooms.Any(room => room.RoomNumber == _selectedRoom.RoomNumber)) // explain the any keyword
            {
                _reservationRequestsforViewPage.Add(request);
            }
        }

        
    }    

    //explain view model and why I did not use it.

    ////load function
    //public class ViewRequestsViewModel
    //{
    //    public string RoomNumber { get; }
    //    public List<ReservationRequest> ReservationRequests { get; }
    //    public ReservationRequestManager RequestManager { get; }

    //    public ViewRequestsViewModel(MeetingRoom selectedRoom, ReservationRequestManager requestManager)
    //    {
    //        RoomNumber = selectedRoom.RoomNumber;
    //        ReservationRequests = requestManager.ReservationRequests;
    //        RequestManager = requestManager;
    //    }
    //}
    //singleton pattern, create a function in rrm check to see if the instance is null, tries to use same instance across the code
    private void OnBackToRooms(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PickRoomPage());
    }


}





      
   
