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


    public ViewRequestsPage(MeetingRoom selectedRoom, ReservationRequestManager requests)
    {  
        InitializeComponent();
        _selectedRoom = selectedRoom;
        _requestManager = requests;
        BindingContext = this;
        SelectedRoomNumber.Text=$"The Selected Room Number is: {_selectedRoom.RoomNumber}";


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
            foreach (var room in request.MeetingRooms)
            {
                if (room.RoomNumber == _selectedRoom.RoomNumber)
                {
                    _reservationRequestsforViewPage.Add(request);
                    break; // Exit the inner loop once a matching room is found
                }
            }
        }
    }

    private void OnBackToRooms(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PickRoomPage());
    }


}





      
   
