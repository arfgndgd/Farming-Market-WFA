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
    public partial class wBlog : Form
    {
        ProjectFarmBAEntities db;
        public wBlog()
        {
            InitializeComponent();
            db = DBTool.DBInstance;
        }
        SqlConnection connection = new SqlConnection("Data Source=LENOVO-PC\\SQLEXPRESS;Initial Catalog=ProjectFarmBA;Integrated Security=True;MultipleActiveResultSets=True");
        private void wBlog_Load(object sender, EventArgs e)
        {
            //Çalışan resmini ekleme wForm3
            pctEmployee.Height = 180;
            pctEmployee.Width = 180;
            pctEmployee.SizeMode = PictureBoxSizeMode.StretchImage;


            try
            {
                pctEmployee.Image = Image.FromFile(Application.StartupPath + "\\ImageEmployee\\" + Login.tcno + ".jpg");
            }
            catch
            {
                pctEmployee.Image = Image.FromFile(Application.StartupPath + "\\ImageEmployee\\resimyok.jpg");
            }

            lblEmployee.ForeColor = Color.Green;
            lblEmployee.Text = Login.name + " " + Login.surname;

            //Kategori İşlemleri Sekmesi

            pctBlog.SizeMode = PictureBoxSizeMode.StretchImage;
            pctBlog.Width = 180;
            pctBlog.Height = 180;
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bool searchData = false;
            if (txtBlog.Text.Length > 0)
            {
                connection.Open();
                SqlCommand selectQuery = new SqlCommand("select * from Blogs where Title = '" + txtBlog.Text + "'", connection);
                SqlDataReader dataReader = selectQuery.ExecuteReader();

                while (dataReader.Read())
                {
                    searchData = true;
                    lblID.Text = dataReader.GetValue(0).ToString();
                    txtBlog.Text = dataReader.GetValue(1).ToString();
                    lblDescription.Text = dataReader.GetValue(2).ToString();
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
                MessageBox.Show("Lütfen kayıtlarda olan bir Blog yazısı başlığı giriniz", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
