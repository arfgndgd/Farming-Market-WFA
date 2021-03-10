
namespace ProjectFarmBA_WFA
{
    partial class mOrder
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
            this.dGVOrder = new System.Windows.Forms.DataGridView();
            this.label = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.pctEmployee = new System.Windows.Forms.PictureBox();
            this.btnShowDatas = new System.Windows.Forms.Button();
            this.dGVResult = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOrderDetailPage = new System.Windows.Forms.Button();
            this.lablID = new System.Windows.Forms.Label();
            this.lblAppUserID = new System.Windows.Forms.Label();
            this.lblShipperID = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblDeleted = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUpdated = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCreated = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblID = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtShipperID = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtAppUserID = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGVOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVResult)).BeginInit();
            this.SuspendLayout();
            // 
            // dGVOrder
            // 
            this.dGVOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVOrder.Location = new System.Drawing.Point(15, 481);
            this.dGVOrder.Name = "dGVOrder";
            this.dGVOrder.RowHeadersWidth = 51;
            this.dGVOrder.RowTemplate.Height = 24;
            this.dGVOrder.Size = new System.Drawing.Size(1773, 339);
            this.dGVOrder.TabIndex = 0;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label.Location = new System.Drawing.Point(13, 199);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(147, 18);
            this.label.TabIndex = 1;
            this.label.Text = "Mail ile Arama Yap";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSearch.Location = new System.Drawing.Point(190, 199);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(203, 24);
            this.txtSearch.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(14, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Arama Sonucu";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1561, 187);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(85, 17);
            this.label14.TabIndex = 7;
            this.label14.Text = "Aktif Çalışan";
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.ForeColor = System.Drawing.Color.Green;
            this.lblEmployee.Location = new System.Drawing.Point(1664, 189);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(70, 17);
            this.lblEmployee.TabIndex = 6;
            this.lblEmployee.Text = "Employee";
            // 
            // pctEmployee
            // 
            this.pctEmployee.Location = new System.Drawing.Point(1571, 12);
            this.pctEmployee.Name = "pctEmployee";
            this.pctEmployee.Size = new System.Drawing.Size(184, 147);
            this.pctEmployee.TabIndex = 5;
            this.pctEmployee.TabStop = false;
            // 
            // btnShowDatas
            // 
            this.btnShowDatas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnShowDatas.Location = new System.Drawing.Point(190, 232);
            this.btnShowDatas.Name = "btnShowDatas";
            this.btnShowDatas.Size = new System.Drawing.Size(203, 34);
            this.btnShowDatas.TabIndex = 8;
            this.btnShowDatas.Text = "Arama";
            this.btnShowDatas.UseVisualStyleBackColor = true;
            this.btnShowDatas.Click += new System.EventHandler(this.btnShowDatas_Click);
            // 
            // dGVResult
            // 
            this.dGVResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVResult.Location = new System.Drawing.Point(13, 272);
            this.dGVResult.Name = "dGVResult";
            this.dGVResult.RowHeadersWidth = 51;
            this.dGVResult.RowTemplate.Height = 24;
            this.dGVResult.Size = new System.Drawing.Size(1772, 163);
            this.dGVResult.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(14, 452);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tüm Siparişler";
            // 
            // btnOrderDetailPage
            // 
            this.btnOrderDetailPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnOrderDetailPage.Location = new System.Drawing.Point(402, 232);
            this.btnOrderDetailPage.Name = "btnOrderDetailPage";
            this.btnOrderDetailPage.Size = new System.Drawing.Size(387, 34);
            this.btnOrderDetailPage.TabIndex = 10;
            this.btnOrderDetailPage.Text = " OrderID\'si ile Sipariş Detaylarını Görün";
            this.btnOrderDetailPage.UseVisualStyleBackColor = true;
            this.btnOrderDetailPage.Click += new System.EventHandler(this.btnOrderDetailPage_Click);
            // 
            // lablID
            // 
            this.lablID.AutoSize = true;
            this.lablID.Location = new System.Drawing.Point(467, 14);
            this.lablID.Name = "lablID";
            this.lablID.Size = new System.Drawing.Size(21, 17);
            this.lablID.TabIndex = 11;
            this.lablID.Text = "ID";
            // 
            // lblAppUserID
            // 
            this.lblAppUserID.AutoSize = true;
            this.lblAppUserID.Location = new System.Drawing.Point(417, 50);
            this.lblAppUserID.Name = "lblAppUserID";
            this.lblAppUserID.Size = new System.Drawing.Size(71, 17);
            this.lblAppUserID.TabIndex = 11;
            this.lblAppUserID.Text = "Müşteri ID";
            // 
            // lblShipperID
            // 
            this.lblShipperID.AutoSize = true;
            this.lblShipperID.Location = new System.Drawing.Point(410, 88);
            this.lblShipperID.Name = "lblShipperID";
            this.lblShipperID.Size = new System.Drawing.Size(78, 17);
            this.lblShipperID.TabIndex = 11;
            this.lblShipperID.Text = "Kargocu ID";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Location = new System.Drawing.Point(399, 126);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(89, 17);
            this.lblTotalPrice.TabIndex = 11;
            this.lblTotalPrice.Text = "Toplam Fiyat";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(683, 13);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(84, 17);
            this.lblUsername.TabIndex = 11;
            this.lblUsername.Text = "Kullanıcı Adı";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(725, 49);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(42, 17);
            this.lblEmail.TabIndex = 11;
            this.lblEmail.Text = "Email";
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(731, 87);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(36, 17);
            this.lblCountry.TabIndex = 11;
            this.lblCountry.Text = "Ülke";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(726, 125);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(41, 17);
            this.lblCity.TabIndex = 11;
            this.lblCity.Text = "Şehir";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(722, 154);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(45, 17);
            this.lblAddress.TabIndex = 11;
            this.lblAddress.Text = "Adres";
            // 
            // lblDeleted
            // 
            this.lblDeleted.AutoSize = true;
            this.lblDeleted.Location = new System.Drawing.Point(1357, 94);
            this.lblDeleted.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDeleted.Name = "lblDeleted";
            this.lblDeleted.Size = new System.Drawing.Size(0, 17);
            this.lblDeleted.TabIndex = 148;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(1242, 92);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 18);
            this.label3.TabIndex = 147;
            this.label3.Text = "Silme Tarihi";
            // 
            // lblUpdated
            // 
            this.lblUpdated.AutoSize = true;
            this.lblUpdated.Location = new System.Drawing.Point(1357, 49);
            this.lblUpdated.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUpdated.Name = "lblUpdated";
            this.lblUpdated.Size = new System.Drawing.Size(0, 17);
            this.lblUpdated.TabIndex = 146;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(1195, 47);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 18);
            this.label8.TabIndex = 145;
            this.label8.Text = "Güncelleme Tarihi";
            // 
            // lblCreated
            // 
            this.lblCreated.AutoSize = true;
            this.lblCreated.Location = new System.Drawing.Point(1357, 10);
            this.lblCreated.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCreated.Name = "lblCreated";
            this.lblCreated.Size = new System.Drawing.Size(0, 17);
            this.lblCreated.TabIndex = 144;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(1248, 8);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 18);
            this.label5.TabIndex = 143;
            this.label5.Text = "Giriş Tarihi";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(1357, 131);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            this.lblStatus.TabIndex = 142;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(1238, 129);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 18);
            this.label4.TabIndex = 141;
            this.label4.Text = "Veri Durumu";
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Location = new System.Drawing.Point(495, 126);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Size = new System.Drawing.Size(100, 22);
            this.txtTotalPrice.TabIndex = 149;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(786, 12);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(207, 22);
            this.txtUserName.TabIndex = 149;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(786, 49);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(207, 22);
            this.txtEmail.TabIndex = 149;
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(786, 86);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(207, 22);
            this.txtCountry.TabIndex = 149;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(786, 125);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(207, 22);
            this.txtCity.TabIndex = 149;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(786, 154);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(521, 78);
            this.txtAddress.TabIndex = 149;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1313, 154);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 39);
            this.btnSave.TabIndex = 150;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1409, 154);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 39);
            this.btnDelete.TabIndex = 150;
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(1313, 199);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 33);
            this.btnUpdate.TabIndex = 150;
            this.btnUpdate.Text = "Güncelle";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1409, 199);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 33);
            this.btnClear.TabIndex = 150;
            this.btnClear.Text = "Temizle";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(494, 13);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(0, 17);
            this.lblID.TabIndex = 11;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSearch.Location = new System.Drawing.Point(4, 19);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(175, 18);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "OrderID ile Arama Yap";
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtID.Location = new System.Drawing.Point(190, 19);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(203, 24);
            this.txtID.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSearch.Location = new System.Drawing.Point(190, 62);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(203, 34);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Arama";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(4, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(180, 109);
            this.label6.TabIndex = 1;
            this.label6.Text = "*Order ID ile güncellenek silinecek Siparişleri arayabilirsin önce Müşteri Maili " +
    "ile arama yaparak kayıtlı OrderID\'leri görebilirsin";
            // 
            // txtShipperID
            // 
            this.txtShipperID.Location = new System.Drawing.Point(495, 87);
            this.txtShipperID.Name = "txtShipperID";
            this.txtShipperID.Size = new System.Drawing.Size(100, 22);
            this.txtShipperID.TabIndex = 149;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1409, 160);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 33);
            this.button1.TabIndex = 150;
            this.button1.Text = "Temizle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtAppUserID
            // 
            this.txtAppUserID.Location = new System.Drawing.Point(495, 47);
            this.txtAppUserID.Name = "txtAppUserID";
            this.txtAppUserID.Size = new System.Drawing.Size(100, 22);
            this.txtAppUserID.TabIndex = 149;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1409, 120);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 33);
            this.button2.TabIndex = 150;
            this.button2.Text = "Temizle";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // mOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1866, 832);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.txtAppUserID);
            this.Controls.Add(this.txtShipperID);
            this.Controls.Add(this.txtCountry);
            this.Controls.Add(this.txtTotalPrice);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblDeleted);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblUpdated);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblCreated);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblShipperID);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblAppUserID);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lablID);
            this.Controls.Add(this.btnOrderDetailPage);
            this.Controls.Add(this.dGVResult);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnShowDatas);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.pctEmployee);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label);
            this.Controls.Add(this.dGVOrder);
            this.Name = "mOrder";
            this.Text = "mOrder";
            this.Load += new System.EventHandler(this.mOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGVOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dGVOrder;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.PictureBox pctEmployee;
        private System.Windows.Forms.Button btnShowDatas;
        private System.Windows.Forms.DataGridView dGVResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOrderDetailPage;
        private System.Windows.Forms.Label lablID;
        private System.Windows.Forms.Label lblAppUserID;
        private System.Windows.Forms.Label lblShipperID;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblDeleted;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUpdated;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCreated;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtShipperID;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtAppUserID;
        private System.Windows.Forms.Button button2;
    }
}