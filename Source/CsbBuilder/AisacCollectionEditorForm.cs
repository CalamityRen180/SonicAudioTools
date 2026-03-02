using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsbBuilder
{
    public partial class AisacCollectionEditorForm : Form
    {
        private TreeView aisacTreeView;

        public List<string> References { get; private set; }

        public AisacCollectionEditorForm(List<string> currentReferences, TreeView aisacTree)
        {
            InitializeComponent();

            aisacTreeView = aisacTree;
            References = new List<string>(currentReferences);

            RefreshList();
        }

        private void RefreshList()
        {
            int selectedIndex = membersListBox.SelectedIndex;

            membersListBox.Items.Clear();
            for (int i = 0; i < References.Count; i++)
            {
                membersListBox.Items.Add(i + "    " + References[i]);
            }

            if (selectedIndex >= 0 && selectedIndex < membersListBox.Items.Count)
            {
                membersListBox.SelectedIndex = selectedIndex;
            }
            else if (membersListBox.Items.Count > 0)
            {
                membersListBox.SelectedIndex = membersListBox.Items.Count - 1;
            }

            UpdateButtons();
        }

        private void UpdateButtons()
        {
            bool hasSelection = membersListBox.SelectedIndex >= 0;
            removeButton.Enabled = hasSelection;
            upButton.Enabled = hasSelection && membersListBox.SelectedIndex > 0;
            downButton.Enabled = hasSelection && membersListBox.SelectedIndex < membersListBox.Items.Count - 1;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            using (SetReferenceForm setReferenceForm = new SetReferenceForm(aisacTreeView))
            {
                if (setReferenceForm.ShowDialog(this) == DialogResult.OK)
                {
                    if (setReferenceForm.SelectedNode != null)
                    {
                        string path = setReferenceForm.SelectedNode.FullPath;
                        if (!References.Contains(path))
                        {
                            References.Add(path);
                            RefreshList();
                        }
                        else
                        {
                            MessageBox.Show("This AISAC reference is already in the list.", "CSB Builder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            int index = membersListBox.SelectedIndex;
            if (index >= 0 && index < References.Count)
            {
                References.RemoveAt(index);
                RefreshList();
            }
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            int index = membersListBox.SelectedIndex;
            if (index > 0)
            {
                string temp = References[index];
                References[index] = References[index - 1];
                References[index - 1] = temp;
                RefreshList();
                membersListBox.SelectedIndex = index - 1;
            }
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            int index = membersListBox.SelectedIndex;
            if (index >= 0 && index < References.Count - 1)
            {
                string temp = References[index];
                References[index] = References[index + 1];
                References[index + 1] = temp;
                RefreshList();
                membersListBox.SelectedIndex = index + 1;
            }
        }

        private void membersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }
    }
}
