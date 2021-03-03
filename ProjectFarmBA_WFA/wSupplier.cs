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
    public partial class wSupplier : Form
    {
        ProjectFarmBAEntities db;
        public wSupplier()
        {
            InitializeComponent();

            db = DBTool.DBInstance;
        }

        SqlConnection connection = new SqlConnection("Data Source=LENOVO-PC\\SQLEXPRESS;Initial Catalog=ProjectFarmBA;Integrated Security=True;MultipleActiveResultSets=True");

        private void wSupplier_Load(object sender, EventArgs e)
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

            pctSupplier.SizeMode = PictureBoxSizeMode.StretchImage;
            pctSupplier.Width = 180;
            pctSupplier.Height = 180;
            pctSupplier.BorderStyle = BorderStyle.Fixed3D;

            SupplierShow();
        }

        private void SupplierShow()
        {
            try
            {
                connection.Open();
                SqlDataAdapter supplierList = new SqlDataAdapter("select ID ,SupplierName as [Firma Adı],Address as [Adres], City as [Şehir], Country as [Ülke], Phone as [Telefon], Email as [E-Mail],[Veri Yaratma Tarihi] , [Veri Güncelleme Tarihi] , [Veri Silme Tarihi] ,[Veri Durumu] from Suppliers", connection);
                DataSet dataSet = new DataSet();
                supplierList.Fill(dataSet);
                dGVSupplier.DataSource = dataSet.Tables[0];


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
                SqlCommand selectQuery = new SqlCommand("select * from Suppliers where SupplierName = '" + txtCompanyName.Text + "'", connection);
                SqlDataReader dataReader = selectQuery.ExecuteReader();

                while (dataReader.Read())
                {
                    searchData = true;
                    lblID.Text = dataReader.GetValue(0).ToString();
                    txtCompanyName.Text = dataReader.GetValue(1).ToString();
                    lblAdress.Text = dataReader.GetValue(2).ToString();
                    lblCity.Text = dataReader.GetValue(3).ToString();
                    lblCountry.Text = dataReader.GetValue(4).ToString();
                    lblPhone.Text = dataReader.GetValue(5).ToString();
                    lblEmail.Text = dataReader.GetValue(6).ToString();
                    try
                    {
                        pctSupplier.Image = Image.FromFile(Application.StartupPath + "\\ImageSupplier\\" + dataReader.GetValue(1).ToString() + ".jpg");

                    }
                    catch
                    {
                        pctSupplier.Image = Image.FromFile(Application.StartupPath + "\\ImageSupplier\\resimyok.jpg");
                    }
                    lblCreated.Text = dataReader.GetValue(7).ToString();
                    lblUpdated.Text = dataReader.GetValue(8).ToString();
                    lblDeleted.Text = dataReader.GetValue(9).ToString();
                    lblStatus.Text = dataReader.GetValue(10).ToString();

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
                MessageBox.Show("Lütfen kayıtlarda olan bir Tedarikçi firma ismi giriniz", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
