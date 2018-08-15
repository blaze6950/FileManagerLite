namespace FileManagerLite
{
    partial class Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Node", 3, 3);
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("That computer", 0, 0, new System.Windows.Forms.TreeNode[] {
            treeNode3});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Folders", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Files", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("Drives", System.Windows.Forms.HorizontalAlignment.Left);
            this.treeView = new System.Windows.Forms.TreeView();
            this.smallIconsImageList = new System.Windows.Forms.ImageList(this.components);
            this.listView = new System.Windows.Forms.ListView();
            this.largeIconsImageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.groupsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.smallIconsImageList;
            this.treeView.Location = new System.Drawing.Point(12, 28);
            this.treeView.Name = "treeView";
            treeNode3.ImageIndex = 3;
            treeNode3.Name = "Node";
            treeNode3.SelectedImageIndex = 3;
            treeNode3.Text = "Node";
            treeNode4.ImageIndex = 0;
            treeNode4.Name = "Computer";
            treeNode4.SelectedImageIndex = 0;
            treeNode4.Text = "That computer";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4});
            this.treeView.SelectedImageIndex = 0;
            this.treeView.ShowRootLines = false;
            this.treeView.Size = new System.Drawing.Size(142, 499);
            this.treeView.TabIndex = 0;
            this.treeView.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterCollapse);
            this.treeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView_BeforeExpand);
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // smallIconsImageList
            // 
            this.smallIconsImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("smallIconsImageList.ImageStream")));
            this.smallIconsImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.smallIconsImageList.Images.SetKeyName(0, "Computer.png");
            this.smallIconsImageList.Images.SetKeyName(1, "File.png");
            this.smallIconsImageList.Images.SetKeyName(2, "Folder.png");
            this.smallIconsImageList.Images.SetKeyName(3, "HardDrive.png");
            // 
            // listView
            // 
            listViewGroup4.Header = "Folders";
            listViewGroup4.Name = "Folders";
            listViewGroup5.Header = "Files";
            listViewGroup5.Name = "Files";
            listViewGroup6.Header = "Drives";
            listViewGroup6.Name = "Drives";
            this.listView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup4,
            listViewGroup5,
            listViewGroup6});
            this.listView.LargeImageList = this.largeIconsImageList;
            this.listView.Location = new System.Drawing.Point(160, 28);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(669, 499);
            this.listView.SmallImageList = this.smallIconsImageList;
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
            // 
            // largeIconsImageList
            // 
            this.largeIconsImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("largeIconsImageList.ImageStream")));
            this.largeIconsImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.largeIconsImageList.Images.SetKeyName(0, "Computer.png");
            this.largeIconsImageList.Images.SetKeyName(1, "File.png");
            this.largeIconsImageList.Images.SetKeyName(2, "Folder.png");
            this.largeIconsImageList.Images.SetKeyName(3, "HardDrive.png");
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox,
            this.groupsToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(841, 25);
            this.toolStrip.TabIndex = 3;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripComboBox
            // 
            this.toolStripComboBox.Name = "toolStripComboBox";
            this.toolStripComboBox.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox_SelectedIndexChanged);
            // 
            // groupsToolStripButton
            // 
            this.groupsToolStripButton.Checked = true;
            this.groupsToolStripButton.CheckOnClick = true;
            this.groupsToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.groupsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.groupsToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("groupsToolStripButton.Image")));
            this.groupsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.groupsToolStripButton.Name = "groupsToolStripButton";
            this.groupsToolStripButton.Size = new System.Drawing.Size(48, 22);
            this.groupsToolStripButton.Text = "groups";
            this.groupsToolStripButton.Click += new System.EventHandler(this.groupsToolStripButton_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 539);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.treeView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form";
            this.Text = "FileManager";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ImageList smallIconsImageList;
        private System.Windows.Forms.ImageList largeIconsImageList;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox;
        private System.Windows.Forms.ToolStripButton groupsToolStripButton;
    }
}

