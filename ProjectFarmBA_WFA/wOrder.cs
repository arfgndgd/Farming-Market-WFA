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
    public partial class wOrder : Form
    {
        public wOrder()
        {
            InitializeComponent();
            db = DBTool.DBInstance;

        }
        ProjectFarmBAEntities db;

        SqlConnection connection = new SqlConnection("Data Source=LENOVO-PC\\SQLEXPRESS;Initial Catalog=ProjectFarmBA;Integrated Security=True;MultipleActiveResultSets=True");

        private void wOrder_Load(object sender, EventArgs e)
        {
            //Çalışan resmini ekleme
            pctEmployee.Height = 130;
            pctEmployee.Width = 130;
            pctEmployee.SizeMode = PictureBoxSizeMode.StretchImage;

            try
            {
                pctEmployee.Image = Image.FromFile(Application.StartupPath + "\\ImageEmployee\\" + Login.tcno + ".jpg");
            }
            catch
            {
                pctEmployee.Image = Image.FromFile(Application.StartupPath + "\\ImageEmployee\\resimyok.jpg");
            }

            this.Text = "Sipariş Sayfası";
            lblEmployee.ForeColor = Color.Green;
            lblEmployee.Text = Login.name + " " + Login.surname;
            OrderShow();
        }

        private void OrderShow()
        {
            try
            {
                connection.Open();
                SqlDataAdapter orderList = new SqlDataAdapter("select ID, ShippedAddress as [Adres], ShippedCity as [Şehir], ShippedCountry as [Ülke], AppUserID as [Müşteri ID], ShipperID as [Kargocu ID], TotalPrice as [Fiyat], UserName as [Kullanıcı Adı], Email as [E-Mail], [Veri Yaratma Tarihi] , [Veri Güncelleme Tarihi] , [Veri Silme Tarihi] ,[Veri Durumu] from Orders", connection);
                DataSet dataSet = new DataSet();
                orderList.Fill(dataSet);
                dGVOrder.DataSource = dataSet.Tables[0];


                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }

        private void btnShowDatas_Click(object sender, EventArgs e)
        {
            bool searchData = false;
            if (txtSearch.Text != null)
            {
                connection.Open();
                SqlCommand selectQuery = new SqlCommand("select * from Orders where Email ='" + txtSearch.Text + "'", connection);
                SqlDataReader dataReader = selectQuery.ExecuteReader();

                while (dataReader.Read())
                {
                    searchData = true;
                    SqlDataAdapter orderList = new SqlDataAdapter("select ID, ShippedAddress as [Adres], ShippedCity as [Şehir], ShippedCountry as [Ülke], AppUserID as [Müşteri ID], ShipperID as [Kargocu ID], TotalPrice as [Fiyat], UserName as [Kullanıcı Adı], Email as [E-Mail], [Veri Yaratma Tarihi] , [Veri Güncelleme Tarihi] , [Veri Silme Tarihi] ,[Veri Durumu] from Orders", connection);
                    DataSet dataSet = new DataSet();
                    orderList.Fill(dataSet);
                    dGVResult.DataSource = dataSet.Tables[0];


                    break;
                }

                if (searchData == false) //Kayıt yoksa
                {
                    MessageBox.Show("Sipariş Kaydı bulunamadı", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                connection.Close();
            }
            else
            {
                MessageBox.Show("Lütfen Müşteri Email kaydı giriniz", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bool searchData = false;
            if (txtSearch.Text != null)
            {
                connection.Open();
                SqlCommand selectQuery = new SqlCommand("select * from Orders where ID ='" + txtID.Text + "'", connection);
                SqlDataReader dataReader = selectQuery.ExecuteReader();

                while (dataReader.Read())
                {
                    searchData = true;
                    lblID.Text = dataReader.GetValue(0).ToString();
                    lblAddress.Text = dataReader.GetValue(1).ToString();
                    lblCity.Text = dataReader.GetValue(2).ToString();
                    lblCountry.Text = dataReader.GetValue(3).ToString();
                    lblAppUserID.Text = dataReader.GetValue(4).ToString();
                    lblShipperID.Text = dataReader.GetValue(5).ToString();
                    lblTotalPrice.Text = dataReader.GetValue(6).ToString();
                    lblUserName.Text = dataReader.GetValue(7).ToString();
                    lblEmail.Text = dataReader.GetValue(8).ToString();
                    lblCreated.Text = dataReader.GetValue(9).ToString();
                    lblUpdated.Text = dataReader.GetValue(10).ToString();
                    lblDeleted.Text = dataReader.GetValue(11).ToString();
                    lblStatus.Text = dataReader.GetValue(12).ToString();


                    break;
                }

                if (searchData == false) //Kayıt yoksa
                {
                    MessageBox.Show("Sipariş Kaydı bulunamadı", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                connection.Close();
            }
            else
            {
                MessageBox.Show("Lütfen Müşteri Email kaydı giriniz", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOrderDetailPage_Click(object sender, EventArgs e)
        {
            wOrderDetail detail = new wOrderDetail();
            detail.Show();
        }
    }
}
