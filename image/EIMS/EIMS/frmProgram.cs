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
    public partial class frmProgram : Form
    {
        public frmProgram()
        {
            InitializeComponent();
        }

        private void frmProgram_Load(object sender, EventArgs e)
        {
            gboUniversity.Left = (this.Width - gboUniversity.Width) / 2;
            gboUniversity.Top = (this.Height - gboUniversity.Height) / 2;
        }
    }
}
