namespace WiFiExample
{
    partial class Form2
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
            this.tBWlanCap = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tBWlanCap
            // 
            this.tBWlanCap.Location = new System.Drawing.Point(27, 30);
            this.tBWlanCap.Margin = new System.Windows.Forms.Padding(4);
            this.tBWlanCap.MaxLength = 30;
            this.tBWlanCap.Multiline = true;
            this.tBWlanCap.Name = "tBWlanCap";
            this.tBWlanCap.Size = new System.Drawing.Size(718, 791);
            this.tBWlanCap.TabIndex = 0;
            this.tBWlanCap.TextChanged += new System.EventHandler(this.tBWlanCap_TextChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 851);
            this.Controls.Add(this.tBWlanCap);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Form2";
            this.Text = "WirelessCapabilities";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox tBWlanCap;
    }
}