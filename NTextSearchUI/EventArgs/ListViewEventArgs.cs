using System;
using System.Windows.Forms;

namespace NTextSearch{
    public class ListViewEventArgs: EventArgs{
        public ListViewItem ListViewItem { get; set; }

        public ListViewEventArgs(ListViewItem listViewItem){
            ListViewItem = listViewItem;
        }
    }
}