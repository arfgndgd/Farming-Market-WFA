using ProjectFarmBA_WFA.DesingPatterns.SingletonPattern;
using ProjectFarmBA_WFA.ModelContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectFarmBA_WFA
{
    public partial class mStorageCategory : Form
    {
        ProjectFarmBAEntities db;
        public mStorageCategory()
        {
            InitializeComponent();
            db = DBTool.DBInstance;
        }

        SqlConnection connection = new SqlConnection("Data Source=LENOVO-PC\\SQLEXPRESS;Initial Catalog=ProjectFarmBA;Integrated Security=True;MultipleActiveResultSets=True");

        private void mStorageCategory_Load(object sender, EventArgs e)
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

            //Ürün İşlemleri Sekmesi
            this.Text = "Ambar Kategorisi İşlemleri";
            lblEmployee.ForeColor = Color.Green;
            lblEmployee.Text = Login.name + " " + Login.surname;
            pctStorageCategory.SizeMode = PictureBoxSizeMode.StretchImage;
            pctStorageCategory.Width = 100;
            pctStorageCategory.Height = 100;
            pctStorageCategory.BorderStyle = BorderStyle.Fixed3D;
            StorageCategoryShow();
        }
        private void StorageCategoryShow()
        {
            try
            { 
                connection.Open();
                SqlDataAdapter storageCategoryList = new SqlDataAdapter("select ID , StorageCategoryName as [Kategori], StorageDescription as [Açıklama], [Veri Yaratma Tarihi] , [Veri Güncelleme Tarihi] , [Veri Silme Tarihi] ,[Veri Durumu] from StorageCategories", connection);
                DataSet dataSet = new DataSet();
                storageCategoryList.Fill(dataSet);
                dGVStorageCategory.DataSource = dataSet.Tables[0];

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }
        private void CleanStorageCategoryTabPage()
        {
            pctStorageCategory.Image = null; txtStorageCategoryName.Clear(); txtStorageDescription.Clear();
        }

        

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool dataCheck = false;

            connection.Open();
            SqlCommand selectQuery = new SqlCommand("select * from StorageCategories where StorageCategoryName ='" + txtStorageCategoryName.Text + "'", connection);
            SqlDataReader dataReader = selectQuery.ExecuteReader();
            while (dataReader.Read())
            {
                dataCheck = true;
                break;
            }
            connection.Close();
            if (dataCheck == false)
            {
                if (txtStorageCategoryName.Text == "")
                {
                    lblCategoryName.ForeColor = Color.Red;
                }
                else
                    lblCategoryName.ForeColor = Color.Black;

                if (txtStorageDescription.Text == "")
                {
                    lblDescription.ForeColor = Color.Red;
                }
                else
                    lblDescription.ForeColor = Color.Black;

                if (/*pctCategory.Image !=  null &&*/ txtStorageCategoryName.Text != "" && txtStorageDescription.Text != "")
                {
                    try
                    {
                        connection.Open();

                        StorageCategory s = new StorageCategory();
                        s.StorageCategoryName = txtStorageCategoryName.Text;
                        s.StorageDescription = txtStorageDescription.Text;
                        s.Veri_Yaratma_Tarihi = DateTime.Now;
                        s.Veri_Durumu = 1;
                        db.StorageCategories.Add(s);
                        db.SaveChanges();

                        connection.Close();

                        //resmi debug içinde kaydetme
                        //if (!Directory.Exists(Application.StartupPath + "\\ImageCategory"))
                        //    Directory.CreateDirectory(Application.StartupPath + "\\ImageCategory");
                        //pctCategory.Image.Save(Application.StartupPath + "\\ImageCategory\\" + txtCategoryName.Text + ".jpg");

                        MessageBox.Show("Yeni kayıt oluşturuldu", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        StorageCategoryShow();
                        CleanStorageCategoryTabPage();
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
                MessageBox.Show("Girilen Ambar Kategorisi daha önceden kayıtlıdır", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (pctStorageCategory.Image == null)
                btnAddImage.ForeColor = Color.Red;
            else
                btnAddImage.ForeColor = Color.Black;

            if (txtStorageCategoryName.Text == "")
            {
                lblCategoryName.ForeColor = Color.Red;
            }
            else
                lblCategoryName.ForeColor = Color.Black;

            if (txtStorageDescription.Text == "")
            {
                lblDescription.ForeColor = Color.Red;
            }
            else
                lblDescription.ForeColor = Color.Black;
            if (/*pctCategory.Image !=  null &&*/ txtStorageCategoryName.Text != "" && txtStorageDescription.Text != "")
            {
                try
                {
                    connection.Open();

                    SqlCommand updateData = new SqlCommand("update StorageCategories set  StorageDescription='" + txtStorageDescription.Text + "', [Veri Güncelleme Tarihi] = '" + DateTime.Now + "' where StorageCategoryName='" + txtStorageCategoryName.Text + "'", connection);
                    updateData.ExecuteNonQuery();
                    connection.Close();

                    //resmi debug içinde kaydetme
                    //if (!Directory.Exists(Application.StartupPath + "\\ImageCategory"))
                    //    Directory.CreateDirectory(Application.StartupPath + "\\ImageCategory");
                    //pctCategory.Image.Save(Application.StartupPath + "\\ImageCategory\\" + txtCategoryName.Text + ".jpg");

                    MessageBox.Show("Kayıt Güncellendi", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    StorageCategoryShow();
                    CleanStorageCategoryTabPage();
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
            if (txtStorageCategoryName.Text != null)
            {
                bool searchData = false;

                connection.Open();

                SqlCommand selectQuery = new SqlCommand("select * from StorageCategories where StorageCategoryName='" + txtStorageCategoryName.Text + "'", connection);
                SqlDataReader dataReader = selectQuery.ExecuteReader();
                while (dataReader.Read())
                {
                    searchData = true;
                    SqlCommand deleteData = new SqlCommand("delete from StorageCategories where StorageCategoryName='" + txtStorageCategoryName.Text + "'", connection);
                    deleteData.ExecuteNonQuery();
                    MessageBox.Show("Ambar Kategorisi kaydı silindi !", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    connection.Close();
                    StorageCategoryShow();
                    CleanStorageCategoryTabPage();
                    break;
                }
                if (searchData == false)
                {
                    MessageBox.Show("Silinecek kayıt bulunamadı", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connection.Close();
                    CleanStorageCategoryTabPage();
                }

            }
            else
                MessageBox.Show("Lütfen kayıtlarda bulunan bir Ambar Kategorisi ismi giriniz !", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CleanStorageCategoryTabPage();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bool searchData = false;
            if (txtStorageCategoryName.Text.Length > 0)
            {
                connection.Open();
                SqlCommand selectQuery = new SqlCommand("select * from StorageCategories where StorageCategoryName = '" + txtStorageCategoryName.Text + "'", connection);
                SqlDataReader dataReader = selectQuery.ExecuteReader();

                while (dataReader.Read())
                {
                    searchData = true;
                    lblID.Text = dataReader.GetValue(0).ToString();
                    txtStorageCategoryName.Text = dataReader.GetValue(1).ToString();
                    txtStorageDescription.Text = dataReader.GetValue(2).ToString();
                    try
                    {
                        pctStorageCategory.Image = Image.FromFile(Application.StartupPath + "\\ImageStorageCategory\\" + dataReader.GetValue(1).ToString() + ".jpg");

                    }
                    catch
                    {
                        pctStorageCategory.Image = Image.FromFile(Application.StartupPath + "\\ImageStorageCategory\\resimyok.jpg");
                    }
                    lblCreated.Text = dataReader.GetValue(3).ToString();
                    lblUpdated.Text = dataReader.GetValue(4).ToString();
                    lblDeleted.Text = dataReader.GetValue(5).ToString();
                    lblStatus.Text = dataReader.GetValue(6).ToString();
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
                MessageBox.Show("Lütfen kayıtlarda olan bir Ambar KategorisiS ismi giriniz", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CleanStorageCategoryTabPage();
            }
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog image = new OpenFileDialog();
            image.Title = "Ambar Kategorisi resmi seçiniz";
            image.Filter = "JPG (*.jpg) | *.jpg";
            if (image.ShowDialog() == DialogResult.OK)
            {
                this.pctStorageCategory.Image = new Bitmap(image.OpenFile());
            }
        }
    }
}
