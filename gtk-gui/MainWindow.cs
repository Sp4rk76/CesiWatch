
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.VBox vbox1;

	private global::Gtk.DrawingArea DrawingArea;

	private global::Gtk.HBox hbox2;

	private global::Gtk.VBox vbox2;

	private global::Gtk.VBox vbox7;

	private global::Gtk.Entry TextBoxPlayerName;

	private global::Gtk.Entry TextBoxPosition;

	private global::Gtk.VBox vbox8;

	private global::Gtk.Entry TextBoxDateTime;

	private global::Gtk.Entry TextBoxTimeLeft;

	private global::Gtk.VBox vbox9;

	private global::Gtk.HBox hbox3;

	private global::Gtk.SpinButton ButtonRangeTeamId;

	private global::Gtk.HBox hbox4;

	private global::Gtk.Button ButtonValidateTeamId;

	private global::Gtk.Button ButtonBackTeamId;

	private global::Gtk.VBox vbox10;

	private global::Gtk.VBox vbox11;

	private global::Gtk.Button ButtonSave;

	private global::Gtk.VBox vbox12;

	private global::Gtk.Button ButtonTalk;

	private global::Gtk.VBox vbox13;

	private global::Gtk.Button ButtonDead;

	protected virtual void Build()
	{
		global::Stetic.Gui.Initialize(this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString("CesiWatch 1.0");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		this.BorderWidth = ((uint)(17));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 6;
		// Container child vbox1.Gtk.Box+BoxChild
		this.DrawingArea = new global::Gtk.DrawingArea();
		this.DrawingArea.WidthRequest = 280;
		this.DrawingArea.Name = "DrawingArea";
		this.vbox1.Add(this.DrawingArea);
		global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.DrawingArea]));
		w1.Position = 0;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hbox2 = new global::Gtk.HBox();
		this.hbox2.Name = "hbox2";
		this.hbox2.Spacing = 6;
		// Container child hbox2.Gtk.Box+BoxChild
		this.vbox2 = new global::Gtk.VBox();
		this.vbox2.Name = "vbox2";
		this.vbox2.Spacing = 6;
		this.vbox2.BorderWidth = ((uint)(3));
		// Container child vbox2.Gtk.Box+BoxChild
		this.vbox7 = new global::Gtk.VBox();
		this.vbox7.Name = "vbox7";
		this.vbox7.Spacing = 6;
		// Container child vbox7.Gtk.Box+BoxChild
		this.TextBoxPlayerName = new global::Gtk.Entry();
		this.TextBoxPlayerName.CanFocus = true;
		this.TextBoxPlayerName.Name = "TextBoxPlayerName";
		this.TextBoxPlayerName.IsEditable = true;
		this.TextBoxPlayerName.InvisibleChar = '●';
		this.vbox7.Add(this.TextBoxPlayerName);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox7[this.TextBoxPlayerName]));
		w2.Position = 0;
		// Container child vbox7.Gtk.Box+BoxChild
		this.TextBoxPosition = new global::Gtk.Entry();
		this.TextBoxPosition.CanFocus = true;
		this.TextBoxPosition.Name = "TextBoxPosition";
		this.TextBoxPosition.IsEditable = true;
		this.TextBoxPosition.InvisibleChar = '●';
		this.vbox7.Add(this.TextBoxPosition);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox7[this.TextBoxPosition]));
		w3.Position = 1;
		this.vbox2.Add(this.vbox7);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.vbox7]));
		w4.Position = 0;
		// Container child vbox2.Gtk.Box+BoxChild
		this.vbox8 = new global::Gtk.VBox();
		this.vbox8.Name = "vbox8";
		this.vbox8.Spacing = 6;
		// Container child vbox8.Gtk.Box+BoxChild
		this.TextBoxDateTime = new global::Gtk.Entry();
		this.TextBoxDateTime.CanFocus = true;
		this.TextBoxDateTime.Name = "TextBoxDateTime";
		this.TextBoxDateTime.IsEditable = true;
		this.TextBoxDateTime.InvisibleChar = '●';
		this.vbox8.Add(this.TextBoxDateTime);
		global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox8[this.TextBoxDateTime]));
		w5.Position = 0;
		// Container child vbox8.Gtk.Box+BoxChild
		this.TextBoxTimeLeft = new global::Gtk.Entry();
		this.TextBoxTimeLeft.CanFocus = true;
		this.TextBoxTimeLeft.Name = "TextBoxTimeLeft";
		this.TextBoxTimeLeft.IsEditable = true;
		this.TextBoxTimeLeft.InvisibleChar = '●';
		this.vbox8.Add(this.TextBoxTimeLeft);
		global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox8[this.TextBoxTimeLeft]));
		w6.Position = 1;
		this.vbox2.Add(this.vbox8);
		global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.vbox8]));
		w7.Position = 1;
		// Container child vbox2.Gtk.Box+BoxChild
		this.vbox9 = new global::Gtk.VBox();
		this.vbox9.Name = "vbox9";
		this.vbox9.Spacing = 6;
		// Container child vbox9.Gtk.Box+BoxChild
		this.hbox3 = new global::Gtk.HBox();
		this.hbox3.Name = "hbox3";
		this.hbox3.Spacing = 6;
		// Container child hbox3.Gtk.Box+BoxChild
		this.ButtonRangeTeamId = new global::Gtk.SpinButton(0D, 100D, 1D);
		this.ButtonRangeTeamId.CanFocus = true;
		this.ButtonRangeTeamId.Name = "ButtonRangeTeamId";
		this.ButtonRangeTeamId.Adjustment.PageIncrement = 10D;
		this.ButtonRangeTeamId.ClimbRate = 1D;
		this.ButtonRangeTeamId.Numeric = true;
		this.ButtonRangeTeamId.Value = 1D;
		this.hbox3.Add(this.ButtonRangeTeamId);
		global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.ButtonRangeTeamId]));
		w8.Position = 0;
		// Container child hbox3.Gtk.Box+BoxChild
		this.hbox4 = new global::Gtk.HBox();
		this.hbox4.Name = "hbox4";
		this.hbox4.Spacing = 6;
		// Container child hbox4.Gtk.Box+BoxChild
		this.ButtonValidateTeamId = new global::Gtk.Button();
		this.ButtonValidateTeamId.CanFocus = true;
		this.ButtonValidateTeamId.Name = "ButtonValidateTeamId";
		this.ButtonValidateTeamId.UseUnderline = true;
		this.ButtonValidateTeamId.Label = global::Mono.Unix.Catalog.GetString("Validate");
		this.hbox4.Add(this.ButtonValidateTeamId);
		global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.ButtonValidateTeamId]));
		w9.Position = 0;
		// Container child hbox4.Gtk.Box+BoxChild
		this.ButtonBackTeamId = new global::Gtk.Button();
		this.ButtonBackTeamId.WidthRequest = 25;
		this.ButtonBackTeamId.HeightRequest = 25;
		this.ButtonBackTeamId.CanFocus = true;
		this.ButtonBackTeamId.Name = "ButtonBackTeamId";
		this.ButtonBackTeamId.UseUnderline = true;
		this.ButtonBackTeamId.Label = global::Mono.Unix.Catalog.GetString("<-");
		this.hbox4.Add(this.ButtonBackTeamId);
		global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.ButtonBackTeamId]));
		w10.Position = 1;
		w10.Expand = false;
		w10.Fill = false;
		this.hbox3.Add(this.hbox4);
		global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.hbox4]));
		w11.Position = 1;
		w11.Expand = false;
		w11.Fill = false;
		this.vbox9.Add(this.hbox3);
		global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox9[this.hbox3]));
		w12.Position = 0;
		this.vbox2.Add(this.vbox9);
		global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.vbox9]));
		w13.Position = 2;
		w13.Expand = false;
		w13.Fill = false;
		this.hbox2.Add(this.vbox2);
		global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.vbox2]));
		w14.Position = 0;
		w14.Padding = ((uint)(17));
		// Container child hbox2.Gtk.Box+BoxChild
		this.vbox10 = new global::Gtk.VBox();
		this.vbox10.Name = "vbox10";
		this.vbox10.Spacing = 6;
		this.vbox10.BorderWidth = ((uint)(3));
		// Container child vbox10.Gtk.Box+BoxChild
		this.vbox11 = new global::Gtk.VBox();
		this.vbox11.Name = "vbox11";
		this.vbox11.Spacing = 6;
		// Container child vbox11.Gtk.Box+BoxChild
		this.ButtonSave = new global::Gtk.Button();
		this.ButtonSave.WidthRequest = 65;
		this.ButtonSave.HeightRequest = 65;
		this.ButtonSave.CanFocus = true;
		this.ButtonSave.Name = "ButtonSave";
		this.ButtonSave.UseUnderline = true;
		this.ButtonSave.Label = global::Mono.Unix.Catalog.GetString("Start");
		this.vbox11.Add(this.ButtonSave);
		global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox11[this.ButtonSave]));
		w15.Position = 0;
		this.vbox10.Add(this.vbox11);
		global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox10[this.vbox11]));
		w16.Position = 0;
		w16.Expand = false;
		w16.Fill = false;
		// Container child vbox10.Gtk.Box+BoxChild
		this.vbox12 = new global::Gtk.VBox();
		this.vbox12.Name = "vbox12";
		this.vbox12.Spacing = 6;
		// Container child vbox12.Gtk.Box+BoxChild
		this.ButtonTalk = new global::Gtk.Button();
		this.ButtonTalk.WidthRequest = 65;
		this.ButtonTalk.HeightRequest = 65;
		this.ButtonTalk.CanFocus = true;
		this.ButtonTalk.Name = "ButtonTalk";
		this.ButtonTalk.UseUnderline = true;
		this.ButtonTalk.Label = global::Mono.Unix.Catalog.GetString("Talk");
		this.vbox12.Add(this.ButtonTalk);
		global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.vbox12[this.ButtonTalk]));
		w17.Position = 0;
		this.vbox10.Add(this.vbox12);
		global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.vbox10[this.vbox12]));
		w18.Position = 1;
		w18.Expand = false;
		w18.Fill = false;
		// Container child vbox10.Gtk.Box+BoxChild
		this.vbox13 = new global::Gtk.VBox();
		this.vbox13.Name = "vbox13";
		this.vbox13.Spacing = 6;
		// Container child vbox13.Gtk.Box+BoxChild
		this.ButtonDead = new global::Gtk.Button();
		this.ButtonDead.HeightRequest = 65;
		this.ButtonDead.CanFocus = true;
		this.ButtonDead.Name = "ButtonDead";
		this.ButtonDead.UseUnderline = true;
		this.ButtonDead.Label = global::Mono.Unix.Catalog.GetString("Dead");
		this.vbox13.Add(this.ButtonDead);
		global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.vbox13[this.ButtonDead]));
		w19.Position = 0;
		this.vbox10.Add(this.vbox13);
		global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox10[this.vbox13]));
		w20.Position = 2;
		w20.Expand = false;
		w20.Fill = false;
		this.hbox2.Add(this.vbox10);
		global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.vbox10]));
		w21.Position = 1;
		w21.Padding = ((uint)(18));
		this.vbox1.Add(this.hbox2);
		global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox2]));
		w22.Position = 1;
		w22.Expand = false;
		w22.Padding = ((uint)(5));
		this.Add(this.vbox1);
		if ((this.Child != null))
		{
			this.Child.ShowAll();
		}
		this.DefaultWidth = 387;
		this.DefaultHeight = 541;
		this.Show();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
		this.TextBoxPlayerName.Changed += new global::System.EventHandler(this.OnTextBoxPlayerChanged);
		this.TextBoxDateTime.Changed += new global::System.EventHandler(this.OnTextBoxDateTimeChanged);
		this.TextBoxTimeLeft.Changed += new global::System.EventHandler(this.OnTextBoxTimeLeftChanged);
		this.ButtonRangeTeamId.Changed += new global::System.EventHandler(this.OnButtonRangeTeamIdChanged);
		this.ButtonValidateTeamId.Released += new global::System.EventHandler(this.OnButtonValidateTeamIdReleased);
		this.ButtonBackTeamId.Released += new global::System.EventHandler(this.OnButtonBackTeamIdReleased);
		this.ButtonSave.Released += new global::System.EventHandler(this.OnButtonSaveReleased);
		this.ButtonDead.Released += new global::System.EventHandler(this.OnButtonDeadReleased);
	}
}
