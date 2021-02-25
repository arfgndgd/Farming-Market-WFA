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
            //Çalışan resmini ekleme
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
            this.Text = "Çalışan İşlemleri";
            lblEmployee.ForeColor = Color.Green;
            lblEmployee.Text = Login.name + " " + Login.surname;


            //Ürün İşlemleri Sekmesi
            pctProduct.SizeMode = PictureBoxSizeMode.StretchImage;
            pctProduct.Width = 100;
            pctProduct.Height = 100;
            pctProduct.BorderStyle = BorderStyle.Fixed3D;
            mtxtProductName.Mask = "LL????????????????????"; //iki karakter zorunlu soru işareti sayısı kadar da limit var
            mtxtProductName.Text.ToUpper();

            ProductShow();
        }

        //Product sekmesi
        private void CleanProductTabPage()
        {
            pctProduct.Image = null; mtxtProductName.Clear(); mtxtUnitPrice.Clear(); mtxtUnitInStock.Clear(); mtxtFeatures.Clear(); cmbSupplier.SelectedIndex = -1; cmbCategory.SelectedIndex = -1;
        }
    }
}
