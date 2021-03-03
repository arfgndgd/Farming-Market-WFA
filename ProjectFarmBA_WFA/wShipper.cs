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
    public partial class wShipper : Form
    {
        ProjectFarmBAEntities db;
        public wShipper()
        {
            InitializeComponent();
            db = DBTool.DBInstance;
        }

        SqlConnection connection = new SqlConnection("Data Source=LENOVO-PC\\SQLEXPRESS;Initial Catalog=ProjectFarmBA;Integrated Security=True;MultipleActiveResultSets=True");

        private void wShipper_Load(object sender, EventArgs e)
        {
            //Çalışan resmini ekleme wForm3
            pctEmployee.Height = 180;
            pctEmployee.Width = 180;
            pctEmployee.SizeMode = PictureBoxSizeMode.StretchImage;
            lblEmployee.ForeColor = Color.Green;
            lblEmployee.Text = Login.name + " " + Login.surname;

            try
            {
                pctEmployee.Image = Image.FromFile(Application.StartupPath + "\\ImageEmployee\\" + Login.tcno + ".jpg");
            }
            catch
            {
                pctEmployee.Image = Image.FromFile(Application.StartupPath + "\\ImageEmployee\\resimyok.jpg");
            }

            //Kategori İşlemleri Sekmesi

            pctShipper.SizeMode = PictureBoxSizeMode.StretchImage;
            pctShipper.Width = 180;
            pctShipper.Height = 180;
            pctShipper.BorderStyle = BorderStyle.Fixed3D;

            ShipperShow();
        }

        private void ShipperShow()
        {
            try
            {
                connection.Open();
                SqlDataAdapter shipperList = new SqlDataAdapter("select ID , ShipperName as [Firma Adı], Phone as [Telefon], Email as [E-Mail],[Veri Yaratma Tarihi] , [Veri Güncelleme Tarihi] , [Veri Silme Tarihi] ,[Veri Durumu] from Shippers", connection);
                DataSet dataSet = new DataSet();
                shipperList.Fill(dataSet);
                dGVShipper.DataSource = dataSet.Tables[0];


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
            if (txtCompanyName.Text.Length > 0)
            {
                connection.Open();
                SqlCommand selectQuery = new SqlCommand("select * from Shippers where ShipperName = '" + txtCompanyName.Text + "'", connection);
                SqlDataReader dataReader = selectQuery.ExecuteReader();

                while (dataReader.Read())
                {
                    searchData = true;
                    lblID.Text = dataReader.GetValue(0).ToString();
                    txtCompanyName.Text = dataReader.GetValue(1).ToString();
                    lblPhone.Text = dataReader.GetValue(2).ToString();
                    lblEmail.Text = dataReader.GetValue(3).ToString();
                    try
                    {
                        pctShipper.Image = Image.FromFile(Application.StartupPath + "\\ImageShipper\\" + dataReader.GetValue(1).ToString() + ".jpg");

                    }
                    catch
                    {
                        pctShipper.Image = Image.FromFile(Application.StartupPath + "\\ImageShipper\\resimyok.jpg");
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
                MessageBox.Show("Lütfen kayıtlarda olan bir Kargo/Nakliye firması ismi giriniz", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
