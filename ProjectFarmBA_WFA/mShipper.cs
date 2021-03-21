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
    public partial class mShipper : Form
    {
        ProjectFarmBAEntities db;
        public mShipper()
        {
            InitializeComponent();
            db = DBTool.DBInstance;
        }

        SqlConnection connection = new SqlConnection("Data Source=LENOVO-PC\\SQLEXPRESS;Initial Catalog=ProjectFarmBA;Integrated Security=True;MultipleActiveResultSets=True");

        private void mShipper_Load(object sender, EventArgs e)
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

            //Ürün İşlemleri Sekmesi
            this.Text = "Kargo/Nakliye Firması İşlemleri";
            lblEmployee.ForeColor = Color.Green;
            lblEmployee.Text = Login.name + " " + Login.surname;
            pctShipper.SizeMode = PictureBoxSizeMode.StretchImage;
            pctShipper.Width = 100;
            pctShipper.Height = 100;
            pctShipper.BorderStyle = BorderStyle.Fixed3D;
            ShipperShow();
        }
        private void ShipperShow()
        {
            try
            {
                connection.Open();
                SqlDataAdapter shipperList = new SqlDataAdapter("select ID , ShipperName as [Kategori], Phone as [Telefon], Email as [E-Mail], [Veri Yaratma Tarihi] , [Veri Güncelleme Tarihi] , [Veri Silme Tarihi] ,[Veri Durumu] from Shippers", connection);
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

        private void CleanShipperTabPage()
        {
            pctShipper.Image = null; txtCompanyName.Clear(); txtPhone.Clear(); txtEmail.Clear();
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog image = new OpenFileDialog();
            image.Title = "Firma resmi seçiniz";
            image.Filter = "JPG (*.jpg) | *.jpg";
            if (image.ShowDialog() == DialogResult.OK)
            {
                this.pctShipper.Image = new Bitmap(image.OpenFile());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool dataCheck = false;

            connection.Open();
            SqlCommand selectQuery = new SqlCommand("select * from Shippers where ShipperName ='" + txtCompanyName.Text + "'", connection);
            SqlDataReader dataReader = selectQuery.ExecuteReader();
            while (dataReader.Read())
            {
                dataCheck = true;
                break;
            }
            connection.Close();
            if (dataCheck == false)
            {
                if (txtCompanyName.Text == "")
                {
                    lblCompanyName.ForeColor = Color.Red;
                }
                else
                    lblCompanyName.ForeColor = Color.Black;

                if (txtEmail.Text == "")
                {
                    lblEmail.ForeColor = Color.Red;
                }
                else
                    lblEmail.ForeColor = Color.Black;

                if (txtPhone.Text.Length < 10 || txtPhone.Text == "")
                {
                    lblPhone.ForeColor = Color.Red;
                }
                else
                    lblPhone.ForeColor = Color.Black;

                if (/*pctCategory.Image !=  null &&*/ txtCompanyName.Text != "" && txtEmail.Text != "" && txtPhone.Text != "" && txtPhone.Text.Length == 10)
                {
                    try
                    {
                        connection.Open();

                        Shipper s = new Shipper();
                        s.ShipperName = txtCompanyName.Text;
                        s.Email = txtEmail.Text;
                        s.Phone = txtPhone.Text;
                        s.Veri_Yaratma_Tarihi = DateTime.Now;
                        //TODO: soft delete ve veri durumu lazım 
                        s.Veri_Durumu = 1;
                        db.Shippers.Add(s);
                        db.SaveChanges();

                        connection.Close();

                        //resmi debug içinde kaydetme
                        //if (!Directory.Exists(Application.StartupPath + "\\ImageCategory"))
                        //    Directory.CreateDirectory(Application.StartupPath + "\\ImageCategory");
                        //pctCategory.Image.Save(Application.StartupPath + "\\ImageCategory\\" + txtCategoryName.Text + ".jpg");

                        MessageBox.Show("Yeni kayıt oluşturuldu", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        ShipperShow();
                        CleanShipperTabPage();
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
                MessageBox.Show("Girilen Firma daha önceden kayıtlıdır", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    txtPhone.Text = dataReader.GetValue(2).ToString();
                    txtEmail.Text = dataReader.GetValue(3).ToString();

                    try
                    {
                        pctShipper.Image = Image.FromFile(Application.StartupPath + "\\ImageShipper\\" + dataReader.GetValue(1).ToString() + ".jpg");

                    }
                    catch
                    {
                        pctShipper.Image = Image.FromFile(Application.StartupPath + "\\ImageShipper\\resimyok.jpg");
                    }
                    lblCreated.Text = dataReader.GetValue(4).ToString();
                    lblUpdated.Text = dataReader.GetValue(5).ToString();
                    lblDeleted.Text = dataReader.GetValue(6).ToString();
                    lblStatus.Text = dataReader.GetValue(7).ToString();
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
                MessageBox.Show("Lütfen kayıtlarda olan bir Firma ismi giriniz", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CleanShipperTabPage();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (pctShipper.Image == null)
                btnAddImage.ForeColor = Color.Red;
            else
                btnAddImage.ForeColor = Color.Black;

            if (txtCompanyName.Text == "")
            {
                lblCompanyName.ForeColor = Color.Red;
            }
            else
                lblCompanyName.ForeColor = Color.Black;

            if (txtEmail.Text == "")
            {
                lblEmail.ForeColor = Color.Red;
            }
            else
                lblEmail.ForeColor = Color.Black;

            if (txtPhone.Text == "" || txtPhone.Text.Length < 10 )
            {
                lblPhone.ForeColor = Color.Red;
            }
            else
                lblPhone.ForeColor = Color.Black;

            if (/*pctCategory.Image !=  null &&*/ txtCompanyName.Text != "" && txtPhone.Text != "" && txtEmail.Text != "" && txtPhone.Text.Length == 10)
            {
                try
                {
                    connection.Open();
                    
                    SqlCommand updateData = new SqlCommand("update Shippers set  Phone='" + txtPhone.Text + "',Email='" + txtEmail.Text + "', [Veri Güncelleme Tarihi] = '" +DateTime.Now +"' where ShipperName='" + txtCompanyName.Text + "'", connection);
                    updateData.ExecuteNonQuery();
                    connection.Close();

                    //resmi debug içinde kaydetme
                    //if (!Directory.Exists(Application.StartupPath + "\\ImageCategory"))
                    //    Directory.CreateDirectory(Application.StartupPath + "\\ImageCategory");
                    //pctCategory.Image.Save(Application.StartupPath + "\\ImageCategory\\" + txtCategoryName.Text + ".jpg");

                    MessageBox.Show("Kayıt Güncellendi", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ShipperShow();
                    CleanShipperTabPage();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtCompanyName.Text != null)
            {
                bool searchData = false;

                connection.Open();

                SqlCommand selectQuery = new SqlCommand("select * from Shippers where ShipperName='" + txtCompanyName.Text + "'", connection);
                SqlDataReader dataReader = selectQuery.ExecuteReader();
                while (dataReader.Read())
                {
                    searchData = true;
                    SqlCommand deleteData = new SqlCommand("delete from Shippers where ShipperName='" + txtCompanyName.Text + "'", connection);
                    deleteData.ExecuteNonQuery();
                    MessageBox.Show("Firma kaydı silindi !", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    connection.Close();
                    ShipperShow();
                    CleanShipperTabPage();
                    break;
                }
                if (searchData == false)
                {
                    MessageBox.Show("Silinecek kayıt bulunamadı", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connection.Close();
                    CleanShipperTabPage();
                }

            }
            else
                MessageBox.Show("Lütfen kayıtlarda bulunan bir Firma ismi giriniz !", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CleanShipperTabPage();
        }

        private void txtCompanyName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8 || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true|| char.IsPunctuation(e.KeyChar) == true)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
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

        

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            if (txtPhone.Text.Length != 3)
                errorProvider1.SetError(txtPhone, "Lütfen 10 haneli bir telefon no giriniz");
            else
                errorProvider1.Clear();
        }
    }
}
