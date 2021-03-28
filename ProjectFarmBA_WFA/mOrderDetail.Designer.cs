
namespace ProjectFarmBA_WFA
{
    partial class mOrderDetail
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
            this.btnOrderPage = new System.Windows.Forms.Button();
            this.dGVResult = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.pctEmployee = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dGVOrderDetail = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.lblProductID = new System.Windows.Forms.Label();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblOrderID = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSoftDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGVResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVOrderDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOrderPage
            // 
            this.btnOrderPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnOrderPage.Location = new System.Drawing.Point(16, 149);
            this.btnOrderPage.Name = "btnOrderPage";
            this.btnOrderPage.Size = new System.Drawing.Size(505, 28);
            this.btnOrderPage.TabIndex = 21;
            this.btnOrderPage.Text = "Siparişler Sayfasına Gidin";
            this.btnOrderPage.UseVisualStyleBackColor = true;
            this.btnOrderPage.Click += new System.EventHandler(this.btnOrderPage_Click);
            // 
            // dGVResult
            // 
            this.dGVResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVResult.Location = new System.Drawing.Point(21, 261);
            this.dGVResult.Name = "dGVResult";
            this.dGVResult.RowHeadersWidth = 51;
            this.dGVResult.RowTemplate.Height = 24;
            this.dGVResult.Size = new System.Drawing.Size(1113, 119);
            this.dGVResult.TabIndex = 20;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Location = new System.Drawing.Point(409, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(112, 34);
            this.btnSearch.TabIndex = 19;
            this.btnSearch.Text = "Arama";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(940, 205);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(85, 17);
            this.label14.TabIndex = 18;
            this.label14.Text = "Aktif Çalışan";
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.ForeColor = System.Drawing.Color.Green;
            this.lblEmployee.Location = new System.Drawing.Point(1043, 207);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(70, 17);
            this.lblEmployee.TabIndex = 17;
            this.lblEmployee.Text = "Employee";
            // 
            // pctEmployee
            // 
            this.pctEmployee.Location = new System.Drawing.Point(950, 30);
            this.pctEmployee.Name = "pctEmployee";
            this.pctEmployee.Size = new System.Drawing.Size(184, 147);
            this.pctEmployee.TabIndex = 16;
            this.pctEmployee.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(18, 415);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 18);
            this.label2.TabIndex = 14;
            this.label2.Text = "Tüm Sipariş Detayları";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(20, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 18);
            this.label1.TabIndex = 15;
            this.label1.Text = "Arama Sonucu";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.txtSearch.Location = new System.Drawing.Point(200, 21);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(203, 24);
            this.txtSearch.TabIndex = 13;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblSearch.Location = new System.Drawing.Point(13, 24);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(180, 18);
            this.lblSearch.TabIndex = 12;
            this.lblSearch.Text = "Order ID ile Arama Yap";
            // 
            // dGVOrderDetail
            // 
            this.dGVOrderDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVOrderDetail.Location = new System.Drawing.Point(20, 435);
            this.dGVOrderDetail.Name = "dGVOrderDetail";
            this.dGVOrderDetail.RowHeadersWidth = 51;
            this.dGVOrderDetail.RowTemplate.Height = 24;
            this.dGVOrderDetail.Size = new System.Drawing.Size(1114, 292);
            this.dGVOrderDetail.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(635, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 23);
            this.label3.TabIndex = 22;
            this.label3.Text = "Sipariş Detayı CRUD";
            // 
            // txtOrderID
            // 
            this.txtOrderID.Location = new System.Drawing.Point(694, 51);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.Size = new System.Drawing.Size(145, 22);
            this.txtOrderID.TabIndex = 23;
            // 
            // lblProductID
            // 
            this.lblProductID.AutoSize = true;
            this.lblProductID.Location = new System.Drawing.Point(604, 92);
            this.lblProductID.Name = "lblProductID";
            this.lblProductID.Size = new System.Drawing.Size(70, 17);
            this.lblProductID.TabIndex = 22;
            this.lblProductID.Text = "ProductID";
            // 
            // txtProductID
            // 
            this.txtProductID.Location = new System.Drawing.Point(694, 92);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(145, 22);
            this.txtProductID.TabIndex = 23;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(694, 170);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(145, 22);
            this.txtQuantity.TabIndex = 25;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(604, 170);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(61, 17);
            this.lblQuantity.TabIndex = 24;
            this.lblQuantity.Text = "Quantity";
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Location = new System.Drawing.Point(694, 132);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Size = new System.Drawing.Size(145, 22);
            this.txtTotalPrice.TabIndex = 27;
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Location = new System.Drawing.Point(604, 132);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(72, 17);
            this.lblTotalPrice.TabIndex = 26;
            this.lblTotalPrice.Text = "TotalPrice";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(845, 51);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 141);
            this.btnClear.TabIndex = 151;
            this.btnClear.Text = "Temizle";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(671, 206);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 40);
            this.btnUpdate.TabIndex = 152;
            this.btnUpdate.Text = "Güncelle";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(833, 208);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 39);
            this.btnDelete.TabIndex = 153;
            this.btnDelete.Text = "Yok Et";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblOrderID
            // 
            this.lblOrderID.AutoSize = true;
            this.lblOrderID.Location = new System.Drawing.Point(604, 51);
            this.lblOrderID.Name = "lblOrderID";
            this.lblOrderID.Size = new System.Drawing.Size(58, 17);
            this.lblOrderID.TabIndex = 22;
            this.lblOrderID.Text = "OrderID";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(590, 207);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 39);
            this.btnSave.TabIndex = 154;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnSoftDelete
            // 
            this.btnSoftDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSoftDelete.Location = new System.Drawing.Point(752, 207);
            this.btnSoftDelete.Name = "btnSoftDelete";
            this.btnSoftDelete.Size = new System.Drawing.Size(75, 39);
            this.btnSoftDelete.TabIndex = 155;
            this.btnSoftDelete.Text = "Sil";
            this.btnSoftDelete.UseVisualStyleBackColor = true;
            this.btnSoftDelete.Click += new System.EventHandler(this.btnSoftDelete_Click);
            // 
            // mOrderDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 768);
            this.Controls.Add(this.btnSoftDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtTotalPrice);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtProductID);
            this.Controls.Add(this.lblOrderID);
            this.Controls.Add(this.lblProductID);
            this.Controls.Add(this.txtOrderID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnOrderPage);
            this.Controls.Add(this.dGVResult);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.pctEmployee);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.dGVOrderDetail);
            this.Name = "mOrderDetail";
            this.Text = "mOrderDetail";
            this.Load += new System.EventHandler(this.mOrderDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGVResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVOrderDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOrderPage;
        private System.Windows.Forms.DataGridView dGVResult;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.PictureBox pctEmployee;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.DataGridView dGVOrderDetail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.Label lblProductID;
        private System.Windows.Forms.TextBox txtProductID;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblOrderID;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSoftDelete;
    }
}