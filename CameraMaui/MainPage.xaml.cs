namespace CameraMaui;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}
	private void cameraView_CamerasLoaded(object sender, EventArgs e)
	{
		cameraView.Camera = cameraView.Cameras.First();// .Cameras[0];
		MainThread.BeginInvokeOnMainThread(async () =>
		{
			await cameraView.StopCameraAsync();
			await cameraView.StartCameraAsync();

		});

	}
	private void button_clicked(object sender, EventArgs e)
	{
		myImage.Source = cameraView.GetSnapShot(Camera.MAUI.ImageFormat.PNG);
	}
}

