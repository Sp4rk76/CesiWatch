using CesiWatch;
using Gtk;
using Gdk;
using System;
using Pango;

public partial class MainWindow : Gtk.Window
{
	static int i = 0;

	DrawingArea da;
	
	private WatchController watchController_ = null;

	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		Build();

		Initialize();
	}

	private void Initialize()
	{
		da = new DrawingArea();

		watchController_ = new WatchController();

		watchController_.Start(); // start connection (Receive=asynchronous | Send=synchronous);

		// this.ModifyBg(StateType.Normal, col);
		// this.DrawingAreaMap.ModifyBg(StateType.Normal, col);




		var gc = new Gdk.GC((Drawable)DrawingAreaMap.GdkWindow);
		gc.RgbFgColor = new Gdk.Color(255, 0, 0);
		var darkGray = new Gdk.Color(79, 79, 79);
		this.ModifyBg(StateType.Normal, darkGray);
		var gray = new Gdk.Color(100, 100, 100);
		this.DrawingAreaMap.ModifyBg(StateType.Normal, gray);
		DrawingAreaMap.GdkWindow.DrawRectangle(gc, true, 5 + (i * 50), 5 + (i * 50), 5, 5);

		this.Add(this.da);

		this.Show();
	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		watchController_.Stop();

		Application.Quit();

		a.RetVal = true;
	}

	protected void OnTextBoxPlayerChanged(object sender, System.EventArgs e)
	{
		i++;

		var textBoxPlayerName = sender as Gtk.Entry;

		TextBoxPlayerName.Text = textBoxPlayerName.Text;

		// watchController_.WatchModel.PlayerName = TextBoxPlayerName.Text;
	}

	protected void OnTextBoxPositionChanged(object sender, System.EventArgs e)
	{
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
}
