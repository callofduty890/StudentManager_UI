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
        //�������ݷ��ʶ���
        private StudentClassService objClassService = new StudentClassService();
        //private StudentService objStudentService = new StudentService();

        public FrmAddStudent()
        {
            InitializeComponent();
            //��ʼ���༶������
            this.cboClassName.DataSource = objClassService.GetAllClasses();
            this.cboClassName.DisplayMember = "ClassName";//�������������ʾ�ı�
            this.cboClassName.ValueMember = "ClassId";//������������ʾ�ı���Ӧ��value      
        }
        //�����ѧԱ
        private void btnAdd_Click(object sender, EventArgs e)
        {
            #region  ��֤����

            if (this.txtStudentName.Text.Trim().Length == 0)
            {
                MessageBox.Show("ѧ����������Ϊ�գ�", "��ʾ��Ϣ");
                this.txtStudentName.Focus();
                return;
            }
            if (this.txtCardNo.Text.Trim().Length == 0)
            {
                MessageBox.Show("���ڿ��Ų���Ϊ�գ�", "��ʾ��Ϣ");
                this.txtCardNo.Focus();
                return;
            }
            //��֤�Ա�
            if (!this.rdoFemale.Checked && !this.rdoMale.Checked)
            {
                MessageBox.Show("��ѡ��ѧ���Ա�", "��ʾ��Ϣ");
                return;
            }
            //��֤�༶
            if (this.cboClassName.SelectedIndex == -1)
            {
                MessageBox.Show("��ѡ��༶��", "��ʾ��Ϣ");
                return;
            }
            //��֤����
            int age = DateTime.Now.Year - Convert.ToDateTime(this.dtpBirthday.Text).Year;
            if (age > 35 && age < 18)
            {
                MessageBox.Show("���������28-35��֮�䣡", "��ʾ��Ϣ");
                return;
            }
            //��֤���֤���Ƿ����Ҫ��
            if (!Common.DataValidate.IsIdentityCard(this.txtStudentIdNo.Text.Trim()))
            {
                MessageBox.Show("���֤�Ų�����Ҫ��", "��֤��ʾ");
                this.txtStudentIdNo.Focus();
                return;
            }


            // if (!this.txtStudentIdNo.Text.Trim().Contains(Convert.ToDateTime(this.dtpBirthday.Text).ToString("yyyyMMdd")))
            if (!this.txtStudentIdNo.Text.Trim().Contains(this.dtpBirthday.Value.ToString("yyyyMMdd")))
            {
                MessageBox.Show("���֤�źͳ������ڲ�ƥ�䣡", "��֤��ʾ");
                this.txtStudentIdNo.Focus();
                this.txtStudentIdNo.SelectAll();
                return;
            }
            ////��֤���֤���Ƿ��ظ�
            //if (objStudentService.IsIdNoExisted(this.txtStudentIdNo.Text.Trim()))
            //{
            //    MessageBox.Show("���֤�Ų��ܺ�����ѧԱ���֤���ظ���", "��֤��ʾ");
            //    this.txtStudentIdNo.Focus();
            //    this.txtStudentIdNo.SelectAll();
            //    return;
            //}
            ////��֤�����Ƿ��ظ�
            //if (objStudentService.IsCardNoExisted(this.txtCardNo.Text.Trim()))
            //{
            //    MessageBox.Show("��ǰ�����Ѿ����ڣ�", "��֤��ʾ");
            //    this.txtCardNo.Focus();
            //    this.txtCardNo.SelectAll();
            //    return;
            //}
            #endregion
        }
        //�رմ���
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmAddStudent_KeyDown(object sender, KeyEventArgs e)
        {
       

        }
        //ѡ������Ƭ
        private void btnChoseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog objFileDialog = new OpenFileDialog();
            DialogResult result = objFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.pbStu.Image = Image.FromFile(objFileDialog.FileName);
            }
                
        }
        //��������ͷ
        private void btnStartVideo_Click(object sender, EventArgs e)
        {
         
        }
        //����
        private void btnTake_Click(object sender, EventArgs e)
        {
        
        }
        //�����Ƭ
        private void btnClear_Click(object sender, EventArgs e)
        {
         
        }

     
    }
}