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
    public partial class mOrder : Form
    {
        public mOrder()
        {
            InitializeComponent();
            db = DBTool.DBInstance;
        }

        ProjectFarmBAEntities db;


        SqlConnection connection = new SqlConnection("Data Source=LENOVO-PC\\SQLEXPRESS;Initial Catalog=ProjectFarmBA;Integrated Security=True;MultipleActiveResultSets=True");
        //formdan birden fazla istek alacağım zaman multipleActiveResultSets=true eklemek lazım

        private void OrderShow()
        {
            try
            {
                connection.Open();
                SqlDataAdapter orderList = new SqlDataAdapter("select ID, ShippedAddress as [Adres], ShippedCity as [Şehir], ShippedCountry as [Ülke], AppUserID as [Müşteri ID], ShipperID as [Kargocu ID], TotalPrice as [Fiyat], UserName as [Kullanıcı Adı], Email as [E-Mail], [Veri Yaratma Tarihi] , [Veri Güncelleme Tarihi] , [Veri Silme Tarihi] ,[Veri Durumu] from Orders", connection);
                DataSet dataSet = new DataSet();
                orderList.Fill(dataSet);
                dGVOrder.DataSource = dataSet.Tables[0];

                //cmbAppUserID.DataSource = db.AppUsers.ToList();
                //cmbAppUserID.DisplayMember = "AppUserID";
                //cmbShipperID.DataSource = db.Shippers.ToList();
                //cmbShipperID.DisplayMember = "ShipperID";

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }


        private void mOrder_Load(object sender, EventArgs e)
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

        private void CleanOrderPage()
        {
            txtSearch.Clear();txtAddress.Clear();txtCity.Clear();txtCountry.Clear();txtAppUserID.Clear();txtShipperID.Clear();txtTotalPrice.Clear();txtUserName.Clear();txtEmail.Clear();
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
                    txtAddress.Text = dataReader.GetValue(1).ToString();
                    txtCity.Text = dataReader.GetValue(2).ToString();
                    txtCountry.Text = dataReader.GetValue(3).ToString();
                    txtAppUserID.Text = dataReader.GetValue(4).ToString();
                    txtShipperID.Text = dataReader.GetValue(5).ToString();
                    txtTotalPrice.Text = dataReader.GetValue(6).ToString();
                    txtUserName.Text = dataReader.GetValue(7).ToString();
                    txtEmail.Text = dataReader.GetValue(8).ToString();
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
            mOrderDetail orderDetail = new mOrderDetail();
            orderDetail.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtAddress.Text == "")
            {
                lblAddress.ForeColor = Color.Red;
            }
            else
                lblAddress.ForeColor = Color.Black;

            if (txtCity.Text == "")
            {
                lblCity.ForeColor = Color.Red;
            }
            else
                lblCity.ForeColor = Color.Black;

            if (txtCountry.Text == "")
            {
                lblCountry.ForeColor = Color.Red;
            }
            else
                lblCountry.ForeColor = Color.Black;

            if (txtAppUserID.Text == "")
            {
                lblAppUserID.ForeColor = Color.Red;
            }
            else
                lblAppUserID.ForeColor = Color.Black;

            if (txtShipperID.Text == "")
            {
                lblShipperID.ForeColor = Color.Red;
            }
            else
                lblShipperID.ForeColor = Color.Black;

            if (txtTotalPrice.Text == "")
            {
                lblTotalPrice.ForeColor = Color.Red;
            }
            else
                lblTotalPrice.ForeColor = Color.Black;

            if (txtEmail.Text == "")
            {
                lblEmail.ForeColor = Color.Red;
            }
            else
                lblEmail.ForeColor = Color.Black;

            if (txtAddress.Text == "")
            {
                lblAddress.ForeColor = Color.Red;
            }
            else
                lblAddress.ForeColor = Color.Black;

            if (txtAddress.Text != "" && txtCity.Text != "" && txtCountry.Text != "" && txtAppUserID.Text != "" && txtShipperID.Text != "" && txtTotalPrice.Text != "" && txtEmail.Text != "" && txtAddress.Text != "")
            {
                try
                {
                    connection.Open();
                    SqlCommand updateData = new SqlCommand("update Orders set ShippedAddress='" + txtAddress.Text + "', ShippedCity= '" + txtCity.Text + "', ShippedCountry= '" + txtCountry.Text + "',AppUserID= '" + txtAppUserID.Text + "',ShipperID= '" + txtShipperID.Text + "',TotalPrice= '" + txtTotalPrice.Text.Replace(",", ".") + "',UserName= '" + txtUserName.Text + "',Email= '" + txtEmail.Text + "', [Veri Güncelleme Tarihi] = '" + DateTime.Now + "' where ID='" + lblID.Text + "'", connection);

                    updateData.ExecuteNonQuery();

                    connection.Close();
                    MessageBox.Show("Kayıt Güncellendi", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    OrderShow();
                    CleanOrderPage();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
            if (txtSearch.Text != null)
            {
                bool searchData = false;

                connection.Open();

                SqlCommand selectQuery = new SqlCommand("select * from Orders where ID ='" + txtID.Text + "'", connection);
                SqlDataReader dataReader = selectQuery.ExecuteReader();

                while (dataReader.Read())
                {
                    searchData = true;
                    SqlCommand deleteData = new SqlCommand("delete from Orders where ID='" + txtID.Text + "'", connection);
                    deleteData.ExecuteNonQuery();
                    MessageBox.Show("Sipariş kaydı silindi !", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    connection.Close();
                    OrderShow();
                    //CleanOrderPage();
                    break;
                }
                if (searchData == false)
                {
                    MessageBox.Show("Silinecek kayıt bulunamadı", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connection.Close();
                    CleanOrderPage();
                }

            }
            else
                MessageBox.Show("Lütfen kayıtlarda olan bir Sipariş ID giriniz !", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CleanOrderPage();
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

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    bool dataCheck = false;

        //    connection.Open();
        //    SqlCommand selectQuery = new SqlCommand("select * from Orders where Email='" + txtID.Text + "'", connection);
        //    SqlDataReader dataReader = selectQuery.ExecuteReader();
        //    while (dataReader.Read())
        //    {
        //        dataCheck = true;
        //        break;
        //    }

        //    connection.Close();

        //    if (dataCheck == false)
        //    {


        //        if (txtAddress.Text == "")
        //        {
        //            lblAddress.ForeColor = Color.Red;
        //        }
        //        else
        //            lblAddress.ForeColor = Color.Black;

        //        if (txtCity.Text == "")
        //        {
        //            lblCity.ForeColor = Color.Red;
        //        }
        //        else
        //            lblCity.ForeColor = Color.Black;

        //        if (txtCountry.Text == "")
        //        {
        //            lblCountry.ForeColor = Color.Red;
        //        }
        //        else
        //            lblCountry.ForeColor = Color.Black;

        //        if (txtAppUserID.Text == "")
        //        {
        //            lblAppUserID.ForeColor = Color.Red;
        //        }
        //        else
        //            lblAppUserID.ForeColor = Color.Black;

        //        if (txtShipperID.Text == "")
        //        {
        //            lblShipperID.ForeColor = Color.Red;
        //        }
        //        else
        //            lblShipperID.ForeColor = Color.Black;

        //        if (txtTotalPrice.Text == "")
        //        {
        //            lblTotalPrice.ForeColor = Color.Red;
        //        }
        //        else
        //            lblTotalPrice.ForeColor = Color.Black;

        //        if (txtEmail.Text == "")
        //        {
        //            lblEmail.ForeColor = Color.Red;
        //        }
        //        else
        //            lblEmail.ForeColor = Color.Black;

        //        if (txtAddress.Text == "")
        //        {
        //            lblAddress.ForeColor = Color.Red;
        //        }
        //        else
        //            lblAddress.ForeColor = Color.Black;

        //        if (txtAddress.Text != "" && txtCity.Text != "" && txtCountry.Text != "" && txtAppUserID.Text != "" && txtShipperID.Text != "" && txtTotalPrice.Text != "" && txtEmail.Text != "" && txtAddress.Text != "")
        //        {
        //            try
        //            {
        //                connection.Open();
        //                Order o = new Order();
        //                o.ShippedAddress = txtAddress.Text;
        //                o.ShippedCity = txtCity.Text;
        //                o.ShippedCountry = txtCountry.Text;
        //                o.AppUserID = Convert.ToInt32(txtAppUserID.Text);
        //                o.ShipperID = Convert.ToInt32(txtShipperID.Text);
        //                o.TotalPrice = Convert.ToInt32(txtTotalPrice.Text);
        //                o.UserName = txtUserName.Text;
        //                o.Email = txtEmail.Text;
        //                o.Veri_Yaratma_Tarihi = DateTime.Now;
        //                db.Orders.Add(o);
        //                db.SaveChanges();

        //                connection.Close();
        //                MessageBox.Show("Yeni kayıt oluşturuldu", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //                OrderShow();
        //                CleanOrderPage();
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.Message);
        //                connection.Close();
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Zorunlu alanları doldurunuz", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}
    }
}
