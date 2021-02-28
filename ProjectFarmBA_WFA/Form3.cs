using ProjectFarmBA_WFA.DesingPatterns.SingletonPattern;
using ProjectFarmBA_WFA.ModelContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectFarmBA_WFA
{
    public partial class Form3 : Form
    {
        ProjectFarmBAEntities db;
        public Form3()
        {
            InitializeComponent();
            db = DBTool.DBInstance;
        }

        SqlConnection connection = new SqlConnection("Data Source=LENOVO-PC\\SQLEXPRESS;Initial Catalog=ProjectFarmBA;Integrated Security=True");

        private void ProductShow()
        {
            try
            { //TODO: veriyaratma gibi tarihler yok
                connection.Open();
                SqlDataAdapter productList = new SqlDataAdapter("select ID , ProductName as [Ürün Adı], UnitPrice as [Fiyat], UnitInStock as [Stok], ImagePath as [Görsel], CategoryID as [Kategori], SupplierID as [Tedarikçi], Features as [Özellikler] from Products", connection);
                DataSet dataSet = new DataSet();
                productList.Fill(dataSet);
                dGVProduct.DataSource = dataSet.Tables[0];

                cmbCategory.DataSource = db.Categories.ToList();
                cmbCategory.DisplayMember = "CategoryName";

                cmbSupplier.DataSource = db.Suppliers.ToList();
                cmbSupplier.DisplayMember = "SupplierName";

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
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
            this.Text = "Ürün İşlemleri";
            lblEmployee.ForeColor = Color.Green;
            lblEmployee.Text = Login.name + " " + Login.surname;
            pctProduct.SizeMode = PictureBoxSizeMode.StretchImage;
            pctProduct.Width = 100;
            pctProduct.Height = 100;
            pctProduct.BorderStyle = BorderStyle.Fixed3D;
            //try
            //{
            //    pctProduct.Image = Image.FromFile(Application.StartupPath + "\\ImageProduct\\"+ Login.photo + ".jpg");
            //}
            //catch (Exception)
            //{
            //    pctProduct.Image = Image.FromFile(Application.StartupPath + "\\ImageProduct\\urunresimyok.jpg");
            //}
            //TODO: ürün resmi
            

            ProductShow();
        }

        //Product sekmesi
        private void CleanProductTabPage()
        {
            pctProduct.Image = null; txtProductName.Clear(); txtUnitPrice.Clear(); txtStock.Clear(); txtFeatures.Clear(); cmbSupplier.SelectedIndex = -1; cmbCategory.SelectedIndex = -1;
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog image = new OpenFileDialog();
            image.Title = "Ürün resmi seçiniz";
            image.Filter = "JPG (*.jpg) | *.jpg";
            if (image.ShowDialog() == DialogResult.OK)
            {
                this.pctProduct.Image = new Bitmap(image.OpenFile()); //Bitmap: görsel tanımlamak için kullanılıyor.
            }
        } //Fotoğraf ekleme

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool dataCheck = false;

            connection.Open();
            SqlCommand selectQuery = new SqlCommand("select * from Products where ProductName ='" +txtProductName.Text +"'", connection);
            SqlDataReader dataReader = selectQuery.ExecuteReader();
            while (dataReader.Read())
            {
                dataCheck = true;
                break;
            }
            connection.Close();

            if (dataCheck == false)
            {
                //fotoğraf
                if (pctProduct.Image == null)
                    btnAddImage.ForeColor = Color.Red;
                else
                    btnAddImage.ForeColor = Color.Black;

                //isim
                if (txtProductName.Text == "")
                    lblProductName.ForeColor = Color.Red;
                else
                    lblProductName.ForeColor = Color.Black;

                //fiyat
                if (txtUnitPrice.Text == "")
                    lblUnitPrice.ForeColor = Color.Red;
                else
                    lblUnitPrice.ForeColor = Color.Black;

                //stok
                if (txtStock.Text == "")
                    lblStock.ForeColor = Color.Red;
                else
                    lblStock.ForeColor = Color.Black;

                //özellikler
                if (txtFeatures.Text == "")
                    lblFeatures.ForeColor = Color.Red;
                else
                    lblFeatures.ForeColor = Color.Black;

                //tedarikçi
                if (cmbSupplier.Text == "")
                    lblSupplier.ForeColor = Color.Red;
                else
                    lblSupplier.ForeColor = Color.Black;

                //Kategori
                if (cmbCategory.Text == "")
                    lblCategory.ForeColor = Color.Red;
                else
                    lblCategory.ForeColor = Color.Black;

                if (pctProduct.Image != null && txtProductName.Text != "" && txtUnitPrice.Text != "" && txtStock.Text != "" && txtFeatures.Text != "" && cmbCategory.Text != "" && cmbSupplier.Text != "")
                {
                    try
                    {
                        connection.Open();

                        Product p = new Product();
                        p.ProductName = txtProductName.Text;
                        p.UnitPrice = Convert.ToInt32(txtUnitPrice.Text);
                        p.UnitInStock = Convert.ToInt16(txtStock.Text);
                        p.Features = txtFeatures.Text;
                        p.SupplierID = cmbSupplier.SelectedItem != null ? (cmbSupplier.SelectedItem as Supplier).ID : default(int?);
                        p.CategoryID = cmbCategory.SelectedItem != null ? (cmbCategory.SelectedItem as Category).ID : default(int?);
                        db.Products.Add(p);
                        db.SaveChanges();

                        connection.Close();

                        //resmi debug içinde kaydetme
                        if (!Directory.Exists(Application.StartupPath + "\\ImageProduct"))
                        {
                            Directory.CreateDirectory(Application.StartupPath + "\\ImageProduct");
                        }
                        else
                        {
                            pctProduct.Image.Save(Application.StartupPath + "\\ImageProduct" + txtProductName.Text+ ".jpg");
                        }

                        MessageBox.Show("Yeni kayıt oluşturuldu", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        ProductShow();
                        CleanProductTabPage();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Farming Market", MessageBoxButtons.OK,MessageBoxIcon.Error);
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
                MessageBox.Show("Girilen Ürün daha önceden kayıtlıdır", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
