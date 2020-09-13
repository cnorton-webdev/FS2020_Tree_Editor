namespace FS2020_Tree_Size_Editor
{
    partial class Biomes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Biomes));
            this.lstRegions = new System.Windows.Forms.ListBox();
            this.cmbRules = new System.Windows.Forms.ComboBox();
            this.lstSpecies = new System.Windows.Forms.ListBox();
            this.numSpawnRatio = new System.Windows.Forms.NumericUpDown();
            this.numScaleFactor = new System.Windows.Forms.NumericUpDown();
            this.numSpeciesInstances = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNewRule = new System.Windows.Forms.TextBox();
            this.btnRemoveRegion = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRemoveSpecies = new System.Windows.Forms.Button();
            this.btnAddSpecies = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.lstAllSpecies = new System.Windows.Forms.ListBox();
            this.btnAddRegions = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button2 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lstAllRegions = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.numSpawnRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScaleFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeciesInstances)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstRegions
            // 
            this.lstRegions.FormattingEnabled = true;
            this.lstRegions.Location = new System.Drawing.Point(12, 83);
            this.lstRegions.Name = "lstRegions";
            this.lstRegions.Size = new System.Drawing.Size(326, 355);
            this.lstRegions.TabIndex = 0;
            // 
            // cmbRules
            // 
            this.cmbRules.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRules.FormattingEnabled = true;
            this.cmbRules.Location = new System.Drawing.Point(12, 25);
            this.cmbRules.MaxDropDownItems = 100;
            this.cmbRules.Name = "cmbRules";
            this.cmbRules.Size = new System.Drawing.Size(326, 21);
            this.cmbRules.TabIndex = 1;
            this.cmbRules.SelectedIndexChanged += new System.EventHandler(this.CmbRules_SelectedIndexChanged);
            // 
            // lstSpecies
            // 
            this.lstSpecies.FormattingEnabled = true;
            this.lstSpecies.Location = new System.Drawing.Point(344, 83);
            this.lstSpecies.Name = "lstSpecies";
            this.lstSpecies.Size = new System.Drawing.Size(195, 355);
            this.lstSpecies.TabIndex = 2;
            this.lstSpecies.SelectedIndexChanged += new System.EventHandler(this.LstSpecies_SelectedIndexChanged);
            // 
            // numSpawnRatio
            // 
            this.numSpawnRatio.DecimalPlaces = 2;
            this.numSpawnRatio.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numSpawnRatio.Location = new System.Drawing.Point(561, 83);
            this.numSpawnRatio.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSpawnRatio.Name = "numSpawnRatio";
            this.numSpawnRatio.Size = new System.Drawing.Size(45, 20);
            this.numSpawnRatio.TabIndex = 3;
            this.numSpawnRatio.ValueChanged += new System.EventHandler(this.NumSpawnRatio_ValueChanged);
            // 
            // numScaleFactor
            // 
            this.numScaleFactor.DecimalPlaces = 2;
            this.numScaleFactor.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numScaleFactor.Location = new System.Drawing.Point(561, 26);
            this.numScaleFactor.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numScaleFactor.Name = "numScaleFactor";
            this.numScaleFactor.Size = new System.Drawing.Size(45, 20);
            this.numScaleFactor.TabIndex = 4;
            this.numScaleFactor.ValueChanged += new System.EventHandler(this.NumScaleFactor_ValueChanged);
            // 
            // numSpeciesInstances
            // 
            this.numSpeciesInstances.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numSpeciesInstances.Location = new System.Drawing.Point(344, 26);
            this.numSpeciesInstances.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.numSpeciesInstances.Name = "numSpeciesInstances";
            this.numSpeciesInstances.Size = new System.Drawing.Size(96, 20);
            this.numSpeciesInstances.TabIndex = 5;
            this.numSpeciesInstances.ValueChanged += new System.EventHandler(this.NumSpeciesInstances_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Biome Rules";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Biome Rule - Eco Region List";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(344, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Biome Rule - Species";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(558, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Selected Species Spawn Ratio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(341, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(203, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Species instances per hectar (2.47 acres)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(558, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Artificial surfaces scale factor";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(545, 415);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save changes";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Add new Biome Rule";
            // 
            // txtNewRule
            // 
            this.txtNewRule.Location = new System.Drawing.Point(8, 65);
            this.txtNewRule.Name = "txtNewRule";
            this.txtNewRule.Size = new System.Drawing.Size(326, 20);
            this.txtNewRule.TabIndex = 14;
            // 
            // btnRemoveRegion
            // 
            this.btnRemoveRegion.Location = new System.Drawing.Point(8, 19);
            this.btnRemoveRegion.Name = "btnRemoveRegion";
            this.btnRemoveRegion.Size = new System.Drawing.Size(304, 23);
            this.btnRemoveRegion.TabIndex = 15;
            this.btnRemoveRegion.Text = "Remove Selected Eco Region Above From Selected Rule";
            this.btnRemoveRegion.UseVisualStyleBackColor = true;
            this.btnRemoveRegion.Click += new System.EventHandler(this.BtnRemoveRegion_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRemoveSpecies);
            this.groupBox1.Controls.Add(this.btnAddSpecies);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lstAllSpecies);
            this.groupBox1.Controls.Add(this.btnAddRegions);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lstAllRegions);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnRemoveRegion);
            this.groupBox1.Controls.Add(this.txtNewRule);
            this.groupBox1.Location = new System.Drawing.Point(4, 444);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(706, 345);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Advanced Tweaking";
            // 
            // btnRemoveSpecies
            // 
            this.btnRemoveSpecies.Location = new System.Drawing.Point(340, 19);
            this.btnRemoveSpecies.Name = "btnRemoveSpecies";
            this.btnRemoveSpecies.Size = new System.Drawing.Size(278, 23);
            this.btnRemoveSpecies.TabIndex = 23;
            this.btnRemoveSpecies.Text = "Remove Selected Species Above From Selected Rule";
            this.btnRemoveSpecies.UseVisualStyleBackColor = true;
            this.btnRemoveSpecies.Click += new System.EventHandler(this.BtnRemoveSpecies_Click);
            // 
            // btnAddSpecies
            // 
            this.btnAddSpecies.Location = new System.Drawing.Point(623, 301);
            this.btnAddSpecies.Name = "btnAddSpecies";
            this.btnAddSpecies.Size = new System.Drawing.Size(75, 23);
            this.btnAddSpecies.TabIndex = 22;
            this.btnAddSpecies.Text = "Add Species";
            this.btnAddSpecies.UseVisualStyleBackColor = true;
            this.btnAddSpecies.Click += new System.EventHandler(this.BtnAddSpecies_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(436, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(179, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Add selected Species to Biome Rule";
            // 
            // lstAllSpecies
            // 
            this.lstAllSpecies.FormattingEnabled = true;
            this.lstAllSpecies.Location = new System.Drawing.Point(440, 112);
            this.lstAllSpecies.Name = "lstAllSpecies";
            this.lstAllSpecies.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstAllSpecies.Size = new System.Drawing.Size(178, 212);
            this.lstAllSpecies.TabIndex = 20;
            // 
            // btnAddRegions
            // 
            this.btnAddRegions.Location = new System.Drawing.Point(340, 301);
            this.btnAddRegions.Name = "btnAddRegions";
            this.btnAddRegions.Size = new System.Drawing.Size(85, 23);
            this.btnAddRegions.TabIndex = 19;
            this.btnAddRegions.Text = "Add Regions";
            this.btnAddRegions.UseVisualStyleBackColor = true;
            this.btnAddRegions.Click += new System.EventHandler(this.BtnAddRegions_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(5, 327);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(210, 13);
            this.linkLabel1.TabIndex = 17;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "List of eco regions for the world (Wikipedia)";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(340, 63);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Create";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(202, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Add selected Eco Regions to Biome Rule";
            // 
            // lstAllRegions
            // 
            this.lstAllRegions.FormattingEnabled = true;
            this.lstAllRegions.Location = new System.Drawing.Point(8, 112);
            this.lstAllRegions.Name = "lstAllRegions";
            this.lstAllRegions.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstAllRegions.Size = new System.Drawing.Size(326, 212);
            this.lstAllRegions.Sorted = true;
            this.lstAllRegions.TabIndex = 16;
            // 
            // Biomes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(737, 801);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numSpeciesInstances);
            this.Controls.Add(this.numScaleFactor);
            this.Controls.Add(this.numSpawnRatio);
            this.Controls.Add(this.lstSpecies);
            this.Controls.Add(this.cmbRules);
            this.Controls.Add(this.lstRegions);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Biomes";
            this.Text = "FS2020 Tree Editor - Biomes";
            this.Load += new System.EventHandler(this.Biomes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numSpawnRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScaleFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeciesInstances)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstRegions;
        private System.Windows.Forms.ComboBox cmbRules;
        private System.Windows.Forms.ListBox lstSpecies;
        private System.Windows.Forms.NumericUpDown numSpawnRatio;
        private System.Windows.Forms.NumericUpDown numSpeciesInstances;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numScaleFactor;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNewRule;
        private System.Windows.Forms.Button btnRemoveRegion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox lstAllRegions;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnAddRegions;
        private System.Windows.Forms.Button btnAddSpecies;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox lstAllSpecies;
        private System.Windows.Forms.Button btnRemoveSpecies;
    }
}