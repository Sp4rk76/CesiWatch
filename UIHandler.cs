using Gdk;

namespace CesiWatch
{
	public class UIHandler
	{
		private MainWindow mainWindow_ = null; // MainWindow's reference

		private Gdk.GC graphicContextWindow_ = null; // MainWindow's Context

		private Gdk.GC graphicContextAreaMap_ = null; // AreaMap's Context

		public Gdk.GC GraphicContextWindow
		{
			get { return graphicContextWindow_; }
			set { graphicContextWindow_ = value; }
		}

		public Gdk.GC GraphicContextAreaMap
		{
			get { return graphicContextAreaMap_; }
			set { graphicContextAreaMap_ = value; }
		}

		public MainWindow MainWindow
		{ 
			get { return mainWindow_; }
			set { mainWindow_ = value; }
		}

		public UIHandler(MainWindow mainWindow)
		{
			mainWindow_ = mainWindow;

			graphicContextWindow_ = new Gdk.GC((Drawable)mainWindow_.GdkWindow);

			graphicContextAreaMap_ = new Gdk.GC((Drawable)mainWindow_.DrawingAreaMap.GdkWindow);
		}

		public void Initialize()
		{
			LoadBackGrounds();

			LoadForegrounds();
		}

		public void LoadBackGrounds()
		{
			/* MainWindow's Background */
			mainWindow_.ModifyBg(Gtk.StateType.Normal, ColorPicker.DarkGray);

			/* DrawingAreaMap's Background */
			mainWindow_.DrawingAreaMap.ModifyBg(Gtk.StateType.Normal, ColorPicker.Gray);
		}

		public void LoadForegrounds()
		{
			/* DrawingAreaMap's Foreground */
			graphicContextAreaMap_.RgbFgColor = ColorPicker.Red;
		}

		public void DrawMapPoint(Color color, int x, int y, int w = 4, int h = 4)
		{
			graphicContextAreaMap_.RgbFgColor = color;

			mainWindow_.DrawingAreaMap.GdkWindow.DrawRectangle(graphicContextAreaMap_, true, x, y, w, h);
		}

		public void ClearDrawingArea()
		{
			mainWindow_.DrawingAreaMap.GdkWindow.Clear();
		}
	}
}
