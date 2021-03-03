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
    public partial class wProductCategory : Form
    {
        ProjectFarmBAEntities db;
        public wProductCategory()
        {
            InitializeComponent();
            db = DBTool.DBInstance;
        }

        SqlConnection connection = new SqlConnection("Data Source=LENOVO-PC\\SQLEXPRESS;Initial Catalog=ProjectFarmBA;Integrated Security=True;MultipleActiveResultSets=True");

        private void wProductCategory_Load(object sender, EventArgs e)
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
            
            pctCategory.SizeMode = PictureBoxSizeMode.StretchImage;
            pctCategory.Width = 180;
            pctCategory.Height = 180;
            pctCategory.BorderStyle = BorderStyle.Fixed3D;

            CategoryShow();
        }

        private void CategoryShow()
        {
            try
            { 
                connection.Open();
                SqlDataAdapter categoryList = new SqlDataAdapter("select ID , CategoryName as [Kategori Adı], Description as [Açıklama], [Veri Yaratma Tarihi] , [Veri Güncelleme Tarihi] , [Veri Silme Tarihi] ,[Veri Durumu] from Categories", connection);
                DataSet dataSet = new DataSet();
                categoryList.Fill(dataSet);
                dGVProductCategory.DataSource = dataSet.Tables[0];


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
                    lblDescription.Text = dataReader.GetValue(2).ToString();
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
            }
        }
    }
}
