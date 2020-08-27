using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
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
            if (Properties.Settings.Default.xmlFile != "")
            {
                loadXML();
            }
            else
            {
                DialogResult result = MessageBox.Show("Oops! Looks like we don't have your 10-asobo_species.xml file location saved. Click OK below to set the file location. If you're not sure where this file is located, in the location you installed the game:\n\nFor Microsoft Store installs:\nOfficial\\OneStore\\fs - base\\vegetation\n\nFor Steam installs\nOfficial\\Steam\\fs - base\\vegetation", "Vegetation file location not found", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    openXML.ShowDialog();
                }

            }
        }
        public void loadXML()
        {
            xmlTrees.Load(Properties.Settings.Default.xmlFile);
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
            xmlTrees.Save(Properties.Settings.Default.xmlFile);
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

        private void OpenXML_FileOk(object sender, CancelEventArgs e)
        {
            Properties.Settings.Default.xmlFile = openXML.FileName;
            Properties.Settings.Default.Save();
            loadXML();
        }
    }
}
