using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Collections.Generic;

namespace FS2020_Tree_Size_Editor
{
    public partial class Form1 : Form
    {
        private static List<Variants> variant = new List<Variants>();
        private int selectedVariantIndex;
        XmlDocument xmlTrees = new XmlDocument();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.installLocation != "")
            {
                loadXML();
            }
            else
            {
                DialogResult result = MessageBox.Show("Oops! Looks like we don't have your game location saved. Click OK below to set the location of where you instructed the installer to install Flight Simulator 2020 to.", "Flight Simulator folder location not found", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    DialogResult folderDlg = openFolder.ShowDialog();
                    if (folderDlg == DialogResult.OK)
                    {
                        Properties.Settings.Default.installLocation = openFolder.SelectedPath;
                        Properties.Settings.Default.xmlFile = openFolder.SelectedPath + "\\Community\\Tree-Editor\\vegetation\\10-asobo_species.xml";
                        Properties.Settings.Default.xmlFileBiomes = openFolder.SelectedPath + "\\Community\\Tree-Editor\\vegetation\\10-asobo_biomes.xml";
                        Properties.Settings.Default.xmlFileBiomesCities = openFolder.SelectedPath + "\\Community\\Tree-Editor\\vegetation\\15-asobo_biomes_cities.xml";
                        Properties.Settings.Default.layoutFile = openFolder.SelectedPath + "\\Community\\Tree-Editor\\layout.json";
                        Properties.Settings.Default.manifestFile = openFolder.SelectedPath + "\\Community\\Tree-Editor\\manifest.json";
                        Properties.Settings.Default.Save();

                        loadXML();
                    }
                }

            }
        }
        public void loadXML()
        {
            string installFolder = Properties.Settings.Default.installLocation;
            string xmlFile = "";
            // Load initial data, this could be from the core file or community if we've already saved there.
            // Have we already saved into the community folder?
            if (Directory.Exists(installFolder + "\\Community\\Tree-Editor\\vegetation") && File.Exists(installFolder + "\\Community\\Tree-Editor\\vegetation\\10-asobo_species.xml"))
            {
                xmlFile = installFolder + "\\Community\\Tree-Editor\\vegetation\\10-asobo_species.xml";
            }
            // Microsoft Store
            else if (Directory.Exists(installFolder + "\\Official\\OneStore\\fs-base\\vegetation") && File.Exists(installFolder + "\\Official\\OneStore\\fs-base\\vegetation\\10-asobo_species.xml"))
            {
                xmlFile = installFolder + "\\Official\\OneStore\\fs-base\\vegetation\\10-asobo_species.xml";
            }
            // Steam
            else if (Directory.Exists(installFolder + "\\Official\\Steam\\fs-base\\vegetation") && File.Exists(installFolder + "\\Official\\Steam\\fs-base\\vegetation\\10-asobo_species.xml"))
            {
                xmlFile = installFolder + "\\Official\\Steam\\fs-base\\vegetation\\10-asobo_species.xml";
            }
            else
            {
                MessageBox.Show("We can't seem to locate your 10-asobo_species.xml file. Please close the program, verify your install location and try again.", "Error locating file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            xmlTrees.Load(xmlFile);
            XmlNodeList elemList = xmlTrees.GetElementsByTagName("Species");

            for (int i = 0; i < elemList.Count; i++)
            {
                string speciesName = elemList[i].Attributes.Item(0).Value;
                cmbSpecies.Items.Add(speciesName);
                XmlNodeList variationsNodes = xmlTrees.DocumentElement.SelectNodes("//Species[@name='" + speciesName + "']/Variations/Variation");
                int variantNumber = 1;
                foreach (XmlNode variantNode in variationsNodes)
                {
                    Variants curVariant = new Variants();
                    int minValue = 0;
                    int maxValue = 0;
                    decimal spawnRatio = 0.00m;
                    minValue = int.Parse(variantNode.ChildNodes.Item(0).Attributes["min"].Value);
                    maxValue = int.Parse(variantNode.ChildNodes.Item(0).Attributes["max"].Value);
                    if (variantNode.Attributes.Count > 0)
                    {
                        spawnRatio = decimal.Parse(variantNode.Attributes["spawnRatio"].Value);
                        curVariant.hasSpawnRatio = true;
                    }
                    else
                    {
                        curVariant.hasSpawnRatio = false;
                    }
                    curVariant.speciesName = speciesName;
                    curVariant.minimum = minValue;
                    curVariant.maximum = maxValue;
                    curVariant.spawnRatio = spawnRatio;
                    curVariant.variantNumber = variantNumber;
                    variant.Add(curVariant);
                    variantNumber++;
                }
            }
            cmbSpecies.SelectedIndex = 0;
            massEditGrp.Enabled = true;
            btnSaveBackup.Enabled = true;
            btnSave.Enabled = true;
        }

        private void BtnSaveBackup_Click(object sender, EventArgs e)
        {
            saveBackup.ShowDialog();
        }

        private void SaveBackup_FileOk(object sender, CancelEventArgs e)
        {
            xmlTrees.Save(saveBackup.FileName);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string curSpecies = null;
            XmlNodeList variations = null;

            foreach (Variants v in variant)
            {
                // Only update variations node list if different species or first loop
                if (curSpecies == null || curSpecies != v.speciesName)
                {
                    variations = xmlTrees.DocumentElement.SelectNodes("//Species[@name='" + v.speciesName + "']/Variations/Variation");
                    curSpecies = v.speciesName;
                }
                if (v.hasSpawnRatio && variations[v.variantNumber - 1].Attributes["spawnRatio"] == null)
                {
                    XmlAttribute spawnRatioNode = xmlTrees.CreateAttribute("spawnRatio");
                    spawnRatioNode.Value = v.spawnRatio.ToString();
                    variations[v.variantNumber - 1].Attributes.Append(spawnRatioNode);
                }
                else if (v.hasSpawnRatio == false)
                {
                    variations[v.variantNumber - 1].Attributes.RemoveNamedItem("spawnRatio");
                }
                variations[v.variantNumber - 1].FirstChild.Attributes["min"].Value = v.minimum.ToString();
                variations[v.variantNumber - 1].FirstChild.Attributes["max"].Value = v.maximum.ToString();
            }    
            xmlTrees.Save(Properties.Settings.Default.xmlFile);
            int xmlFileSize = (int)new FileInfo(Properties.Settings.Default.xmlFile).Length;
            Layout layout = new Layout();
            layout.setSize(xmlFileSize);
            File.WriteAllText(Properties.Settings.Default.layoutFile, layout.getJson());
            if (File.Exists(Properties.Settings.Default.xmlFileBiomes))
            {
                xmlFileSize += (int)new FileInfo(Properties.Settings.Default.xmlFileBiomes).Length;
            }
            if (File.Exists(Properties.Settings.Default.xmlFileBiomesCities))
            {
                xmlFileSize += (int)new FileInfo(Properties.Settings.Default.xmlFileBiomesCities).Length;
            }
            Manifest manifest = new Manifest();
            manifest.setSize(xmlFileSize);
            File.WriteAllText(Properties.Settings.Default.manifestFile, manifest.getJson());
            lblToast.Text = "Successfully saved to community folder";
        }

        private void BtnSubtractMin_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < variant.Count; i++)
            {
                // No Scrubs. If variant has scrub in the name and no scrubs checked, skip it.
                if (noScrubs.Checked && (variant[i].speciesName.Contains("scrub") || variant[i].speciesName.Contains("shrub")))
                {
                    continue;
                }
                // If no cactus and this cariant has cactus in the name, skip it.
                if (noCacti.Checked && variant[i].speciesName.Contains("cactus"))
                {
                    continue;
                }
                variant[i].minimum -= (int)changeMin.Value;

                if (variant[i].minimum < 0)
                    variant[i].minimum = 0;
            }
            lblToast.Text = "Successfully subtracted " + changeMin.Value.ToString() + " from all variants minimum values";
            if (lstVariations.SelectedIndex > -1)
            {
                numVarMin.Value = variant[selectedVariantIndex].minimum;
            }
        }

        private void BtnAddMin_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < variant.Count; i++)
            {
                // No Scrubs. If variant has scrub in the name and no scrubs checked, skip it.
                if (noScrubs.Checked && (variant[i].speciesName.Contains("scrub") || variant[i].speciesName.Contains("shrub")))
                {
                    continue;
                }
                // If no cactus and this cariant has cactus in the name, skip it.
                if (noCacti.Checked && variant[i].speciesName.Contains("cactus"))
                {
                    continue;
                }
                variant[i].maximum += (int)changeMax.Value;
                if (variant[i].maximum > 100)
                    variant[i].maximum = 100;
            }
            lblToast.Text = "Successfully added " + changeMax.Value.ToString() + " to all variants minimum values";
            if (lstVariations.SelectedIndex > -1)
            {
                numVarMax.Value = variant[selectedVariantIndex].maximum;
            }
        }

        private void BtnSubtractMax_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < variant.Count; i++)
            {
                // No Scrubs. If variant has scrub in the name and no scrubs checked, skip it.
                if (noScrubs.Checked && (variant[i].speciesName.Contains("scrub") || variant[i].speciesName.Contains("shrub")))
                {
                    continue;
                }
                // If no cactus and this cariant has cactus in the name, skip it.
                if (noCacti.Checked && variant[i].speciesName.Contains("cactus"))
                {
                    continue;
                }
                variant[i].maximum -= (int)changeMax.Value;
                if (variant[i].maximum < 1)
                    variant[i].maximum = 1;
            }
            lblToast.Text = "Successfully subtracted " + changeMax.Value.ToString() + " from all variants maximum values";
            if (lstVariations.SelectedIndex > -1)
            {
                numVarMax.Value = variant[selectedVariantIndex].maximum;
            }
        }

        private void BtnAddMax_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < variant.Count; i++)
            {
                // No Scrubs. If variant has scrub in the name and no scrubs checked, skip it.
                if (noScrubs.Checked && (variant[i].speciesName.Contains("scrub") || variant[i].speciesName.Contains("shrub")))
                {
                    continue;
                }
                // If no cactus and this cariant has cactus in the name, skip it.
                if (noCacti.Checked && variant[i].speciesName.Contains("cactus"))
                {
                    continue;
                }
                variant[i].maximum += (int)changeMax.Value;
                if (variant[i].maximum > 100)
                    variant[i].maximum = 100;
            }
            lblToast.Text = "Successfully added " + changeMax.Value.ToString() + " to all variants maximum values";
            if (lstVariations.SelectedIndex > -1)
            {
                numVarMax.Value = variant[selectedVariantIndex].maximum;
            }
        }

        private void BtnReload_Click(object sender, EventArgs e)
        {
            loadXML();
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settingsForm = new Settings();
            settingsForm.Show();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BiomesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Biomes biomeForm = new Biomes();
            biomeForm.Show();
        }

        private void BiomesCitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BiomesCities biomeCitiesForm = new BiomesCities();
            biomeCitiesForm.Show();
        }

        private void CmbRules_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstVariations.Items.Clear();
            List<Variants> results = variant.FindAll(r => r.speciesName.Equals(cmbSpecies.SelectedItem.ToString()));
            foreach (Variants v in results)
            {
                lstVariations.Items.Add("Variation " + v.variantNumber);
            }
            // On species change, reset our fields to default and reset selected variant index of -1 to prevent saving changes on field change
            selectedVariantIndex = -1;
            chkHasSpawn.Checked = false;
            numVarMax.Value = 1;
            numVarMin.Value = 0;
            numSpawnRatio.Value = 0.00m;
        }

        private void ChkHasSpawn_CheckedChanged(object sender, EventArgs e)
        {
            if (selectedVariantIndex > -1)
            {
                if (chkHasSpawn.Checked)
                {
                    variant[selectedVariantIndex].hasSpawnRatio = true;
                    numSpawnRatio.Enabled = true;
                    numSpawnRatio.Enabled = true;

                }
                else
                {
                    variant[selectedVariantIndex].hasSpawnRatio = false;
                    numSpawnRatio.Enabled = false;
                    numSpawnRatio.Enabled = false;
                }

            }
        }

        private void LstVariations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstVariations.SelectedIndex > -1)
            {
                // Parse out what variant ID we are working on from the name
                int varNumber = int.Parse(lstVariations.SelectedItem.ToString().Split(' ')[1]);
                // Get the variant information to populate fields
                Variants item = variant.Find(r => (r.speciesName.Equals(cmbSpecies.SelectedItem.ToString()) && (r.variantNumber.Equals(varNumber))));
                // Store what index we are currently working on globally to save changes to this item
                selectedVariantIndex = variant.FindIndex(r => (r.speciesName.Equals(cmbSpecies.SelectedItem.ToString()) && (r.variantNumber.Equals(varNumber))));
                chkHasSpawn.Checked = item.hasSpawnRatio;
                numSpawnRatio.Value = item.spawnRatio;
                numVarMin.Value = item.minimum;
                numVarMax.Value = item.maximum;
                if (item.hasSpawnRatio == false)
                    numSpawnRatio.Enabled = false;
            }
        }

        private void NumSpawnRatio_ValueChanged(object sender, EventArgs e)
        {
            if (selectedVariantIndex > -1)
            {
                variant[selectedVariantIndex].spawnRatio = numSpawnRatio.Value;
            }
        }
        private void NumVarMax_ValueChanged(object sender, EventArgs e)
        {
            if (selectedVariantIndex > -1)
            {
                variant[selectedVariantIndex].maximum = (int)numVarMax.Value;
            }
        }

        private void NumVarMin_ValueChanged(object sender, EventArgs e)
        {
            if (selectedVariantIndex > -1)
            {
                variant[selectedVariantIndex].minimum = (int)numVarMin.Value;
            }
        }
    }

    public class Layout
    {
        public int size = 0;
        public void setSize(int fileSize)
        {
            size = fileSize;
        }
        public string getJson()
        {
            string jsonOut = "{\n" +
                    "  \"content\": [\n";

            if (File.Exists(Properties.Settings.Default.xmlFileBiomes))
            {
                jsonOut += "    {\n" +
                    "      \"path\": \"vegetation/10-asobo_biomes.xml\",\n" +
                    "      \"size\": " + (int)new FileInfo(Properties.Settings.Default.xmlFileBiomes).Length + ",\n" +
                    "      \"date\": 132387590510000000\n" +
                    "    }\n";
            }
            if (File.Exists(Properties.Settings.Default.xmlFileBiomesCities))
            {
                jsonOut += "    ,{\n" +
                    "      \"path\": \"vegetation/15-asobo_biomes_cities.xml\",\n" +
                    "      \"size\": " + (int)new FileInfo(Properties.Settings.Default.xmlFileBiomesCities).Length + ",\n" +
                    "      \"date\": 132387590510000000\n" +
                    "    }\n";
            }

            if (jsonOut.Length > 20)
                jsonOut += "    ,{\n";
            else
                jsonOut += "    {\n";

            jsonOut +=
                "      \"path\": \"vegetation/10-asobo_species.xml\",\n" +
                "      \"size\": " + size + ",\n" +
                "      \"date\": 132387590510000000\n" +
                "    }\n" +
                "  ]\n" +
                "}";

            return jsonOut;
        }
    }
    public class Manifest
    {
        private string totalSize = "".PadLeft(20, '0');
        public void setSize(int fileSize)
        {
            totalSize = fileSize.ToString().PadLeft(20 - fileSize.ToString().Length, '0');
        }
        public string getJson()
        {
            return "{\n" +
                "  \"dependencies\": [],\n" +
                "  \"content_type\": \"CORE\",\n" +
                "  \"title\": \"\",\n" +
                "  \"manufacturer\": \"\",\n" +
                "  \"creator\": \"community fix\",\n" +
                "  \"package_version\": \"0.1.80\",\n" +
                "  \"minimum_game_version\": \"1.7.12\",\n" +
                "  \"release_notes\": {\n" +
                "    \"neutral\": {\n" +
                "      \"LastUpdate\": \"\",\n" +
                "      \"OlderHistory\": \"\"\n" +
                "    }\n" +
                "  },\n" +
                "  \"total_package_size\": \"" + totalSize + "\"\n" +
                "}";
        }
    }
    public class Variants
    {
        public string speciesName { get; set; }
        public int variantNumber { get; set; }
        public int minimum { get; set; }
        public int maximum { get; set; }
        public decimal spawnRatio { get; set; }
        public bool hasSpawnRatio { get; set; }
    }
}
