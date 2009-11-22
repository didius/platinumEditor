namespace WindowsFormsApplication1
{
    partial class frmWorld
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picWorld = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picWorld)).BeginInit();
            this.SuspendLayout();
            // 
            // picWorld
            // 
            this.picWorld.BackColor = System.Drawing.Color.Black;
            this.picWorld.Location = new System.Drawing.Point(2, 3);
            this.picWorld.Name = "picWorld";
            this.picWorld.Size = new System.Drawing.Size(448, 224);
            this.picWorld.TabIndex = 0;
            this.picWorld.TabStop = false;
            this.picWorld.Click += new System.EventHandler(this.picWorld_Click);
            // 
            // frmWorld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(555, 330);
            this.Controls.Add(this.picWorld);
            this.Name = "frmWorld";
            this.Text = "frmWorld";
            this.Load += new System.EventHandler(this.frmWorld_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picWorld)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox picWorld;

    }
}