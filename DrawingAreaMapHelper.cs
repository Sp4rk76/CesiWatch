using Gtk;

namespace CesiWatch
{
	public class DrawingAreaMapHelper
	{
		private DrawingArea drawingArea_ = null;

		private int width_ = 0;

		private int height_ = 0;

		private int windowWidth_ = 0;

		private int windowHeight_ = 0;

		public int WindowWidth { 
			get
			{
				return windowWidth_;
			}
			set
			{
				if (value > 0)
				{
					windowWidth_ = value;
				}
				else
				{
					windowWidth_ = 0;
				}
			}
		}

		public int WindowHeight
		{
			get
			{
				return windowHeight_;
			}
			set
			{
				if (value > 0)
				{
					windowHeight_ = value;
				}
				else
				{
					windowHeight_ = 0;
				}
			}
		}

		public DrawingAreaMapHelper(DrawingArea drawingArea)
		{
			drawingArea_ = drawingArea;

			drawingArea_.GdkWindow.GetSize(out width_, out height_);

			WindowWidth = width_;

			WindowHeight = height_;

		}
	}
}
