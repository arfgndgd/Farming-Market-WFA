
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
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblShippedCountry = new System.Windows.Forms.Label();
            this.dGVStorageOrder = new System.Windows.Forms.DataGridView();
            this.grbCustomer = new System.Windows.Forms.GroupBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grbStorage = new System.Windows.Forms.GroupBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtStorageName = new System.Windows.Forms.TextBox();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalWeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSale = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.btnAddStorage = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dGVStorageOrder)).BeginInit();
            this.grbCustomer.SuspendLayout();
            this.grbStorage.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Location = new System.Drawing.Point(36, 29);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(180, 59);
            this.btnAddCustomer.TabIndex = 13;
            this.btnAddCustomer.Text = "Yeni Müşteri Ekle";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(104, 88);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(144, 22);
            this.txtLastName.TabIndex = 11;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(104, 60);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(144, 22);
            this.txtFirstName.TabIndex = 12;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(12, 37);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(56, 17);
            this.lblAddress.TabIndex = 7;
            this.lblAddress.Text = "Telefon";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(21, 91);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(48, 17);
            this.lblCity.TabIndex = 8;
            this.lblCity.Text = "Soyad";
            // 
            // lblShippedCountry
            // 
            this.lblShippedCountry.AutoSize = true;
            this.lblShippedCountry.Location = new System.Drawing.Point(21, 65);
            this.lblShippedCountry.Name = "lblShippedCountry";
            this.lblShippedCountry.Size = new System.Drawing.Size(25, 17);
            this.lblShippedCountry.TabIndex = 9;
            this.lblShippedCountry.Text = "Ad";
            // 
            // dGVStorageOrder
            // 
            this.dGVStorageOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVStorageOrder.Location = new System.Drawing.Point(324, 140);
            this.dGVStorageOrder.Name = "dGVStorageOrder";
            this.dGVStorageOrder.RowHeadersWidth = 51;
            this.dGVStorageOrder.RowTemplate.Height = 24;
            this.dGVStorageOrder.Size = new System.Drawing.Size(839, 354);
            this.dGVStorageOrder.TabIndex = 6;
            // 
            // grbCustomer
            // 
            this.grbCustomer.Controls.Add(this.txtFirstName);
            this.grbCustomer.Controls.Add(this.txtEmail);
            this.grbCustomer.Controls.Add(this.txtPhone);
            this.grbCustomer.Controls.Add(this.txtLastName);
            this.grbCustomer.Controls.Add(this.lblShippedCountry);
            this.grbCustomer.Controls.Add(this.label1);
            this.grbCustomer.Controls.Add(this.lblCity);
            this.grbCustomer.Controls.Add(this.lblAddress);
            this.grbCustomer.Location = new System.Drawing.Point(12, 94);
            this.grbCustomer.Name = "grbCustomer";
            this.grbCustomer.Size = new System.Drawing.Size(264, 158);
            this.grbCustomer.TabIndex = 18;
            this.grbCustomer.TabStop = false;
            this.grbCustomer.Text = "Müşteri İşlemleri";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(104, 116);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(144, 22);
            this.txtEmail.TabIndex = 11;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(104, 32);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(144, 22);
            this.txtPhone.TabIndex = 11;
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Email";
            // 
            // grbStorage
            // 
            this.grbStorage.Controls.Add(this.txtID);
            this.grbStorage.Controls.Add(this.txtStorageName);
            this.grbStorage.Controls.Add(this.txtAddress);
            this.grbStorage.Controls.Add(this.label10);
            this.grbStorage.Controls.Add(this.txtTotalPrice);
            this.grbStorage.Controls.Add(this.txtCountry);
            this.grbStorage.Controls.Add(this.label2);
            this.grbStorage.Controls.Add(this.label9);
            this.grbStorage.Controls.Add(this.txtTotalWeight);
            this.grbStorage.Controls.Add(this.txtCity);
            this.grbStorage.Controls.Add(this.label3);
            this.grbStorage.Controls.Add(this.txtUnitPrice);
            this.grbStorage.Controls.Add(this.label8);
            this.grbStorage.Controls.Add(this.label7);
            this.grbStorage.Controls.Add(this.label4);
            this.grbStorage.Controls.Add(this.label5);
            this.grbStorage.Location = new System.Drawing.Point(12, 274);
            this.grbStorage.Name = "grbStorage";
            this.grbStorage.Size = new System.Drawing.Size(264, 365);
            this.grbStorage.TabIndex = 18;
            this.grbStorage.TabStop = false;
            this.grbStorage.Text = "Ürün İşlemleri";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(104, 21);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(144, 22);
            this.txtID.TabIndex = 12;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            // 
            // txtStorageName
            // 
            this.txtStorageName.Location = new System.Drawing.Point(104, 49);
            this.txtStorageName.Name = "txtStorageName";
            this.txtStorageName.Size = new System.Drawing.Size(144, 22);
            this.txtStorageName.TabIndex = 12;
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Location = new System.Drawing.Point(104, 133);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Size = new System.Drawing.Size(144, 22);
            this.txtTotalPrice.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Miktar";
            // 
            // txtTotalWeight
            // 
            this.txtTotalWeight.Location = new System.Drawing.Point(104, 105);
            this.txtTotalWeight.Name = "txtTotalWeight";
            this.txtTotalWeight.Size = new System.Drawing.Size(144, 22);
            this.txtTotalWeight.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Birim Fiyat";
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(104, 77);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(144, 22);
            this.txtUnitPrice.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "Ürün ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Toplam Fiyat";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Ürün Adı";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(324, 500);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(98, 46);
            this.btnAdd.TabIndex = 19;
            this.btnAdd.Text = "Ekle";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSale
            // 
            this.btnSale.Location = new System.Drawing.Point(458, 500);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(98, 46);
            this.btnSale.TabIndex = 19;
            this.btnSale.Text = "Satış Yap";
            this.btnSale.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(588, 500);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(98, 46);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1066, 500);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 46);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "İptal";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(737, 579);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 18);
            this.label6.TabIndex = 17;
            this.label6.Text = "Genel Toplam";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTotalPrice.Location = new System.Drawing.Point(885, 579);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(115, 48);
            this.lblTotalPrice.TabIndex = 17;
            // 
            // btnAddStorage
            // 
            this.btnAddStorage.Location = new System.Drawing.Point(485, 29);
            this.btnAddStorage.Name = "btnAddStorage";
            this.btnAddStorage.Size = new System.Drawing.Size(180, 59);
            this.btnAddStorage.TabIndex = 13;
            this.btnAddStorage.Text = "Yeni Ambar Ürünü Ekle";
            this.btnAddStorage.UseVisualStyleBackColor = true;
            this.btnAddStorage.Click += new System.EventHandler(this.btnAddStorage_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 220);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "Adres";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(104, 159);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(144, 22);
            this.txtCity.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 162);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 17);
            this.label9.TabIndex = 8;
            this.label9.Text = "Şehir";
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(104, 187);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(144, 22);
            this.txtCountry.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 192);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 17);
            this.label10.TabIndex = 7;
            this.label10.Text = "Ülke";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(14, 239);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(234, 120);
            this.txtAddress.TabIndex = 11;
            // 
            // mStorageOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1196, 651);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSale);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.grbStorage);
            this.Controls.Add(this.grbCustomer);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnAddStorage);
            this.Controls.Add(this.btnAddCustomer);
            this.Controls.Add(this.dGVStorageOrder);
            this.Name = "mStorageOrder";
            this.Text = "mStorageOrder";
            this.Load += new System.EventHandler(this.mStorageOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGVStorageOrder)).EndInit();
            this.grbCustomer.ResumeLayout(false);
            this.grbCustomer.PerformLayout();
            this.grbStorage.ResumeLayout(false);
            this.grbStorage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblShippedCountry;
        private System.Windows.Forms.DataGridView dGVStorageOrder;
        private System.Windows.Forms.GroupBox grbCustomer;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.GroupBox grbStorage;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStorageName;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalWeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSale;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAddStorage;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label8;
    }
}