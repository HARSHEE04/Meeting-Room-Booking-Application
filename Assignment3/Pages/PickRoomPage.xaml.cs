using Assignment3.BusinessLogic;
using System.ComponentModel;


namespace Assignment3.Pages;
//This is the code-behind for the Pick Room Page which shows the popluated listview of the meeting rooms to the user with their details. It allows them to select a meeting room and as they go from some selection to the next.
//The selected room will show up on the right side to give the user a view of what their selected room looks like in real life aside from the layouts provided with the each meeting room. This has a composition relationship with the ReservationRequestManager
public partial class PickRoomPage : ContentPage, INotifyPropertyChanged// this page inherits from the content page and inherits the INotifyPropertyChanged interface.
                                                                       //MORE INFO ABOUT THE INOTIFYPROPERTYCHANGED INTERFACE: This interface is used when the class wants to notify cleints about changes in the property values.
///This interface declares an event called PropertyChanged and this is used for data binding
///and is used to notify bound controls so the binding target responds to the changes in properties of data source.
///References: DATA BINDING AND NAVIGATION Slides, implementation help: https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged?view=net-8.0
/// This interface has a OnPropertyChanged method which is explained below

{
    private ReservationRequestManager _requestmanager;
    private MeetingRoom _selectedRoom;
    public event PropertyChangedEventHandler PropertyChanged;// This declares an event named PropertyChanged and is used to implement the INotifyPropertyChnaged interface.
    //This is an event of the type PropertyChangedEventHandler which is a type of event. This is a delegate type which
    ////Is defined in the .NET Framework and this is used to handle property changed events. Resources used for this: DATA BIDNING AND NAVIGATION CLASS SLIDES, https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/events/
    //https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged?view=net-8.0, https://stackoverflow.com/questions/1315621/implementing-inotifypropertychanged-does-a-better-way-exist,
    //    https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged.propertychanged?view=net-8.0.
    ///// <summary>
    /// Delegate types are used to pass method as arguments to other methods in the class. Thus, a delegate is a specific type that reresents references to a method with a specific 
    /// list of parameters and a return type. These methods which are attchached to these are ivoked through the delegate instance.
    /// References: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/
    /// </summary>
    public PickRoomPage()
    {
        InitializeComponent();
        _requestmanager = new ReservationRequestManager();// composition relationship in compliance with the provided UML in the assignment 
        RoomTypesListview.ItemsSource = _requestmanager.MeetingRooms; //populates the listview with the Meeting Rooms present in the list
         BindingContext = this; // this line sets the binding context of an UI element/page to the current isnatcnes of a class. This is used
        //This allows us to use data binding because now the data bindings will be done againts the properties of the current instance. 
        //References: https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/data-binding/basic-bindings?view=net-maui-8.0

    }

    // Property to hold the selected room
    public MeetingRoom SelectedRoom
    {
        get { return _selectedRoom; }
        set
        {
            if (_selectedRoom != value) //checks to see if new value is different from current value.
                //This was required so we would not have uneeded property change notifications corresponding to the INotifyChangedInterface
            {
                _selectedRoom = value;
                OnPropertyChanged(nameof(SelectedRoom)); // Notify property changed if the new value is different. Done by raising the Property Changed event using OnPropertyChnaged method.
                //This tells the UI that the SelectedRoom property has changed. The nameof keyword was just used to obtain the name (SelectedRoom) which is a property to be able to pass it as a parameter.
                //References for this are the same as the ones mentioned above with the INotifyChanged Interface.
            }
        }
    }

    public void AddMeetingRoomsToPage()
    {
        //hard coded values of Meeting Rooms
        _requestmanager.AddMeetingRoom("A102", 20, RoomLayoutType.hollowsquare, "hollowsquare.png");
        _requestmanager.AddMeetingRoom("B013", 20, RoomLayoutType.ushape, "ushape.png");
        _requestmanager.AddMeetingRoom("C202", 40, RoomLayoutType.classroom, "classroom.png");
        _requestmanager.AddMeetingRoom("C105", 200, RoomLayoutType.auditorium, "auditorium.png");
    }

    // OnPropertyChanged method to raise the PropertyChanged event. Takes the property that has changed( In our case SelectedRoom as seen above). It takes this paramter and ivokes the PropertyChanged event passing this as the sender.
    //Also passed PropertyChangedEventArgs which is an object and this has the property name.
    //This method allows us notify UI elements that the property has changed, chaging the display accoridnly.
    //Made this prtected virtual because was unsure if I needed to overide in derived classes but I did not end up doing that.
    //In our case, it updates the real room image as the different rooms are selected. References are the same as before. Also used this for implementation help: https://stackoverflow.com/questions/12034840/handling-onpropertychanged
    
    /// <summary>
    /// Explaination is above
    /// </summary>
    /// <param name="propertyName"> Name of property which will be monitoried for changes</param>
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// This event attached to a button allows is to navigate to the AddRequestPage so we can
    /// add a reservation. It takes the selected room and instance of ReservationRequestManager with it.
    /// First checks to see if the selected room is null, if it is, exception is thrown.
    /// If not, the info is send to the Add RequestPage. All other exceptions are caught which can come from business logic because this
    /// is using the Try/Catch block
    /// </summary>
    /// <param name="sender"> represents the object that raises event</param>
    /// <param name="e">In our case, this is a placeholder paramter used in event handlers. References: https://learn.microsoft.com/en-us/dotnet/api/system.eventhandler-1?view=net-8.0</param>
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
            DisplayAlert("Error", ex.Message, "OK");  //catchs an other errors and uses Exception base class to show message
        }
    }


    /// <summary>
    /// Event handler accociated with the OnClick propety in the XAML for when the user wants to navigate to the ViewRequest page for a selectedroom.
    /// First, checks to ensure a room is selected and if it is, the selected room and the objects of the reservationrequestmanager are both sent to the ViewRequestsPage constructor.Had exception handling to ensure the code does not crash and 
    /// errors are handled gracefully.Resoruces for the paramters in the summary are the same as before
    /// </summary>
    /// <param name="sender">represents the object that raises event</param>
    /// <param name="e">In our case, this is a placeholder paramter used in event handlers.</param>
    private void OnViewRequest(object sender, EventArgs e)
    {
        try
        {   
            if (_selectedRoom == null)
            {
                throw new Exception("Please select a room before viewing requests.");
            }
            

            Navigation.PushAsync(new ViewRequestsPage(this._selectedRoom, _requestmanager));
           
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

