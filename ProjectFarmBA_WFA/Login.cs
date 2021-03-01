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
    public partial class Login : Form
    {
        ProjectFarmBAEntities db;
        //TODO: bu boku kullanamayacak mıyım
        public Login()
        {
            InitializeComponent();
            db = DBTool.DBInstance;
        }

        SqlConnection connection = new SqlConnection("Data Source=LENOVO-PC\\SQLEXPRESS;Initial Catalog=ProjectFarmBA;Integrated Security=True");

        public static string tcno, name, surname, authority;

        //public static string photo;

        int fail = 3;
        bool authorized = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Çalışan Girişi";
            this.AcceptButton = btnLogin; this.CancelButton = btnLogOut;
            lblFail.Text = Convert.ToString(fail);
            rdbManager.Checked = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (fail != 0)
            {
                connection.Open();
                SqlCommand selectQuery = new SqlCommand("select * from Employees", connection);
                SqlDataReader dataRead = selectQuery.ExecuteReader();
                while(dataRead.Read())
                {
                    if (rdbManager.Checked==true)
                    {
                        if (dataRead["TCNO"].ToString()==txtTcNo.Text && dataRead["Password"].ToString()== txtPassword.Text && dataRead["ERole"].ToString() == "1")
                        {
                            authorized = true;
                            tcno = dataRead.GetValue(8).ToString();
                            name = dataRead.GetValue(1).ToString();
                            surname = dataRead.GetValue(2).ToString();
                            authority = dataRead.GetValue(9).ToString();
                            this.Hide();
                            AnaSayfa anaSayfa = new AnaSayfa();
                            anaSayfa.Show();
                            break;
                        }
                    }
                    if (rdbWorker.Checked == true)
                    {
                        if (dataRead["TCNO"].ToString() == txtTcNo.Text && dataRead["Password"].ToString() == txtPassword.Text && dataRead["ERole"].ToString() == "2")
                        {
                            authorized = true;
                            tcno = dataRead.GetValue(8).ToString();
                            name = dataRead.GetValue(1).ToString();
                            surname = dataRead.GetValue(2).ToString();
                            authority = dataRead.GetValue(9).ToString();
                            this.Hide();
                            Form3 frm3 = new Form3(); //TODO: worker için farklı anasayfa ile sadece listeleme yapılacak
                            frm3.Show();
                            break;
                        }
                    }
                }
                if (authorized == false)
                {
                    fail--;
                    connection.Close();
                }
                lblFail.Text = Convert.ToString(fail);
                if (fail == 0)
                {
                    btnLogin.Enabled = false;
                    MessageBox.Show("Giriş Hakkı Kalmadı!", "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
               
            }
        }
    }
}
