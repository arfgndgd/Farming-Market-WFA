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
    public partial class mBlog : Form
    {
        ProjectFarmBAEntities db;
        public mBlog()
        {
            InitializeComponent();
            db = DBTool.DBInstance;
        }

        SqlConnection connection = new SqlConnection("Data Source=LENOVO-PC\\SQLEXPRESS;Initial Catalog=ProjectFarmBA;Integrated Security=True;MultipleActiveResultSets=True");
        private void mBlog_Load(object sender, EventArgs e)
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

            //Blog İşlemleri Sekmesi
            this.Text = "Blog İşlemleri";
            lblEmployee.ForeColor = Color.Green;
            lblEmployee.Text = Login.name + " " + Login.surname;
            pctBlog.SizeMode = PictureBoxSizeMode.StretchImage;
            pctBlog.Width = 100;
            pctBlog.Height = 100;
            pctBlog.BorderStyle = BorderStyle.Fixed3D;
            BlogShow();
        }

        private void BlogShow()
        {
            try
            {
                connection.Open();
                SqlDataAdapter blogList = new SqlDataAdapter("select ID , Title as [Başlık], Description as [Blog Yazısı], [Veri Yaratma Tarihi] , [Veri Güncelleme Tarihi] , [Veri Silme Tarihi] ,[Veri Durumu] from Blogs", connection);
                DataSet dataSet = new DataSet();
                blogList.Fill(dataSet);
                dGVBlog.DataSource = dataSet.Tables[0];

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }

        private void CleanBlogTabPage()
        {
            pctBlog.Image = null; txtTitle.Clear(); txtDescription.Clear();
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog image = new OpenFileDialog();
            image.Title = "Blog resmi seçiniz";
            image.Filter = "JPG (*.jpg) | *.jpg";
            if (image.ShowDialog() == DialogResult.OK)
            {
                this.pctBlog.Image = new Bitmap(image.OpenFile());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool dataCheck = false;

            connection.Open();
            SqlCommand selectQuery = new SqlCommand("select * from Blogs where Title ='" + txtTitle.Text + "'", connection);
            SqlDataReader dataReader = selectQuery.ExecuteReader();
            while (dataReader.Read())
            {
                dataCheck = true;
                break;
            }
            connection.Close();
            if (dataCheck == false)
            {
                if (txtTitle.Text == "")
                {
                    lblTitle.ForeColor = Color.Red;
                }
                else
                    lblTitle.ForeColor = Color.Black;

                if (txtDescription.Text == "")
                {
                    lblDescription.ForeColor = Color.Red;
                }
                else
                    lblDescription.ForeColor = Color.Black;

                if (/*pctCategory.Image !=  null &&*/ txtTitle.Text != "" && txtDescription.Text != "")
                {
                    try
                    {
                        connection.Open();

                        Blog b = new Blog();
                        b.Title = txtTitle.Text;
                        b.Description = txtDescription.Text;
                        b.Veri_Yaratma_Tarihi = DateTime.Now;
                        b.Veri_Durumu = 1;
                        db.Blogs.Add(b);
                        db.SaveChanges();

                        connection.Close();

                        //resmi debug içinde kaydetme
                        //if (!Directory.Exists(Application.StartupPath + "\\ImageCategory"))
                        //    Directory.CreateDirectory(Application.StartupPath + "\\ImageCategory");
                        //pctCategory.Image.Save(Application.StartupPath + "\\ImageCategory\\" + txtCategoryName.Text + ".jpg");

                        MessageBox.Show("Yeni kayıt oluşturuldu", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        BlogShow();
                        CleanBlogTabPage();
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
                MessageBox.Show("Girilen Blog yazısı daha önceden kayıtlıdır", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bool searchData = false;
            if (txtTitle.Text.Length > 0)
            {
                connection.Open();
                SqlCommand selectQuery = new SqlCommand("select * from Blogs where Title = '" + txtTitle.Text + "'", connection);
                SqlDataReader dataReader = selectQuery.ExecuteReader();

                while (dataReader.Read())
                {
                    searchData = true;
                    lblID.Text = dataReader.GetValue(0).ToString();
                    txtTitle.Text = dataReader.GetValue(1).ToString();
                    txtDescription.Text = dataReader.GetValue(2).ToString();
                    try
                    {
                        pctBlog.Image = Image.FromFile(Application.StartupPath + "\\ImageBlog\\" + dataReader.GetValue(1).ToString() + ".jpg");

                    }
                    catch
                    {
                        pctBlog.Image = Image.FromFile(Application.StartupPath + "\\ImageBlog\\resimyok.jpg");
                    }
                    lblCreated.Text = dataReader.GetValue(4).ToString();
                    lblUpdated.Text = dataReader.GetValue(5).ToString();
                    lblDeleted.Text = dataReader.GetValue(6).ToString();
                    lblStatus.Text = dataReader.GetValue(7).ToString();
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
                MessageBox.Show("Lütfen kayıtlarda olan bir Blog başlığı giriniz", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CleanBlogTabPage();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (txtTitle.Text != null)
            {
                bool searchData = false;

                connection.Open();

                SqlCommand selectQuery = new SqlCommand("select * from Blogs where Title='" + txtTitle.Text + "'", connection);
                SqlDataReader dataReader = selectQuery.ExecuteReader();
                while (dataReader.Read())
                {
                    searchData = true;
                    SqlCommand deleteData = new SqlCommand("delete from Blogs where Title='" + txtTitle.Text + "'", connection);
                    deleteData.ExecuteNonQuery();
                    MessageBox.Show("Kategori kaydı silindi !", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    connection.Close();
                    BlogShow();
                    CleanBlogTabPage();
                    break;
                }
                if (searchData == false)
                {
                    MessageBox.Show("Silinecek kayıt bulunamadı", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connection.Close();
                    CleanBlogTabPage();
                }

            }
            else
                MessageBox.Show("Lütfen kayıtlarda bulunan bir Blog yazı başlığı giriniz !", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (pctBlog.Image == null)
                btnAddImage.ForeColor = Color.Red;
            else
                btnAddImage.ForeColor = Color.Black;

            if (txtTitle.Text == "")
            {
                lblTitle.ForeColor = Color.Red;
            }
            else
                lblTitle.ForeColor = Color.Black;

            if (txtDescription.Text == "")
            {
                lblDescription.ForeColor = Color.Red;
            }
            else
                lblDescription.ForeColor = Color.Black;
            if (/*pctCategory.Image !=  null &&*/ txtTitle.Text != "" && txtDescription.Text != "")
            {
                try
                {
                    connection.Open();

                    SqlCommand updateData = new SqlCommand("update Blogs set  Description='" + txtDescription.Text + "', [Veri Durumu] = '" + 2 + "' where Title='" + txtTitle.Text + "'", connection);
                    //TODO: [Veri Güncelleme Tarihi] = '" + DateTime.Now + "'
                    updateData.ExecuteNonQuery();
                    connection.Close();

                    //resmi debug içinde kaydetme
                    //if (!Directory.Exists(Application.StartupPath + "\\ImageBlog"))
                    //    Directory.CreateDirectory(Application.StartupPath + "\\ImageBlog");
                    //pctCategory.Image.Save(Application.StartupPath + "\\ImageBlog\\" + txtTitle.Text + ".jpg");

                    MessageBox.Show("Kayıt Güncellendi", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    BlogShow();
                    CleanBlogTabPage();
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            CleanBlogTabPage();
        }
    }
}
