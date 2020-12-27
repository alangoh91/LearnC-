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

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string id = this.txtID.Text;
            string pw = this.txtPassword.Text;

            //Step1: Create database connection object ADO.NET
            SqlConnection conn = new SqlConnection("Data Source=LAPTOP-2OJ79OUP;Initial Catalog=test;Integrated Security=True");
            
            //Step2: Open database connnection
            conn.Open();


            //Step3: Create query object

            #region 解释SQL注入
            /*
                如果加这句：  ' or 1=1--
                原本的sql: select count(1) from Table1 where Id = '1001' and Password = '123456' 会被变成下面的sql
                            select count(1) from Table1 where Id = '1001' and Password = '' or 1=1 --'
                结局是：竟然可以成功登录！这就是如果你熟悉sql语句，可以“破解”的地方！
            */
            #endregion
            //防止SQL注入：使用变量和参数化：把特殊符号（比如')转义成普通字符串
            SqlParameter para1 = new SqlParameter("@Id",id);  //using System.Data.SqlClient;
            SqlParameter para2 = new SqlParameter("@Password", pw);

            #region 高级写法：用数组；就不用写那么多参数
            /*
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@Id",id),
            new SqlParameter("@Password", pw)
            };
            */

            #endregion

            /* 原本的这句不要了：
                string sql = $"select count(1) from Table1 where Id='{id}' and Password='{pw}'";   //count(1)的1代表地是 伪列 （“不是实际的列”：不是指第一个列名id）
            */
            string sql = "select count(1) from Table1 where Id=@Id and Password=@Password";
            
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.Add(para1);
            command.Parameters.Add(para2);

            #region 高级写法：用数组；就不用写那么多参数
            /*
                丢弃：
                     command.Parameters.Add(para1);
                     command.Parameters.Add(para2);
                改用：
                    command.Parameters.AddRange(paras);
            */
            #endregion

            //Step4: Run query
            /* 
             command.ExecuteNonQuery();  //add, delete, edit
             command.ExecuteReader();  //query will return multiple rows and columns
           */

            int result = (int)command.ExecuteScalar(); //query will return first row and first column
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
            //Step5: close connection
            conn.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
