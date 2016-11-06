namespace Singularity
{
    partial class Dialog
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
            this.text = new System.Windows.Forms.Label();
            this.YES = new System.Windows.Forms.Button();
            this.NO = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // text
            // 
            this.text.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text.Location = new System.Drawing.Point(13, 77);
            this.text.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.text.Name = "text";
            this.text.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.text.Size = new System.Drawing.Size(306, 86);
            this.text.TabIndex = 0;
            this.text.Text = "Hello?";
            this.text.Click += new System.EventHandler(this.text_Click);
            // 
            // YES
            // 
            this.YES.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YES.Location = new System.Drawing.Point(54, 195);
            this.YES.Margin = new System.Windows.Forms.Padding(45, 3, 3, 3);
            this.YES.Name = "YES";
            this.YES.Size = new System.Drawing.Size(86, 51);
            this.YES.TabIndex = 1;
            this.YES.Text = "YES";
            this.YES.UseVisualStyleBackColor = true;
            this.YES.Click += new System.EventHandler(this.YES_Click);
            // 
            // NO
            // 
            this.NO.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.NO.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NO.Location = new System.Drawing.Point(192, 195);
            this.NO.Margin = new System.Windows.Forms.Padding(3, 3, 45, 3);
            this.NO.Name = "NO";
            this.NO.Padding = new System.Windows.Forms.Padding(5);
            this.NO.Size = new System.Drawing.Size(86, 51);
            this.NO.TabIndex = 2;
            this.NO.Text = "NO";
            this.NO.UseVisualStyleBackColor = true;
            this.NO.Click += new System.EventHandler(this.NO_Click);
            // 
            // Dialog
            // 
            this.AcceptButton = this.YES;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.NO;
            this.ClientSize = new System.Drawing.Size(332, 302);
            this.Controls.Add(this.NO);
            this.Controls.Add(this.YES);
            this.Controls.Add(this.text);
            this.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Dialog";
            this.Text = "Confirmation";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label text;
        private System.Windows.Forms.Button YES;
        private System.Windows.Forms.Button NO;
    }
}