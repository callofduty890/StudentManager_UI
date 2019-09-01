using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using DAL;
using Models.Ext;
using Models;

namespace StudentManager
{
    public partial class FrmStudentManage : Form
    {
        private StudentClassService objClassService = new StudentClassService();
        private StudentService objStuService = new StudentService();
        private List<StudentExt> list = null;


        public FrmStudentManage()
        {
            InitializeComponent();
            //初始化班级下拉框
            this.cboClass.DataSource = objClassService.GetAllClasses();
            this.cboClass.DisplayMember = "ClassName";
            this.cboClass.ValueMember = "ClassId";

        }
        //按照班级查询
        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (this.cboClass.SelectedIndex == -1)
            {
                MessageBox.Show("请选则班级！", "提示");
                return;
            }
            this.dgvStudentList.AutoGenerateColumns = false;    //不显示未封装的属性
            //执行查询并绑定数据
            list = objStuService.GetStudentByClass(this.cboClass.Text);
            this.dgvStudentList.DataSource = list;
            //修改样式显示样式
            new Common.DataGridViewStyle().DgvStyle1(this.dgvStudentList);

            //让标题彻底居中，消除排序按钮的影响
            foreach (DataGridViewColumn item in this.dgvStudentList.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        //根据学号查询
        private void btnQueryById_Click(object sender, EventArgs e)
        {
            if (this.txtStudentId.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入学号！", "提示信息");
                this.txtStudentId.Focus();
                return;
            }
            if (!Common.DataValidate.IsInteger(this.txtStudentId.Text.Trim()))
            {
                MessageBox.Show("学号必须是正整数！", "提示信息");
                this.txtStudentId.SelectAll();
                this.txtStudentId.Focus();
                return;
            }
            StudentExt objStudent = objStuService.GetStudentById(this.txtStudentId.Text.Trim());
            if (objStudent == null)
            {
                MessageBox.Show("学员信息不存在！", "提示信息");
                this.txtStudentId.Focus();
            }
            else
            {
                FrmStudentInfo objStuInfo = new FrmStudentInfo(objStudent);
                objStuInfo.Show();
            }
        }
        private void txtStudentId_KeyDown(object sender, KeyEventArgs e)
        {
         
        }
        //双击选中的学员对象并显示详细信息
        private void dgvStudentList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        //修改学员对象
        private void btnEidt_Click(object sender, EventArgs e)
        {
          
        }
        //删除学员对象
        private void btnDel_Click(object sender, EventArgs e)
        {
           
        }
        //姓名降序
        private void btnNameDESC_Click(object sender, EventArgs e)
        {
            if (this.dgvStudentList.RowCount == 0)
            {
                return;
            } 
            list.Sort(new NameDESC());
            this.dgvStudentList.Refresh();
        }
        //学号降序
        private void btnStuIdDESC_Click(object sender, EventArgs e)
        {
            if (this.dgvStudentList.RowCount == 0)
            {
                return;
            } 
            list.Sort(new StuIdDESC());
            //刷新显示
            this.dgvStudentList.Refresh();
        }
        //添加行号
        private void dgvStudentList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
        
        }
        //打印当前学员信息
        private void btnPrint_Click(object sender, EventArgs e)
        {
          
        }

        //关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //导出到Excel
        private void btnExport_Click(object sender, EventArgs e)
        {

        }
    }

    #region 实现排序
    //学生姓名的排序
    class NameDESC : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return y.StudentName.CompareTo(x.StudentName);
        }
    }
    //学生ID的排序
    class StuIdDESC : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return y.StudentId.CompareTo(x.StudentId);
        }
    }
    #endregion
}