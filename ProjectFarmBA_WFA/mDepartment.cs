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
    public partial class mDepartment : Form
    {
        ProjectFarmBAEntities db;
        public mDepartment()
        {
            InitializeComponent();
            db = DBTool.DBInstance;
        }
        SqlConnection connection = new SqlConnection("Data Source=LENOVO-PC\\SQLEXPRESS;Initial Catalog=ProjectFarmBA;Integrated Security=True;MultipleActiveResultSets=True");
        private void mDepartment_Load(object sender, EventArgs e)
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
            this.Text = "Departman İşlemleri";
            lblEmployee.ForeColor = Color.Green;
            lblEmployee.Text = Login.name + " " + Login.surname;
            pctDepartment.SizeMode = PictureBoxSizeMode.StretchImage;
            pctDepartment.Width = 100;
            pctDepartment.Height = 100;
            pctDepartment.BorderStyle = BorderStyle.Fixed3D;
            DepartmentShow();
        }

        private void DepartmentShow()
        {
            try
            { 
                connection.Open();
                SqlDataAdapter departmentList = new SqlDataAdapter("select ID , DepartmentName as [Departman], Description as [Açıklama], [Veri Yaratma Tarihi] , [Veri Güncelleme Tarihi] , [Veri Silme Tarihi] ,[Veri Durumu] from Departments", connection);
                DataSet dataSet = new DataSet();
                departmentList.Fill(dataSet);
                dGVDepartment.DataSource = dataSet.Tables[0];

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

        private void CleanDepartmentTabPage()
        {
            pctDepartment.Image = null; txtDepartmentName.Clear(); txtDescription.Clear();
            txtID.Clear();
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog image = new OpenFileDialog();
            image.Title = "Departman resmi seçiniz";
            image.Filter = "JPG (*.jpg) | *.jpg";
            if (image.ShowDialog() == DialogResult.OK)
            {
                this.pctDepartment.Image = new Bitmap(image.OpenFile());
            }
        }
    }
}
