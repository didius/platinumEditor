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
    public partial class NewWorld : Form
    {
        public int height
        {
            get { return Convert.ToInt32(txtHeight.Text); }
        }
        public int width
        {
            get { return Convert.ToInt32(txtWidth.Text); }
        }
        public NewWorld()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
