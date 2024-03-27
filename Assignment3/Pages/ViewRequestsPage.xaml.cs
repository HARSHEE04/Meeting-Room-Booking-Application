namespace Assignment3.Pages;
using Assignment3.BusinessLogic;


public partial class ViewRequestsPage : ContentPage
{
    private ReservationRequestManager _requestManager;
    private MeetingRoom _selectedRoom;

    public ViewRequestsPage(MeetingRoom selectedRoom, ReservationRequestManager requestsList)
    {
        InitializeComponent();
        _selectedRoom = selectedRoom;
        _requestManager = requestsList;
        BindingContext = selectedRoom;
        BindingContext = requestsList;

       
        AllRequestListview.ItemsSource = requestsList.ReservationRequests;
    }

    public MeetingRoom SelectedRoom => _selectedRoom;
    public List<ReservationRequest> ReservationRequests => _requestManager.ReservationRequests;

    private void OnBackToRooms(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PickRoomPage());
    }
}