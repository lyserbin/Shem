using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LazyAsFuck
{
    public partial class LazyAsFuck : Form
    {
        public LazyAsFuck()
        {
            InitializeComponent();
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LazyAsFuck());
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            string path;
            string filecontent;

            path = txtPath.Text;
            if (!File.Exists(path))
            {
                MessageBox.Show("File not found", "Fuck you", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            filecontent = File.ReadAllText(path);

            Clipboard.SetText(parseman(filecontent));
            MessageBox.Show("Done!\nConfigs.cs is now in your clipboard.\n\n/!\\ Revision it as it could be dirty /!\\", "Fuck yeah", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string parseman(string mancontent)
        {
            string configs = "namespace Shem.Commands\n{\n/// <summary>\n"+
                             "/// Configs availables for *CONF commands.\n"+
                             "/// </summary>\npublic enum Configs\n{\n";
            string tmp;
            string tmpconfig = "";
            bool parse = false;
            bool inpara = false;
            StringReader sr = new StringReader(mancontent);


            while((tmp = sr.ReadLine()) != null)
            {
                if (!string.IsNullOrWhiteSpace(tmp)) // No shit, thanks
                {
                    if (!parse && tmp == "GENERAL OPTIONS") // Do not do shit till then
                    {
                        parse = true;
                    }
                    else if (parse)
                    {
                        if (tmp == "SIGNALS") // Stop doing shit
                        {
                            configs += String.Format("/// </summary>\n{0}\n}}\n}}", tmpconfig);
                            parse = false;
                        }
                        else if (tmp[0] == '[') // We are @ another Config
                        {
                            if(tmpconfig != "") // Is not the first item we write
                            {
                                configs += String.Format("/// </para></summary>\n{0},\n\n", tmpconfig);
                            }
                            tmpconfig = tmp.Substring(2, tmp.IndexOf("]") - 2);
                            configs += String.Format("/// <summary>\n/// <para>{0}</para>\n/// <para>&#160;</para>\n",
                                                    removeshit(tmp.Substring(tmpconfig.Length + 5)));
                            inpara = false;
                        }
                        else if (tmp.Length > 3 && tmp.Substring(0, 3) == "   ") // Documentation BOYZ!
                        {
                            string shitty = tmp;
                            shitty = tmp.Substring(4, tmp.Length - 4); // Remove the spaces
                            shitty = removeshit(shitty); // hell yeah
                            if (shitty.EndsWith(" +"))
                                shitty = shitty.Substring(0, shitty.Length - 2);

                            configs += String.Format("/// {0}{1}\n", inpara ? "" : "<para>", shitty);

                            if (!inpara)
                                inpara = true;

                        }
                        else if (tmp == " +")
                        {
                            configs += "/// </para>\n/// <para>&#160;</para>\n";
                            inpara = false;
                        }
                    }
                }
            }
            
            return configs;
        }

        private string removeshit(string input)
        {
            return input.Replace("*", "").Replace("_", "").Replace("::", "").Replace("\\", "");
        }
    }
}
