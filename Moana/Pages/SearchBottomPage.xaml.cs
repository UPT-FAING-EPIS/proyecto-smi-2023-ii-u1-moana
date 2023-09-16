using Newtonsoft.Json.Linq;
using The49.Maui.BottomSheet;

namespace Moana.Pages;

public partial class SearchBottomPage : BottomSheet
{
	public SearchBottomPage(string response, ImageSource streamPhoto)
	{
		InitializeComponent();

        try
        {
            var jsonObject = JObject.Parse(response);
            var prediction = jsonObject["prediction"]?.ToString();
            if (!string.IsNullOrEmpty(prediction))
            {
                Resultado.Text = "RESULT: " + prediction;
            }
            else
            {
                Resultado.Text = "No se pudo obtener la predicción.";
            }
            PhotoSnap.Source = streamPhoto;
        }
        catch (Exception ex)
        {
            Resultado.Text = "Error al procesar la respuesta: " + ex.Message;
        }

    }
}