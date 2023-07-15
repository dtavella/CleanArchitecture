namespace WinForm
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
            cmbCountry = new ComboBox();
            btnCheck = new Button();
            txtCheck = new TextBox();
            SuspendLayout();
            // 
            // cmbCountry
            // 
            cmbCountry.FormattingEnabled = true;
            cmbCountry.Location = new Point(124, 95);
            cmbCountry.Name = "cmbCountry";
            cmbCountry.Size = new Size(151, 28);
            cmbCountry.TabIndex = 0;
            cmbCountry.DropDown += cmbCountry_DropDown;
            // 
            // btnCheck
            // 
            btnCheck.Location = new Point(397, 95);
            btnCheck.Name = "btnCheck";
            btnCheck.Size = new Size(94, 29);
            btnCheck.TabIndex = 1;
            btnCheck.Text = "ClickMe";
            btnCheck.UseVisualStyleBackColor = true;
            btnCheck.Click += btnCheck_Click;
            // 
            // txtCheck
            // 
            txtCheck.Location = new Point(3, 230);
            txtCheck.Multiline = true;
            txtCheck.Name = "txtCheck";
            txtCheck.Size = new Size(794, 219);
            txtCheck.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtCheck);
            Controls.Add(btnCheck);
            Controls.Add(cmbCountry);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbCountry;
        private Button btnCheck;
        private TextBox txtCheck;
    }
}