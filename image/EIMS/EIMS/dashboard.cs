using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EIMS
{
    public partial class dashboard : Form
    {
        private int childFormNumber = 0;

        public dashboard()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void examinationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            frmMain man = new frmMain();
            man.MdiParent = this;
            man.Visible = true;
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Visible = true;
            this.Dispose();
        }

        private void universityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUniversity uni = new frmUniversity();
            uni.MdiParent = this;
            uni.Visible = true;
        }

        private void centreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCentre uni = new frmCentre();
            uni.MdiParent = this;
            uni.Visible = true;
        }

        private void academicYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAcademicYear uni = new frmAcademicYear();
            uni.MdiParent = this;
            uni.Visible = true;
        }

        private void yearOfStudyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmYearOfStudy uni = new frmYearOfStudy();
            uni.MdiParent = this;
            uni.Visible = true;
        }

        private void facultyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmFaculty uni = new frmFaculty();
            uni.MdiParent = this;
            uni.Visible = true;
        }

        private void departmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepartment uni = new frmDepartment();
            uni.MdiParent = this;
            uni.Visible = true;
        }

        private void programToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProgram uni = new frmProgram();
            uni.MdiParent = this;
            uni.Visible = true;
        }

        private void courseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCourse uni = new frmCourse();
            uni.MdiParent = this;
            uni.Visible = true;
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudent uni = new frmStudent();
            uni.MdiParent = this;
            uni.Visible = true;
        }

        private void examToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExam uni = new frmExam();
            uni.MdiParent = this;
            uni.Visible = true;
        }

        private void examinerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExaminer uni = new frmExaminer();
            uni.MdiParent = this;
            uni.Visible = true;
        }

        private void studentExamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudentExam uni = new frmStudentExam();
            uni.MdiParent = this;
            uni.Visible = true;
        }

        private void administrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUser uni = new frmUser();
            uni.MdiParent = this;
            uni.Visible = true;
        }
    }
}
