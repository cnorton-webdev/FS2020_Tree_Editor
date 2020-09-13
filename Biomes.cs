using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace FS2020_Tree_Size_Editor
{
    public partial class Biomes : Form
    {
        XmlDocument xmlBiomes = new XmlDocument();
        public Biomes()
        {
            InitializeComponent();
        }

        private void Biomes_Load(object sender, EventArgs e)
        {
            loadBiomeXML();
        }

        public void loadBiomeXML()
        {
            string installFolder = Properties.Settings.Default.installLocation;
            string xmlFile = "";
            if (Properties.Settings.Default.xmlFileBiomes == "")
            {
                Properties.Settings.Default.xmlFileBiomes = installFolder + "\\Community\\Tree-Editor\\vegetation\\10-asobo_biomes.xml";
                Properties.Settings.Default.Save();
            }
            // Load initial data, this could be from the core file or community if we've already saved there.
            // Have we already saved into the community folder?
            if (Directory.Exists(installFolder + "\\Community\\Tree-Editor\\vegetation") && File.Exists(installFolder + "\\Community\\Tree-Editor\\vegetation\\10-asobo_biomes.xml"))
            {
                xmlFile = installFolder + "\\Community\\Tree-Editor\\vegetation\\10-asobo_biomes.xml";
            }
            // Microsoft Store
            else if (Directory.Exists(installFolder + "\\Official\\OneStore\\fs-base\\vegetation") && File.Exists(installFolder + "\\Official\\OneStore\\fs-base\\vegetation\\10-asobo_biomes.xml"))
            {
                xmlFile = installFolder + "\\Official\\OneStore\\fs-base\\vegetation\\10-asobo_biomes.xml";
            }
            // Steam
            else if (Directory.Exists(installFolder + "\\Official\\Steam\\fs-base\\vegetation") && File.Exists(installFolder + "\\Official\\Steam\\fs-base\\vegetation\\10-asobo_biomes.xml"))
            {
                xmlFile = installFolder + "\\Official\\Steam\\fs-base\\vegetation\\10-asobo_biomes.xml";
            }
            else
            {
                MessageBox.Show("We can't seem to locate your 10-asobo_biomes.xml file. Please close the program, verify your install location and try again.", "Error locating file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            xmlBiomes.Load(xmlFile);
            XmlNodeList elemList = xmlBiomes.GetElementsByTagName("BiomeRule");

            for (int i = 0; i < elemList.Count; i++)
            {
                cmbRules.Items.Add(elemList[i].Attributes[0].Value);
                // Add each EcoRegion node name to the advanced tweaking list
                XmlNodeList ecoRegionList = xmlBiomes.DocumentElement.SelectNodes("//BiomeRule[@name='" + elemList[i].Attributes[0].Value + "']/EcoRegionList/EcoRegion");
                for (int x = 0; x < ecoRegionList.Count; x++)
                {
                    bool existsAlready = false;
                    // Make sure we aren't duplicating Eco Regions in the list
                    foreach (var item in lstAllRegions.Items)
                    {
                        if (item.ToString() == ecoRegionList[x].Attributes.GetNamedItem("name").Value)
                        {
                            existsAlready = true;
                            break;
                        }
                    }
                    if (existsAlready == false)
                    {
                        lstAllRegions.Items.Add(ecoRegionList[x].Attributes.GetNamedItem("name").Value);
                    }
                }
                // Add each Species node name to the advanced tweaking list
                XmlNodeList speciesList = xmlBiomes.DocumentElement.SelectNodes("//BiomeRule[@name='" + elemList[i].Attributes[0].Value + "']/SpeciesList/Species");
                for (int x = 0; x < speciesList.Count; x++)
                {
                    bool existsAlready = false;
                    // Make sure we aren't duplicating Species in the list
                    foreach (var item in lstAllSpecies.Items)
                    {
                        if (item.ToString() == speciesList[x].Attributes.GetNamedItem("name").Value)
                        {
                            existsAlready = true;
                            break;
                        }
                    }
                    if (existsAlready == false)
                    {
                        lstAllSpecies.Items.Add(speciesList[x].Attributes.GetNamedItem("name").Value);
                    }
                }
            }
            cmbRules.SelectedIndex = 0;
        }

        private void CmbRules_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstRegions.Items.Clear();
            lstSpecies.Items.Clear();
            string biomeRule = cmbRules.SelectedItem.ToString();
            // Add each EcoRegion node name to the dropdown box for this Biome rule
            XmlNodeList ecoRegionList = xmlBiomes.DocumentElement.SelectNodes("//BiomeRule[@name='" + biomeRule + "']/EcoRegionList/EcoRegion");
            for (int i = 0; i < ecoRegionList.Count; i++)
            {
                lstRegions.Items.Add(ecoRegionList[i].Attributes.GetNamedItem("name").Value);
            }
            // Add each Species node name to the listbox for this Biome rule
            XmlNodeList speciesList = xmlBiomes.DocumentElement.SelectNodes("//BiomeRule[@name='" + biomeRule + "']/SpeciesList/Species");
            for (int i = 0; i < speciesList.Count; i++)
            {
                lstSpecies.Items.Add(speciesList[i].Attributes.GetNamedItem("name").Value);
            }
            // Get Biome rule species instances and scale factor
            XmlNode biomeRuleNode = xmlBiomes.DocumentElement.SelectSingleNode("//BiomeRule[@name='" + biomeRule + "']");
            numSpeciesInstances.Value = int.Parse(biomeRuleNode.Attributes.GetNamedItem("speciesInstancesPerHectar").Value);
            numScaleFactor.Value = decimal.Parse(biomeRuleNode.Attributes.GetNamedItem("artificialSurfacesScaleFactor").Value);
        }

        private void LstSpecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSpecies.SelectedIndex > -1)
            {
                string biomeRule = cmbRules.SelectedItem.ToString();
                string speciesName = lstSpecies.SelectedItem.ToString();
                decimal speciesSpawnRatio = 0;
                // Get the specific Biome rule and Species XML node
                XmlNode species = xmlBiomes.DocumentElement.SelectSingleNode("//BiomeRule[@name='" + biomeRule + "']/SpeciesList/Species[@name='" + speciesName + "']");
                // Get the spawnRatio attribute for this node
                try
                {
                    numSpawnRatio.Enabled = true;
                    speciesSpawnRatio = decimal.Parse(species.Attributes.GetNamedItem("spawnRatio").Value);
                    numSpawnRatio.Value = speciesSpawnRatio;
                }
                catch
                {
                    numSpawnRatio.Enabled = false;
                }
            }
        }

        private void NumSpawnRatio_ValueChanged(object sender, EventArgs e)
        {
            string biomeRule = cmbRules.SelectedItem.ToString();
            string speciesName = lstSpecies.SelectedItem.ToString();
            // Get the specific Biome rule and Species XML node
            XmlNode species = xmlBiomes.DocumentElement.SelectSingleNode("//BiomeRule[@name='" + biomeRule + "']/SpeciesList/Species[@name='" + speciesName + "']");
            // spawnRatio is always the 2nd attribute in the node
            species.Attributes[1].Value = numSpawnRatio.Value.ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // Setup our new XML node data
            XmlNode newBiome = xmlBiomes.CreateNode(XmlNodeType.Element, "BiomeRule", xmlBiomes.NamespaceURI);
            XmlAttribute bioName = xmlBiomes.CreateAttribute("name");
            XmlAttribute bioSpeciesInstances = xmlBiomes.CreateAttribute("speciesInstancesPerHectar");
            XmlAttribute bioScaleFactor = xmlBiomes.CreateAttribute("artificialSurfacesScaleFactor");
            bioSpeciesInstances.Value = "0";
            bioScaleFactor.Value = "0";
            bioName.Value = txtNewRule.Text.Replace(" ", "_");
            // Add our attributes for BiomeRule
            newBiome.Attributes.Append(bioName);
            newBiome.Attributes.Append(bioSpeciesInstances);
            newBiome.Attributes.Append(bioScaleFactor);
            // Add our new BiomeRule to the XML
            xmlBiomes.DocumentElement.AppendChild(newBiome);
            reloadBiomeRules(txtNewRule.Text.Replace(" ", "_"));
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Open default browser for list of Eco Regions on Wikipedia
            System.Diagnostics.Process.Start("https://wikipedia.org/wiki/List_of_terrestrial_ecoregions_(WWF)");
        }
        private void reloadBiomeRules(string selectValue = "")
        {
            XmlNodeList elemList = xmlBiomes.GetElementsByTagName("BiomeRule");

            for (int i = 0; i < elemList.Count; i++)
            {
                cmbRules.Items.Add(elemList[i].Attributes[0].Value);
                if (selectValue != "")
                {
                    if (elemList[i].Attributes[0].Value == selectValue)
                    {
                        cmbRules.SelectedIndex = cmbRules.Items.Count - 1;
                    }
                }
            }
        }

        private void BtnAddRegions_Click(object sender, EventArgs e)
        {
            string biomeRuleName = cmbRules.SelectedItem.ToString();
            XmlNode biomeRule = xmlBiomes.DocumentElement.SelectSingleNode("//BiomeRule[@name='" + biomeRuleName + "']");
            // Setup our new XML node data
            XmlNode newRegionList = xmlBiomes.CreateNode(XmlNodeType.Element, "EcoRegionList", xmlBiomes.NamespaceURI);
            foreach (var item in lstAllRegions.SelectedItems)
            {
                XmlNode newRegion = xmlBiomes.CreateNode(XmlNodeType.Element, "EcoRegion", xmlBiomes.NamespaceURI);
                XmlAttribute regionName = xmlBiomes.CreateAttribute("name");
                regionName.Value = item.ToString();
                newRegion.Attributes.Append(regionName);
                newRegionList.AppendChild(newRegion);
            }
            biomeRule.AppendChild(newRegionList);
            reloadBiomeRules(biomeRuleName);
        }

        private void BtnAddSpecies_Click(object sender, EventArgs e)
        {
            string biomeRuleName = cmbRules.SelectedItem.ToString();
            XmlNode newSpeciesList;
            XmlNode biomeRule = xmlBiomes.DocumentElement.SelectSingleNode("//BiomeRule[@name='" + biomeRuleName + "']");
            bool newList;
            // Setup our new XML node data
            try
            {
                // We need to test if the SpeciesList node exists
                var nodeSpeciesListTest = xmlBiomes.DocumentElement.SelectSingleNode("//BiomeRule[@name='" + biomeRuleName + "']/SpeciesList").InnerXml;
                newList = false;
            }
            catch
            {
                newList = true;
            }
            if (newList == false)
            {
                newSpeciesList = xmlBiomes.DocumentElement.SelectSingleNode("//BiomeRule[@name='" + biomeRuleName + "']/SpeciesList");
            }
            else
            {
                newSpeciesList = xmlBiomes.CreateNode(XmlNodeType.Element, "SpeciesList", xmlBiomes.NamespaceURI);
            }
            // Add new species to the species list for new Biome rule
            foreach (var item in lstAllSpecies.SelectedItems)
            {
                if (xmlBiomes.DocumentElement.SelectSingleNode("//BiomeRule[@name='" + biomeRuleName + "']/SpeciesList/Species[@name='" + item.ToString() + "']") == null)
                {
                    XmlNode newSpecies = xmlBiomes.CreateNode(XmlNodeType.Element, "Species", xmlBiomes.NamespaceURI);
                    XmlAttribute speciesName = xmlBiomes.CreateAttribute("name");
                    XmlAttribute speciesSpawnRatio = xmlBiomes.CreateAttribute("spawnRatio");
                    speciesName.Value = item.ToString();
                    speciesSpawnRatio.Value = "0";
                    newSpecies.Attributes.Append(speciesName);
                    newSpecies.Attributes.Append(speciesSpawnRatio);
                    newSpeciesList.AppendChild(newSpecies);
                }
            }
            if (newList)
            {
                // Add our new SpeciesList node
                biomeRule.AppendChild(newSpeciesList);

            }
            else
            {
                // If we already have a SpeciesList and are adding a new species, we need to replace the node with the new one
                biomeRule.ReplaceChild(newSpeciesList, xmlBiomes.DocumentElement.SelectSingleNode("//BiomeRule[@name='" + biomeRuleName + "']/SpeciesList"));
            }
            reloadBiomeRules(biomeRuleName);
        }

        private void BtnRemoveRegion_Click(object sender, EventArgs e)
        {
            string biomeRule = cmbRules.SelectedItem.ToString();
            string ecoRegion = lstRegions.SelectedItem.ToString();
            XmlNode biomeRegionList = xmlBiomes.DocumentElement.SelectSingleNode("//BiomeRule[@name='" + biomeRule + "']/EcoRegionList");
            XmlNode biomeRuleRegion = xmlBiomes.DocumentElement.SelectSingleNode("//BiomeRule[@name='" + biomeRule + "']/EcoRegionList/EcoRegion[@name='" + ecoRegion + "']");
            biomeRegionList.RemoveChild(biomeRuleRegion);
            reloadBiomeRules(biomeRule);
        }

        private void BtnRemoveSpecies_Click(object sender, EventArgs e)
        {
            string biomeRule = cmbRules.SelectedItem.ToString();
            string speciesListName = lstSpecies.SelectedItem.ToString();
            XmlNode biomeSpeciesList = xmlBiomes.DocumentElement.SelectSingleNode("//BiomeRule[@name='" + biomeRule + "']/SpeciesList");
            XmlNode biomeRuleSpecies = xmlBiomes.DocumentElement.SelectSingleNode("//BiomeRule[@name='" + biomeRule + "']/SpeciesList/Species[@name='" + speciesListName + "']");
            biomeSpeciesList.RemoveChild(biomeRuleSpecies);
            reloadBiomeRules(biomeRule);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string installFolder = Properties.Settings.Default.installLocation;
            if (Directory.Exists(installFolder + "\\Community\\Tree-Editor\\vegetation") == false)
            {
                Directory.CreateDirectory(installFolder + "\\Community\\Tree-Editor\\vegetation");
            }
            xmlBiomes.Save(Properties.Settings.Default.xmlFileBiomes);

            int xmlFileSize = (int)new FileInfo(Properties.Settings.Default.xmlFileBiomes).Length;
            LayoutJson layout = new LayoutJson();
            layout.setSize(xmlFileSize);
            File.WriteAllText(Properties.Settings.Default.layoutFile, layout.getJson());
            if (File.Exists(Properties.Settings.Default.xmlFile))
            {
                xmlFileSize += (int)new FileInfo(Properties.Settings.Default.xmlFile).Length;
            }
            if (File.Exists(Properties.Settings.Default.xmlFileBiomesCities))
            {
                xmlFileSize += (int)new FileInfo(Properties.Settings.Default.xmlFileBiomesCities).Length;
            }
            Manifest manifest = new Manifest();
            manifest.setSize(xmlFileSize);
            File.WriteAllText(Properties.Settings.Default.manifestFile, manifest.getJson());
        }
        public class LayoutJson
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

                if (File.Exists(Properties.Settings.Default.xmlFile))
                {
                    jsonOut += "    {\n" +
                        "      \"path\": \"vegetation/10-asobo_species.xml\",\n" +
                        "      \"size\": " + (int)new FileInfo(Properties.Settings.Default.xmlFile).Length + ",\n" +
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
                    "      \"path\": \"vegetation/10-asobo_biomes.xml\",\n" +
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

        private void NumSpeciesInstances_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string biomeRule = cmbRules.SelectedItem.ToString();
                // Get the specific Biome rule node
                XmlNode biomeRuleNode = xmlBiomes.DocumentElement.SelectSingleNode("//BiomeRule[@name='" + biomeRule + "']");
                // Species instances is always the 2nd attribute in the node
                biomeRuleNode.Attributes[1].Value = numSpeciesInstances.Value.ToString();
            }
            catch
            { }
        }

        private void NumScaleFactor_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string biomeRule = cmbRules.SelectedItem.ToString();
                // Get the specific Biome rule node
                XmlNode biomeRuleNode = xmlBiomes.DocumentElement.SelectSingleNode("//BiomeRule[@name='" + biomeRule + "']");
                // Scale factor is always the 3rd attribute in the node
                biomeRuleNode.Attributes[2].Value = numScaleFactor.Value.ToString();
            }
            catch
            { }
        }
    }
}
