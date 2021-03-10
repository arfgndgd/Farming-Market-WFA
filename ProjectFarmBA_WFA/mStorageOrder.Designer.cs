
namespace ProjectFarmBA_WFA
{
    partial class mStorageOrder
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
            this.lblShipper = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblShippedCountry = new System.Windows.Forms.Label();
            this.dGVStorageOrder = new System.Windows.Forms.DataGridView();
            this.btnStorageOrderDetail = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGVStorageOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // lblShipper
            // 
            this.lblShipper.AutoSize = true;
            this.lblShipper.Location = new System.Drawing.Point(299, 99);
            this.lblShipper.Name = "lblShipper";
            this.lblShipper.Size = new System.Drawing.Size(95, 17);
            this.lblShipper.TabIndex = 16;
            this.lblShipper.Text = "Kargo Firması";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(299, 51);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(54, 17);
            this.lblCustomer.TabIndex = 17;
            this.lblCustomer.Text = "Müşteri";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(428, 94);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(180, 24);
            this.comboBox2.TabIndex = 14;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(428, 45);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(180, 24);
            this.comboBox1.TabIndex = 15;
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Location = new System.Drawing.Point(428, 10);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(180, 29);
            this.btnAddCustomer.TabIndex = 13;
            this.btnAddCustomer.Text = "Yeni Müşteri Ekle";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(84, 140);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(524, 98);
            this.textBox3.TabIndex = 10;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(84, 94);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(144, 22);
            this.textBox2.TabIndex = 11;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(84, 48);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(144, 22);
            this.textBox1.TabIndex = 12;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(12, 140);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(45, 17);
            this.lblAddress.TabIndex = 7;
            this.lblAddress.Text = "Adres";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(12, 94);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(41, 17);
            this.lblCity.TabIndex = 8;
            this.lblCity.Text = "Şehir";
            // 
            // lblShippedCountry
            // 
            this.lblShippedCountry.AutoSize = true;
            this.lblShippedCountry.Location = new System.Drawing.Point(12, 48);
            this.lblShippedCountry.Name = "lblShippedCountry";
            this.lblShippedCountry.Size = new System.Drawing.Size(36, 17);
            this.lblShippedCountry.TabIndex = 9;
            this.lblShippedCountry.Text = "Ülke";
            // 
            // dGVStorageOrder
            // 
            this.dGVStorageOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVStorageOrder.Location = new System.Drawing.Point(15, 273);
            this.dGVStorageOrder.Name = "dGVStorageOrder";
            this.dGVStorageOrder.RowHeadersWidth = 51;
            this.dGVStorageOrder.RowTemplate.Height = 24;
            this.dGVStorageOrder.Size = new System.Drawing.Size(1159, 366);
            this.dGVStorageOrder.TabIndex = 6;
            // 
            // btnStorageOrderDetail
            // 
            this.btnStorageOrderDetail.Location = new System.Drawing.Point(645, 93);
            this.btnStorageOrderDetail.Name = "btnStorageOrderDetail";
            this.btnStorageOrderDetail.Size = new System.Drawing.Size(180, 145);
            this.btnStorageOrderDetail.TabIndex = 13;
            this.btnStorageOrderDetail.Text = "Sipariş Detayına Devam Et";
            this.btnStorageOrderDetail.UseVisualStyleBackColor = true;
            // 
            // mStorageOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 651);
            this.Controls.Add(this.lblShipper);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnStorageOrderDetail);
            this.Controls.Add(this.btnAddCustomer);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.lblShippedCountry);
            this.Controls.Add(this.dGVStorageOrder);
            this.Name = "mStorageOrder";
            this.Text = "mStorageOrder";
            ((System.ComponentModel.ISupportInitialize)(this.dGVStorageOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblShipper;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblShippedCountry;
        private System.Windows.Forms.DataGridView dGVStorageOrder;
        private System.Windows.Forms.Button btnStorageOrderDetail;
    }
}