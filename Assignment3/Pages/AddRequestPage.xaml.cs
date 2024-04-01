using Assignment3.BusinessLogic;
namespace Assignment3.Pages;

public partial class AddRequestPage : ContentPage
    //perform validation checks here as well , ask
{
    private MeetingRoom _selectedRoom;
    private Action<string, string, DateTime, DateTime, int, string> _addReservationRequest;

    public AddRequestPage(MeetingRoom selectedRoom, Action<string, string, DateTime, DateTime, int, string> addReservationRequest)//takes the info about the selected room to the next page
	{
		InitializeComponent();
        this.BindingContext = selectedRoom;
        _selectedRoom = selectedRoom;
        _addReservationRequest = addReservationRequest;

    }

    //Issue found with debugging, is that the viewrequests page is not getting the instance of the request which is being made. Getting that specific instance would allow it to access the list

    private void OnAddRequest(object sender, EventArgs e)
    {
        

        DateTime startDateTime= DatePicker.Date + StartTimePicker.Time;

        DateTime endDateTime= DatePicker.Date + EndTimePicker.Time;

        ReservationRequest newRequest = new ReservationRequest(Requestedby.Text, Description.Text, startDateTime, endDateTime, int.Parse(ParticipantCount.Text));
        // Store the newRequest object in the static class
      //  GlobalVariables.NewRequest = newRequest;
        _addReservationRequest?.Invoke(Requestedby.Text, Description.Text, startDateTime, endDateTime, int.Parse(ParticipantCount.Text), _selectedRoom.RoomNumber);

        DisplayAlert("Success", "Your request has been added", "Ok");

    }


    private void OnBackToRooms(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PickRoomPage());

    }
}