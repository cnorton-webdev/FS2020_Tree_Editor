using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace FS2020_Tree_Size_Editor
{
    public partial class Form1 : Form
    {
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
            } else
            {
                MessageBox.Show("We can't seem to locate your 10-asobo_species.xml file. Please close the program, verify your install location and try again.", "Error locating file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            xmlTrees.Load(xmlFile);
            XmlNodeList elemList = xmlTrees.GetElementsByTagName("Species");

            for (int i = 0; i < elemList.Count; i++)
            {
                treeTabs.TabPages.Add(elemList[i].Attributes.Item(0).Value);
                int curTab = treeTabs.TabPages.Count - 1;
                int childCount = 0;
                for (int x = 0; x < elemList[i].ChildNodes[0].ChildNodes.Count; x++)
                {
                    childCount++;

                    Label variantLbl = new Label
                    {
                        Text = "Variant " + childCount + " Minimum:"
                    };

                    NumericUpDown minNum = new NumericUpDown
                    {
                        Name = "minNum_" + childCount,
                        Size = new Size(40, 26)
                    };

                    int height = 35 * childCount;

                    variantLbl.Location = new Point(10, height);
                    minNum.Location = new Point(variantLbl.Location.X + 100, height);

                    Label maxLbl = new Label
                    {
                        Text = "Maximum:",
                        AutoSize = true
                    };
                    maxLbl.Location = new Point(minNum.Location.X + 50, height);

                    NumericUpDown maxNum = new NumericUpDown
                    {
                        Name = "maxNum_" + childCount,
                        Size = new Size(40, 26)
                    };
                    maxNum.Location = new Point((maxLbl.Location.X + 60), height);

                    treeTabs.TabPages[curTab].Controls.Add(variantLbl);
                    treeTabs.TabPages[curTab].Controls.Add(minNum);
                    treeTabs.TabPages[curTab].Controls.Add(maxLbl);
                    treeTabs.TabPages[curTab].Controls.Add(maxNum);
                }
            }

            for (int i = 0; i < treeTabs.TabPages.Count; i++)
            {
                XmlNodeList variations = xmlTrees.DocumentElement.SelectNodes("//Species[@name='" + treeTabs.TabPages[i].Text + "']/Variations/Variation/Size");
                for (int x = 0; x <= 20; x++)
                {
                    int varId = x - 1;
                    //TODO: Make this for loop more dynamic instead of hard coded at 20.
                    Control[] numMins = treeTabs.TabPages[i].Controls.Find("minNum_" + x, true);
                    Control[] numMaxs = treeTabs.TabPages[i].Controls.Find("maxNum_" + x, true);
                    if (numMins != null && numMins.Length > 0)
                    {
                        foreach (NumericUpDown numMin in numMins)
                        {
                            if (x <= variations.Count)
                            {
                                numMin.Value = int.Parse(variations[varId].Attributes["min"].Value);
                                if (numMaxs != null)
                                {
                                    NumericUpDown numMax = (NumericUpDown)numMaxs[0];
                                    numMax.Value = int.Parse(variations[varId].Attributes["max"].Value);
                                }

                            }
                        }
                    }
                    else if (x > 0 && numMins == null)
                    {
                        break;
                    }
                }
            }
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
            for (int i = 0; i < treeTabs.TabPages.Count; i++)
            {
                if (noScrubs.Checked && (treeTabs.TabPages[i].Text.Contains("shrub") || treeTabs.TabPages[i].Text.Contains("scrub")))
                {
                    continue;
                }
                if (noCacti.Checked && treeTabs.TabPages[i].Text.Contains("cactus"))
                {
                    continue;
                }
                for (int x = 0; x <= 20; x++)
                {
                    //TODO: Make this for loop more dynamic instead of hard coded at 20.
                    Control[] numMins = treeTabs.TabPages[i].Controls.Find("minNum_" + x, true);
                    Control[] numMaxs = treeTabs.TabPages[i].Controls.Find("maxNum_" + x, true);
                    int varId = x - 1;
                    if (numMins != null && numMins.Length > 0)
                    {
                        foreach (NumericUpDown numMin in numMins)
                        {
                            XmlNodeList variations = xmlTrees.DocumentElement.SelectNodes("//Species[@name='" + treeTabs.TabPages[i].Text + "']/Variations/Variation/Size");
                            if (x <= variations.Count)
                            {
                                variations[varId].Attributes["min"].Value = numMin.Value.ToString();
                                if (numMaxs != null)
                                {
                                    NumericUpDown numMax = (NumericUpDown)numMaxs[0];
                                    variations[varId].Attributes["max"].Value = numMax.Value.ToString();
                                }
                            }
                        }
                    }
                    else if (x > 0 && numMins == null)
                    {
                        break;
                    }
                }
            }

            string installFolder = Properties.Settings.Default.installLocation;
            if (Directory.Exists(installFolder + "\\Community\\Tree-Editor\\vegetation") == false)
            {
                Directory.CreateDirectory(installFolder + "\\Community\\Tree-Editor\\vegetation");
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
            Manifest manifest = new Manifest();
            manifest.setSize(xmlFileSize);
            File.WriteAllText(Properties.Settings.Default.manifestFile, manifest.getJson());
        }

        private void BtnSubtractMin_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < treeTabs.TabPages.Count; i++)
            {
                if (noScrubs.Checked && (treeTabs.TabPages[i].Text.Contains("shrub") || treeTabs.TabPages[i].Text.Contains("scrub")))
                {
                    continue;
                }
                if (noCacti.Checked && treeTabs.TabPages[i].Text.Contains("cactus"))
                {
                    continue;
                }
                for (int x = 0; x <= 20; x++)
                {
                    //TODO: Make this for loop more dynamic instead of hard coded at 20.
                    Control[] numMins = treeTabs.TabPages[i].Controls.Find("minNum_" + x, true);
                    int varId = x - 1;
                    if (numMins != null && numMins.Length > 0)
                    {
                        foreach (NumericUpDown numMin in numMins)
                        {
                            if ((numMin.Value - changeMin.Value) >= 0)
                            {
                                numMin.Value -= changeMin.Value;
                                XmlNodeList variations = xmlTrees.DocumentElement.SelectNodes("//Species[@name='" + treeTabs.TabPages[i].Text + "']/Variations/Variation/Size");
                                if (x <= variations.Count)
                                {
                                    variations[varId].Attributes["min"].Value = (int.Parse(variations[varId].Attributes["min"].Value) - changeMin.Value).ToString();
                                    numMin.Value = int.Parse(variations[varId].Attributes["min"].Value);
                                }
                            }
                        }
                    }
                    else if (x > 0 && numMins == null)
                    {
                        break;
                    }
                }
            }
        }

        private void BtnAddMin_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < treeTabs.TabPages.Count; i++)
            {
                if (noScrubs.Checked && (treeTabs.TabPages[i].Text.Contains("shrub") || treeTabs.TabPages[i].Text.Contains("scrub")))
                {
                    continue;
                }
                if (noCacti.Checked && treeTabs.TabPages[i].Text.Contains("cactus"))
                {
                    continue;
                }
                for (int x = 0; x <= 20; x++)
                {
                    //TODO: Make this for loop more dynamic instead of hard coded at 20.
                    Control[] numMins = treeTabs.TabPages[i].Controls.Find("minNum_" + x, true);
                    int varId = x - 1;
                    if (numMins != null && numMins.Length > 0)
                    {
                        foreach (NumericUpDown numMin in numMins)
                        {
                            if ((numMin.Value + changeMin.Value) <= 100)
                            {
                                numMin.Value += changeMin.Value;
                                XmlNodeList variations = xmlTrees.DocumentElement.SelectNodes("//Species[@name='" + treeTabs.TabPages[i].Text + "']/Variations/Variation/Size");
                                if (x <= variations.Count)
                                {
                                    variations[varId].Attributes["min"].Value = (int.Parse(variations[varId].Attributes["min"].Value) + changeMin.Value).ToString();
                                    numMin.Value = int.Parse(variations[varId].Attributes["min"].Value);
                                }
                            }
                        }
                    }
                    else if (x > 0 && numMins == null)
                    {
                        break;
                    }
                }
            }
        }

        private void BtnSubtractMax_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < treeTabs.TabPages.Count; i++)
            {
                if (noScrubs.Checked && (treeTabs.TabPages[i].Text.Contains("shrub") || treeTabs.TabPages[i].Text.Contains("scrub")))
                {
                    continue;
                }
                if (noCacti.Checked && treeTabs.TabPages[i].Text.Contains("cactus"))
                {
                    continue;
                }
                for (int x = 0; x <= 20; x++)
                {
                    //TODO: Make this for loop more dynamic instead of hard coded at 20.
                    Control[] numMaxs = treeTabs.TabPages[i].Controls.Find("maxNum_" + x, true);
                    int varId = x - 1;
                    if (numMaxs != null && numMaxs.Length > 0)
                    {
                        foreach (NumericUpDown numMax in numMaxs)
                        {
                            if ((numMax.Value - changeMax.Value) >= 0)
                            {
                                numMax.Value -= changeMax.Value;
                                XmlNodeList variations = xmlTrees.DocumentElement.SelectNodes("//Species[@name='" + treeTabs.TabPages[i].Text + "']/Variations/Variation/Size");
                                if (x <= variations.Count)
                                {
                                    variations[varId].Attributes["max"].Value = (int.Parse(variations[varId].Attributes["max"].Value) - changeMax.Value).ToString();
                                    numMax.Value = int.Parse(variations[varId].Attributes["max"].Value);
                                }
                            }
                        }
                    }
                    else if (x > 0 && numMaxs == null)
                    {
                        break;
                    }
                }
            }
        }

        private void BtnAddMax_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < treeTabs.TabPages.Count; i++)
            {
                if (noScrubs.Checked && (treeTabs.TabPages[i].Text.Contains("shrub") || treeTabs.TabPages[i].Text.Contains("scrub")))
                {
                    continue;
                }
                if (noCacti.Checked && treeTabs.TabPages[i].Text.Contains("cactus"))
                {
                    continue;
                }
                for (int x = 0; x <= 20; x++)
                {
                    //TODO: Make this for loop more dynamic instead of hard coded at 20.
                    Control[] numMaxs = treeTabs.TabPages[i].Controls.Find("maxNum_" + x, true);
                    int varId = x - 1;
                    if (numMaxs != null && numMaxs.Length > 0)
                    {
                        foreach (NumericUpDown numMax in numMaxs)
                        {
                            if ((numMax.Value + changeMax.Value) <= 100)
                            {
                                numMax.Value += changeMax.Value;
                                XmlNodeList variations = xmlTrees.DocumentElement.SelectNodes("//Species[@name='" + treeTabs.TabPages[i].Text + "']/Variations/Variation/Size");
                                if (x <= variations.Count)
                                {
                                    variations[varId].Attributes["max"].Value = (int.Parse(variations[varId].Attributes["max"].Value) + changeMax.Value).ToString();
                                    numMax.Value = int.Parse(variations[varId].Attributes["max"].Value);
                                }
                            }
                        }
                    }
                    else if (x > 0 && numMaxs == null)
                    {
                        break;
                    }
                }
            }
        }

        private void BtnReload_Click(object sender, EventArgs e)
        {
            treeTabs.TabPages.Clear();
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
            string installFolder = Properties.Settings.Default.installLocation;
            if (File.Exists(installFolder + "\\Community\\Tree-Editor\\vegetation\\10-asobo_biomes.xml"))
            {
                return "{\n" +
                    "  \"content\": [\n" +
                    "    {\n" +
                    "      \"path\": \"vegetation/10-asobo_species.xml\",\n" +
                    "      \"size\": " + size + ",\n" +
                    "      \"date\": 132387590510000000\n" +
                    "    },\n" +
                    "    {\n" +
                    "      \"path\": \"vegetation/10-asobo_biomes.xml\",\n" +
                    "      \"size\": " + (int)new FileInfo(Properties.Settings.Default.xmlFileBiomes).Length + ",\n" +
                    "      \"date\": 132387590510000000\n" +
                    "    }\n" +
                    "  ]\n" +
                    "}";
            }
            else
            {
                return "{\n" +
                    "  \"content\": [\n" +
                    "    {\n" +
                    "      \"path\": \"vegetation/10-asobo_species.xml\",\n" +
                    "      \"size\": " + size + ",\n" +
                    "      \"date\": 132387590510000000\n" +
                    "    }\n" +
                    "  ]\n" +
                    "}";
            }
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
}
