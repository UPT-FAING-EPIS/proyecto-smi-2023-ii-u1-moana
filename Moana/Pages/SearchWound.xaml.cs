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
            // Tomar una foto y obtener la secuencia
            Stream streamPhoto = await cameraView.TakePhotoAsync();

            // Crear un MemoryStream para copiar la secuencia
            using (MemoryStream ms = new MemoryStream())
            {
                await streamPhoto.CopyToAsync(ms);
                byte[] photoBytes = ms.ToArray();

                // Crear una ImageSource desde el arreglo de bytes
                ImageSource imageSource = ImageSource.FromStream(() => new MemoryStream(photoBytes));

                // Establecer la fuente de la Image
                myImage.Source = imageSource;

                // Realizar la solicitud POST al servidor
                await UploadPhotoAsync(photoBytes);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

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

    private async Task UploadPhotoAsync(byte[] photoBytes)
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "https://woundapi.onrender.com/predict/";

                ByteArrayContent imageContent = new ByteArrayContent(photoBytes);

                imageContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, apiUrl);
                request.Content = imageContent;

                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Respuesta del servidor:");
                    Console.WriteLine(responseContent);

                    var page = new SearchBottomPage(responseContent);
                    await page.ShowAsync();
                }
                else
                {
                    Console.WriteLine($"Error en la solicitud HTTP: {response.StatusCode}");
                    Console.WriteLine($"Error en la solicitud HTTP: {response}");

                    var responseContent = await response.Content.ReadAsStringAsync();
                    var page = new SearchBottomPage(responseContent);
                    await page.ShowAsync();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error en la solicitud HTTP: {ex.Message}");
        }
    }

}