using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//引入的库
using System.Data.SqlClient;
using System.Data;

namespace DAL.Helper
{
    /// <summary>
    /// 访问SQLserver数据的通用类
    /// </summary>
    class SQLHelper
    {
        //连接语句
        private static readonly string connString = "Server=.;DataBase=StudentManageDB;Uid=sa;Pwd=password01!";
        //private static readonly string connString = "Server=.;DataBase=StudentManageDB;Uid=sa;Pwd=123456";
        /// <summary>
        /// 增删改执行命令
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int Update(string sql)
       {
            //创建连接数据库对象
            SqlConnection conn = new SqlConnection(connString);

            //创建数据库操作对象
            SqlCommand cmd = new SqlCommand(sql, conn);

            try
            {
                //打开数据库
                conn.Open();
                //执行SQL语句并返回受影响的行数
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //可以进行错误日志的记录
                throw ex;
            }
            finally
            {
                //关闭连接
                conn.Close();
            }



            
       }

        /// <summary>
        /// 单一查询,查询结果返回结果集的第一行第一列,其他结果忽略
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object GetSingleResult(string sql)
        {
            //创建连接数据库对象
            SqlConnection conn = new SqlConnection(connString);

            //创建数据库操作对象
            SqlCommand cmd = new SqlCommand(sql, conn);

            //查找错误
            try
            {
                //打开数据库
                conn.Open();
                //返回执行结果
                object result = cmd.ExecuteScalar();
                return result;
            }
            catch (Exception ex)
            {
                //可以进行错误日志的记录
                throw ex;
            }
            finally
            {
                //关闭连接
                conn.Close();
            }

        }

        /// <summary>
        /// 执行多结果查询（select）
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlDataReader GetReader(string sql)
        {
            //创建连接数据库对象
            SqlConnection conn = new SqlConnection(connString);
            //创建数据库操作对象
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                //打开数据库
                conn.Open();
                //读取返回对象 CommandBehavior.CloseConnection判断连接语出关闭状态，为的是防止有别的数据库还在连接着，等别的数据断开再接上查询 
                SqlDataReader objReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return objReader;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw ex;
            }
        }

        /// <summary>
        /// 获取服务器的时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetServerTime()
        {
            //转换成时间
            return Convert.ToDateTime(GetSingleResult("select getdate()"));
        }

    }
}
