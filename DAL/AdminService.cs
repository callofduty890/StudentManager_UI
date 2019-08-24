using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//账号密码是否正确
using Models;
using DAL.Helper;

namespace DAL
{
    public class AdminService
    {
        /// <summary>
        /// 根据用户账号和密码登录
        /// </summary>
        /// <param name="objAdmin"></param>
        /// <returns></returns>
        public Admin AdminLogin(Admin objAdmin)
        {
            //构建查询语句
            string sql = "select LoginId,LoginPwd,AdminName from Admins where loginId={0} and loginPwd='{1}'";
            sql = string.Format(sql, objAdmin.LoginId, objAdmin.LoginPwd);
            try
            {
                //接受查询的返回数据
                SqlDataReader objReader = SQLHelper.GetReader(sql);
                //判断读取是否成功
                if (objReader.Read())
                {
                    //对用户名进行赋值
                    objAdmin.AdminName = objReader["AdminName"].ToString();
                    //关闭登录
                    objReader.Close();
                }
                else
                {
                    //没有周到赋值为空
                    objAdmin = null;
                }
            }
            catch (SqlException)
            {
                throw new Exception("应用程序和数据库连接出现问题！");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objAdmin;
        }
    }
}
