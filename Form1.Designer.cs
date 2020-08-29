namespace FS2020_Tree_Size_Editor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.massEditGrp = new System.Windows.Forms.GroupBox();
            this.btnAddMax = new System.Windows.Forms.Button();
            this.btnSubtractMax = new System.Windows.Forms.Button();
            this.btnAddMin = new System.Windows.Forms.Button();
            this.btnSubtractMin = new System.Windows.Forms.Button();
            this.changeMax = new System.Windows.Forms.NumericUpDown();
            this.label53 = new System.Windows.Forms.Label();
            this.noCacti = new System.Windows.Forms.CheckBox();
            this.noScrubs = new System.Windows.Forms.CheckBox();
            this.changeMin = new System.Windows.Forms.NumericUpDown();
            this.label52 = new System.Windows.Forms.Label();
            this.btnSaveBackup = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.saveBackup = new System.Windows.Forms.SaveFileDialog();
            this.treeTabs = new System.Windows.Forms.TabControl();
            this.openFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.massEditGrp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.changeMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.changeMin)).BeginInit();
            this.SuspendLayout();
            // 
            // massEditGrp
            // 
            this.massEditGrp.Controls.Add(this.btnAddMax);
            this.massEditGrp.Controls.Add(this.btnSubtractMax);
            this.massEditGrp.Controls.Add(this.btnAddMin);
            this.massEditGrp.Controls.Add(this.btnSubtractMin);
            this.massEditGrp.Controls.Add(this.changeMax);
            this.massEditGrp.Controls.Add(this.label53);
            this.massEditGrp.Controls.Add(this.noCacti);
            this.massEditGrp.Controls.Add(this.noScrubs);
            this.massEditGrp.Controls.Add(this.changeMin);
            this.massEditGrp.Controls.Add(this.label52);
            this.massEditGrp.Enabled = false;
            this.massEditGrp.Location = new System.Drawing.Point(333, 344);
            this.massEditGrp.Name = "massEditGrp";
            this.massEditGrp.Size = new System.Drawing.Size(407, 128);
            this.massEditGrp.TabIndex = 89;
            this.massEditGrp.TabStop = false;
            this.massEditGrp.Text = "Mass edit";
            // 
            // btnAddMax
            // 
            this.btnAddMax.Location = new System.Drawing.Point(281, 90);
            this.btnAddMax.Name = "btnAddMax";
            this.btnAddMax.Size = new System.Drawing.Size(104, 23);
            this.btnAddMax.TabIndex = 98;
            this.btnAddMax.Text = "Add maximums";
            this.btnAddMax.UseVisualStyleBackColor = true;
            this.btnAddMax.Click += new System.EventHandler(this.BtnAddMax_Click);
            // 
            // btnSubtractMax
            // 
            this.btnSubtractMax.Location = new System.Drawing.Point(163, 90);
            this.btnSubtractMax.Name = "btnSubtractMax";
            this.btnSubtractMax.Size = new System.Drawing.Size(112, 23);
            this.btnSubtractMax.TabIndex = 97;
            this.btnSubtractMax.Text = "Subtract maximums";
            this.btnSubtractMax.UseVisualStyleBackColor = true;
            this.btnSubtractMax.Click += new System.EventHandler(this.BtnSubtractMax_Click);
            // 
            // btnAddMin
            // 
            this.btnAddMin.Location = new System.Drawing.Point(281, 62);
            this.btnAddMin.Name = "btnAddMin";
            this.btnAddMin.Size = new System.Drawing.Size(104, 23);
            this.btnAddMin.TabIndex = 96;
            this.btnAddMin.Text = "Add minimums";
            this.btnAddMin.UseVisualStyleBackColor = true;
            this.btnAddMin.Click += new System.EventHandler(this.BtnAddMin_Click);
            // 
            // btnSubtractMin
            // 
            this.btnSubtractMin.Location = new System.Drawing.Point(163, 62);
            this.btnSubtractMin.Name = "btnSubtractMin";
            this.btnSubtractMin.Size = new System.Drawing.Size(112, 23);
            this.btnSubtractMin.TabIndex = 95;
            this.btnSubtractMin.Text = "Subtract minimums";
            this.btnSubtractMin.UseVisualStyleBackColor = true;
            this.btnSubtractMin.Click += new System.EventHandler(this.BtnSubtractMin_Click);
            // 
            // changeMax
            // 
            this.changeMax.Location = new System.Drawing.Point(121, 93);
            this.changeMax.Name = "changeMax";
            this.changeMax.Size = new System.Drawing.Size(37, 20);
            this.changeMax.TabIndex = 94;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(6, 95);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(112, 13);
            this.label53.TabIndex = 93;
            this.label53.Text = "Change maximums by:";
            // 
            // noCacti
            // 
            this.noCacti.AutoSize = true;
            this.noCacti.Location = new System.Drawing.Point(5, 42);
            this.noCacti.Name = "noCacti";
            this.noCacti.Size = new System.Drawing.Size(152, 17);
            this.noCacti.TabIndex = 92;
            this.noCacti.Text = "Don\'t mass change cactus";
            this.noCacti.UseVisualStyleBackColor = true;
            // 
            // noScrubs
            // 
            this.noScrubs.AutoSize = true;
            this.noScrubs.Location = new System.Drawing.Point(6, 19);
            this.noScrubs.Name = "noScrubs";
            this.noScrubs.Size = new System.Drawing.Size(188, 17);
            this.noScrubs.TabIndex = 91;
            this.noScrubs.Text = "Don\'t mass change scrubs, shrubs";
            this.noScrubs.UseVisualStyleBackColor = true;
            // 
            // changeMin
            // 
            this.changeMin.Location = new System.Drawing.Point(120, 65);
            this.changeMin.Name = "changeMin";
            this.changeMin.Size = new System.Drawing.Size(37, 20);
            this.changeMin.TabIndex = 90;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(5, 67);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(109, 13);
            this.label52.TabIndex = 89;
            this.label52.Text = "Change minimums by:";
            // 
            // btnSaveBackup
            // 
            this.btnSaveBackup.Enabled = false;
            this.btnSaveBackup.Location = new System.Drawing.Point(554, 478);
            this.btnSaveBackup.Name = "btnSaveBackup";
            this.btnSaveBackup.Size = new System.Drawing.Size(91, 23);
            this.btnSaveBackup.TabIndex = 90;
            this.btnSaveBackup.Text = "Save backup";
            this.btnSaveBackup.UseVisualStyleBackColor = true;
            this.btnSaveBackup.Click += new System.EventHandler(this.BtnSaveBackup_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(423, 478);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 23);
            this.btnSave.TabIndex = 91;
            this.btnSave.Text = "Save changes";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // saveBackup
            // 
            this.saveBackup.DefaultExt = "xml";
            this.saveBackup.FileName = "10-asobo_species_BACKUP";
            this.saveBackup.Filter = "XML Files (*.xml)|*.xml";
            this.saveBackup.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveBackup_FileOk);
            // 
            // treeTabs
            // 
            this.treeTabs.Location = new System.Drawing.Point(12, 12);
            this.treeTabs.Name = "treeTabs";
            this.treeTabs.SelectedIndex = 0;
            this.treeTabs.Size = new System.Drawing.Size(1042, 326);
            this.treeTabs.TabIndex = 92;
            // 
            // openFolder
            // 
            this.openFolder.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.openFolder.ShowNewFolderButton = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkRed;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(933, 478);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 93;
            this.button1.Text = "Reset saved settings";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 512);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.treeTabs);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSaveBackup);
            this.Controls.Add(this.massEditGrp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "FS2020 Tree Size Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.massEditGrp.ResumeLayout(false);
            this.massEditGrp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.changeMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.changeMin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox massEditGrp;
        private System.Windows.Forms.Button btnSubtractMin;
        private System.Windows.Forms.NumericUpDown changeMax;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.CheckBox noCacti;
        private System.Windows.Forms.CheckBox noScrubs;
        private System.Windows.Forms.NumericUpDown changeMin;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Button btnAddMax;
        private System.Windows.Forms.Button btnSubtractMax;
        private System.Windows.Forms.Button btnAddMin;
        private System.Windows.Forms.Button btnSaveBackup;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog saveBackup;
        private System.Windows.Forms.TabControl treeTabs;
        private System.Windows.Forms.FolderBrowserDialog openFolder;
        private System.Windows.Forms.Button button1;
    }
}

