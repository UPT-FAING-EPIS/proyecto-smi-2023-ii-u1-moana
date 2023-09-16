using System.IO;
using System.Net.Http.Headers;

namespace Moana.Pages;

public partial class SearchWound : ContentPage
{
	public SearchWound()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            ImageSource streamPhotolocal = cameraView.GetSnapShot();
            Stream streamPhoto = await cameraView.TakePhotoAsync();
            using (MemoryStream ms = new MemoryStream())
            {
                await streamPhoto.CopyToAsync(ms);
                byte[] photoBytes = ms.ToArray();

                ImageSource imageSource = ImageSource.FromStream(() => new MemoryStream(photoBytes));

                myImage.Source = imageSource;

                await UploadPhotoAsync(photoBytes, streamPhotolocal);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }

    private void cameraView_CamerasLoaded(object sender, EventArgs e)
    {
        cameraView.Camera = cameraView.Cameras.First();
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            await cameraView.StopCameraAsync();
            await cameraView.StartCameraAsync();

        });
    }

    private async Task UploadPhotoAsync(byte[] photoBytes, ImageSource streamPhoto )
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "https://woundapi.onrender.com/predict/";

                var content = new MultipartFormDataContent();

                content.Add(new ByteArrayContent(photoBytes), "file", "photo.jpg");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Respuesta del servidor:");
                    Console.WriteLine(responseContent);

                    var page = new SearchBottomPage(responseContent, streamPhoto);
                    await page.ShowAsync();
                }
                else
                {
                    Console.WriteLine($"Error en la solicitud HTTP: {response.StatusCode}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error en la solicitud HTTP: {ex.Message}");
        }
    }
}