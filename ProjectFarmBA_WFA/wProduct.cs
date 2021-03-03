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
    public partial class wProduct : Form
    {
        ProjectFarmBAEntities db;

        public wProduct()
        {
            InitializeComponent();
            db = DBTool.DBInstance;

        }

        SqlConnection connection = new SqlConnection("Data Source=LENOVO-PC\\SQLEXPRESS;Initial Catalog=ProjectFarmBA;Integrated Security=True;MultipleActiveResultSets=True");

        private void wProduct_Load(object sender, EventArgs e)
        {
            //Çalışan resmini ekleme wForm3
            pctEmployee.Height = 200;
            pctEmployee.Width = 200;
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
            pctProduct.Width = 200;
            pctProduct.Height = 200;
            pctProduct.BorderStyle = BorderStyle.Fixed3D;

            ProductShow();
        }

        private void ProductShow()
        {
            try
            { //TODO: veriyaratma gibi tarihler yok
                connection.Open();
                SqlDataAdapter productList = new SqlDataAdapter("select ID , ProductName as [Ürün Adı], UnitPrice as [Fiyat], UnitInStock as [Stok], ImagePath as [Görsel], CategoryID as [Kategori], SupplierID as [Tedarikçi], [Veri Yaratma Tarihi] , [Veri Güncelleme Tarihi] , [Veri Silme Tarihi] ,[Veri Durumu], Features as [Özellikler] from Products", connection);
                DataSet dataSet = new DataSet();
                productList.Fill(dataSet);
                dGVProduct.DataSource = dataSet.Tables[0];

                //cmbCategory.DataSource = db.Categories.ToList();
                //cmbCategory.DisplayMember = "CategoryName";

                //cmbSupplier.DataSource = db.Suppliers.ToList();
                //cmbSupplier.DisplayMember = "SupplierName";

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bool searchData = false;
            if (txtProductName.Text.Length > 0)
            {
                connection.Open();
                SqlCommand selectQuery = new SqlCommand("select * from Products where ProductName = '" + txtProductName.Text + "'", connection);
                SqlDataReader dataReader = selectQuery.ExecuteReader();

                while (dataReader.Read())
                {
                    searchData = true;
                    txtProductName.Text = dataReader.GetValue(1).ToString();
                    lblUnitPrice.Text = dataReader.GetValue(2).ToString();
                    lblStock.Text = dataReader.GetValue(3).ToString();
                    try
                    {
                        pctProduct.Image = Image.FromFile(Application.StartupPath + "\\ImageProduct\\" + dataReader.GetValue(1).ToString() + ".jpg");

                    }
                    catch
                    {
                        pctProduct.Image = Image.FromFile(Application.StartupPath + "\\ImageProduct\\resimyok.jpg");
                    }
                    lblCategory.Text = dataReader.GetValue(5).ToString();
                    lblSupplier.Text = dataReader.GetValue(6).ToString();
                    lblCreated.Text = dataReader.GetValue(7).ToString();
                    lblUpdated.Text = dataReader.GetValue(8).ToString();
                    lblDeleted.Text = dataReader.GetValue(9).ToString();
                    lblStatus.Text = dataReader.GetValue(10).ToString();
                    lblFeatures.Text = dataReader.GetValue(11).ToString();

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
                MessageBox.Show("Lütfen kayıtlarda olan bir Ürün ismi giriniz", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
