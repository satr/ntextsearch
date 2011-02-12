using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NTextSearchUI {
    public partial class NTextSearchView : Form {
        public NTextSearchView() {
            InitializeComponent();
        }

        private void toolStripButtonExit_Click(object sender, EventArgs e) {
            var dialogResult = MessageBox.Show("Do you really want to exit?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if(dialogResult == DialogResult.Yes)
                Close();
        }

        private void toolStripButtonRefreshPlugins_Click(object sender, EventArgs e) {

        }
    }
}
