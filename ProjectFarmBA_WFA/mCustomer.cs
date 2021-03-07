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
    public partial class mCustomer : Form
    {
        ProjectFarmBAEntities db;
        public mCustomer()
        {
            InitializeComponent();
            db = DBTool.DBInstance;
        }

        //TODO: Customer Storage elden alışveriş hallet

        SqlConnection connection = new SqlConnection("Data Source=LENOVO-PC\\SQLEXPRESS;Initial Catalog=ProjectFarmBA;Integrated Security=True;MultipleActiveResultSets=True");
        private void mCustomer_Load(object sender, EventArgs e)
        {

        }
    }
}
