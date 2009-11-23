using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SdlDotNet;
using SdlDotNet.Windows;
using SdlDotNet.Core;
using SdlDotNet.Graphics;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class frmWorld : Form
    {
        int px;
        int py;
        int world_index;
        public World wrld = new World();
        private SdlDotNet.Graphics.Surface surface;
        bool mutex;
        private int camera_x;
        private int camera_y;
        private Point Selected_Point;

        private int point_index;
        private int row_index;
        private bool selected;
        public frmWorld()
        {
            InitializeComponent();
            this.surfaceControl1.MouseClick += new MouseEventHandler(picWorld_Click);
            this.KeyPress += new KeyPressEventHandler(frmWorld_KeyPress);
            SdlDotNet.Core.Events.Tick += new EventHandler<TickEventArgs>(Events_Tick);
            surface = new Surface(this.surfaceControl1.Width, this.surfaceControl1.Height);
            SdlDotNet.Core.Events.MouseButtonUp += new EventHandler<SdlDotNet.Input.MouseButtonEventArgs>(Events_MouseButtonUp);
            SdlDotNet.Core.Events.MouseButtonDown += new EventHandler<SdlDotNet.Input.MouseButtonEventArgs>(Events_MouseButtonDown);
            SdlDotNet.Core.Events.MouseMotion += new EventHandler<SdlDotNet.Input.MouseMotionEventArgs>(Events_MouseMotion);
            this.surfaceControl1.Resize += new EventHandler(surfaceControl1_Resize);
            world_index = -1;
            px = 0;
            py = 0;
            camera_x = 0;
            camera_y = 0;
          

            Thread thread = new Thread(new ThreadStart(SdlDotNet.Core.Events.Run));
            thread.IsBackground = true;
            thread.Name = "SDL.NET";
            thread.Priority = ThreadPriority.Normal;
            thread.Start();
            
           
        }

        void Events_MouseMotion(object sender, SdlDotNet.Input.MouseMotionEventArgs e)
        {
             frmEditor edit = (frmEditor)this.MdiParent;
            if (e.ButtonPressed == true && edit.current_tool == tooltype.select && selected)
            {
                ArrayList r = (ArrayList)wrld.collision_segment[this.row_index];
                r[this.point_index] = new Point(e.X + this.camera_x, e.Y + this.camera_y);
                this.Selected_Point = new Point(e.X + this.camera_x, e.Y + this.camera_y);
            }
        }

        void surfaceControl1_Resize(object sender, EventArgs e)
        {
            this.surface = new Surface(this.surfaceControl1.Width, this.surfaceControl1.Height);
        }

        void Events_Tick(object sender, TickEventArgs e)
        {
            surface.Fill(Color.Black);
            //surface.Blit(master);
            renderworld();
            this.surfaceControl1.Blit(this.surface);
        }
        public void renderworld()
        {
            //picWorld.Image = new Bitmap(wrld.width, wrld.height);
            //Graphics g = Graphics.FromImage(picWorld.Image);
            foreach (ArrayList path in wrld.collision_segment)
            {
                Point previous = new Point(-1, -1);
                foreach (Point p in path)
                {
                    //Console.Write(p.ToString());
                    if (previous.X != -1 && previous.Y != -1)
                    {
                        Point render1 = new Point(previous.X + this.camera_x, previous.Y + this.camera_y);
                        Point render2 = new Point(p.X + this.camera_x, p.Y + this.camera_y);
                        surface.Draw(new SdlDotNet.Graphics.Primitives.Line(render1, render2), Color.White);
                        //surface.DrawDrawLine(new Pen(Color.White), previous, p);
                        //picWorld.Refresh();
                    }
                    previous = p;
                }
            }
            Point selected_render = new Point(Selected_Point.X + this.camera_x, Selected_Point.Y + this.camera_y);
            surface.Draw(new SdlDotNet.Graphics.Primitives.Circle(selected_render, 5), Color.Red);
        }

        void frmWorld_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'x')
            {
                px = 0;
                py = 0;
              
            }
            if (e.KeyChar == 'a')
            {
                camera_x+= 10;
            }
            if (e.KeyChar == 'd')
            {
                camera_x-= 10;
            }
            if (e.KeyChar == 'w')
            {
                camera_y += 10;
            }
            if (e.KeyChar == 's')
            {
                camera_y -= 10;
            }
        }
        void Events_MouseButtonDown(object sender, SdlDotNet.Input.MouseButtonEventArgs e)
        {
            frmEditor edit = (frmEditor)this.MdiParent;
            if (edit.current_tool == tooltype.select)
            {
                select_tool_click(e);
            }
        }
        void Events_MouseButtonUp(object sender, SdlDotNet.Input.MouseButtonEventArgs e)
        {
            frmEditor edit = (frmEditor)this.MdiParent;
            if (edit.current_tool == tooltype.line)
            {
                line_tool_click(e);
            }
            if (edit.current_tool == tooltype.select && selected)
            {
                ArrayList r = (ArrayList)wrld.collision_segment[this.row_index];
                r[this.point_index] = new Point(e.X + this.camera_x, e.Y + this.camera_y);
                this.Selected_Point = new Point(-10, -10);
                
            }
            selected = false;
            
        }
        private void select_tool_click(SdlDotNet.Input.MouseButtonEventArgs e)
        {
            for (int i=0; i < wrld.collision_segment.Count; i++)
            {
                ArrayList path = (ArrayList)wrld.collision_segment[i];
                Point previous = new Point(-1, -1);
                for (int j = 0; j < path.Count; j++)
                {
                    Point p = (Point)path[j];
                    if (previous.X != -1 && previous.Y != -1)
                    {
                        Point render2 = new Point(p.X + this.camera_x, p.Y + this.camera_y);
                        if (Math.Abs(render2.X - e.X) < 10 && Math.Abs(render2.Y - e.Y) < 10)
                        {
                            Selected_Point = p;
                            point_index = j;
                            row_index = i;
                            selected = true;
                        }
                        //surface.DrawDrawLine(new Pen(Color.White), previous, p);
                        //picWorld.Refresh();
                    }
                    previous = p;
                }
            }
        }
        private void line_tool_click(SdlDotNet.Input.MouseButtonEventArgs e)
        {
            if (px == 0 || py == 0)
            {
                px = e.X;
                py = e.Y;
                this.world_index = wrld.collision_segment.Add(new ArrayList());
                ((ArrayList)wrld.collision_segment[this.world_index]).Add(new Point(px - this.camera_x, py - this.camera_y));
                
            }
            else
            {
                //Graphics g = Graphics.FromImage(picWorld.Image);
                //g.DrawLine(new Pen(Color.White), px, py, e.X, e.Y);
                //Console.WriteLine("draw line");
                px = e.X;
                py = e.Y;
                ((ArrayList)wrld.collision_segment[this.world_index]).Add(new Point(px - this.camera_x, py - this.camera_y));
                //picWorld.Refresh();
            }
        }

        private void frmWorld_Load(object sender, EventArgs e)
        {

        }

        private void picWorld_Click(object sender, EventArgs e)
        {

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (hScrollBar1.Value > (this.hScrollBar1.Maximum - 10))
                this.hScrollBar1.Maximum += 10;

            if (e.OldValue > e.NewValue)
            {
                camera_x += 10 * Math.Abs(e.NewValue - e.OldValue);
            }
            else
            {
                camera_x -= 10 * Math.Abs(e.NewValue - e.OldValue); 
            }
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (vScrollBar1.Value > (this.vScrollBar1.Maximum - 10))
                this.vScrollBar1.Maximum += 10;

            if (e.OldValue > e.NewValue)
            {
                camera_y += 10 * Math.Abs(e.NewValue - e.OldValue);
            }
            else
            {
                camera_y -= 10 * Math.Abs(e.NewValue - e.OldValue);
            }
        }
        
    }
}
