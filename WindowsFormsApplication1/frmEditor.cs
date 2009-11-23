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
    public enum tooltype
    {
        line = 1,
        select,
        sprite
    }
    public partial class frmEditor : Form
    {
        public tooltype current_tool;
        public frmEditor()
        {
            InitializeComponent();
            frmTools tools = new frmTools(this);
            tools.Show();
            
        }
        private void new_world()
        {
            frmWorld wrl = new frmWorld();
            wrl.wrld.height = 100;
            wrl.wrld.width = 100;
            wrl.MdiParent = this;
            wrl.Show();

        }
        private void open_world()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Lua World File|*.lua";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                frmWorld editor = new frmWorld();
                editor.wrld.load(ofd.FileName);
                editor.MdiParent = this;
                //editor..Width = editor.wrld.width;
                //editor.pipicWorldcWorld.Height = editor.wrld.height;
                editor.Show();
                editor.renderworld();
            }
        }
        private void save_world()
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
        private void save_as_world()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Lua World File|*.lua";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                frmWorld editor = (frmWorld)this.MdiChildren[0];
                editor.wrld.save(sfd.FileName);
            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new_world();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save_world();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save_as_world();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            open_world();
        }

        private void toolbar_new_Click(object sender, EventArgs e)
        {
            new_world();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            save_world();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            save_as_world();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            open_world();
        }
    }
}
