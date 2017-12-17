using Gdk;

namespace CesiWatch
{
	public class UIHandler
	{
		private MainWindow mainWindow_ = null;
		private Gdk.GC graphicContextWindow_ = null;
		private Gdk.GC graphicContextAreaMap_ = null;

		Color red_ = new Gdk.Color(255, 0, 0);
		Color darkGray_ = new Gdk.Color(79, 79, 79);
		Color gray_ = new Gdk.Color(100, 100, 100);

		public Gdk.GC GraphicContextWindow
		{
			get
			{
				return graphicContextWindow_;
			}
			set
			{
				graphicContextWindow_ = value;
			}
		}

		public Gdk.GC GraphicContextAreaMap
		{
			get
			{
				return graphicContextAreaMap_;
			}
			set
			{
				graphicContextAreaMap_ = value;
			}
		}

		public MainWindow MainWindow
		{
			get
			{
				return mainWindow_;
			}
			set
			{
				mainWindow_ = value;
			}
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
			mainWindow_.ModifyBg(Gtk.StateType.Normal, darkGray_);

			/* DrawingAreaMap's Background */
			mainWindow_.DrawingAreaMap.ModifyBg(Gtk.StateType.Normal, gray_);
		}

		public void LoadForegrounds()
		{
			/* DrawingAreaMap's Foreground */
			graphicContextAreaMap_.RgbFgColor = red_;
		}

		public void DrawMapPoint(int x, int y, int w = 4, int h = 4)
		{
			
			mainWindow_.DrawingAreaMap.GdkWindow.DrawRectangle(GraphicContextAreaMap, true, x, y, w, h);
		}
	}
}
