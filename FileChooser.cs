using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListMagic
{
    public class FileChooser
    {

        public static OpenFileDialog openFile = new OpenFileDialog();
        public static SaveFileDialog saveFile = new SaveFileDialog();

        public static string Load(string Filters = null, string StartDir = null, string Caption = null)
        {

            openFile.FileName = null;

            if (Filters != null)
                openFile.Filter = Filters;
            if (StartDir != null)
                openFile.InitialDirectory = StartDir;
            if (Caption != null)
                openFile.Title = Caption;

            DialogResult dr = openFile.ShowDialog();
            if (dr == DialogResult.Cancel) return null;
            if (openFile.FileName.Length == 0 || System.IO.File.Exists(openFile.FileName) == false)
                return null;
            return openFile.FileName;

        }
        public static string[] LoadMulti(string Filters = null, string StartDir = null, string Caption = null)
        {
            openFile.FileName = null;

            if (Filters != null)
                openFile.Filter = Filters;
            if (StartDir != null)
                openFile.InitialDirectory = StartDir;
            if (Caption != null)
                openFile.Title = Caption;

            openFile.Multiselect = true;

            DialogResult dr = openFile.ShowDialog();
            if (dr == DialogResult.Cancel) return null;
            
            if (openFile.FileNames.Length == 0)
                return null;
            return openFile.FileNames;
        }

        public static string Save(string Filters = null, string StartDir = null, string Caption = null)
        {

            saveFile.FileName = null;

            if (Filters != null)
                saveFile.Filter = Filters;
            if (StartDir != null)
                saveFile.InitialDirectory = StartDir;
            if (Caption != null)
                saveFile.Title = Caption;


            DialogResult dr = saveFile.ShowDialog();
            if (dr == DialogResult.Cancel) return null;
            if (saveFile.FileName.Length > 0)
            {
                return saveFile.FileName;
            }
            else
            {
                return null;
            }
        }

    }
}
