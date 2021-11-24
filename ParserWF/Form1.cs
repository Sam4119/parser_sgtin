using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;


namespace ParserWF
{
    public partial class Form1 : Form
    {
        private string name;
        bool enable = false;
        public static string dirWork = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.xml)|*.xml|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                name = openFileDialog1.FileName;
                txbPathInput.Text = name;
                enable = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (enable == true)
            {
                string path = name;
                XmlDocument docXML = new XmlDocument();
                docXML.Load(path);
                List<string> sgtins = new List<string>();
                string parseLine = "";
                bool prs = true;
                int res;
                int itr = 0;
               
                int count = Convert.ToInt32(docXML.GetElementsByTagName("sgtin").Count);
                for (int i = 0; i != count; i++)
                {

                    string sgtin = docXML.GetElementsByTagName("sgtin")[itr].InnerText;
                    string s1 = sgtin;
                    itr = itr + 1;
                    sgtins.Add(s1);

                }
                foreach (var sg in sgtins)
                {
                    for (int j = 0; j < sg.Length; j++)
                    {
                        if (j % 27 == 0)
                        {
                            parseLine += "\n";
                        }
                        if (prs = int.TryParse(sg[j].ToString(), out res))
                        {
                            parseLine += sg[j].ToString();
                        }
                        if (char.IsUpper(sg[j]))
                        {
                            parseLine += char.ToLower(sg[j]).ToString();

                        }
                        if (char.IsLower(sg[j]))
                        {
                            parseLine += char.ToUpper(sg[j]).ToString();

                        }

                    }
                }
                

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    name = saveFileDialog1.FileName;
                    StreamWriter sw = new StreamWriter(name, false); ;
                    sw.WriteLine(parseLine);
                    sw.Close();
                    MessageBox.Show("File saved!");
                }
            }
            else
            {
                MessageBox.Show("Cначала укажите путь.");
            }
            

        }
        //!!!
        //string parseLine = "";
        //StreamReader sr = new StreamReader(path: path);
        //string line;
        //bool prs = true;
        //int res;
        //while ((line = sr.ReadLine()) != null)
        //{
        //    line.Trim();
        //    for (int i = 0; i < line.Length; i++)
        //    {
        //        if (i % 27 == 0)
        //        {
        //            parseLine += "\n";
        //        }
        //        if (prs = int.TryParse(line[i].ToString(), out res))
        //        {
        //            parseLine += line[i].ToString();
        //        }
        //        if (char.IsUpper(line[i]))
        //        {
        //            parseLine += char.ToLower(line[i]).ToString();

        //        }
        //        if (char.IsLower(line[i]))
        //        {
        //            parseLine += char.ToUpper(line[i]).ToString();

        //        }
        //    }

        //}
        //Console.WriteLine(parseLine.Trim());
        //sr.Close();




    }
}
