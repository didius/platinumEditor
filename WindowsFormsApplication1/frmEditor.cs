using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmEditor : Form
    {
        public frmEditor()
        {
            InitializeComponent();
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWorld wrl = new frmWorld();
            NewWorld nw = new NewWorld();
            if (nw.ShowDialog() == DialogResult.OK)
            {
                wrl.picWorld.Image = new Bitmap(nw.height, nw.width);
                wrl.picWorld.Width = nw.width;
                wrl.picWorld.Height = nw.height;
                wrl.wrld.height = nw.height;
                wrl.wrld.width = nw.width;
                wrl.MdiParent = this;
                wrl.Show();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWorld editor = (frmWorld)this.MdiChildren[0];
            if (editor.wrld.fname == "")
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Lua World File|*.lua";
                if (sfd.ShowDialog() == DialogResult.OK)
                {

                    editor.wrld.save(sfd.FileName);
                }
            }
            else
            {
                editor.wrld.save(editor.wrld.fname);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Lua World File|*.lua";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                frmWorld editor = (frmWorld)this.MdiChildren[0];
                editor.wrld.save(sfd.FileName);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Lua World File|*.lua";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                frmWorld editor = new frmWorld();
                editor.wrld.load(ofd.FileName);
                editor.MdiParent = this;
                editor.picWorld.Width = editor.wrld.width;
                editor.picWorld.Height = editor.wrld.height;
                editor.Show();
                editor.renderworld();
            }
        }
    }
}
