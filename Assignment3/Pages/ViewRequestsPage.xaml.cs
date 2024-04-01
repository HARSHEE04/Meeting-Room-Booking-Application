namespace Assignment3.Pages;
using Assignment3.BusinessLogic;
using System.Collections.ObjectModel;

public partial class ViewRequestsPage : ContentPage
{
    private MeetingRoom _selectedRoom;
     private ReservationRequestManager _requestManager;
    
    //notes to self: 
    /*Steps to show the objects list properly in listview
     * 1) ensure that the list of all the requests is getting passed to this page properly
     * 2) Ensure that I bind the selected room's room number to the top 
     * 3) Enusre that I bind the list of requests for this page to the listview
     */


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
        try
        {
            SelectedRoomNumber.Text = $"The Selected Room Number is: {_selectedRoom.RoomNumber}";  //just manually taking info about selected room and showing it on the UI
            if (_requestManager != null && _requestManager.ReservationRequests != null)
            {
                AllRequestListview.ItemsSource = _requestManager.ReservationRequests;//populate the itemsource of the listview with all the relevent requests.
            }   
        }
        catch (Exception ex)
        {
            
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    //just takes users back to the pick room page
    private void OnBackToRooms(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PickRoomPage());
    }


}





      
   
