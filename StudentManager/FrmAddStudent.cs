using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Models;
using DAL;

namespace StudentManager
{
    public partial class FrmAddStudent : Form
    {
        //创建数据访问对象
        private StudentClassService objClassService = new StudentClassService();
        //private StudentService objStudentService = new StudentService();

        public FrmAddStudent()
        {
            InitializeComponent();
            //初始化班级下拉框
            this.cboClassName.DataSource = objClassService.GetAllClasses();
            this.cboClassName.DisplayMember = "ClassName";//设置下拉框的显示文本
            this.cboClassName.ValueMember = "ClassId";//设置下拉框显示文本对应的value      
        }
        //添加新学员
        private void btnAdd_Click(object sender, EventArgs e)
        {
            #region  验证数据

            if (this.txtStudentName.Text.Trim().Length == 0)
            {
                MessageBox.Show("学生姓名不能为空！", "提示信息");
                this.txtStudentName.Focus();
                return;
            }
            if (this.txtCardNo.Text.Trim().Length == 0)
            {
                MessageBox.Show("考勤卡号不能为空！", "提示信息");
                this.txtCardNo.Focus();
                return;
            }
            //验证性别
            if (!this.rdoFemale.Checked && !this.rdoMale.Checked)
            {
                MessageBox.Show("请选择学生性别！", "提示信息");
                return;
            }
            //验证班级
            if (this.cboClassName.SelectedIndex == -1)
            {
                MessageBox.Show("请选择班级！", "提示信息");
                return;
            }
            //验证年龄
            int age = DateTime.Now.Year - Convert.ToDateTime(this.dtpBirthday.Text).Year;
            if (age > 35 && age < 18)
            {
                MessageBox.Show("年龄必须在28-35岁之间！", "提示信息");
                return;
            }
            //验证身份证号是否符合要求
            if (!Common.DataValidate.IsIdentityCard(this.txtStudentIdNo.Text.Trim()))
            {
                MessageBox.Show("身份证号不符合要求！", "验证提示");
                this.txtStudentIdNo.Focus();
                return;
            }


            // if (!this.txtStudentIdNo.Text.Trim().Contains(Convert.ToDateTime(this.dtpBirthday.Text).ToString("yyyyMMdd")))
            if (!this.txtStudentIdNo.Text.Trim().Contains(this.dtpBirthday.Value.ToString("yyyyMMdd")))
            {
                MessageBox.Show("身份证号和出生日期不匹配！", "验证提示");
                this.txtStudentIdNo.Focus();
                this.txtStudentIdNo.SelectAll();
                return;
            }
            ////验证身份证号是否重复
            //if (objStudentService.IsIdNoExisted(this.txtStudentIdNo.Text.Trim()))
            //{
            //    MessageBox.Show("身份证号不能和现有学员身份证号重复！", "验证提示");
            //    this.txtStudentIdNo.Focus();
            //    this.txtStudentIdNo.SelectAll();
            //    return;
            //}
            ////验证卡号是否重复
            //if (objStudentService.IsCardNoExisted(this.txtCardNo.Text.Trim()))
            //{
            //    MessageBox.Show("当前卡号已经存在！", "验证提示");
            //    this.txtCardNo.Focus();
            //    this.txtCardNo.SelectAll();
            //    return;
            //}
            #endregion
        }
        //关闭窗体
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmAddStudent_KeyDown(object sender, KeyEventArgs e)
        {
       

        }
        //选择新照片
        private void btnChoseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog objFileDialog = new OpenFileDialog();
            DialogResult result = objFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.pbStu.Image = Image.FromFile(objFileDialog.FileName);
            }
                
        }
        //启动摄像头
        private void btnStartVideo_Click(object sender, EventArgs e)
        {
         
        }
        //拍照
        private void btnTake_Click(object sender, EventArgs e)
        {
        
        }
        //清除照片
        private void btnClear_Click(object sender, EventArgs e)
        {
         
        }

     
    }
}