using The49.Maui.BottomSheet;

namespace Moana.View;

public partial class SearchBottomPage : BottomSheet
{
	public SearchBottomPage(string response)
	{
		InitializeComponent();
        Resultado.Text = response;

    }
}