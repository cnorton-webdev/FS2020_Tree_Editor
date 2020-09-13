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
            this.openFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.biomesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.biomesCitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReload = new System.Windows.Forms.Button();
            this.cmbSpecies = new System.Windows.Forms.ComboBox();
            this.lstVariations = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numSpawnRatio = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numVarMax = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.chkHasSpawn = new System.Windows.Forms.CheckBox();
            this.numVarMin = new System.Windows.Forms.NumericUpDown();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblToast = new System.Windows.Forms.ToolStripStatusLabel();
            this.massEditGrp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.changeMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.changeMin)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpawnRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVarMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVarMin)).BeginInit();
            this.statusStrip1.SuspendLayout();
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
            this.massEditGrp.Location = new System.Drawing.Point(37, 459);
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
            this.btnSaveBackup.Location = new System.Drawing.Point(277, 593);
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
            this.btnSave.Location = new System.Drawing.Point(146, 593);
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
            // openFolder
            // 
            this.openFolder.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.openFolder.ShowNewFolderButton = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(520, 24);
            this.menuStrip1.TabIndex = 95;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "&Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.biomesToolStripMenuItem,
            this.biomesCitiesToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // biomesToolStripMenuItem
            // 
            this.biomesToolStripMenuItem.Name = "biomesToolStripMenuItem";
            this.biomesToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.biomesToolStripMenuItem.Text = "&Biomes";
            this.biomesToolStripMenuItem.Click += new System.EventHandler(this.BiomesToolStripMenuItem_Click);
            // 
            // biomesCitiesToolStripMenuItem
            // 
            this.biomesCitiesToolStripMenuItem.Name = "biomesCitiesToolStripMenuItem";
            this.biomesCitiesToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.biomesCitiesToolStripMenuItem.Text = "Biomes Cities";
            this.biomesCitiesToolStripMenuItem.Click += new System.EventHandler(this.BiomesCitiesToolStripMenuItem_Click);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(347, 430);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(97, 23);
            this.btnReload.TabIndex = 96;
            this.btnReload.Text = "Reload XML File";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.BtnReload_Click);
            // 
            // cmbSpecies
            // 
            this.cmbSpecies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpecies.FormattingEnabled = true;
            this.cmbSpecies.Location = new System.Drawing.Point(15, 40);
            this.cmbSpecies.MaxDropDownItems = 100;
            this.cmbSpecies.Name = "cmbSpecies";
            this.cmbSpecies.Size = new System.Drawing.Size(326, 21);
            this.cmbSpecies.TabIndex = 98;
            this.cmbSpecies.SelectedIndexChanged += new System.EventHandler(this.CmbRules_SelectedIndexChanged);
            // 
            // lstVariations
            // 
            this.lstVariations.FormattingEnabled = true;
            this.lstVariations.Location = new System.Drawing.Point(15, 98);
            this.lstVariations.Name = "lstVariations";
            this.lstVariations.Size = new System.Drawing.Size(326, 355);
            this.lstVariations.TabIndex = 97;
            this.lstVariations.SelectedIndexChanged += new System.EventHandler(this.LstVariations_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(344, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 13);
            this.label4.TabIndex = 101;
            this.label4.Text = "Selected Variation Spawn Ratio";
            // 
            // numSpawnRatio
            // 
            this.numSpawnRatio.DecimalPlaces = 2;
            this.numSpawnRatio.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numSpawnRatio.Location = new System.Drawing.Point(347, 136);
            this.numSpawnRatio.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSpawnRatio.Name = "numSpawnRatio";
            this.numSpawnRatio.Size = new System.Drawing.Size(45, 20);
            this.numSpawnRatio.TabIndex = 100;
            this.numSpawnRatio.ValueChanged += new System.EventHandler(this.NumSpawnRatio_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 102;
            this.label2.Text = "Species - Variation List";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(344, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 13);
            this.label1.TabIndex = 104;
            this.label1.Text = "Selected Variation Size - Minimum";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(344, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 13);
            this.label3.TabIndex = 106;
            this.label3.Text = "Selected Variation Size - Maximum";
            // 
            // numVarMax
            // 
            this.numVarMax.Location = new System.Drawing.Point(347, 227);
            this.numVarMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numVarMax.Name = "numVarMax";
            this.numVarMax.Size = new System.Drawing.Size(45, 20);
            this.numVarMax.TabIndex = 105;
            this.numVarMax.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numVarMax.ValueChanged += new System.EventHandler(this.NumVarMax_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 107;
            this.label5.Text = "Species";
            // 
            // chkHasSpawn
            // 
            this.chkHasSpawn.AutoSize = true;
            this.chkHasSpawn.Location = new System.Drawing.Point(347, 98);
            this.chkHasSpawn.Name = "chkHasSpawn";
            this.chkHasSpawn.Size = new System.Drawing.Size(109, 17);
            this.chkHasSpawn.TabIndex = 108;
            this.chkHasSpawn.Text = "Has Spawn Ratio";
            this.chkHasSpawn.UseVisualStyleBackColor = true;
            this.chkHasSpawn.CheckedChanged += new System.EventHandler(this.ChkHasSpawn_CheckedChanged);
            // 
            // numVarMin
            // 
            this.numVarMin.Location = new System.Drawing.Point(347, 184);
            this.numVarMin.Name = "numVarMin";
            this.numVarMin.Size = new System.Drawing.Size(45, 20);
            this.numVarMin.TabIndex = 109;
            this.numVarMin.ValueChanged += new System.EventHandler(this.NumVarMin_ValueChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblToast});
            this.statusStrip1.Location = new System.Drawing.Point(0, 627);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(520, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 110;
            // 
            // lblToast
            // 
            this.lblToast.Name = "lblToast";
            this.lblToast.Size = new System.Drawing.Size(0, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 649);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.numVarMin);
            this.Controls.Add(this.chkHasSpawn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numVarMax);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numSpawnRatio);
            this.Controls.Add(this.cmbSpecies);
            this.Controls.Add(this.lstVariations);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSaveBackup);
            this.Controls.Add(this.massEditGrp);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "FS2020 Tree Size Editor - 1.3.2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.massEditGrp.ResumeLayout(false);
            this.massEditGrp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.changeMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.changeMin)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpawnRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVarMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVarMin)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.FolderBrowserDialog openFolder;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem biomesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem biomesCitiesToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbSpecies;
        private System.Windows.Forms.ListBox lstVariations;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numSpawnRatio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numVarMax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkHasSpawn;
        private System.Windows.Forms.NumericUpDown numVarMin;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblToast;
    }
}

