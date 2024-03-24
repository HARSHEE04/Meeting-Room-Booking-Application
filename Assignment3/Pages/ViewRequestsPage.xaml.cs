namespace Assignment3.Pages;

public partial class ViewRequestsPage : ContentPage
{
	public ViewRequestsPage()
	{
		InitializeComponent();
	}

    private void OnBackToRooms(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PickRoomPage());
    }
}