namespace Assignment3.Pages;
using Assignment3.BusinessLogic;


public partial class ViewRequestsPage : ContentPage
{
    private MeetingRoom _selectedRoom;
    private ReservationRequestManager _requestManager;
    
    
    public ViewRequestsPage(MeetingRoom selectedRoom, ReservationRequestManager requestsList) 
    {
        InitializeComponent();
        this.BindingContext = selectedRoom;
        _selectedRoom = selectedRoom;

        _requestManager =requestsList;
        AllRequestListview.ItemsSource =requestsList.ReservationRequests;



    }

    private void OnBackToRooms(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PickRoomPage());
    }
}