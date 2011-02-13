using System;
using System.Windows.Forms;

namespace NTextSearch.PluginPropertyControls {
    public partial class BooleanPluginPropertyControl : UserControl {
        private PluginProperty _property;

        public BooleanPluginPropertyControl() {
            InitializeComponent();
            checkBox.CheckedChanged += (s, e) => _property.Value = checkBox.Checked;
        }

        public PluginProperty Property{
            get { return _property; }
            set{
                _property = value;
                checkBox.Text = _property.Title;
                checkBox.Checked = (bool) _property.Value;
            }
        }
    }
}
