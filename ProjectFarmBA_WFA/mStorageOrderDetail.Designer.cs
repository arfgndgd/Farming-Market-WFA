
namespace ProjectFarmBA_WFA
{
    partial class mStorageOrderDetail
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
            this.dGVStorageOrder = new System.Windows.Forms.DataGridView();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblShipper = new System.Windows.Forms.Label();
            this.lblStorage = new System.Windows.Forms.Label();
            this.cmbStorage = new System.Windows.Forms.ComboBox();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dGVStorageOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // dGVStorageOrder
            // 
            this.dGVStorageOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVStorageOrder.Location = new System.Drawing.Point(13, 241);
            this.dGVStorageOrder.Name = "dGVStorageOrder";
            this.dGVStorageOrder.RowHeadersWidth = 51;
            this.dGVStorageOrder.RowTemplate.Height = 24;
            this.dGVStorageOrder.Size = new System.Drawing.Size(1159, 366);
            this.dGVStorageOrder.TabIndex = 0;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(17, 118);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(46, 17);
            this.lblQuantity.TabIndex = 1;
            this.lblQuantity.Text = "Miktar";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(18, 171);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(45, 17);
            this.lblAddress.TabIndex = 1;
            this.lblAddress.Text = "Adres";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(89, 118);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(144, 22);
            this.txtQuantity.TabIndex = 2;
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Location = new System.Drawing.Point(429, 7);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(180, 29);
            this.btnAddCustomer.TabIndex = 3;
            this.btnAddCustomer.Text = "Yeni Müşteri Ekle";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(429, 42);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(180, 24);
            this.comboBox1.TabIndex = 4;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(429, 91);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(180, 24);
            this.comboBox2.TabIndex = 4;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(300, 48);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(54, 17);
            this.lblCustomer.TabIndex = 5;
            this.lblCustomer.Text = "Müşteri";
            // 
            // lblShipper
            // 
            this.lblShipper.AutoSize = true;
            this.lblShipper.Location = new System.Drawing.Point(300, 96);
            this.lblShipper.Name = "lblShipper";
            this.lblShipper.Size = new System.Drawing.Size(95, 17);
            this.lblShipper.TabIndex = 5;
            this.lblShipper.Text = "Kargo Firması";
            // 
            // lblStorage
            // 
            this.lblStorage.AutoSize = true;
            this.lblStorage.Location = new System.Drawing.Point(18, 74);
            this.lblStorage.Name = "lblStorage";
            this.lblStorage.Size = new System.Drawing.Size(39, 17);
            this.lblStorage.TabIndex = 19;
            this.lblStorage.Text = "Ürün";
            // 
            // cmbStorage
            // 
            this.cmbStorage.FormattingEnabled = true;
            this.cmbStorage.Location = new System.Drawing.Point(89, 69);
            this.cmbStorage.Name = "cmbStorage";
            this.cmbStorage.Size = new System.Drawing.Size(144, 24);
            this.cmbStorage.TabIndex = 18;
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTotalPrice.Location = new System.Drawing.Point(86, 171);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(0, 18);
            this.lblTotalPrice.TabIndex = 1;
            // 
            // mStorageOrderDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 619);
            this.Controls.Add(this.lblStorage);
            this.Controls.Add(this.cmbStorage);
            this.Controls.Add(this.lblShipper);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnAddCustomer);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.dGVStorageOrder);
            this.Name = "mStorageOrderDetail";
            this.Text = "mStorageOrderDetail";
            ((System.ComponentModel.ISupportInitialize)(this.dGVStorageOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dGVStorageOrder;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblShipper;
        private System.Windows.Forms.Label lblStorage;
        private System.Windows.Forms.ComboBox cmbStorage;
        private System.Windows.Forms.Label lblTotalPrice;
    }
}