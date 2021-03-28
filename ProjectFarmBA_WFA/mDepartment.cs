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

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool dataCheck = false;

            connection.Open();
            SqlCommand selectQuery = new SqlCommand("select * from Departments where DepartmentName ='" + txtDepartmentName.Text + "'", connection);
            SqlDataReader dataReader = selectQuery.ExecuteReader();
            while (dataReader.Read())
            {
                dataCheck = true;
                break;
            }
            connection.Close();
            if (dataCheck == false)
            {
                if (txtDepartmentName.Text == "")
                {
                    lblDepartmentName.ForeColor = Color.Red;
                }
                else
                    lblDepartmentName.ForeColor = Color.Black;

                if (txtDescription.Text == "")
                {
                    lblDescription.ForeColor = Color.Red;
                }
                else
                    lblDescription.ForeColor = Color.Black;

                if (/*pctCategory.Image !=  null &&*/ txtDepartmentName.Text != "" && txtDescription.Text != "")
                {
                    try
                    {
                        connection.Open();

                        Department d = new Department();
                        d.DepartmentName = txtDepartmentName.Text;
                        d.Description = txtDescription.Text;
                        d.Veri_Yaratma_Tarihi = DateTime.Now;
                        d.Veri_Durumu = 1;
                        db.Departments.Add(d);
                        db.SaveChanges();

                        connection.Close();

                        //resmi debug içinde kaydetme
                        //if (!Directory.Exists(Application.StartupPath + "\\ImageCategory"))
                        //    Directory.CreateDirectory(Application.StartupPath + "\\ImageCategory");
                        //pctCategory.Image.Save(Application.StartupPath + "\\ImageCategory\\" + txtCategoryName.Text + ".jpg");

                        MessageBox.Show("Yeni kayıt oluşturuldu", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        DepartmentShow();
                        CleanDepartmentTabPage();
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
                MessageBox.Show("Girilen Departman daha önceden kayıtlıdır", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bool searchData = false;
            if (txtDepartmentName.Text.Length > 0)
            {
                connection.Open();
                SqlCommand selectQuery = new SqlCommand("select * from Departments where DepartmentName = '" + txtDepartmentName.Text + "'", connection);
                SqlDataReader dataReader = selectQuery.ExecuteReader();

                while (dataReader.Read())
                {
                    searchData = true;
                    lblID.Text = dataReader.GetValue(0).ToString();
                    txtDepartmentName.Text = dataReader.GetValue(1).ToString();
                    txtDescription.Text = dataReader.GetValue(2).ToString();
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
                CleanDepartmentTabPage();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (pctDepartment.Image == null)
                btnAddImage.ForeColor = Color.Red;
            else
                btnAddImage.ForeColor = Color.Black;

            if (txtDepartmentName.Text == "")
            {
                lblDepartmentName.ForeColor = Color.Red;
            }
            else
                lblDepartmentName.ForeColor = Color.Black;

            if (txtDescription.Text == "")
            {
                lblDescription.ForeColor = Color.Red;
            }
            else
                lblDescription.ForeColor = Color.Black;
            if (/*pctDepartment.Image !=  null &&*/ txtDepartmentName.Text != "" && txtDescription.Text != "")
            {
                try
                {
                    connection.Open();

                    SqlCommand updateData = new SqlCommand("update Departments set Description='" + txtDescription.Text + "', [Veri Durumu] = '" + 2 + "' where DepartmentName='" + txtDepartmentName.Text + "'", connection);
                    updateData.ExecuteNonQuery();
                    //TODO:  [Veri Güncelleme Tarihi] = '" + DateTime.Now + "' 
                    connection.Close();

                    //resmi debug içinde kaydetme
                    //if (!Directory.Exists(Application.StartupPath + "\\ImageCategory"))
                    //    Directory.CreateDirectory(Application.StartupPath + "\\ImageCategory");
                    //pctCategory.Image.Save(Application.StartupPath + "\\ImageCategory\\" + txtCategoryName.Text + ".jpg");

                    MessageBox.Show("Kayıt Güncellendi", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    DepartmentShow();
                    CleanDepartmentTabPage();
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
            if (txtDepartmentName.Text != null)
            {
                bool searchData = false;

                connection.Open();

                SqlCommand selectQuery = new SqlCommand("select * from Departments where DepartmentName='" + txtDepartmentName.Text + "'", connection);
                SqlDataReader dataReader = selectQuery.ExecuteReader();
                while (dataReader.Read())
                {
                    searchData = true;
                    SqlCommand deleteData = new SqlCommand("delete from Departments where DepartmentName='" + txtDepartmentName.Text + "'", connection);
                    deleteData.ExecuteNonQuery();
                    MessageBox.Show("Departman kaydı silindi !", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    connection.Close();
                    DepartmentShow();
                    CleanDepartmentTabPage();
                    break;
                }
                if (searchData == false)
                {
                    MessageBox.Show("Silinecek kayıt bulunamadı", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connection.Close();
                    CleanDepartmentTabPage();
                }

            }
            else
                MessageBox.Show("Lütfen kayıtlarda bulunan bir Departman ismi giriniz !", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CleanDepartmentTabPage();
        }

        private void txtDepartmentName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8 || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8 || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
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
