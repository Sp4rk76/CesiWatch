using CesiWatch;
using Gtk;
using System;

public partial class MainWindow : Gtk.Window
{
	private bool started_ = false;

	private bool validated_ = false;

	private bool talking_ = false;

	private const int MAX_ALLOWED_TEAMS = 64;

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

	public void LoadDefaultControls()
	{
		ButtonRangeTeamId.Sensitive = true;
		ButtonSave.Sensitive = false;
		ButtonTalk.Sensitive = false;
		ButtonDead.Sensitive = false;
		ButtonBackTeamId.Sensitive = false;
		TextBoxPosition.Sensitive = false;
		TextBoxDateTime.Sensitive = false;
		TextBoxTimeLeft.Sensitive = false;
	}

	private void Initialize()
	{
		LoadDefaultControls();

		watchController_ = new WatchController();

		helper_ = new DrawingAreaMapHelper(DrawingAreaMap);

		UIHandler_ = new UIHandler(this);

		UIHandler_.Initialize();

		// TODO: remove event ?
		DrawingAreaMap.ExposeEvent += (o, args) =>
		{
			UIHandler_.ClearDrawingArea();
			UIHandler.DrawMapPoint(ColorPicker.Blue, (helper_.WindowWidth / 2) - 2, (helper_.WindowHeight / 2) - 2, 8, 8);
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

		// TODO: GET NEW DATA FROM CONTROLLER ? (GEOLOCALISATION UPDATE CALL here !)
		// watchController_.WatchModel.Position = new Position( ? ; ? )
	}

	protected void OnTextBoxDateTimeChanged(object sender, System.EventArgs e)
	{
		var textBoxDateTime = sender as Gtk.Entry;

		TextBoxDateTime.Text = textBoxDateTime.Text;

		// TODO: Set DateTime to model
		// watchController_.WatchModel.DateTime = 
	}

	protected void OnTextBoxTimeLeftChanged(object sender, System.EventArgs e)
	{
		// TODO: time elapsed for game;
		// If time reaches 0
		// then game is finished !
	}

	/* Keep result in range */
	protected void OnButtonRangeTeamIdChanged(object sender, System.EventArgs e)
	{
		var result = 1;

		if (int.TryParse(ButtonRangeTeamId.Text.ToString(), out result))
		{
			if (result <= 0)
			{
				result = 1;
			}
			if (result > MAX_ALLOWED_TEAMS)
			{
				result = MAX_ALLOWED_TEAMS;
			}
		}

		ButtonRangeTeamId.Text = result.ToString();
	}

	public bool IsValid(string input)
	{
		return !string.IsNullOrEmpty(input);
	}

	public bool IsValid(int input)
	{
		return (input > 0) && (input <= MAX_ALLOWED_TEAMS);
	}

	protected void OnButtonValidateTeamIdReleased(object sender, System.EventArgs e)
	{


		if (IsValid(TextBoxPlayerName.Text.ToString()) &&
		    IsValid(int.Parse(ButtonRangeTeamId.Text.ToString())))
		{
			validated_ = true;
			TextBoxPlayerName.Sensitive = false;
			ButtonSave.Sensitive = true;
			ButtonValidateTeamId.Sensitive = false;
			ButtonRangeTeamId.Sensitive = false;
			ButtonBackTeamId.Sensitive = true;
		}
		else
		{
			validated_ = false;
		}
	}

	protected void OnFrameEvent(object o, FrameEventArgs args)
	{ // NOTE: this does nothing !!
	}


	protected void OnButtonSaveReleased(object sender, EventArgs e)
	{
		if (watchController_ == null)
		{
			watchController_ = new WatchController();
			Console.WriteLine("Error: Failed to start watch controller (null) !");
			validated_ = false;
			started_ = false;
		}

		if (validated_ && !started_)
		{
			watchController_.Start(); // Start connection

			// TODO: Update Watch data;
			//watchController_.UpdateWatch();

			// Update Buttons and Controls
			ButtonSave.Sensitive = false;
			ButtonTalk.Sensitive = true;
			ButtonDead.Sensitive = true;
			ButtonBackTeamId.Sensitive = false;
			ButtonValidateTeamId.Sensitive = false;
		}
	}

	public void EnableTalk()
	{
		ButtonTalk.Clicked += (sender, e) =>
		{

		};
		ButtonTalk.ModifyFg(Gtk.StateType.Normal, ColorPicker.Green);

		talking_ = true;

		Console.WriteLine("Talk Enabled [ON]");
	}

	public void DisableTalk()
	{
		ButtonTalk.ModifyFg(Gtk.StateType.Normal, ColorPicker.Orange);

		talking_ = false;

		Console.WriteLine("Talk Disabled [OFF]");
	}

	protected void OnButtonTalkReleased(object sender, EventArgs e)
	{
		talking_ = !talking_;
			
		if (talking_)
		{
			DisableTalk();
		}
		else
		{
			EnableTalk();
		}
	}

	protected void OnButtonDeadReleased(object sender, EventArgs e)
	{
		// TODO: Review this code !
		TextBoxPlayerName.Sensitive = true;
		ButtonValidateTeamId.Sensitive = true;
		ButtonRangeTeamId.Sensitive = true;
		ButtonBackTeamId.Sensitive = false;
		ButtonSave.Sensitive = false;
		ButtonTalk.Sensitive = false;

		ButtonDead.Sensitive = false;
		started_ = false;
		validated_ = false;

		watchController_.Stop();
	}

	protected void OnButtonBackTeamIdReleased(object sender, EventArgs e)
	{
		TextBoxPlayerName.Sensitive = true;
		ButtonRangeTeamId.Sensitive = true;
		ButtonBackTeamId.Sensitive = false;
		ButtonValidateTeamId.Sensitive = true;
		ButtonSave.Sensitive = false;

		validated_ = false;
	}
}