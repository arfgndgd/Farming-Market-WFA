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
        //Bu classta Sipariş detayı eklemesi yapılamaz, siparişler yalnızca düzenlebilir ve silinir

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

                    //SqlDataAdapter orderList = new SqlDataAdapter("select OrderID, ProductID as [Ürün ID'si], TotalPrice as [Toplam Fiyat], Quantity as [Miktar], [Veri Yaratma Tarihi] , [Veri Güncelleme Tarihi] , [Veri Silme Tarihi] ,[Veri Durumu] from OrderDetails", connection);
                    //DataSet dataSet = new DataSet();
                    //orderList.Fill(dataSet);
                    //dGVResult.DataSource = dataSet.Tables[0];

                    txtOrderID.Text = dataReader.GetValue(0).ToString();
                    txtProductID.Text = dataReader.GetValue(1).ToString();
                    txtQuantity.Text = dataReader.GetValue(3).ToString();
                    txtTotalPrice.Text = dataReader.GetValue(2).ToString();


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
                MessageBox.Show("Lütfen kayıtlı olan bir Sipariş ID giriniz", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOrderPage_Click(object sender, EventArgs e)
        {
            mOrder order = new mOrder();
            order.Show();
        }

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    bool dataCheck = false;
        //    connection.Open();
        //    SqlCommand selectQuery = new SqlCommand("select * from OrderDetails where OrderID='" + txtOrderID.Text + "'", connection);
        //    SqlDataReader dataReader = selectQuery.ExecuteReader();
        //    while (dataReader.Read())
        //    {
        //        dataCheck = true;
        //        break;
        //    }

        //    connection.Close();
        //    if (dataCheck == false)
        //    {
        //        if (txtOrderID.Text == "")
        //        {
        //            lblOrderID.ForeColor = Color.Red;
        //        }
        //        else
        //            lblOrderID.ForeColor = Color.Black;

        //        if (txtProductID.Text == "")
        //        {
        //            lblProductID.ForeColor = Color.Red;
        //        }
        //        else
        //            lblProductID.ForeColor = Color.Black;

        //        if (txtQuantity.Text == "")
        //        {
        //            lblQuantity.ForeColor = Color.Red;
        //        }
        //        else
        //            lblQuantity.ForeColor = Color.Black;

        //        if (txtTotalPrice.Text == "")
        //        {
        //            lblTotalPrice.ForeColor = Color.Red;
        //        }
        //        else
        //            lblTotalPrice.ForeColor = Color.Black;

        //        if (txtProductID.Text != "" && txtOrderID.Text != "" && txtQuantity.Text != "" && txtTotalPrice.Text != "")
        //        {
        //            try
        //            {
        //                connection.Open();
        //                OrderDetail o = new OrderDetail();
        //                o.OrderID = Convert.ToInt32(txtOrderID.Text);
        //                o.ProductID = Convert.ToInt32(txtProductID.Text);
        //                o.TotalPrice = Convert.ToInt32(txtTotalPrice.Text);
        //                o.Quantity = Convert.ToInt16(txtQuantity.Text);
        //                o.Veri_Yaratma_Tarihi = DateTime.Now;
        //                db.OrderDetails.Add(o);
        //                db.SaveChanges();

        //                connection.Close();
        //                MessageBox.Show("Yeni kayıt oluşturuldu", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //                OrderDetailShow();
        //                CleanOrderDetailPage();
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtOrderID.Text == "")
            {
                lblOrderID.ForeColor = Color.Red;
            }
            else
                lblOrderID.ForeColor = Color.Black;

            if (txtProductID.Text == "")
            {
                lblProductID.ForeColor = Color.Red;
            }
            else
                lblProductID.ForeColor = Color.Black;

            if (txtQuantity.Text == "")
            {
                lblQuantity.ForeColor = Color.Red;
            }
            else
                lblQuantity.ForeColor = Color.Black;

            if (txtTotalPrice.Text == "")
            {
                lblTotalPrice.ForeColor = Color.Red;
            }
            else
                lblTotalPrice.ForeColor = Color.Black;

            if (txtProductID.Text != "" && txtOrderID.Text != "" && txtQuantity.Text != "" && txtTotalPrice.Text != "")
            {
                try
                {
                    connection.Open();
                    SqlCommand updateData = new SqlCommand("update OrderDetails set ProductID= '" + Convert.ToInt32(txtProductID.Text) + "', TotalPrice= '" + Convert.ToInt32(txtTotalPrice.Text) + "',Quantity= '" + Convert.ToInt16(txtQuantity.Text) + "', [Veri Durumu] = '" + 2 + "' where OrderID='" + txtOrderID.Text + "'", connection);
                    //TODO: [Veri Güncelleme Tarihi] = '" + DateTime.Now + "'
                    updateData.ExecuteNonQuery();

                    connection.Close();
                    MessageBox.Show("Kayıt Güncellendi", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    OrderDetailShow();
                    CleanOrderDetailPage();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != null)
            {
                bool searchData = false;

                connection.Open();

                SqlCommand selectQuery = new SqlCommand("select * from OrderDetails where OrderID ='" + txtOrderID.Text + "'", connection);
                SqlDataReader dataReader = selectQuery.ExecuteReader();

                while (dataReader.Read())
                {
                    searchData = true;
                    SqlCommand deleteData = new SqlCommand("delete from OrderDetails where ID='" + txtOrderID.Text + "'", connection);
                    deleteData.ExecuteNonQuery();
                    MessageBox.Show("Sipariş Detayı kaydı yok edildi !", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    connection.Close();
                    OrderDetailShow();
                    //CleanOrderPage();
                    break;
                }
                if (searchData == false)
                {
                    MessageBox.Show("Yok edilecek kayıt bulunamadı", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connection.Close();
                    CleanOrderDetailPage();
                }

            }
            else
                MessageBox.Show("Lütfen kayıtlarda olan bir Sipariş ID giriniz !", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CleanOrderDetailPage();
        }

        private void CleanOrderDetailPage()
        {
            txtSearch.Clear(); txtOrderID.Clear(); txtProductID.Clear(); txtQuantity.Clear(); txtTotalPrice.Clear(); 
        }

        private void btnSoftDelete_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand updateData = new SqlCommand("update OrderDetails set [Veri Durumu] = '" + 3 + "' where OrderID='" + txtOrderID.Text + "'", connection);
            //TODO: [Veri Silme Tarihi] = '" + DateTime.Now + "'
            updateData.ExecuteNonQuery();

            connection.Close();
            MessageBox.Show("Kayıt türü silinmiş olarak değiştirildi", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            OrderDetailShow();
            CleanOrderDetailPage();
        }
    }
}
