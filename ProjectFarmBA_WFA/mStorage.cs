using ProjectFarmBA_WFA.DesingPatterns.SingletonPattern;
using ProjectFarmBA_WFA.ModelContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectFarmBA_WFA
{
    public partial class mStorage : Form
    {
        ProjectFarmBAEntities db;
        public mStorage()
        {
            InitializeComponent();
            db = DBTool.DBInstance;
        }

        SqlConnection connection = new SqlConnection("Data Source=LENOVO-PC\\SQLEXPRESS;Initial Catalog=ProjectFarmBA;Integrated Security=True;MultipleActiveResultSets=True");

        private void StorageShow()
        {
            try
            { 
                connection.Open();
                SqlDataAdapter storageList = new SqlDataAdapter("select ID , StorageName as [Ürün Adı], UnitInPrice as [Fiyat], SupplierID as [Tedarikçi], StorageCategoryID as [Kategori],  [Veri Yaratma Tarihi] , [Veri Güncelleme Tarihi] , [Veri Silme Tarihi] ,[Veri Durumu], Quantity as [Toplam Ağırlık] from Storages", connection);
                DataSet dataSet = new DataSet();
                storageList.Fill(dataSet);
                dGVStorage.DataSource = dataSet.Tables[0];

                cmbCategory.DataSource = db.StorageCategories.ToList();
                cmbCategory.DisplayMember = "StorageCategoryName";

                cmbSupplier.DataSource = db.Suppliers.ToList();
                cmbSupplier.DisplayMember = "SupplierName";

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }

        private void mStorage_Load(object sender, EventArgs e)
        {
            //Çalışan resmini ekleme Form3
            pctEmployee.Height = 150;
            pctEmployee.Width = 150;
            pctEmployee.SizeMode = PictureBoxSizeMode.StretchImage;
            try
            {
                pctEmployee.Image = Image.FromFile(Application.StartupPath + "\\ImageEmployee\\" + Login.tcno + ".jpg");
            }
            catch
            {
                pctEmployee.Image = Image.FromFile(Application.StartupPath + "\\ImageEmployee\\resimyok.jpg");
            }

            //Ambar İşlemleri Sekmesi
            this.Text = "Ambar İşlemleri";
            lblEmployee.ForeColor = Color.Green;
            lblEmployee.Text = Login.name + " " + Login.surname;
            pctStorage.SizeMode = PictureBoxSizeMode.StretchImage;
            pctStorage.Width = 100;
            pctStorage.Height = 100;
            pctStorage.BorderStyle = BorderStyle.Fixed3D;

            StorageShow();
        }

        private void CleanStorageTabPage()
        {
            pctStorage.Image = null; txtProductName.Clear(); txtUnitPrice.Clear(); txtTotalWeight.Clear(); cmbSupplier.SelectedIndex = -1;
            cmbCategory.SelectedIndex = -1;
        }

        private void txtProductName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8 || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void txtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void txtTotalWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog image = new OpenFileDialog();
            image.Title = "Ambar ürünü resmi seçiniz";
            image.Filter = "JPG (*.jpg) | *.jpg";
            if (image.ShowDialog() == DialogResult.OK)
            {
                this.pctStorage.Image = new Bitmap(image.OpenFile()); //Bitmap: görsel tanımlamak için kullanılıyor.
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool dataCheck = false;

            connection.Open();
            SqlCommand selectQuery = new SqlCommand("select * from Storages where StorageName ='" + txtProductName.Text + "'", connection);
            SqlDataReader dataReader = selectQuery.ExecuteReader();
            while (dataReader.Read())
            {
                dataCheck = true;
                break;
            }
            connection.Close();

            if (dataCheck == false)
            {
                //fotoğraf
                //if (pctProduct.Image == null)
                //    btnAddImage.ForeColor = Color.Red;
                //else
                //    btnAddImage.ForeColor = Color.Black;

                //isim
                if (txtProductName.Text == "")
                    lblProductName.ForeColor = Color.Red;
                else
                    lblProductName.ForeColor = Color.Black;

                //fiyat
                if (txtUnitPrice.Text == "")
                    lblUnitPrice.ForeColor = Color.Red;
                else
                    lblUnitPrice.ForeColor = Color.Black;

                //stok
                if (txtTotalWeight.Text == "")
                    lblTotalWeight.ForeColor = Color.Red;
                else
                    lblTotalWeight.ForeColor = Color.Black;


                //tedarikçi
                if (cmbSupplier.Text == "")
                    lblSupplier.ForeColor = Color.Red;
                else
                    lblSupplier.ForeColor = Color.Black;

                //Kategori
                if (cmbCategory.Text == "")
                    lblCategory.ForeColor = Color.Red;
                else
                    lblCategory.ForeColor = Color.Black;

                if (/*pctProduct.Image !=  null &&*/ txtProductName.Text != "" && txtUnitPrice.Text != "" && txtTotalWeight.Text != "" &&  cmbCategory.Text != "" && cmbSupplier.Text != "")
                {
                    try
                    {
                        connection.Open();

                        Storage s = new Storage();
                        s.StorageName = txtProductName.Text;
                        s.UnitInPrice = Convert.ToInt32(txtUnitPrice.Text);
                        s.Quantity = Convert.ToInt16(txtTotalWeight.Text);
                        s.SupplierID = cmbSupplier.SelectedItem != null ? (cmbSupplier.SelectedItem as Supplier).ID : default(int?);
                        s.StorageCategoryID = cmbCategory.SelectedItem != null ? (cmbCategory.SelectedItem as Category).ID : default(int?);
                        s.Veri_Yaratma_Tarihi = DateTime.Now;
                        s.Veri_Durumu = 1;
                        db.Storages.Add(s);
                        db.SaveChanges();

                        connection.Close();

                        //resmi debug içinde kaydetme
                        if (!Directory.Exists(Application.StartupPath + "\\ImageStorage"))
                            Directory.CreateDirectory(Application.StartupPath + "\\ImageStorage");
                        pctStorage.Image.Save(Application.StartupPath + "\\ImageStorage\\" + txtProductName.Text + ".jpg");

                        MessageBox.Show("Yeni kayıt oluşturuldu", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        StorageShow();
                        CleanStorageTabPage();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        connection.Close();
                    }
                }

                else
                {
                    MessageBox.Show("Zorunlu alanları doldurunuz", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Girilen Ambar Ürünü daha önceden kayıtlıdır", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //fotoğraf
            if (pctStorage.Image == null)
                btnAddImage.ForeColor = Color.Red;
            else
                btnAddImage.ForeColor = Color.Black;

            //isim
            if (txtProductName.Text == "")
                lblProductName.ForeColor = Color.Red;
            else
                lblProductName.ForeColor = Color.Black;

            //fiyat
            if (txtUnitPrice.Text == "")
                lblUnitPrice.ForeColor = Color.Red;
            else
                lblUnitPrice.ForeColor = Color.Black;

            //stok
            if (txtTotalWeight.Text == "")
                lblTotalWeight.ForeColor = Color.Red;
            else
                lblTotalWeight.ForeColor = Color.Black;
            

            if (pctStorage.Image != null && txtProductName.Text != "" && txtUnitPrice.Text != "" && txtTotalWeight.Text != "" && cmbCategory.Text != "" )
            {
                try
                {
                    connection.Open();
                    SqlCommand updateData = new SqlCommand("update Storages set UnitInPrice='" + txtUnitPrice.Text.Replace(",", ".") + "', SupplierID = '" + cmbSupplier.Text + "', StorageCategoryID='" + cmbCategory.Text + "', Quantity='" + txtTotalWeight.Text + "', [Veri Durumu] = '" + 2 + "' where StorageName='" + txtProductName.Text + "'", connection);
                    updateData.ExecuteNonQuery(); //TODO:  [Veri Güncelleme Tarihi] = '" + DateTime.Now + "'

                    connection.Close();
                    MessageBox.Show("Kayıt Güncellendi", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                    //resmi debug içinde kaydetme
                    //if (!Directory.Exists(Application.StartupPath + "\\ImageProduct"))
                    //    Directory.CreateDirectory(Application.StartupPath + "\\ImageProduct");
                    //pctProduct.Image.Save(Application.StartupPath + "\\ImageProduct\\" + txtProductName.Text + ".jpg");

                    StorageShow();
                    CleanStorageTabPage();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connection.Close();
                }
            }

            else
            {
                MessageBox.Show("Zorunlu alanları doldurunuz", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtProductName.Text != null)
            {
                bool searchData = false;

                connection.Open();

                SqlCommand selectQuery = new SqlCommand("select * from Storages where StorageName='" + txtProductName.Text + "'", connection);
                SqlDataReader dataReader = selectQuery.ExecuteReader();
                while (dataReader.Read())
                {
                    searchData = true;
                    SqlCommand deleteData = new SqlCommand("delete from Storages where StorageName='" + txtProductName.Text + "'", connection);
                    deleteData.ExecuteNonQuery();
                    MessageBox.Show("Ambar Ürünü kaydı yok edildi !", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    connection.Close();
                    StorageShow();
                    CleanStorageTabPage();
                    break;
                }
                if (searchData == false)
                {
                    MessageBox.Show("Yok edilecek kayıt bulunamadı", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connection.Close();
                    CleanStorageTabPage();
                }

            }
            else
                MessageBox.Show("Lütfen kayıtlarda bulunan bir Ambar Ürün ismi giriniz !", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bool searchData = false;
            if (txtProductName.Text.Length > 0)
            {
                connection.Open();
                SqlCommand selectQuery = new SqlCommand("select * from Storages where StorageName = '" + txtProductName.Text + "'", connection);
                SqlDataReader dataReader = selectQuery.ExecuteReader();

                while (dataReader.Read())
                {
                    searchData = true;
                    lblID.Text = dataReader.GetValue(0).ToString();
                    txtProductName.Text = dataReader.GetValue(9).ToString();
                    txtUnitPrice.Text = dataReader.GetValue(1).ToString();
                    txtTotalWeight.Text = dataReader.GetValue(10).ToString();
                    try
                    {
                        pctStorage.Image = Image.FromFile(Application.StartupPath + "\\ImageStorage\\" + dataReader.GetValue(1).ToString() + ".jpg");

                    }
                    catch
                    {
                        pctStorage.Image = Image.FromFile(Application.StartupPath + "\\ImageStorage\\resimyok.jpg");
                    }
                    cmbCategory.Text = dataReader.GetValue(4).ToString();
                    cmbSupplier.Text = dataReader.GetValue(3).ToString();
                    lblCreated.Text = dataReader.GetValue(5).ToString();
                    lblUpdated.Text = dataReader.GetValue(6).ToString();
                    lblDeleted.Text = dataReader.GetValue(7).ToString();
                    lblStatus.Text = dataReader.GetValue(8).ToString();

                    break;
                }
                if (searchData == false)//Kayıt yoksa
                {
                    MessageBox.Show("Aranan kayıt bulunamadı", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                connection.Close();

            }
            else
            {
                MessageBox.Show("Lütfen kayıtlarda olan bir Ambar Ürünü ismi giriniz", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CleanStorageTabPage();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CleanStorageTabPage();
        }

        private void btnSoftDelete_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand updateData = new SqlCommand("update Storages set [Veri Durumu] = '" + 3 + "' where StorageName='" + txtProductName.Text + "'", connection);
            updateData.ExecuteNonQuery(); //TODO:  [Veri Silme Tarihi] = '" + DateTime.Now + "'

            connection.Close();
            MessageBox.Show("Kayıt türü silinmiş olarak değiştirildi", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            StorageShow();
            CleanStorageTabPage();
        }
    }
}
