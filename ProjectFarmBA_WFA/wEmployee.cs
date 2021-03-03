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
    public partial class wEmployee : Form
    {
        ProjectFarmBAEntities db;
        public wEmployee()
        {
            InitializeComponent();
            db = DBTool.DBInstance;
        }

        SqlConnection connection = new SqlConnection("Data Source=LENOVO-PC\\SQLEXPRESS;Initial Catalog=ProjectFarmBA;Integrated Security=True;MultipleActiveResultSets=True");
        
        private void wEmployee_Load(object sender, EventArgs e)
        {
            //Çalışan resmini ekleme
            //wForm2
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

            //Çalışan İşlemleri Sekmesi
            this.Text = "Çalışan İşlemleri";
            lblEmployee.ForeColor = Color.Green;
            lblEmployee.Text = Login.name + " " + Login.surname;


            //Data Employee Pic
            pctDataEmployee.Height = 180;
            pctDataEmployee.Width = 180;
            pctDataEmployee.SizeMode = PictureBoxSizeMode.StretchImage;
            EmployeeShow();
        }

        private void EmployeeShow()
        {
            try
            {
                connection.Open();
                SqlDataAdapter employeeList = new SqlDataAdapter("select ID, TCNO as [Tc Kimlik No], Password as [Parola], FirstName as [Ad], LastName as [Soyad], Email as [E-Posta], Phone as [Telefon], Address as [Adres], City as [Şehir], ERole as [Yetki], DepartmentID as [Departman], Gender as [Cinsiyet], [Veri Yaratma Tarihi] , [Veri Güncelleme Tarihi] , [Veri Silme Tarihi] ,[Veri Durumu]  from Employees", connection);
                DataSet dataSet = new DataSet();
                employeeList.Fill(dataSet);
                dGVEmployee.DataSource = dataSet.Tables[0];

                //cmbDepartment.DataSource = db.Departments.ToList();
                //cmbDepartment.DisplayMember = "DepartmentName";

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
            if (txtTcNo.Text.Length == 11)
            {
                connection.Open();
                SqlCommand selectQuery = new SqlCommand("select * from Employees where TCNO ='" + txtTcNo.Text + "'", connection);
                SqlDataReader dataReader = selectQuery.ExecuteReader();

                while (dataReader.Read())
                {
                    searchData = true;
                    txtTcNo.Text = dataReader.GetValue(8).ToString();
                    lblFirstName.Text = dataReader.GetValue(1).ToString();
                    lblLastName.Text = dataReader.GetValue(2).ToString();
                    lblEmail.Text = dataReader.GetValue(3).ToString();
                    lblPhone.Text = dataReader.GetValue(4).ToString();
                    try
                    {
                        pctDataEmployee.Image = Image.FromFile(Application.StartupPath + "\\ImageEmployee\\" + dataReader.GetValue(8).ToString() + ".jpg");

                    }
                    catch
                    {
                        pctDataEmployee.Image = Image.FromFile(Application.StartupPath + "\\ImageEmployee\\resimyok.jpg");
                    }
                    lblGender.Text = dataReader.GetValue(11).ToString();
                    lblAdress.Text = dataReader.GetValue(5).ToString();
                    lblCity.Text = dataReader.GetValue(6).ToString();
                    lblAuthory.Text = dataReader.GetValue(9).ToString();
                    lblDepartment.Text = dataReader.GetValue(10).ToString();
                    lblPassword.Text = dataReader.GetValue(12).ToString();
                    lblCreated.Text = dataReader.GetValue(13).ToString();
                    lblUpdated.Text = dataReader.GetValue(14).ToString();
                    lblDeleted.Text = dataReader.GetValue(15).ToString();
                    lblStatus.Text = dataReader.GetValue(16).ToString();

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
                MessageBox.Show("Lütfen 11 haneli bir Tc Kimlik No kaydı giriniz", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        
    }
}
