using CesiWatch;
using Gtk;
using System;
using System.Threading;

public partial class MainWindow : Gtk.Window
{
	private WatchController watchController_ = null;

	private DrawingAreaMapHelper helper_ = null;

	private UIHandler UIHandler_ = null;

	public DrawingArea DrawingAreaMap
	{
		get { return DrawingArea; }
	}

	public UIHandler UIHandler 
	{ 
		get { return UIHandler_; }
	}

	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		Build();

		Initialize();
	}

	private void Initialize()
	{
		watchController_ = new WatchController();

		helper_ = new DrawingAreaMapHelper(DrawingAreaMap);

		UIHandler_ = new UIHandler(this);

		watchController_.Start(); // start connection (Receive=asynchronous | Send=synchronous);

		UIHandler_.Initialize();

		DrawingAreaMap.ExposeEvent += (o, args) =>
		{
			UIHandler.DrawMapPoint((helper_.WindowWidth / 2) - 2, (helper_.WindowHeight / 2) - 2);
		};

		Add(DrawingAreaMap);
		
		Show();
	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs e)
	{
		watchController_.Stop();

		Application.Quit();

		e.RetVal = true;
	}

	protected void OnTextBoxPlayerChanged(object sender, System.EventArgs e)
	{
		var textBoxPlayerName = sender as Gtk.Entry;

		TextBoxPlayerName.Text = textBoxPlayerName.Text;

		// watchController_.WatchModel.PlayerName = TextBoxPlayerName.Text;
	}

	protected void OnTextBoxPositionChanged(object sender, System.EventArgs e)
	{
		var textBoxPosition = sender as Gtk.Entry;

		TextBoxPosition.Text = textBoxPosition.Text;

		// TODO: Parse position to get 2 coordinates (X and Y) !
		// watchController_.WatchModel.Position = 
	}

	protected void OnTextBoxDateTimeChanged(object sender, System.EventArgs e)
	{
	}

	protected void OnTextBoxTimeLeftChanged(object sender, System.EventArgs e)
	{
	}

	protected void OnButtonRangeTeamIdChanged(object sender, System.EventArgs e)
	{
	}

	protected void OnButtonValidateTeamIdReleased(object sender, System.EventArgs e)
	{
		ButtonRangeTeamId.Sensitive = false;
	}

	protected void OnFrameEvent(object o, FrameEventArgs args)
	{
	}

	protected void OnButtonSaveReleased(object sender, EventArgs e)
	{
	}

	protected void OnButtonTalkReleased(object sender, EventArgs e)
	{
	}

	protected void OnButtonDeadReleased(object sender, EventArgs e)
	{
	}

	protected void OnButtonBackTeamIdReleased(object sender, EventArgs e)
	{
	}
}
