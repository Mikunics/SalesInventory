namespace Sales_Inventory
{
    partial class InventoryHome
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
            this.buttonSalesReport = new System.Windows.Forms.Button();
            this.buttonSalesHistory = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonAddItem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSalesReport
            // 
            this.buttonSalesReport.Location = new System.Drawing.Point(16, 15);
            this.buttonSalesReport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSalesReport.Name = "buttonSalesReport";
            this.buttonSalesReport.Size = new System.Drawing.Size(284, 44);
            this.buttonSalesReport.TabIndex = 0;
            this.buttonSalesReport.Text = "Generate Sales Report";
            this.buttonSalesReport.UseVisualStyleBackColor = true;
            this.buttonSalesReport.Click += new System.EventHandler(this.buttonSalesReport_Click);
            // 
            // buttonSalesHistory
            // 
            this.buttonSalesHistory.Location = new System.Drawing.Point(16, 66);
            this.buttonSalesHistory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSalesHistory.Name = "buttonSalesHistory";
            this.buttonSalesHistory.Size = new System.Drawing.Size(284, 44);
            this.buttonSalesHistory.TabIndex = 1;
            this.buttonSalesHistory.Text = "View Sales History";
            this.buttonSalesHistory.UseVisualStyleBackColor = true;
            this.buttonSalesHistory.Click += new System.EventHandler(this.buttonSalesHistory_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(16, 170);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(284, 44);
            this.buttonEdit.TabIndex = 2;
            this.buttonEdit.Text = "Edit / Delete Existing Item";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonAddItem
            // 
            this.buttonAddItem.Location = new System.Drawing.Point(16, 118);
            this.buttonAddItem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonAddItem.Name = "buttonAddItem";
            this.buttonAddItem.Size = new System.Drawing.Size(284, 44);
            this.buttonAddItem.TabIndex = 4;
            this.buttonAddItem.Text = "Add New Item";
            this.buttonAddItem.UseVisualStyleBackColor = true;
            this.buttonAddItem.Click += new System.EventHandler(this.buttonAddItem_Click);
            // 
            // InventoryHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 231);
            this.Controls.Add(this.buttonAddItem);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonSalesHistory);
            this.Controls.Add(this.buttonSalesReport);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "InventoryHome";
            this.Text = "Inventory Home";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InventoryHome_FormClosed);
            this.Load += new System.EventHandler(this.InventoryHome_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSalesReport;
        private System.Windows.Forms.Button buttonSalesHistory;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonAddItem;
    }
}