
namespace ProjectFarmBA_WFA
{
    partial class mHomePage
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
            this.btnPageEmployee = new System.Windows.Forms.Button();
            this.btnPageProduct = new System.Windows.Forms.Button();
            this.btnPageCategory = new System.Windows.Forms.Button();
            this.btnPageDepartment = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.pctEmployee = new System.Windows.Forms.PictureBox();
            this.btnPageStorage = new System.Windows.Forms.Button();
            this.btnPageStorageCategory = new System.Windows.Forms.Button();
            this.btnPageShipper = new System.Windows.Forms.Button();
            this.btnPageSupplier = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pctEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPageEmployee
            // 
            this.btnPageEmployee.Location = new System.Drawing.Point(56, 55);
            this.btnPageEmployee.Name = "btnPageEmployee";
            this.btnPageEmployee.Size = new System.Drawing.Size(115, 59);
            this.btnPageEmployee.TabIndex = 0;
            this.btnPageEmployee.Text = "Personel";
            this.btnPageEmployee.UseVisualStyleBackColor = true;
            this.btnPageEmployee.Click += new System.EventHandler(this.btnPageEmployee_Click);
            // 
            // btnPageProduct
            // 
            this.btnPageProduct.Location = new System.Drawing.Point(56, 149);
            this.btnPageProduct.Name = "btnPageProduct";
            this.btnPageProduct.Size = new System.Drawing.Size(115, 59);
            this.btnPageProduct.TabIndex = 0;
            this.btnPageProduct.Text = "Ürün";
            this.btnPageProduct.UseVisualStyleBackColor = true;
            this.btnPageProduct.Click += new System.EventHandler(this.btnPageProduct_Click);
            // 
            // btnPageCategory
            // 
            this.btnPageCategory.Location = new System.Drawing.Point(56, 239);
            this.btnPageCategory.Name = "btnPageCategory";
            this.btnPageCategory.Size = new System.Drawing.Size(115, 59);
            this.btnPageCategory.TabIndex = 0;
            this.btnPageCategory.Text = "Kategori (Ürün)";
            this.btnPageCategory.UseVisualStyleBackColor = true;
            // 
            // btnPageDepartment
            // 
            this.btnPageDepartment.Location = new System.Drawing.Point(56, 327);
            this.btnPageDepartment.Name = "btnPageDepartment";
            this.btnPageDepartment.Size = new System.Drawing.Size(115, 59);
            this.btnPageDepartment.TabIndex = 0;
            this.btnPageDepartment.Text = "Departman";
            this.btnPageDepartment.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(515, 251);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(85, 17);
            this.label14.TabIndex = 5;
            this.label14.Text = "Aktif Çalışan";
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.ForeColor = System.Drawing.Color.Green;
            this.lblEmployee.Location = new System.Drawing.Point(618, 253);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(70, 17);
            this.lblEmployee.TabIndex = 4;
            this.lblEmployee.Text = "Employee";
            // 
            // pctEmployee
            // 
            this.pctEmployee.Location = new System.Drawing.Point(514, 50);
            this.pctEmployee.Name = "pctEmployee";
            this.pctEmployee.Size = new System.Drawing.Size(210, 172);
            this.pctEmployee.TabIndex = 3;
            this.pctEmployee.TabStop = false;
            // 
            // btnPageStorage
            // 
            this.btnPageStorage.Location = new System.Drawing.Point(257, 55);
            this.btnPageStorage.Name = "btnPageStorage";
            this.btnPageStorage.Size = new System.Drawing.Size(115, 59);
            this.btnPageStorage.TabIndex = 0;
            this.btnPageStorage.Text = "Ambar";
            this.btnPageStorage.UseVisualStyleBackColor = true;
            // 
            // btnPageStorageCategory
            // 
            this.btnPageStorageCategory.Location = new System.Drawing.Point(257, 149);
            this.btnPageStorageCategory.Name = "btnPageStorageCategory";
            this.btnPageStorageCategory.Size = new System.Drawing.Size(115, 59);
            this.btnPageStorageCategory.TabIndex = 0;
            this.btnPageStorageCategory.Text = "Kategori (Ambar)";
            this.btnPageStorageCategory.UseVisualStyleBackColor = true;
            // 
            // btnPageShipper
            // 
            this.btnPageShipper.Location = new System.Drawing.Point(257, 239);
            this.btnPageShipper.Name = "btnPageShipper";
            this.btnPageShipper.Size = new System.Drawing.Size(115, 59);
            this.btnPageShipper.TabIndex = 0;
            this.btnPageShipper.Text = "Kargo/Nakliye ";
            this.btnPageShipper.UseVisualStyleBackColor = true;
            // 
            // btnPageSupplier
            // 
            this.btnPageSupplier.Location = new System.Drawing.Point(257, 327);
            this.btnPageSupplier.Name = "btnPageSupplier";
            this.btnPageSupplier.Size = new System.Drawing.Size(115, 59);
            this.btnPageSupplier.TabIndex = 0;
            this.btnPageSupplier.Text = "Tedarikçi";
            this.btnPageSupplier.UseVisualStyleBackColor = true;
            // 
            // mHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.pctEmployee);
            this.Controls.Add(this.btnPageSupplier);
            this.Controls.Add(this.btnPageDepartment);
            this.Controls.Add(this.btnPageShipper);
            this.Controls.Add(this.btnPageCategory);
            this.Controls.Add(this.btnPageStorageCategory);
            this.Controls.Add(this.btnPageProduct);
            this.Controls.Add(this.btnPageStorage);
            this.Controls.Add(this.btnPageEmployee);
            this.Name = "mHomePage";
            this.Text = "AnaSayfa";
            this.Load += new System.EventHandler(this.mHomePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctEmployee)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPageEmployee;
        private System.Windows.Forms.Button btnPageProduct;
        private System.Windows.Forms.Button btnPageCategory;
        private System.Windows.Forms.Button btnPageDepartment;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.PictureBox pctEmployee;
        private System.Windows.Forms.Button btnPageStorage;
        private System.Windows.Forms.Button btnPageStorageCategory;
        private System.Windows.Forms.Button btnPageShipper;
        private System.Windows.Forms.Button btnPageSupplier;
    }
}