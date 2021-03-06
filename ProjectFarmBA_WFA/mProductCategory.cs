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
    public partial class mProductCategory : Form
    {
        ProjectFarmBAEntities db;
        public mProductCategory()
        {
            InitializeComponent();
            db = DBTool.DBInstance;
        }


        SqlConnection connection = new SqlConnection("Data Source=LENOVO-PC\\SQLEXPRESS;Initial Catalog=ProjectFarmBA;Integrated Security=True;MultipleActiveResultSets=True");

        private void mProductCategory_Load(object sender, EventArgs e)
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

            //Kategori İşlemleri Sekmesi
            this.Text = "Kategori İşlemleri";
            lblEmployee.ForeColor = Color.Green;
            lblEmployee.Text = Login.name + " " + Login.surname;
            pctCategory.SizeMode = PictureBoxSizeMode.StretchImage;
            pctCategory.Width = 100;
            pctCategory.Height = 100;
            pctCategory.BorderStyle = BorderStyle.Fixed3D;
            CategoryShow();
        }

        private void CategoryShow()
        {
            try
            { 
                connection.Open();
                SqlDataAdapter categoryList = new SqlDataAdapter("select ID , CategoryName as [Kategori], Description as [Açıklama], [Veri Yaratma Tarihi] , [Veri Güncelleme Tarihi] , [Veri Silme Tarihi] ,[Veri Durumu] from Categories", connection);
                DataSet dataSet = new DataSet();
                categoryList.Fill(dataSet);
                dGVCategory.DataSource = dataSet.Tables[0];

                //cmbCategory.DataSource = db.Categories.ToList();
                //cmbCategory.DisplayMember = "CategoryName";

                //cmbSupplier.DataSource = db.Suppliers.ToList();
                //cmbSupplier.DisplayMember = "SupplierName";

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }

        private void CleanCategoryTabPage()
        {
            pctCategory.Image = null; txtCategoryName.Clear();txtDescription.Clear();
        }

        private void btnAddImage_Click(object sender, EventArgs e)//Fotoğraf ekleme
        {
            OpenFileDialog image = new OpenFileDialog();
            image.Title = "Kategori resmi seçiniz";
            image.Filter = "JPG (*.jpg) | *.jpg";
            if (image.ShowDialog() == DialogResult.OK)
            {
                this.pctCategory.Image = new Bitmap(image.OpenFile());
            }
        }

        private void btnSave_Click(object sender, EventArgs e) //Ekleme
        {
            bool dataCheck = false;

            connection.Open();
            SqlCommand selectQuery = new SqlCommand("select * from Categories where CategoryName ='" + txtCategoryName.Text + "'", connection);
            SqlDataReader dataReader = selectQuery.ExecuteReader();
            while (dataReader.Read())
            {
                dataCheck = true;
                break;
            }
            connection.Close();
            if (dataCheck == false)
            {
                if (txtCategoryName.Text == "")
                {
                    lblCategoryName.ForeColor = Color.Red;
                }
                else
                    lblCategoryName.ForeColor = Color.Black;

                if (txtDescription.Text == "")
                {
                    lblDescription.ForeColor = Color.Red;
                }
                else
                    lblDescription.ForeColor = Color.Black;

                if (/*pctCategory.Image !=  null &&*/ txtCategoryName.Text != "" && txtDescription.Text != "" )
                {
                    try
                    {
                        connection.Open();

                        Category c = new Category();
                        c.CategoryName = txtCategoryName.Text;
                        c.Description = txtDescription.Text;
                        c.Veri_Yaratma_Tarihi = DateTime.Now;
                        db.Categories.Add(c);
                        db.SaveChanges();

                        connection.Close();

                        //resmi debug içinde kaydetme
                        //if (!Directory.Exists(Application.StartupPath + "\\ImageCategory"))
                        //    Directory.CreateDirectory(Application.StartupPath + "\\ImageCategory");
                        //pctCategory.Image.Save(Application.StartupPath + "\\ImageCategory\\" + txtCategoryName.Text + ".jpg");

                        MessageBox.Show("Yeni kayıt oluşturuldu", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        CategoryShow();
                        CleanCategoryTabPage();
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
                MessageBox.Show("Girilen Kategori daha önceden kayıtlıdır", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        } 

        private void btnSearch_Click(object sender, EventArgs e) //Arama
        {
            bool searchData = false;
            if (txtCategoryName.Text.Length > 0)
            {
                connection.Open();
                SqlCommand selectQuery = new SqlCommand("select * from Categories where CategoryName = '" + txtCategoryName.Text + "'", connection);
                SqlDataReader dataReader = selectQuery.ExecuteReader();

                while (dataReader.Read())
                {
                    searchData = true;
                    lblID.Text = dataReader.GetValue(0).ToString();
                    txtCategoryName.Text = dataReader.GetValue(1).ToString();
                    txtDescription.Text = dataReader.GetValue(2).ToString();
                    try
                    {
                        pctCategory.Image = Image.FromFile(Application.StartupPath + "\\ImageCategory\\" + dataReader.GetValue(1).ToString() + ".jpg");

                    }
                    catch
                    {
                        pctCategory.Image = Image.FromFile(Application.StartupPath + "\\ImageCategory\\resimyok.jpg");
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
                MessageBox.Show("Lütfen kayıtlarda olan bir Kategori ismi giriniz", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CleanCategoryTabPage();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e) //Güncelleme
        {
            //Category

            if (pctCategory.Image == null)
                btnAddImage.ForeColor = Color.Red;
            else
                btnAddImage.ForeColor = Color.Black;

            if (txtCategoryName.Text == "")
            {
                lblCategoryName.ForeColor = Color.Red;
            }
            else
                lblCategoryName.ForeColor = Color.Black;

            if (txtDescription.Text == "")
            {
                lblDescription.ForeColor = Color.Red;
            }
            else
                lblDescription.ForeColor = Color.Black;
            if (/*pctCategory.Image !=  null &&*/ txtCategoryName.Text != "" && txtDescription.Text != "")
            {
                try
                {
                    connection.Open();

                    SqlCommand updateData = new SqlCommand("update Categories set  Description='" + txtDescription.Text + "', [Veri Güncelleme Tarihi] = '" + DateTime.Now + "' where CategoryName='" + txtCategoryName.Text + "'", connection);
                    updateData.ExecuteNonQuery();
                    connection.Close();

                    //resmi debug içinde kaydetme
                    //if (!Directory.Exists(Application.StartupPath + "\\ImageCategory"))
                    //    Directory.CreateDirectory(Application.StartupPath + "\\ImageCategory");
                    //pctCategory.Image.Save(Application.StartupPath + "\\ImageCategory\\" + txtCategoryName.Text + ".jpg");

                    MessageBox.Show("Kayıt Güncellendi", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    CategoryShow();
                    CleanCategoryTabPage();
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

        private void btnDelete_Click(object sender, EventArgs e)//Silme 
        {
            if (txtCategoryName.Text != null)
            {
                bool searchData = false;

                connection.Open();

                SqlCommand selectQuery = new SqlCommand("select * from Categories where CategoryName='" + txtCategoryName.Text + "'", connection);
                SqlDataReader dataReader = selectQuery.ExecuteReader();
                while (dataReader.Read())
                {
                    searchData = true;
                    SqlCommand deleteData = new SqlCommand("delete from Categories where CategoryName='" + txtCategoryName.Text + "'", connection);
                    deleteData.ExecuteNonQuery();
                    MessageBox.Show("Kategori kaydı silindi !", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    connection.Close();
                    CategoryShow();
                    CleanCategoryTabPage();
                    break;
                }
                if (searchData == false)
                {
                    MessageBox.Show("Silinecek kayıt bulunamadı", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connection.Close();
                    CleanCategoryTabPage();
                }

            }
            else
                MessageBox.Show("Lütfen kayıtlarda bulunan bir Kategori ismi giriniz !", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnClear_Click(object sender, EventArgs e)//Form Temizleme
        {
            CleanCategoryTabPage();
        }

        private void txtCategoryName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8 || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8 || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }
    }
}
