using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


using System.Diagnostics;
using Models;

namespace StudentManager
{
    static class Program
    {
        //声明用户信息的全局变量
        public static Admin currentAdmin = null;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //显示登录窗口
            FrmUserLogin frmLogin = new FrmUserLogin();
            DialogResult result = frmLogin.ShowDialog();

            //判断登录是否成功
            if (result==DialogResult.OK)
            {
                Application.Run(new FrmMain());
            }
            else
            {
                //关闭所有的程序
                Application.Exit();
            }
        }
    }
}
