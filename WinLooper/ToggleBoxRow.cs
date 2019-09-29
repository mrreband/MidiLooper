using Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinLooper
{
    class ToggleBoxRow : Panel
    {
        public Pitch Pitch;
        public int BoxCount;
        public List<ToggleBox> ToggleBoxes;

        public ToggleBoxRow(int left, int top, Pitch pitch, int boxCount)
        {
            this.Left = left;
            this.Top = top;

            this.Pitch = pitch;
            this.BoxCount = boxCount;
            this.Width = (this.BoxCount + 1) * 50;
            this.Height = 50;

            this.ToggleBoxes = new List<ToggleBox>();

            //add new boxes
            for (int i = 0; i < this.BoxCount; i++)
            {
                var tb = new ToggleBox((50 * i) + 25, 0, pitch);
                this.ToggleBoxes.Add(tb);
                this.Controls.Add(tb);
            }
        }
    }
}
