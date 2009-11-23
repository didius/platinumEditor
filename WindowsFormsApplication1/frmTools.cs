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
    public partial class frmTools : Form
    {
        private frmEditor master;
        public frmTools(frmEditor master)
        {
            this.master = master;
            InitializeComponent();
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            this.master.lblTool.Text = "Line Drawer";
            this.master.current_tool = tooltype.line;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.master.lblTool.Text = "Line Selector";
            this.master.current_tool = tooltype.select;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.master.lblTool.Text = "Sprite";
            this.master.current_tool = tooltype.sprite;
        }
    }
}
