using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DataSaveUsingXML
{
    public static class HelperClass
    {
        public static void GetConnectionString()
        {
            try
            {
                string filename = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "") + ".config";
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(filename);
                DatabaseOperation.ConnectionString = xmlDocument.SelectSingleNode("descendant::connectionStrings/add[@name='DatabaseConnectionString']").Attributes["connectionString"].Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
