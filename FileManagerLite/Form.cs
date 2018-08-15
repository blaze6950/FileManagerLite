using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManagerLite
{
    enum TypeItem
    {
        drive,
        folder,
        file
    }
    public partial class Form : System.Windows.Forms.Form
    {
        private TreeNode _lastSelectNode;
        public Form()
        {
            InitializeComponent();
            foreach (string view in Enum.GetNames(typeof(View)))
                toolStripComboBox.Items.Add(view);

            toolStripComboBox.SelectedIndex = 0;
            _lastSelectNode = treeView.TopNode;
        }

        private void treeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            SetTreeViewExpandList(e.Node);
        }

        private void treeView_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            var node = e.Node;
            node.Nodes.Clear();
            List<TreeNode> emptyTreeNode = new List<TreeNode>(1);
            emptyTreeNode.Add(new TreeNode("Node"));
            node.Nodes.AddRange(emptyTreeNode.ToArray());
        }

        private void toolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string viewName = toolStripComboBox.SelectedItem.ToString();
            View view = (View)Enum.Parse(typeof(View), viewName);
            if(view != View.Details)
                listView.View = view;
        }

        private void groupsToolStripButton_Click(object sender, EventArgs e)
        {
            listView.ShowGroups = !listView.ShowGroups;
            SetListView(_lastSelectNode);
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _lastSelectNode = e.Node;
            SetListView(_lastSelectNode);
        }

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            var selectedItems = listView.SelectedItems;
            if (selectedItems.Count == 1)
            {
                foreach (TreeNode node in _lastSelectNode.Nodes)
                {
                    if (node.Text == selectedItems[0].Text)
                    {
                        node.Expand();
                        treeView.SelectedNode = node;
                        break;
                    }else if (node.Text == "Node")
                    {
                        _lastSelectNode.Expand();
                        listView_DoubleClick(sender, e);
                        break;
                    }
                }
                
            }
        }


        #region ListView
        private void SetListView(TreeNode _node)
        {
            listView.Items.Clear();
            var node = _node;
            if (treeView.TopNode == node)
            {
                listView.Items.AddRange(GetListViewDrives().ToArray());
            }
            else
            {
                listView.Items.AddRange(GetListViewDirectories(node).ToArray());
                listView.Items.AddRange(GetListViewFiles(node).ToArray());
            }
        }

        private List<ListViewItem> GetListViewFiles(TreeNode node)
        {
            var files = GetFiles(GetFullPathForSelectedNode(node));

            List<ListViewItem> newListViewItemList = new List<ListViewItem>(files.Count);
            foreach (var file in files)
            {
                var listViewItem = new ListViewItem();
                listViewItem.Text = Path.GetFileName(file);
                listViewItem.ImageIndex = 1;
                listViewItem.Group = listView.Groups["Files"];
                newListViewItemList.Add(listViewItem);
            }
            return newListViewItemList;
        }

        private List<ListViewItem> GetListViewDirectories(TreeNode node)
        {
            var directories = GetDirectories(GetFullPathForSelectedNode(node));

            List<ListViewItem> newListViewItemList = new List<ListViewItem>(directories.Count);
            foreach (var directory in directories)
            {
                var listViewItem = new ListViewItem();
                listViewItem.Text = Path.GetFileName(directory);
                listViewItem.ImageIndex = 2;
                listViewItem.Group = listView.Groups["Folders"];
                newListViewItemList.Add(listViewItem);
            }
            return newListViewItemList;
        }

        private List<ListViewItem> GetListViewDrives()
        {
            List<ListViewItem> newListViewItemList = new List<ListViewItem>(GetLogicalDrives().Count);
            foreach (var drive in GetLogicalDrives())
            {
                var listViewItem = new ListViewItem();
                listViewItem.Text = drive;
                listViewItem.ImageIndex = 3;
                listViewItem.Group = listView.Groups["Drives"];
                newListViewItemList.Add(listViewItem);
            }
            return newListViewItemList;
        }
        #endregion


        #region TreeView
        private void SetTreeViewExpandList(TreeNode _node)
        {
            var node = _node;
            if (node.Nodes.Count == 1 && node.Nodes[0].Text == "Node")
            {
                node.Nodes.Clear();
            }
            if (treeView.TopNode == node)
            {
                treeView.TopNode.Nodes.AddRange(GetTreeNodeDrives().ToArray());
            }
            else
            {
                node.Nodes.AddRange(GetTreeNodeDirectories(node).ToArray());
            }
        }

        private List<TreeNode> GetTreeNodeDirectories(TreeNode node)
        {
            List<TreeNode> emptyTreeNode;

            List<TreeNode> newTreeNodeList = new List<TreeNode>(GetDirectories(GetFullPathForSelectedNode(node)).Count);
            foreach (var drive in GetDirectories(GetFullPathForSelectedNode(node)))
            {
                emptyTreeNode = new List<TreeNode>(1);
                emptyTreeNode.Add(new TreeNode("Node"));
                newTreeNodeList.Add(new TreeNode(Path.GetFileName(drive), 2, 2, emptyTreeNode.ToArray()));
            }
            return newTreeNodeList;
        }

        private List<TreeNode> GetTreeNodeDrives()
        {
            List<TreeNode> emptyTreeNode;
            List<TreeNode> newTreeNodeList = new List<TreeNode>(GetLogicalDrives().Count);
            foreach (var drive in GetLogicalDrives())
            {
                emptyTreeNode = new List<TreeNode>(1);
                emptyTreeNode.Add(new TreeNode("Node"));
                newTreeNodeList.Add(new TreeNode(drive, 3, 3, emptyTreeNode.ToArray()));
            }
            return newTreeNodeList;
        }

        private String GetFullPathForSelectedNode(TreeNode node)
        {
            StringBuilder fullPath = new StringBuilder(node.Text);
            TreeNode prevNode = node.Parent;
            while (prevNode.Text != "That computer")
            {
                fullPath = new StringBuilder(prevNode.Text + @"\" + fullPath);
                prevNode = prevNode.Parent;
            }
            return fullPath.ToString();
        }
        #endregion


        #region AdditionalFuntionsForListViewAndTreeView
        private List<String> GetLogicalDrives()
        {
            List<String> drivesList = new List<string>();
            drivesList.AddRange(System.IO.Directory.GetLogicalDrives());
            return drivesList;
        }

        private List<String> GetDirectories(String fullPath)
        {
            List<String> directories = new List<string>();
            try
            {
                directories.AddRange(Directory.GetDirectories(fullPath.ToString()));
            }
            catch (UnauthorizedAccessException er)
            {
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentNullException er)
            {
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException er)
            {
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (PathTooLongException er)
            {
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DirectoryNotFoundException er)
            {
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException er)
            {
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return directories;
        }

        private List<String> GetFiles(String fullPath)
        {
            List<String> files = new List<string>();
            try
            {
                files.AddRange(Directory.GetFiles(fullPath));
            }
            catch (UnauthorizedAccessException er)
            {
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentNullException er)
            {
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException er)
            {
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (PathTooLongException er)
            {
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DirectoryNotFoundException er)
            {
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException er)
            {
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            files.Sort((x, y) => String.Compare(x, y, StringComparison.Ordinal));
            return files;
        }
        #endregion
    }
}
