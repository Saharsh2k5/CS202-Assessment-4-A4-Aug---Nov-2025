namespace OrderPipeline
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
            txtCustomerName = new TextBox();
            cmbProduct = new ComboBox();
            numQuantity = new NumericUpDown();
            btnProcessOrder = new Button();
            lblStatus = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            chkExpress = new CheckBox();
            btnShipOrder = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new Point(150, 35);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(250, 27);
            txtCustomerName.TabIndex = 0;
            // 
            // cmbProduct
            // 
            cmbProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProduct.FormattingEnabled = true;
            cmbProduct.Location = new Point(150, 85);
            cmbProduct.Name = "cmbProduct";
            cmbProduct.Size = new Size(250, 28);
            cmbProduct.TabIndex = 1;
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(150, 135);
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(250, 27);
            numQuantity.TabIndex = 2;
            // 
            // btnProcessOrder
            // 
            btnProcessOrder.BackColor = SystemColors.Highlight;
            btnProcessOrder.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnProcessOrder.ForeColor = Color.White;
            btnProcessOrder.Location = new Point(20, 30);
            btnProcessOrder.Name = "btnProcessOrder";
            btnProcessOrder.Size = new Size(380, 40);
            btnProcessOrder.TabIndex = 3;
            btnProcessOrder.Text = "Process Order";
            btnProcessOrder.UseVisualStyleBackColor = false;
            btnProcessOrder.Click += btnProcessOrder_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStatus.Location = new Point(150, 420);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(59, 23);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Ready";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 38);
            label1.Name = "label1";
            label1.Size = new Size(119, 20);
            label1.TabIndex = 5;
            label1.Text = "Customer Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 88);
            label2.Name = "label2";
            label2.Size = new Size(64, 20);
            label2.TabIndex = 6;
            label2.Text = "Product:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 138);
            label3.Name = "label3";
            label3.Size = new Size(68, 20);
            label3.TabIndex = 7;
            label3.Text = "Quantity:";
            // 
            // label4
            //
            label4.AutoSize = true;
            label4.Location = new Point(20, 423);
            label4.Name = "label4";
            label4.Size = new Size(52, 20);
            label4.TabIndex = 8;
            label4.Text = "Status:";
            // 
            // chkExpress
            // 
            chkExpress.AutoSize = true;
            chkExpress.Font = new Font("Segoe UI", 9F);
            chkExpress.Location = new Point(20, 35);
            chkExpress.Name = "chkExpress";
            chkExpress.Size = new Size(194, 24);
            chkExpress.TabIndex = 9;
            chkExpress.Text = "Enable Express Shipping";
            chkExpress.UseVisualStyleBackColor = true;
            chkExpress.CheckedChanged += chkExpress_CheckedChanged;
            // 
            // btnShipOrder
            // 
            btnShipOrder.BackColor = Color.DarkGreen;
            btnShipOrder.Enabled = false;
            btnShipOrder.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnShipOrder.ForeColor = Color.White;
            btnShipOrder.Location = new Point(20, 75);
            btnShipOrder.Name = "btnShipOrder";
            btnShipOrder.Size = new Size(380, 40);
            btnShipOrder.TabIndex = 10;
            btnShipOrder.Text = "Ship Order";
            btnShipOrder.UseVisualStyleBackColor = false;
            btnShipOrder.Click += btnShipOrder_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnProcessOrder);
            groupBox1.Location = new Point(20, 180);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(420, 90);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Step 1: Order Processing";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(chkExpress);
            groupBox2.Controls.Add(btnShipOrder);
            groupBox2.Location = new Point(20, 285);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(420, 130);
            groupBox2.TabIndex = 12;
            groupBox2.TabStop = false;
            groupBox2.Text = "Step 2: Shipping (Task 2)";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(460, 470);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblStatus);
            Controls.Add(numQuantity);
            Controls.Add(cmbProduct);
            Controls.Add(txtCustomerName);
            Name = "Form1";
            Text = "Order Pipeline - Task 2: Event Filtering";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCustomerName;
        private ComboBox cmbProduct;
        private NumericUpDown numQuantity;
        private Button btnProcessOrder;
        private Label lblStatus;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private CheckBox chkExpress;
        private Button btnShipOrder;
        private GroupBox groupBox1;
        private GroupBox groupBox2;

    }
}
