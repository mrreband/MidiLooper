using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Midi;

namespace MidiSequencer
{
    class ToggleBox : CheckBox
    {
        public bool IsActive { get; private set; }
        public Pitch Pitch;

        public ToggleBox()
        {
            newToggleBox();
        }

        public ToggleBox(int left, int top, Pitch pitch)
        {
            newToggleBox();
            this.Left = left;
            this.Top = top;
            this.Pitch = pitch;
        }

        private void newToggleBox() 
        {
            this.Appearance = System.Windows.Forms.Appearance.Button;
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            this.Width = 20;
            this.Height = 20;
        }
        
        protected override void OnClick(EventArgs e) 
        {
            base.OnClick(e);
            OnMouseEnter(e);
        }

        protected override void OnMouseEnter(EventArgs eventargs)
        {
            base.OnMouseEnter(eventargs);
            this.BackColor = (this.Checked) ? Color.Gray : Color.LightGray;
        }

        protected override void OnMouseLeave(EventArgs eventargs)
        {
            base.OnMouseLeave(eventargs);
            this.BackColor = (this.Checked) ? Color.Black : Color.White;
        }

        public void Activate()
        {
            this.BackColor = (this.Checked) ? Color.Green : Color.LightGreen;
            this.IsActive = true;
        }

        public void Deactivate()
        {
            this.BackColor = (this.Checked) ? Color.Black : Color.White;
            this.IsActive = false;
        }
    }
}
