using TechnicalAxos_NahuelSalomon.ViewModels;

namespace TechnicalAxos_NahuelSalomon.Views;

public partial class MainView : ContentPage
{
	public MainView()
	{
		InitializeComponent();
		BindingContext = new MainViewModel();
	}

}