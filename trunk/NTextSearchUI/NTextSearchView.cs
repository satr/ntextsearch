using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NTextSearch{
    public partial class NTextSearchView : Form, ITextSearchView {
        public NTextSearchView() {
            InitializeComponent();
            Presenter = new NTextSearchPresenter(this);
            Presenter.OnSearchEnabled += (src, args) => { buttonSearch.Enabled = args.Enable; };
            Presenter.OnAddListItem += (src, args) => listView.Items.Add(args.ListViewItem);
        }

        private ITextSearchPresenter Presenter { get; set; }

        private void toolStripButtonExit_Click(object sender, EventArgs e) {
            Presenter.Exit();
        }

        private void toolStripButtonRefreshPlugins_Click(object sender, EventArgs e) {
            Presenter.RefreshPlugins();
        }

        private void buttonRefreshPlugins_Click(object sender, EventArgs e) {
            Presenter.RefreshPlugins();
        }

        public void RefreshPlugins(List<ITextSearch> plugins){
            comboBoxPlugins.SuspendLayout();
            comboBoxPlugins.DataSource = null;
            comboBoxPlugins.DataSource = plugins;
            comboBoxPlugins.DisplayMember = "Title";
            comboBoxPlugins.ResumeLayout(true);
            if (plugins.Count > 0)
                comboBoxPlugins.SelectedIndex = 0;
        }

        private void buttonSearch_Click(object sender, EventArgs e) {
            Presenter.PerformSearch(textBoxTargetText.Text);
        }

        private void comboBoxPlugins_SelectedIndexChanged(object sender, EventArgs e) {
            Presenter.SelectPlugin((ITextSearch) comboBoxPlugins.SelectedItem);
        }
    }
}