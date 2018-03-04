namespace TranslationFileEditor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSaveChanges = new System.Windows.Forms.ToolStripMenuItem();
            this.recentlyOpenedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNextMissing = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGithubProject = new System.Windows.Forms.ToolStripMenuItem();
            this.cbMainLanguageSelector = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbKeys = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tlpTranslations = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxKeyFilter = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(727, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFolderToolStripMenuItem,
            this.btnSaveChanges,
            this.recentlyOpenedToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.openFolderToolStripMenuItem.Text = "Open Folder";
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.openFolderToolStripMenuItem_Click);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Enabled = false;
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.btnSaveChanges.Size = new System.Drawing.Size(187, 22);
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // recentlyOpenedToolStripMenuItem
            // 
            this.recentlyOpenedToolStripMenuItem.Enabled = false;
            this.recentlyOpenedToolStripMenuItem.Name = "recentlyOpenedToolStripMenuItem";
            this.recentlyOpenedToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.recentlyOpenedToolStripMenuItem.Text = "Recent Folders";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNextMissing});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // btnNextMissing
            // 
            this.btnNextMissing.Enabled = false;
            this.btnNextMissing.Name = "btnNextMissing";
            this.btnNextMissing.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.btnNextMissing.Size = new System.Drawing.Size(222, 22);
            this.btnNextMissing.Text = "Next Missing Translation";
            this.btnNextMissing.Click += new System.EventHandler(this.btnNextMissing_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGithubProject});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // btnGithubProject
            // 
            this.btnGithubProject.Name = "btnGithubProject";
            this.btnGithubProject.Size = new System.Drawing.Size(150, 22);
            this.btnGithubProject.Text = "Github Project";
            this.btnGithubProject.Click += new System.EventHandler(this.btnGithubProject_Click);
            // 
            // cbMainLanguageSelector
            // 
            this.cbMainLanguageSelector.Enabled = false;
            this.cbMainLanguageSelector.FormattingEnabled = true;
            this.cbMainLanguageSelector.Location = new System.Drawing.Point(109, 25);
            this.cbMainLanguageSelector.Name = "cbMainLanguageSelector";
            this.cbMainLanguageSelector.Size = new System.Drawing.Size(121, 21);
            this.cbMainLanguageSelector.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Main Language : ";
            // 
            // lbKeys
            // 
            this.lbKeys.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbKeys.Enabled = false;
            this.lbKeys.FormattingEnabled = true;
            this.lbKeys.Location = new System.Drawing.Point(16, 92);
            this.lbKeys.Name = "lbKeys";
            this.lbKeys.Size = new System.Drawing.Size(357, 433);
            this.lbKeys.TabIndex = 3;
            this.lbKeys.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbKeys_DrawItem);
            this.lbKeys.SelectedIndexChanged += new System.EventHandler(this.lbKeys_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tlpTranslations
            // 
            this.tlpTranslations.AutoSize = true;
            this.tlpTranslations.ColumnCount = 1;
            this.tlpTranslations.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTranslations.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTranslations.Location = new System.Drawing.Point(380, 66);
            this.tlpTranslations.Name = "tlpTranslations";
            this.tlpTranslations.RowCount = 1;
            this.tlpTranslations.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTranslations.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTranslations.Size = new System.Drawing.Size(335, 46);
            this.tlpTranslations.TabIndex = 6;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 533);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(727, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(118, 17);
            this.lblStatus.Text = "toolStripStatusLabel1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Filter : ";
            // 
            // tbxKeyFilter
            // 
            this.tbxKeyFilter.Enabled = false;
            this.tbxKeyFilter.Location = new System.Drawing.Point(47, 66);
            this.tbxKeyFilter.Name = "tbxKeyFilter";
            this.tbxKeyFilter.Size = new System.Drawing.Size(327, 20);
            this.tbxKeyFilter.TabIndex = 9;
            this.tbxKeyFilter.TextChanged += new System.EventHandler(this.tbxKeyFilter_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 555);
            this.Controls.Add(this.tbxKeyFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tlpTranslations);
            this.Controls.Add(this.lbKeys);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbMainLanguageSelector);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Translation File Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbMainLanguageSelector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbKeys;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TableLayoutPanel tlpTranslations;
        private System.Windows.Forms.ToolStripMenuItem btnSaveChanges;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnGithubProject;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnNextMissing;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxKeyFilter;
        private System.Windows.Forms.ToolStripMenuItem recentlyOpenedToolStripMenuItem;
    }
}

