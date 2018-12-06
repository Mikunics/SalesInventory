namespace Sales_Inventory
{
    partial class CashierHomePage
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonEndTransaction = new System.Windows.Forms.Button();
            this.buttonCancelTransaction = new System.Windows.Forms.Button();
            this.buttonResetTransaction = new System.Windows.Forms.Button();
            this.buttonSalesInventory = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonAdmin = new System.Windows.Forms.Button();
            this.comboBoxItemName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 10);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(573, 296);
            this.dataGridView1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(590, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Cashier:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(590, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Time:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(589, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Date:";
            // 
            // buttonEndTransaction
            // 
            this.buttonEndTransaction.Location = new System.Drawing.Point(12, 370);
            this.buttonEndTransaction.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonEndTransaction.Name = "buttonEndTransaction";
            this.buttonEndTransaction.Size = new System.Drawing.Size(187, 84);
            this.buttonEndTransaction.TabIndex = 4;
            this.buttonEndTransaction.Text = "End Current Transcation";
            this.buttonEndTransaction.UseVisualStyleBackColor = true;
            this.buttonEndTransaction.Click += new System.EventHandler(this.buttonEndTransaction_Click);
            // 
            // buttonCancelTransaction
            // 
            this.buttonCancelTransaction.Location = new System.Drawing.Point(204, 370);
            this.buttonCancelTransaction.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCancelTransaction.Name = "buttonCancelTransaction";
            this.buttonCancelTransaction.Size = new System.Drawing.Size(187, 84);
            this.buttonCancelTransaction.TabIndex = 5;
            this.buttonCancelTransaction.Text = "Cancel Previous Transaction";
            this.buttonCancelTransaction.UseVisualStyleBackColor = true;
            this.buttonCancelTransaction.Click += new System.EventHandler(this.buttonCancelTransaction_Click);
            // 
            // buttonResetTransaction
            // 
            this.buttonResetTransaction.Location = new System.Drawing.Point(397, 370);
            this.buttonResetTransaction.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonResetTransaction.Name = "buttonResetTransaction";
            this.buttonResetTransaction.Size = new System.Drawing.Size(187, 84);
            this.buttonResetTransaction.TabIndex = 6;
            this.buttonResetTransaction.Text = "Reset Current Transaction";
            this.buttonResetTransaction.UseVisualStyleBackColor = true;
            this.buttonResetTransaction.Click += new System.EventHandler(this.buttonResetTransaction_Click);
            // 
            // buttonSalesInventory
            // 
            this.buttonSalesInventory.Location = new System.Drawing.Point(594, 215);
            this.buttonSalesInventory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSalesInventory.Name = "buttonSalesInventory";
            this.buttonSalesInventory.Size = new System.Drawing.Size(145, 50);
            this.buttonSalesInventory.TabIndex = 7;
            this.buttonSalesInventory.Text = "Access Sales Inventory";
            this.buttonSalesInventory.UseVisualStyleBackColor = true;
            this.buttonSalesInventory.Click += new System.EventHandler(this.buttonSalesInventory_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(594, 393);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(145, 38);
            this.buttonLogout.TabIndex = 8;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // buttonAdmin
            // 
            this.buttonAdmin.Location = new System.Drawing.Point(594, 289);
            this.buttonAdmin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAdmin.Name = "buttonAdmin";
            this.buttonAdmin.Size = new System.Drawing.Size(145, 49);
            this.buttonAdmin.TabIndex = 9;
            this.buttonAdmin.Text = "Access Admin Controls";
            this.buttonAdmin.UseVisualStyleBackColor = true;
            this.buttonAdmin.Click += new System.EventHandler(this.buttonAdmin_Click);
            // 
            // comboBoxItemName
            // 
            this.comboBoxItemName.FormattingEnabled = true;
            this.comboBoxItemName.Location = new System.Drawing.Point(98, 311);
            this.comboBoxItemName.Name = "comboBoxItemName";
            this.comboBoxItemName.Size = new System.Drawing.Size(293, 24);
            this.comboBoxItemName.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 314);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Item Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 344);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Quantity:";
            // 
            // numericUpDownQuantity
            // 
            this.numericUpDownQuantity.Location = new System.Drawing.Point(98, 341);
            this.numericUpDownQuantity.Name = "numericUpDownQuantity";
            this.numericUpDownQuantity.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownQuantity.TabIndex = 14;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(224, 340);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(167, 25);
            this.buttonAdd.TabIndex = 15;
            this.buttonAdd.Text = "Add Item";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(592, 31);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(46, 17);
            this.labelName.TabIndex = 16;
            this.labelName.Text = "label6";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(592, 88);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(46, 17);
            this.labelDate.TabIndex = 17;
            this.labelDate.Text = "label7";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(592, 147);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(46, 17);
            this.labelTime.TabIndex = 18;
            this.labelTime.Text = "label8";
            // 
            // CashierHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 463);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.numericUpDownQuantity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxItemName);
            this.Controls.Add(this.buttonAdmin);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.buttonSalesInventory);
            this.Controls.Add(this.buttonResetTransaction);
            this.Controls.Add(this.buttonCancelTransaction);
            this.Controls.Add(this.buttonEndTransaction);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CashierHomePage";
            this.Text = "Cashier Home";
            this.Load += new System.EventHandler(this.CashierHomePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonEndTransaction;
        private System.Windows.Forms.Button buttonCancelTransaction;
        private System.Windows.Forms.Button buttonResetTransaction;
        private System.Windows.Forms.Button buttonSalesInventory;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonAdmin;
        private System.Windows.Forms.ComboBox comboBoxItemName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelTime;
    }
}