using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamViewer.AdditionalClasses
{
    public class ScreenShot
    {
        public string GetScreenShotPath(int count)
        {
            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size);
                bmp.Save(@"C:\Users\Documents\source\repos\TeamViewer\TeamViewer\bin\Debug\Images\" + "screenshot" + count.ToString() + ".png");  // saves the image
            }
            var source = @"C:\Users\Documents\source\repos\TeamViewer\TeamViewer\bin\Debug\Images\" + "screenshot" + count.ToString() + ".png";
            return source;
        }
    }
}
