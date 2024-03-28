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

    //method to change the endtime to the same as start time, does not work yet
    private void StartTimePicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
       
        if (e.PropertyName == nameof(TimePicker.Time))
        {
            
            EndTimePicker.Time = StartTimePicker.Time;
        }
    }

    private void OnAddRequest(object sender, EventArgs e)
    {
        

        DateTime startDateTime= DatePicker.Date + StartTimePicker.Time;

        DateTime endDateTime= DatePicker.Date + EndTimePicker.Time;


        _addReservationRequest?.Invoke(Requestedby.Text, Description.Text, startDateTime, endDateTime, int.Parse(ParticipantCount.Text), _selectedRoom.RoomNumber);

        DisplayAlert("Success", "Your request has been added", "Ok");

    }

    private void OnBackToRooms(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PickRoomPage());

    }
}