namespace Assignment3.Pages;
using Assignment3.BusinessLogic;
using System.Collections.ObjectModel;

public partial class ViewRequestsPage : ContentPage
{
    private MeetingRoom _selectedRoom;
     private ReservationRequestManager _requestManager;
    //An obserable collection is a dynamic data collection that provides notifictaions when things are added/ removed from this collection. Also updated when the entire collection is refreshed.
    //Used in place for list for its ability to update dynamically which is required for this page where requests are added.
    private ObservableCollection<ReservationRequest> _reservationRequestsforViewPage=new ObservableCollection<ReservationRequest>();
    

    //notes to self: 
    /*Steps to show the objects list properly in listview
     * 1) ensure that the list of all the requests is getting passed to this page properly
     * 2) Ensure that I bind the selected room's room number to the top 
     * 3) Enusre that I bind the list of requests for this page to the listview
     */

    //make a method to get the list from the ReservationRequestsManager

    /// <summary>
    /// The construtor takes the info passed from the PickRoomPage regarding the selected room and an inatcne of the ReservationRequestManager.
    /// </summary>
    /// <param name="selectedRoom">paramter of type Meeting room which carries info about selected room</param>
    /// <param name="requests">paramter of type ReservationRequestManager.</param>
    public ViewRequestsPage(MeetingRoom selectedRoom, ReservationRequestManager requests)
    {  
        InitializeComponent();
        _selectedRoom = selectedRoom;
        _requestManager = requests;
        BindingContext = this;  //sets the binding context to the data of this specific instance.
        SelectedRoomNumber.Text=$"The Selected Room Number is: {_selectedRoom.RoomNumber}";  //just manually taking info about selected room and showing it on the UI


        //allows us to load all the requests so the _reservationRequestsforViewPage is populated
        RequestsLoader();

        //shows that obserable collection on the listview
        AllRequestListview.ItemsSource = _reservationRequestsforViewPage;

    }

    /// <summary>
    /// This method filters and populates the _reservationRequestsforViewPag obserable collection with the reservation requests which are accosiated 
    /// with the selected room with should allow users to see all the requests to the relevent room.
    /// </summary>
    private void RequestsLoader()
    {
        _reservationRequestsforViewPage.Clear(); //this line clears the collection using the Clear() method which removes all the items from the collection so we can populate it with new items.

        //loops through requests stored in _requestManager.ReservationRequests from the ReservationRequestManager class. The loops through the meeting rooms with each reservation request. Thenit checks to see if the 
        //two room numbers match, meaning a request and room number match is found, it added it to the collection and breaks from the loop once the match is found.
        foreach (var request in _requestManager.ReservationRequests)
        {
            foreach (var room in request.MeetingRooms)
            {
                if (room.RoomNumber == _selectedRoom.RoomNumber)
                {
                    _reservationRequestsforViewPage.Add(request);
                    break; 
                }
            }
        }
    }

    //just takes users back to the pick room page
    private void OnBackToRooms(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PickRoomPage());
    }


}





      
   
