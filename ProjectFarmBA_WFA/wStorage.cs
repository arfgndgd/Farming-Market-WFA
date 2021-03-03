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
    public partial class wStorage : Form
    {
        ProjectFarmBAEntities db;
        public wStorage()
        {
            InitializeComponent();
            db = DBTool.DBInstance;
        }

        SqlConnection connection = new SqlConnection("Data Source=LENOVO-PC\\SQLEXPRESS;Initial Catalog=ProjectFarmBA;Integrated Security=True;MultipleActiveResultSets=True");

        private void wStorage_Load(object sender, EventArgs e)
        {

            //Çalışan resmini ekleme wForm3
            pctEmployee.Height = 180;
            pctEmployee.Width = 180;
            pctEmployee.SizeMode = PictureBoxSizeMode.StretchImage;
            try
            {
                pctEmployee.Image = Image.FromFile(Application.StartupPath + "\\ImageEmployee\\" + Login.tcno + ".jpg");
            }
            catch
            {
                pctEmployee.Image = Image.FromFile(Application.StartupPath + "\\ImageEmployee\\resimyok.jpg");
            }

            //Ambar Ürün İşlemleri Sekmesi
            lblEmployee.ForeColor = Color.Green;
            lblEmployee.Text = Login.name + " " + Login.surname;
            pctStorage.SizeMode = PictureBoxSizeMode.StretchImage;
            pctStorage.Width = 180;
            pctStorage.Height = 180;
            pctStorage.BorderStyle = BorderStyle.Fixed3D;

            StorageShow();
        }
        private void StorageShow()
        {
            try
            {
                connection.Open();
                SqlDataAdapter storageList = new SqlDataAdapter("select ID , ProductName as [Ürün Adı], UnitInPrice as [Fiyat], ImagePath as [Görsel],SupplierID as [Tedarikçi], StorageCategoryID as [Kategori],  [Veri Yaratma Tarihi] , [Veri Güncelleme Tarihi] , [Veri Silme Tarihi] ,[Veri Durumu], TotalWeight as [Toplam Ağırlık] from Storages", connection);
                DataSet dataSet = new DataSet();
                storageList.Fill(dataSet);
                dGVStorage.DataSource = dataSet.Tables[0];

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
            if (txtStorageName.Text.Length > 0)
            {
                connection.Open();
                SqlCommand selectQuery = new SqlCommand("select * from Storages where ProductName = '" + txtStorageName.Text + "'", connection);
                SqlDataReader dataReader = selectQuery.ExecuteReader();

                while (dataReader.Read())
                {
                    searchData = true;
                    lblID.Text = dataReader.GetValue(0).ToString();
                    txtStorageName.Text = dataReader.GetValue(1).ToString();
                    lblUnitPrice.Text = dataReader.GetValue(2).ToString();
                    try
                    {
                        pctStorage.Image = Image.FromFile(Application.StartupPath + "\\ImageStorage\\" + dataReader.GetValue(1).ToString() + ".jpg");

                    }
                    catch
                    {
                        pctStorage.Image = Image.FromFile(Application.StartupPath + "\\ImageStorage\\resimyok.jpg");
                    }
                    lblCategory.Text = dataReader.GetValue(5).ToString();
                    lblSupplier.Text = dataReader.GetValue(4).ToString();
                    lblCreated.Text = dataReader.GetValue(6).ToString();
                    lblUpdated.Text = dataReader.GetValue(7).ToString();
                    lblDeleted.Text = dataReader.GetValue(8).ToString();
                    lblStatus.Text = dataReader.GetValue(9).ToString();
                    lblTotalWeight.Text = dataReader.GetValue(10).ToString();

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
                MessageBox.Show("Lütfen kayıtlarda olan bir Ambar Ürünü ismi giriniz", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
