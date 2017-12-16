using CesiWatch;
using Gtk;

public partial class MainWindow : Gtk.Window
{
	private WatchController watchController_ = null;

	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		Build();

		Initialize();
	}

	private void Initialize()
	{
		watchController_ = new WatchController();
	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		Application.Quit();
		a.RetVal = true;
	}
}
