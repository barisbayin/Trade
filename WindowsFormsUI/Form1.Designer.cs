
namespace WindowsFormsUI
{
    partial class Form1
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Day Parameters");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Parameters", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Futures Usdt");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Spot");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Symbol Information", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            this.tlpMainWindow = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuTree = new System.Windows.Forms.TreeView();
            this.tlpMainWindow.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMainWindow
            // 
            this.tlpMainWindow.AutoSize = true;
            this.tlpMainWindow.ColumnCount = 2;
            this.tlpMainWindow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.76238F));
            this.tlpMainWindow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.23763F));
            this.tlpMainWindow.Controls.Add(this.panel1, 0, 1);
            this.tlpMainWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMainWindow.Location = new System.Drawing.Point(0, 0);
            this.tlpMainWindow.Name = "tlpMainWindow";
            this.tlpMainWindow.RowCount = 2;
            this.tlpMainWindow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.192878F));
            this.tlpMainWindow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.80712F));
            this.tlpMainWindow.Size = new System.Drawing.Size(1010, 674);
            this.tlpMainWindow.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.menuTree);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(133, 634);
            this.panel1.TabIndex = 1;
            // 
            // menuTree
            // 
            this.menuTree.BackColor = System.Drawing.SystemColors.Info;
            this.menuTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuTree.Location = new System.Drawing.Point(0, 0);
            this.menuTree.Name = "menuTree";
            treeNode1.Name = "subMenuDayParameters";
            treeNode1.Text = "Day Parameters";
            treeNode2.Checked = true;
            treeNode2.Name = "menuParameters";
            treeNode2.Text = "Parameters";
            treeNode3.Name = "subMenuFuturesUsdt";
            treeNode3.Text = "Futures Usdt";
            treeNode4.Name = "subMenuSpot";
            treeNode4.Text = "Spot";
            treeNode5.Name = "menuSymbolInformation";
            treeNode5.Text = "Symbol Information";
            this.menuTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode5});
            this.menuTree.Size = new System.Drawing.Size(133, 634);
            this.menuTree.TabIndex = 0;
            this.menuTree.DoubleClick += new System.EventHandler(this.menuTree_DoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1010, 674);
            this.Controls.Add(this.tlpMainWindow);
            this.Name = "Form1";
            this.Text = "Control Panel";
            this.tlpMainWindow.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMainWindow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView menuTree;
    }
}

