using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmWorld : Form
    {
        int px;
        int py;
        int world_index;
        public World wrld = new World();
        public frmWorld()
        {
            InitializeComponent();
            this.picWorld.MouseClick += new MouseEventHandler(picWorld_Click);
            this.KeyPress += new KeyPressEventHandler(frmWorld_KeyPress);
            px = 0;
            py = 0;
            world_index = -1;
           
        }

        void frmWorld_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'x')
            {
                px = 0;
                py = 0;
              
            }
        }

        void picWorld_Click(object sender, MouseEventArgs e)
        {
            if (px == 0 || py == 0)
            {
                px = e.X;
                py = e.Y;
                this.world_index = wrld.collision_segment.Add(new ArrayList());
                ((ArrayList)wrld.collision_segment[this.world_index]).Add(new Point(px, py));
            }
            else
            {
                Graphics g = Graphics.FromImage(picWorld.Image);
                g.DrawLine(new Pen(Color.White), px, py, e.X, e.Y);
                Console.WriteLine("draw line");
                px = e.X;
                py = e.Y;
                ((ArrayList)wrld.collision_segment[this.world_index]).Add(new Point(px, py));
                picWorld.Refresh();
            }
        }

        private void frmWorld_Load(object sender, EventArgs e)
        {

        }

        private void picWorld_Click(object sender, EventArgs e)
        {

        }
        
    }
}
