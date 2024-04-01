using Assignment3.BusinessLogic;
namespace Assignment3.Pages;

public partial class AddRequestPage : ContentPage
    
{
    private MeetingRoom _selectedRoom;//aggregation relationship with the Meeting Room class which means field variable present, this is passed into the constructor and defined in the constructor.
   /// <summary>
   /// Below a field variable named _addReservationRequest of the action "Action" is present with required paramter types.
   /// Action is also a delegate type and it represents a method that that is able to take parameters of specifed types eg string and returns void.This was done to avoid creating a field variable of ReservationRequestManager which
   /// has the AddReservationRequest method
   /// </summary>
    private Action<string, string, DateTime, DateTime, int, string> _addReservationRequest;


    /// <summary>
    /// Constructor for this AddRequests page, accepts the parameters passed from PickRoomPage to allow use in events or methods on this page.
    /// </summary>
    /// <param name="selectedRoom"> variable containg info about the room selected in PickRoomPage</param>
    /// <param name="addReservationRequest">parameter of type Action<string, string, DateTime, DateTime, int, string> which is a delegate type. This allowus use to interact with the AddReservationRequest method in ReservationRequestManager to add the request</param>
    public AddRequestPage(MeetingRoom selectedRoom, Action<string, string, DateTime, DateTime, int, string> addReservationRequest)//the field varibales are passed into the constructor of this page
	{
		InitializeComponent();
        this.BindingContext = selectedRoom;//stating that the binding context of this instance is the selected room which was passed from previous page
        _selectedRoom = selectedRoom;
        _addReservationRequest = addReservationRequest;

    }

    //Issue found with debugging, is that the viewrequests page is not getting the instance of the request which is being made. Getting that specific instance would allow it to access the list

    /// <summary>
    /// After details are entered about the reuqest on the UI, we are looking to take that info and create ReservationRequest object and this is done when the addRequest button is pressed.
    /// This event handler performs exception handling as well to ensure the details entered are valid
    /// </summary>
    /// <param name="sender">variable which referes to the object that triggers the event</param>
    /// <param name="e">In our case, this is a placeholder paramter used in event handlers</param>
    private void OnAddRequest(object sender, EventArgs e)
    {
        try
        {
            //combines the dat and time values from user to make DateTime variables to create instance.
            DateTime startDateTime = DatePicker.Date + StartTimePicker.Time;

            DateTime endDateTime = DatePicker.Date + EndTimePicker.Time;

          
            //Object of ReservationRequest made using user data
            ReservationRequest newRequest = new ReservationRequest(Requestedby.Text, Description.Text, startDateTime, endDateTime, int.Parse(ParticipantCount.Text));//create instance of ReservationRequest
                                                                                                                                                                     //takes the _addReservationRequest action whihc was defined in field variable and ivokes it using IVOKE method which is provided by delegate types like Action.
            ///Delegate types are references types holding references to method. when we used the IVOKE method on this delegate instance, we are exectuing the AddReservationRequest method which is what this delegate is pointing to 
            ///References used: https://stackoverflow.com/questions/594268/whats-the-use-of-invoke-in-net, https://learn.microsoft.com/en-us/dotnet/api/system.action?view=net-8.0
            ///https://stackoverflow.com/questions/14703698/invokedelegate. Video reference: https://www.youtube.com/watch?v=_rykXzs3NqQ
            ///
            _addReservationRequest?.Invoke(Requestedby.Text, Description.Text, startDateTime, endDateTime, int.Parse(ParticipantCount.Text), _selectedRoom.RoomNumber);

            
            DisplayAlert("Success", "Your request has been added", "Ok");

        }
        catch (Exception ex)
        {
            // Handle any other unexpected errors
            DisplayAlert("Error", ex.Message, "Ok");

        }

    }

    /// <summary>
    /// Just an event handler that is attached to the BackToRooms button  which takes the user to the PickRoomPage, nothing is passed since the PickRoomPage doesnt need aything from this page.
    /// </summary>
    /// <param name="sender">variable which referes to the object that triggers the event<</param>
    /// <param name="e">In our case, this is a placeholder paramter used in event handlers</param>
    private void OnBackToRooms(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PickRoomPage());

    }
   
}