using Assignment3.BusinessLogic;
using System.ComponentModel;


namespace Assignment3.Pages;

public partial class PickRoomPage : ContentPage, INotifyPropertyChanged
{
    private ReservationRequestManager _requestmanager;
    private MeetingRoom _selectedRoom;
    public event PropertyChangedEventHandler PropertyChanged;
    public PickRoomPage()
    {
        InitializeComponent();
        _requestmanager = new ReservationRequestManager();
        RoomTypesListview.ItemsSource = _requestmanager.MeetingRooms;
         BindingContext = this;
    }

    // Property to hold the selected room
    public MeetingRoom SelectedRoom
    {
        get { return _selectedRoom; }
        set
        {
            if (_selectedRoom != value)
            {
                _selectedRoom = value;
                OnPropertyChanged(nameof(SelectedRoom)); // Notify property changed
            }
        }
    }
    
    // OnPropertyChanged method to raise the PropertyChanged event
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void OnAddRequest(object sender, EventArgs e)
    {
        try
        {
            //ensure a room is selected
            if (_selectedRoom == null)
            {
                throw new Exception("Please select a room before adding a request.");
            }
            //use the this keyword for to get info about the specific instance, basically gets the info about the room
            Navigation.PushAsync(new AddRequestPage(this._selectedRoom, _requestmanager.AddReservationRequest));
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "OK");
        }
    }



    private void OnViewRequest(object sender, EventArgs e)
    {
        try
        {   
            if (_selectedRoom == null)
            {
                throw new Exception("Please select a room before viewing requests.");
            }


            Navigation.PushAsync(new ViewRequestsPage(this._selectedRoom, this._requestmanager));
           
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "OK");
        }
    }
    

    //need to use data binding to do this,
    //}
    //private void OnRoomSelectionChanged(object sender, EventArgs e)
    //{
    //    RealRoomImage.Source.BindingContext = this.selectedRoom.RoomImageFileName;
    //}

    //private void OnListviewItemSelected(object sender, SelectedItemChangedEventArgs e)
    //{
    //    //EXPLAIN WHAT E IS, explain this portion in detail
    //    selectedRoom = (MeetingRoom)e.SelectedItem;


    //    if (selectedRoom.LayoutType== RoomLayoutType.hollowsquare)
    //    {
    //        RealRoomImage.Source = "hollowsquare.png";
    //    }
    //    if (selectedRoom.LayoutType == RoomLayoutType.classroom)
    //    {
    //        RealRoomImage.Source = "classroom.png";
    //    }
    //    if (selectedRoom.LayoutType == RoomLayoutType.ushape)
    //    {
    //        RealRoomImage.Source = "ushape.png";
    //    }
    //    if (selectedRoom.LayoutType == RoomLayoutType.auditorium)
    //    {
    //        RealRoomImage.Source = "auditorium.png";
    //    }
    //}
}

