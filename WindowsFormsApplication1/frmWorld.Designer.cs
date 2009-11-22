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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWorld));
            this.surfaceControl1 = new SdlDotNet.Windows.SurfaceControl();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.surfaceControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // surfaceControl1
            // 
            this.surfaceControl1.AccessibleDescription = "SdlDotNet SurfaceControl";
            this.surfaceControl1.AccessibleName = "SurfaceControl";
            this.surfaceControl1.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.surfaceControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.surfaceControl1.Image = ((System.Drawing.Image)(resources.GetObject("surfaceControl1.Image")));
            this.surfaceControl1.InitialImage = ((System.Drawing.Image)(resources.GetObject("surfaceControl1.InitialImage")));
            this.surfaceControl1.Location = new System.Drawing.Point(0, 0);
            this.surfaceControl1.Name = "surfaceControl1";
            this.surfaceControl1.Size = new System.Drawing.Size(538, 313);
            this.surfaceControl1.TabIndex = 0;
            this.surfaceControl1.TabStop = false;
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrollBar1.Location = new System.Drawing.Point(0, 313);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(555, 17);
            this.hScrollBar1.TabIndex = 1;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar1.Location = new System.Drawing.Point(538, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 313);
            this.vScrollBar1.TabIndex = 2;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // frmWorld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(555, 330);
            this.Controls.Add(this.surfaceControl1);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.hScrollBar1);
            this.Name = "frmWorld";
            this.Text = "frmWorld";
            this.Load += new System.EventHandler(this.frmWorld_Load);
            ((System.ComponentModel.ISupportInitialize)(this.surfaceControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SdlDotNet.Windows.SurfaceControl surfaceControl1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.VScrollBar vScrollBar1;


    }
}