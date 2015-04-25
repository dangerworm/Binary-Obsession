using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Binary_Obsession
{
    public partial class BinaryObsession : Form
    {
        private List<Label> labels;
        private List<TextBox> textboxes;

        int imageHeight;
        int imageWidthMultiplier;

        public BinaryObsession()
        {
            InitializeComponent();
            labels = new List<Label>();
            textboxes = new List<TextBox>();
            imageHeight = 100;
            imageWidthMultiplier = 1;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            //int numToDivide = 9100;
            //for (int i = 1; i < numToDivide / 2; i++)
            //{
            //    if (numToDivide % i == 0)
            //        MessageBox.Show(i.ToString());
            //}

            Random r = new Random(DateTime.Now.Millisecond);
            int numThrows = 9100; //Convert.ToInt32((new DateTime(2009, 12, 17) - new DateTime(1985, 1, 19)).TotalDays);
            int groupSize = 11;

            try
            {
                groupSize = Convert.ToInt32(txtGroupSize.Text) + 1;

                int black = 0;

                //for (int i = groupSize; i <= labels.Count; i++)
                //{
                //    Controls.Remove(labels[i]);
                //    labels.RemoveAt(i);
                //}

                //for (int i = groupSize; i <= textboxes.Count; i++)
                //{
                //    Controls.Remove(textboxes[i]);
                //    textboxes.RemoveAt(i);
                //}

                //Refresh();

                Bitmap bStripes = new Bitmap((numThrows / (groupSize - 1)) * imageWidthMultiplier, imageHeight);
                Graphics gStripes = Graphics.FromImage(bStripes);

                List<Brush> brushes = new List<Brush>();
                for (int i = 0; i < groupSize; i++)
                {
                    double greyness = 255 - ((i / (double)(groupSize - 1)) * 255);
                    brushes.Add(new SolidBrush(Color.FromArgb(Convert.ToInt32(greyness), Convert.ToInt32(greyness), Convert.ToInt32(greyness))));
                }


                for (int i = 0; i < groupSize; i++)
                {
                    if (labels.Count <= i)
                    {
                        labels.Add(new Label
                        {
                            Location = new Point(12, (26 * i) + 15),
                            Name = "lbl" + i.ToString(),
                            Size = new Size(25, 13),
                            TabIndex = 2 * i,
                            Text = i.ToString() + ":"
                        });
                        Controls.Add(labels[i]);

                    }

                    if (textboxes.Count <= i)
                    {
                        textboxes.Add(new TextBox
                        {
                            Location = new Point(53, (26 * i) + 12),
                            Name = "txt" + i.ToString(),
                            Size = new Size(75, 23),
                            TabIndex = (2 * i) + 1,
                            Tag = i.ToString()
                        });
                        Controls.Add(textboxes[i]);
                    }
                }

                Height = (26 * (groupSize - 1)) + 80;

                int[] groups = new int[groupSize];
                lblTosses.Text = (numThrows / (groupSize - 1)).ToString() + " x " + (groupSize - 1).ToString() + " = " + ((numThrows / (groupSize - 1)) * (groupSize - 1)).ToString() + " tosses";

                StreamWriter output = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + Path.DirectorySeparatorChar + 
                                                        "Binary Stream " +
                                                        DateTime.Now.ToShortDateString().Replace('/','-') + "-" +
                                                        DateTime.Now.ToShortTimeString().Replace(':', '-') + "-" + DateTime.Now.Second.ToString() +
                                                        ".txt");

                string tosses = "";

                for (int i = 0; i < numThrows / (groupSize - 1); i++)
                {
                    black = 0;

                    for (int j = 0; j < groupSize - 1; j++)
                    {
                        if (r.Next(0, 2) == 0)
                        {
                            black++;
                            tosses += "B";
                        }
                        else
                        {
                            tosses += "W";
                        }
                    }

                    groups[black]++;
                }

                for (int i = 0; i < groupSize; i++)
                {
                    foreach (Control c in Controls)
                    {
                        if (((string)c.Tag) == i.ToString())
                            c.Text = groups[i].ToString();
                    }

                    output.WriteLine(i.ToString() + (i == 1 ? " black:  " : " blacks: ") + groups[i].ToString());
                }

                output.WriteLine(Environment.NewLine + tosses + Environment.NewLine);
                int blacks = 0;
                int whites = 0;

                for (int i = 0; i < tosses.Length; i += groupSize - 1)
                {
                    blacks = 0;
                    whites = 0;
                    foreach (char c in tosses.Substring(i, groupSize - 1))
                    {
                        if (c == 'B')
                        {
                            blacks++;
                        }
                        else
                        {
                            whites++;
                        }
                    }

                    output.WriteLine(tosses.Substring(i, groupSize - 1) + "\t" +
                                     (blacks > 9 ? blacks.ToString() : " " + blacks.ToString()) + "B\t" +
                                     (whites > 9 ? whites.ToString() : " " + whites.ToString()) + "W\t");

                    gStripes.FillRectangle(brushes[blacks], (i / (groupSize - 1)) * imageWidthMultiplier, 0, imageWidthMultiplier, imageHeight);
                }

                output.Close();
                bStripes.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + Path.DirectorySeparatorChar +
                                "Binary Stream " +
                                DateTime.Now.ToShortDateString().Replace('/', '-') + "-" +
                                DateTime.Now.ToShortTimeString().Replace(':', '-') + "-" + DateTime.Now.Second.ToString() +
                                ".png", System.Drawing.Imaging.ImageFormat.Png);
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Couldn't work out the group size. Please check and try again.", "Group Size Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
