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
    public partial class wCustomer : Form
    {
        ProjectFarmBAEntities db;
        public wCustomer()
        {
            InitializeComponent();
            db = DBTool.DBInstance;

        }

        SqlConnection connection = new SqlConnection("Data Source=LENOVO-PC\\SQLEXPRESS;Initial Catalog=ProjectFarmBA;Integrated Security=True;MultipleActiveResultSets=True");
        private void wCustomer_Load(object sender, EventArgs e)
        {
            //Çalışan resmini ekleme
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

            //Çalışan İşlemleri Sekmesi
            this.Text = "Müşteri İşlemleri";
            lblEmployee.ForeColor = Color.Green;
            lblEmployee.Text = Login.name + " " + Login.surname;

            CustomerShow();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bool searchData = false;
            if (txtSearch.Text.Length == 10)
            {
                connection.Open();
                SqlCommand selectQuery = new SqlCommand("select * from Customers where Phone ='" + txtSearch.Text + "'", connection);
                SqlDataReader dataReader = selectQuery.ExecuteReader();

                while (dataReader.Read())
                {
                    searchData = true;
                    lblPhone.Text = dataReader.GetValue(3).ToString();
                    lblID.Text = dataReader.GetValue(0).ToString();
                    lblFirstName.Text = dataReader.GetValue(1).ToString();
                    lblLastName.Text = dataReader.GetValue(2).ToString();
                    lblEmail.Text = dataReader.GetValue(4).ToString();
                    lblAdress.Text = dataReader.GetValue(5).ToString();
                    lblCreated.Text = dataReader.GetValue(6).ToString();
                    lblUpdated.Text = dataReader.GetValue(7).ToString();
                    lblDeleted.Text = dataReader.GetValue(8).ToString();
                    lblStatus.Text = dataReader.GetValue(9).ToString();

                    break;
                }
                if (searchData == false) //Kayıt yoksa
                {
                    MessageBox.Show("Aranan kayıt bulunamadı", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                connection.Close();
            }
            else
            {
                MessageBox.Show("Lütfen 10 haneli bir Telefon No kaydı giriniz", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void CustomerShow()
        {
            try
            {
                connection.Open();
                SqlDataAdapter customerList = new SqlDataAdapter("select ID, FirstName as [Ad], LastName as [Soyad], Phone as [Telefon], Email as [E-Posta],  Address as [Adres], [Veri Yaratma Tarihi] , [Veri Güncelleme Tarihi] , [Veri Silme Tarihi] ,[Veri Durumu]  from Customers", connection);
                DataSet dataSet = new DataSet();
                customerList.Fill(dataSet);
                dGVCustomer.DataSource = dataSet.Tables[0];

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }

    }
}
