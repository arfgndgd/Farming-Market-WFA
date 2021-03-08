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
    public partial class mCustomer : Form
    {
        ProjectFarmBAEntities db;
        public mCustomer()
        {
            InitializeComponent();
            db = DBTool.DBInstance;
        }

        //TODO: Customer Storage elden alışveriş hallet

        SqlConnection connection = new SqlConnection("Data Source=LENOVO-PC\\SQLEXPRESS;Initial Catalog=ProjectFarmBA;Integrated Security=True;MultipleActiveResultSets=True");

        private void mCustomer_Load(object sender, EventArgs e)
        {
            //Çalışan resmini ekleme
            //Form2
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

            //Çalışan İşlemleri Sekmesi
            this.Text = "Müşteri İşlemleri";
            lblEmployee.ForeColor = Color.Green;
            lblEmployee.Text = Login.name + " " + Login.surname;

            CustomerShow();
        }

        private void CustomerShow()
        {
            try
            {
                connection.Open();
                SqlDataAdapter customerList = new SqlDataAdapter("select ID,  FirstName as [Ad], LastName as [Soyad], Phone as [Telefon], Email as [E-Posta], Address as [Adres], [Veri Yaratma Tarihi] , [Veri Güncelleme Tarihi] , [Veri Silme Tarihi] ,[Veri Durumu] from Customers", connection);
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

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void CleanCustomerTabPage()
        {
            txtSearch.Clear(); txtFirstName.Clear(); txtLastName.Clear(); txtEmail.Clear(); txtPhone.Clear(); txtAddress.Clear(); 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool dataCheck = false;

            connection.Open();
            SqlCommand selectQuery = new SqlCommand("select * from Customers where Phone='" + txtPhone.Text + "'", connection);
            SqlDataReader dataReader = selectQuery.ExecuteReader();
            while (dataReader.Read())
            {
                dataCheck = true;
                break;
            }

            connection.Close();

            if (dataCheck == false)
            {
                //Ad 
                if (txtFirstName.Text.Length < 2 || txtFirstName.Text == "")
                {
                    lblFirstName.ForeColor = Color.Red;
                }
                else
                    lblFirstName.ForeColor = Color.Black;

                //soyad
                if (txtLastName.Text.Length < 2 || txtLastName.Text == "")
                {
                    lblLastName.ForeColor = Color.Red;
                }
                else
                    lblLastName.ForeColor = Color.Black;

                //telefon
                if (txtPhone.Text.Length < 10 || txtPhone.Text == "")
                {
                    lblPhone.ForeColor = Color.Red;
                }
                else
                    lblPhone.ForeColor = Color.Black;

                //Adres
                if (txtAddress.Text == "")
                {
                    lblAdress.ForeColor = Color.Red;
                }
                else
                    lblAdress.ForeColor = Color.Black;

                //Email
                if (txtEmail.Text == "")
                {
                    lblEmail.ForeColor = Color.Red;
                }
                else
                    lblEmail.ForeColor = Color.Black;

                if (txtFirstName.Text != "" && txtFirstName.Text.Length > 1 && txtLastName.Text != "" && txtLastName.Text.Length > 1 && txtEmail.Text != "" && txtPhone.Text.Length == 10 && txtPhone.Text != "" && txtAddress.Text != "" )
                {
                    try
                    {
                        connection.Open();

                        Customer c = new Customer();
                        c.Phone = txtPhone.Text;
                        c.FirstName = txtFirstName.Text;
                        c.LastName = txtLastName.Text;
                        c.Email = txtEmail.Text;
                        c.Address = txtAddress.Text;
                        c.Veri_Yaratma_Tarihi = DateTime.Now;
                        db.Customers.Add(c);
                        db.SaveChanges();


                        connection.Close();
                        MessageBox.Show("Yeni kayıt oluşturuldu", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        CustomerShow();
                        CleanCustomerTabPage();
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
            else
            {
                MessageBox.Show("Müşteri kaydı için girilen Müşteri Tel No kayıtlıdır", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    lblID.Text = dataReader.GetValue(0).ToString();
                    txtFirstName.Text = dataReader.GetValue(1).ToString();
                    txtLastName.Text = dataReader.GetValue(2).ToString();
                    txtEmail.Text = dataReader.GetValue(4).ToString();
                    txtPhone.Text = dataReader.GetValue(3).ToString();
                    txtAddress.Text = dataReader.GetValue(5).ToString();
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
                CleanCustomerTabPage();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Ad 
            if (txtFirstName.Text.Length < 2 || txtFirstName.Text == "")
            {
                lblFirstName.ForeColor = Color.Red;
            }
            else
                lblFirstName.ForeColor = Color.Black;

            //soyad
            if (txtLastName.Text.Length < 2 || txtLastName.Text == "")
            {
                lblLastName.ForeColor = Color.Red;
            }
            else
                lblLastName.ForeColor = Color.Black;

            //telefon
            if (txtPhone.Text.Length < 10 || txtPhone.Text == "")
            {
                lblPhone.ForeColor = Color.Red;
            }
            else
                lblPhone.ForeColor = Color.Black;

            //Adres
            if (txtAddress.Text == "")
            {
                lblAdress.ForeColor = Color.Red;
            }
            else
                lblAdress.ForeColor = Color.Black;

            //Email
            if (txtEmail.Text == "")
            {
                lblEmail.ForeColor = Color.Red;
            }
            else
                lblEmail.ForeColor = Color.Black;

            if (txtFirstName.Text != "" && txtFirstName.Text.Length > 1 && txtLastName.Text != "" && txtLastName.Text.Length > 1 && txtEmail.Text != "" && txtPhone.Text.Length == 10 && txtPhone.Text != "" && txtAddress.Text != "")
            { 
                try
                {
                    connection.Open();
                    SqlCommand updateData = new SqlCommand("update Customers set FirstName='" + txtFirstName.Text + "', LastName= '" + txtLastName.Text + "', Email= '" + txtEmail.Text + "', Address= '" + txtAddress.Text + "', [Veri Güncelleme Tarihi] = '" + DateTime.Now + "' where Phone='" + txtPhone.Text + "'", connection);

                    updateData.ExecuteNonQuery();

                    connection.Close();
                    MessageBox.Show("Kayıt Güncellendi", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    CustomerShow();
                    CleanCustomerTabPage();
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
            if (txtSearch.Text.Length == 10)
            {
                bool searchData = false;

                connection.Open();

                SqlCommand selectQuery = new SqlCommand("select * from Customers where Phone='" + txtSearch.Text + "'", connection);
                SqlDataReader dataReader = selectQuery.ExecuteReader();

                while (dataReader.Read())
                {
                    searchData = true;
                    SqlCommand deleteData = new SqlCommand("delete from Customers where Phone='" + txtPhone.Text + "'", connection);
                    deleteData.ExecuteNonQuery();
                    MessageBox.Show("Müşteri kaydı silindi !", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    connection.Close();
                    CustomerShow();
                    CleanCustomerTabPage();
                    break;
                }
                if (searchData == false)
                {
                    MessageBox.Show("Silinecek kayıt bulunamadı", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connection.Close();
                    CleanCustomerTabPage();
                }

            }
            else
                MessageBox.Show("Lütfen 10 haneli bir Telefon No giriniz !", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CleanCustomerTabPage();
        }
    }
}
