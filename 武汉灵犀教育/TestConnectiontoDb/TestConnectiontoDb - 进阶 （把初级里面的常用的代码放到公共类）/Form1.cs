using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TestConnectiontoDb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Login Event by Alan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            string sql = "select * from Table1";
            DataTable dt= DbHelper.GetDataTable(sql);
            //可以在上面设置一个断点，然后dt变量那里会有一个临时表跳出来的

            //dt.Rows[0]["Id"];  //取第0行，然后下标名字 //这行code简单说，code还不完整的会报错
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string id = this.txtID.Text;
            string pw = this.txtPassword.Text;

            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@Id",id), 
                new SqlParameter("@Password",pw)
            };

            string sql = "select count(1) from Table1 where Id=@Id and Password=@Password";

            int result = (int)DbHelper.ExecuteScalar(sql,paras);

            if (result > 0)
            {
                //MessageBox.Show("login success");

                FriendForm ff = new FriendForm();
                ff.Show(); //ff.Visible = true;

            }
            else
            {
                MessageBox.Show("login failed");
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
