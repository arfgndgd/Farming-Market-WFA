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
    public partial class wDepartment : Form
    {
        ProjectFarmBAEntities db;
        public wDepartment()
        {
            InitializeComponent();
            db = DBTool.DBInstance;
        }

        SqlConnection connection = new SqlConnection("Data Source=LENOVO-PC\\SQLEXPRESS;Initial Catalog=ProjectFarmBA;Integrated Security=True;MultipleActiveResultSets=True");

        private void wDepartment_Load(object sender, EventArgs e)
        {
            //Çalışan resmini ekleme wForm3
            pctEmployee.Height = 200;
            pctEmployee.Width = 200;
            pctEmployee.SizeMode = PictureBoxSizeMode.StretchImage;
            lblEmployee.ForeColor = Color.Green;
            lblEmployee.Text = Login.name + " " + Login.surname;

            try
            {
                pctEmployee.Image = Image.FromFile(Application.StartupPath + "\\ImageEmployee\\" + Login.tcno + ".jpg");
            }
            catch
            {
                pctEmployee.Image = Image.FromFile(Application.StartupPath + "\\ImageEmployee\\resimyok.jpg");
            }

            //Kategori İşlemleri Sekmesi

            pctDepartment.SizeMode = PictureBoxSizeMode.StretchImage;
            pctDepartment.Width = 200;
            pctDepartment.Height = 200;
            pctDepartment.BorderStyle = BorderStyle.Fixed3D;

            DepartmentShow();
        }

        private void DepartmentShow()
        {
            try
            {
                connection.Open();
                SqlDataAdapter departmentList = new SqlDataAdapter("select ID , DepartmentName as [Deparman Adı], Description as [Açıklama], [Veri Yaratma Tarihi] , [Veri Güncelleme Tarihi] , [Veri Silme Tarihi] ,[Veri Durumu] from Departments", connection);
                DataSet dataSet = new DataSet();
                departmentList.Fill(dataSet);
                dGVDepartment.DataSource = dataSet.Tables[0];


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
            if (txtDepartmentName.Text.Length > 0)
            {
                connection.Open();
                SqlCommand selectQuery = new SqlCommand("select * from Categories where CategoryName = '" + txtDepartmentName.Text + "'", connection);
                SqlDataReader dataReader = selectQuery.ExecuteReader();

                while (dataReader.Read())
                {
                    searchData = true;
                    lblID.Text = dataReader.GetValue(0).ToString();
                    txtDepartmentName.Text = dataReader.GetValue(1).ToString();
                    lblDescription.Text = dataReader.GetValue(2).ToString();
                    try
                    {
                        pctDepartment.Image = Image.FromFile(Application.StartupPath + "\\ImageDepartment\\" + dataReader.GetValue(1).ToString() + ".jpg");

                    }
                    catch
                    {
                        pctDepartment.Image = Image.FromFile(Application.StartupPath + "\\ImageDepartment\\resimyok.jpg");
                    }
                    lblCreated.Text = dataReader.GetValue(3).ToString();
                    lblUpdated.Text = dataReader.GetValue(4).ToString();
                    lblDeleted.Text = dataReader.GetValue(5).ToString();
                    lblStatus.Text = dataReader.GetValue(6).ToString();

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
                MessageBox.Show("Lütfen kayıtlarda olan bir Departman ismi giriniz", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
