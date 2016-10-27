namespace WiFiExample
{
    partial class Form3
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
            this.HWNetworkDisplay = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // HWNetworkDisplay
            // 
            this.HWNetworkDisplay.Location = new System.Drawing.Point(39, 12);
            this.HWNetworkDisplay.Multiline = true;
            this.HWNetworkDisplay.Name = "HWNetworkDisplay";
            this.HWNetworkDisplay.Size = new System.Drawing.Size(615, 693);
            this.HWNetworkDisplay.TabIndex = 0;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 734);
            this.Controls.Add(this.HWNetworkDisplay);
            this.Name = "Form3";
            this.Text = "HW Network Info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox HWNetworkDisplay;//declare public to let form1 to access this object
    }
}