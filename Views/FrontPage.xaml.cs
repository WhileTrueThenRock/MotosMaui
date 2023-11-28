using MauiMotos.ViewModels;

namespace MauiMotos;

public partial class FrontPage : ContentPage
{
	public FrontPage()
	{
		InitializeComponent();
		BindingContext = new FrontViewModel();
	}
}