namespace BinaryDataDecoders.WinForms.Samples
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            validTextBox1 = new Windows.Forms.ValidTextBox();
            SuspendLayout();
            // 
            // validTextBox1
            // 
            validTextBox1.BackColor = System.Drawing.Color.LightGreen;
            validTextBox1.Filter = "^Hello$";
            validTextBox1.InvalidColor = System.Drawing.Color.LightPink;
            validTextBox1.Location = new System.Drawing.Point(172, 122);
            validTextBox1.Name = "validTextBox1";
            validTextBox1.Size = new System.Drawing.Size(100, 23);
            validTextBox1.TabIndex = 0;
            validTextBox1.ValidColor = System.Drawing.Color.LightGreen;
            validTextBox1.TextChanged += validTextBox1_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(validTextBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Windows.Forms.ValidTextBox validTextBox1;
    }
}