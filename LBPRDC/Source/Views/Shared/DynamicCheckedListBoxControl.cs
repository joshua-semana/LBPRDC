using System.ComponentModel;
using System.Windows.Forms;

namespace LBPRDC.Source.Views.Shared
{
    public partial class DynamicCheckedListBoxControl : UserControl
    {
        public class CheckedListBoxItems
        {
            public int ID { get; set; }
            public string Name { get; set; }

            public CheckedListBoxItems(int id, string name)
            {
                ID = id;
                Name = name;
            }
        }

        private List<CheckedListBoxItems> items = new();
        private bool isCollapsed = true;

        public DynamicCheckedListBoxControl()
        {
            InitializeComponent();
        }
        private void DynamicCheckedListBoxControl_Load(object sender, EventArgs e)
        {
            DisplayItems();
        }

        public void SetItems(List<CheckedListBoxItems> itemsToSet)
        {
            items.AddRange(itemsToSet);
        }

        private void DisplayItems()
        {
            //chkListItems.Items.Clear();
            lblAction.Visible = items.Count > 4;

            chkListItems.DataSource = (isCollapsed) ? items.Take(4).ToList() : items;
            chkListItems.DisplayMember = "Name";

            //foreach (var item in (isCollapsed) ? items.Take(4) : items)
            //{
            //    chkListItems.Items.Add(item.Name);
            //}

            UpdateCheckedListBoxHeight();
        }

        public List<CheckedListBoxItems> GetCheckedItems()
        {
            List<CheckedListBoxItems> checkedNames = new();

            foreach (CheckedListBoxItems item in chkListItems.CheckedItems)
            {
                checkedNames.Add(item);
            }

            return checkedNames;
        }

        public void ClearCheckedItems()
        {
            for (int i = 0; i < chkListItems.Items.Count; i++)
            {
                chkListItems.SetItemChecked(i, false);
            }
        }

        private void UpdateCheckedListBoxHeight()
        {
            int itemHeight = chkListItems.GetItemHeight(0);
            chkListItems.Height = (chkListItems.Items.Count * itemHeight);
        }

        private void lblAction_Click(object sender, EventArgs e)
        {
            if (lblAction.Tag.ToString() == "Show")
            {
                isCollapsed = false;
                lblAction.Tag = "Collapse";
                lblAction.Text = "Collapse";
            }
            else if (lblAction.Tag.ToString() == "Collapse")
            {
                isCollapsed = true;
                lblAction.Tag = "Show";
                lblAction.Text = "Show more";
            }
            DisplayItems();
        }

        private void chkListItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkListItems.ClearSelected();
        }
    }
}
