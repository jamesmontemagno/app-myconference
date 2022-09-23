namespace MyConference;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

	}
    protected override Window CreateWindow(IActivationState activationState)
    {
        Window window = base.CreateWindow(activationState);

        if (DeviceInfo.Idiom == DeviceIdiom.Desktop)
        {
            // Manipulate Window object
            const int newWidth = 800;
            const int newHeight = 600;

            // get screen size
            //var disp = DeviceDisplay.Current.MainDisplayInfo;

            // center the window
            //window.X = (disp.Width / disp.Density - newWidth) / 2;
            //window.Y = (disp.Height / disp.Density - newHeight) / 2;

            // resize
            window.MinimumWidth = 400;
            window.MinimumHeight = 400;

            window.MaximumWidth = 1920;
            window.MaximumHeight = 1080;
        }
        return window;
    }
}
