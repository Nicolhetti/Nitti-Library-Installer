namespace NittiLibraryInstaller
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.CheckedListBox checkedListBoxLibraries;
        private System.Windows.Forms.Button buttonInstall;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Button buttonDeleteTempFiles;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.checkedListBoxLibraries = new System.Windows.Forms.CheckedListBox();
            this.buttonInstall = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelStatus = new System.Windows.Forms.Label();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.labelInfo = new System.Windows.Forms.Label();
            this.buttonDeleteTempFiles = new System.Windows.Forms.Button();
            this.panelInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkedListBoxLibraries
            // 
            this.checkedListBoxLibraries.FormattingEnabled = true;
            resources.ApplyResources(this.checkedListBoxLibraries, "checkedListBoxLibraries");
            this.checkedListBoxLibraries.Name = "checkedListBoxLibraries";
            this.checkedListBoxLibraries.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxLibraries_SelectedIndexChanged);
            // 
            // buttonInstall
            // 
            resources.ApplyResources(this.buttonInstall, "buttonInstall");
            this.buttonInstall.Name = "buttonInstall";
            this.buttonInstall.UseVisualStyleBackColor = true;
            this.buttonInstall.Click += new System.EventHandler(this.buttonInstall_Click);
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            // 
            // labelStatus
            // 
            resources.ApplyResources(this.labelStatus, "labelStatus");
            this.labelStatus.Name = "labelStatus";
            // 
            // panelInfo
            // 
            resources.ApplyResources(this.panelInfo, "panelInfo");
            this.panelInfo.Controls.Add(this.labelInfo);
            this.panelInfo.Name = "panelInfo";
            // 
            // labelInfo
            // 
            resources.ApplyResources(this.labelInfo, "labelInfo");
            this.labelInfo.Name = "labelInfo";
            // 
            // buttonDeleteTempFiles
            // 
            resources.ApplyResources(this.buttonDeleteTempFiles, "buttonDeleteTempFiles");
            this.buttonDeleteTempFiles.Name = "buttonDeleteTempFiles";
            this.buttonDeleteTempFiles.UseVisualStyleBackColor = true;
            this.buttonDeleteTempFiles.Click += new System.EventHandler(this.buttonDeleteTempFiles_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonInstall);
            this.Controls.Add(this.checkedListBoxLibraries);
            this.Controls.Add(this.buttonDeleteTempFiles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
