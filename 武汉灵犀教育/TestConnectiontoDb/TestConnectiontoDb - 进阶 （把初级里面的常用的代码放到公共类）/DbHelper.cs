using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace TestConnectiontoDb
{
    public class DbHelper
    {
        private static string ConnStr = "Data Source = LAPTOP-2OJ79OUP; Initial Catalog = test; Integrated Security = True";

        /// <summary>
        /// 执行添加，删除，修改的通用方法
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, params SqlParameter[]paras) //params 代表可选参数
        {
            int result = -1;
            //利用using，有IDisposable，它能够自动释放资源，就不用写Close()了
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.Add(paras);
                result = command.ExecuteNonQuery(); 
                // int result = command.ExecuteNonQuery();
                // conn.Close();
            }
            
            return result;
        }
        /// <summary>
        /// 执行返回第一行和第一列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, params SqlParameter[] paras) //params 代表可选参数
        {
            object obj = null;
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddRange(paras);
                obj = command.ExecuteScalar(); 
            }  

            return obj;
        }
        /// <summary>
        /// 执行返回游标方式的结果集
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] paras) //params 代表可选参数
        {
            //SqlDataReader 需要建立在Db打开的状态下，，所以不能用using了
            SqlConnection conn = new SqlConnection(ConnStr);
            conn.Open();
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddRange(paras);

            //SqlDataReader是链接是连接方式： 需要和数据库实时保持连接状态，
            //所以用下面的commandbehaviour，不需要Close（）了
            SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection); 
                
            return reader;
        }
        /// <summary>
        /// 执行返回 临时表DataTable
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDataTable(string sql, params SqlParameter[] paras)
        {
            DataTable dt = new DataTable();
            //DataTable是断开式连接方式,所以可以使用using了
            // 也不需要写 conn.Open()
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddRange(paras);
                //创建数据适配器
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                //填充
                adapter.Fill(dt);
            }
            return dt;
        }
    }
}
