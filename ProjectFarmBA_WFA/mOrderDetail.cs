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
    public partial class mOrderDetail : Form
    {
        public mOrderDetail()
        {
            InitializeComponent();
            db = DBTool.DBInstance;
        }

        ProjectFarmBAEntities db;


        SqlConnection connection = new SqlConnection("Data Source=LENOVO-PC\\SQLEXPRESS;Initial Catalog=ProjectFarmBA;Integrated Security=True;MultipleActiveResultSets=True");
        //formdan birden fazla istek alacağım zaman multipleActiveResultSets=true eklemek lazım

        private void OrderDetailShow()
        {
            try
            {
                connection.Open();
                SqlDataAdapter orderList = new SqlDataAdapter("select OrderID, ProductID as [Ürün ID'si], TotalPrice as [Toplam Fiyat], Quantity as [Miktar], [Veri Yaratma Tarihi] , [Veri Güncelleme Tarihi] , [Veri Silme Tarihi] ,[Veri Durumu] from OrderDetails", connection);
                DataSet dataSet = new DataSet();
                orderList.Fill(dataSet);
                dGVOrderDetail.DataSource = dataSet.Tables[0];

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }

        private void mOrderDetail_Load(object sender, EventArgs e)
        {
            //Çalışan resmini ekleme
            //Form2
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

            //Çalışan İşlemleri Sekmesi
            this.Text = "Sipariş Detayları Sayfası";
            lblEmployee.ForeColor = Color.Green;
            lblEmployee.Text = Login.name + " " + Login.surname;
            OrderDetailShow();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bool searchData = false;
            if (txtSearch.Text != null)
            {
                connection.Open();
                SqlCommand selectQuery = new SqlCommand("select * from OrderDetails where OrderID ='" + txtSearch.Text + "'", connection);
                SqlDataReader dataReader = selectQuery.ExecuteReader();

                while (dataReader.Read())
                {
                    searchData = true;
                    //lstOrder.DataSource = db.Orders.ToList();
                    //lstOrder.DisplayMember = "ID";
                    //lstOrder.DisplayMember = "ShippedAddress";

                    SqlDataAdapter orderList = new SqlDataAdapter("select OrderID, ProductID as [Ürün ID'si], TotalPrice as [Toplam Fiyat], Quantity as [Miktar], [Veri Yaratma Tarihi] , [Veri Güncelleme Tarihi] , [Veri Silme Tarihi] ,[Veri Durumu] from OrderDetails", connection);
                    DataSet dataSet = new DataSet();
                    orderList.Fill(dataSet);
                    dGVResult.DataSource = dataSet.Tables[0];


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
                MessageBox.Show("Lütfen 11 haneli bir Tc Kimlik No kaydı giriniz", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOrderPage_Click(object sender, EventArgs e)
        {
            mOrder order = new mOrder();
            order.Show();
        }
    }
}
