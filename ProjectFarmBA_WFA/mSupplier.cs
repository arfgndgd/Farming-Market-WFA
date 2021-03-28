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
    public partial class mSupplier : Form
    {
        ProjectFarmBAEntities db;
        public mSupplier()
        {
            InitializeComponent();
            db = DBTool.DBInstance;
        }

        SqlConnection connection = new SqlConnection("Data Source=LENOVO-PC\\SQLEXPRESS;Initial Catalog=ProjectFarmBA;Integrated Security=True;MultipleActiveResultSets=True");
        private void mSupplier_Load(object sender, EventArgs e)
        {
            //Çalışan resmini ekleme Form3
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

            //Tedarikçi İşlemleri Sekmesi
            this.Text = "Tedarikçi İşlemleri";
            lblEmployee.ForeColor = Color.Green;
            lblEmployee.Text = Login.name + " " + Login.surname;
            pctSupplier.SizeMode = PictureBoxSizeMode.StretchImage;
            pctSupplier.Width = 100;
            pctSupplier.Height = 100;
            pctSupplier.BorderStyle = BorderStyle.Fixed3D;
            SupplierShow();
        }
        private void SupplierShow()
        {
            try
            {
                connection.Open();
                SqlDataAdapter supplierList = new SqlDataAdapter("select ID , SupplierName as [Tedarikçi], Address as [Adres], City as [Şehir], Country as [Ülke], Phone as [Telefon], Email as [E-Posta], [Veri Yaratma Tarihi] , [Veri Güncelleme Tarihi] , [Veri Silme Tarihi] ,[Veri Durumu] from Suppliers", connection);
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

        private void CleanSupplierTabPage()
        {
            pctSupplier.Image = null; txtSupplierName.Clear(); txtAddress.Clear(); txtCity.Clear(); txtCountry.Clear(); txtPhone.Clear(); txtEmail.Clear();
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog image = new OpenFileDialog();
            image.Title = "Tedarikçi resmi seçiniz";
            image.Filter = "JPG (*.jpg) | *.jpg";
            if (image.ShowDialog() == DialogResult.OK)
            {
                this.pctSupplier.Image = new Bitmap(image.OpenFile());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool dataCheck = false;

            connection.Open();
            SqlCommand selectQuery = new SqlCommand("select * from Suppliers where SupplierName ='" + txtSupplierName.Text + "'", connection);
            SqlDataReader dataReader = selectQuery.ExecuteReader();
            while (dataReader.Read())
            {
                dataCheck = true;
                break;
            }
            connection.Close();
            if (dataCheck == false)
            {
                if (txtSupplierName.Text == "")
                {
                    lblSupplier.ForeColor = Color.Red;
                }
                else
                    lblSupplier.ForeColor = Color.Black;

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

                if (txtPhone.Text.Length < 10 || txtPhone.Text == "")
                {
                    lblPhone.ForeColor = Color.Red;
                }
                else
                    lblPhone.ForeColor = Color.Black;

                if (txtEmail.Text == "")
                {
                    lblEmail.ForeColor = Color.Red;
                }
                else
                    lblEmail.ForeColor = Color.Black;

                if (/*pctCategory.Image !=  null &&*/ txtSupplierName.Text != "" && txtAddress.Text != "" && txtCity.Text != "" && txtCountry.Text != "" && txtEmail.Text != "" && txtPhone.Text != "" && txtPhone.Text.Length == 10)
                {
                    try
                    {
                        connection.Open();

                        Supplier s = new Supplier();
                        s.SupplierName = txtSupplierName.Text;
                        s.Address = txtAddress.Text;
                        s.City = txtCity.Text;
                        s.Country = txtCountry.Text;
                        s.Phone = txtPhone.Text;
                        s.Email = txtEmail.Text;
                        s.Veri_Yaratma_Tarihi = DateTime.Now;
                        s.Veri_Durumu = 1;
                        db.Suppliers.Add(s);
                        db.SaveChanges();

                        connection.Close();

                        //resmi debug içinde kaydetme
                        //if (!Directory.Exists(Application.StartupPath + "\\ImageCategory"))
                        //    Directory.CreateDirectory(Application.StartupPath + "\\ImageCategory");
                        //pctCategory.Image.Save(Application.StartupPath + "\\ImageCategory\\" + txtCategoryName.Text + ".jpg");

                        MessageBox.Show("Yeni kayıt oluşturuldu", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        SupplierShow();
                        CleanSupplierTabPage();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Girilen Tedarikçi daha önceden kayıtlıdır", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtSupplierName.Text == "")
            {
                lblSupplier.ForeColor = Color.Red;
            }
            else
                lblSupplier.ForeColor = Color.Black;

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

            if (txtPhone.Text == "")
            {
                lblPhone.ForeColor = Color.Red;
            }
            else
                lblPhone.ForeColor = Color.Black;

            if (txtEmail.Text == "")
            {
                lblEmail.ForeColor = Color.Red;
            }
            else
                lblEmail.ForeColor = Color.Black;

            if (/*pctCategory.Image !=  null &&*/ txtSupplierName.Text != "" && txtAddress.Text != "" && txtCity.Text != "" && txtCountry.Text != "" && txtEmail.Text != "" && txtPhone.Text != "")
            {
                try
                {
                    connection.Open();

                    SqlCommand updateData = new SqlCommand("update Suppliers set  Address='" + txtAddress.Text + "', City='" + txtCity.Text + "', Country='" + txtCountry.Text + "', Phone='" + txtPhone.Text + "', Email='" + txtEmail.Text + "', [Veri Durumu] = '" + 2 + "' where SupplierName='" + txtSupplierName.Text + "'", connection); //TODO: [Veri Güncelleme Tarihi] = '" + DateTime.Now + "'
                    updateData.ExecuteNonQuery();
                    connection.Close();

                    //resmi debug içinde kaydetme
                    //if (!Directory.Exists(Application.StartupPath + "\\ImageCategory"))
                    //    Directory.CreateDirectory(Application.StartupPath + "\\ImageCategory");
                    //pctCategory.Image.Save(Application.StartupPath + "\\ImageCategory\\" + txtCategoryName.Text + ".jpg");

                    MessageBox.Show("Kayıt Güncellendi", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    SupplierShow();
                    CleanSupplierTabPage();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connection.Close();
                }
            }

            else
            {
                MessageBox.Show("Zorunlu alanları doldurunuz", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bool searchData = false;
            if (txtSupplierName.Text.Length > 0)
            {
                connection.Open();
                SqlCommand selectQuery = new SqlCommand("select * from Suppliers where SupplierName = '" + txtSupplierName.Text + "'", connection);
                SqlDataReader dataReader = selectQuery.ExecuteReader();

                while (dataReader.Read())
                {
                    searchData = true;
                    lblID.Text = dataReader.GetValue(0).ToString();
                    txtSupplierName.Text = dataReader.GetValue(1).ToString();
                    txtAddress.Text = dataReader.GetValue(2).ToString();
                    txtCity.Text = dataReader.GetValue(3).ToString();
                    txtCountry.Text = dataReader.GetValue(4).ToString();
                    txtPhone.Text = dataReader.GetValue(5).ToString();
                    txtEmail.Text = dataReader.GetValue(6).ToString();
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
                MessageBox.Show("Lütfen kayıtlarda olan bir Tedarikçi ismi giriniz", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CleanSupplierTabPage();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtSupplierName.Text != null)
            {
                bool searchData = false;

                connection.Open();

                SqlCommand selectQuery = new SqlCommand("select * from Suppliers where SupplierName='" + txtSupplierName.Text + "'", connection);
                SqlDataReader dataReader = selectQuery.ExecuteReader();
                while (dataReader.Read())
                {
                    searchData = true;
                    SqlCommand deleteData = new SqlCommand("delete from Suppliers where SupplierName='" + txtSupplierName.Text + "'", connection);
                    deleteData.ExecuteNonQuery();
                    MessageBox.Show("Tedarikçi kaydı silindi !", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    connection.Close();
                    SupplierShow();
                    CleanSupplierTabPage();
                    break;
                }
                if (searchData == false)
                {
                    MessageBox.Show("Silinecek kayıt bulunamadı", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connection.Close();
                    CleanSupplierTabPage();
                }

            }
            else
                MessageBox.Show("Lütfen kayıtlarda bulunan bir Tedarikçi ismi giriniz !", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CleanSupplierTabPage();
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
    }
}
