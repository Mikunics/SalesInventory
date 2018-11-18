namespace Sales_Inventory
{
    partial class AdminHome
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
            this.buttonAddLogin = new System.Windows.Forms.Button();
            this.buttonEditLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAddLogin
            // 
            this.buttonAddLogin.Location = new System.Drawing.Point(12, 12);
            this.buttonAddLogin.Name = "buttonAddLogin";
            this.buttonAddLogin.Size = new System.Drawing.Size(192, 36);
            this.buttonAddLogin.TabIndex = 0;
            this.buttonAddLogin.Text = "Add New Login";
            this.buttonAddLogin.UseVisualStyleBackColor = true;
            this.buttonAddLogin.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonEditLogin
            // 
            this.buttonEditLogin.Location = new System.Drawing.Point(12, 54);
            this.buttonEditLogin.Name = "buttonEditLogin";
            this.buttonEditLogin.Size = new System.Drawing.Size(192, 36);
            this.buttonEditLogin.TabIndex = 1;
            this.buttonEditLogin.Text = "Edit Existing Login";
            this.buttonEditLogin.UseVisualStyleBackColor = true;
            this.buttonEditLogin.Click += new System.EventHandler(this.buttonEditLogin_Click);
            // 
            // AdminHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(216, 104);
            this.Controls.Add(this.buttonEditLogin);
            this.Controls.Add(this.buttonAddLogin);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AdminHome";
            this.Text = "Admin Home";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminHome_FormClosed);
            this.Load += new System.EventHandler(this.AdminHome_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAddLogin;
        private System.Windows.Forms.Button buttonEditLogin;
    }
}