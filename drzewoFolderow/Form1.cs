using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace drzewoFolderow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\");
            if (directoryInfo.Exists)
            {
                //treeView1.AfterSelect += treeView1_AfterSelect;
                TreeNode rootNode = new TreeNode(directoryInfo.Name);
                treeView1.Nodes.Add(directoryInfo.Name);

                foreach (DirectoryInfo subDirectoryInfo in directoryInfo.GetDirectories())
                {
                    TreeNode subNode = new TreeNode(subDirectoryInfo.Name);
                    rootNode.Nodes.Add(subNode);
                }

                foreach (FileInfo fileInfo in directoryInfo.GetFiles())
                {
                    TreeNode fileNode = new TreeNode(fileInfo.Name);
                    rootNode.Nodes.Add(fileNode);
                }

            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            // SprawdŸ, czy wybrany wêze³ jest folderem
            if (File.Exists(e.Node.FullPath))
            {
                // Wybrany wêze³ jest plikiem
                if (e.Node.Name.EndsWith("jpg"))
                {

                }
                return;
            }

            // SprawdŸ, czy wybrany wêze³ ma podfoldery
            if (e.Node.Nodes.Count > 0)
            {
                // Wêze³ ma ju¿ podfoldery
                return;
            }

            // Pobierz informacje o folderze
            DirectoryInfo directoryInfo = new DirectoryInfo(e.Node.FullPath);

            // Dodaj podfoldery do wêz³a
            foreach (DirectoryInfo subDirectoryInfo in directoryInfo.GetDirectories())
            {
                TreeNode subNode = new TreeNode(subDirectoryInfo.Name);
                e.Node.Nodes.Add(subNode);
            }

            // Dodaj pliki do wêz³a
            foreach (FileInfo fileInfo in directoryInfo.GetFiles())
            {
                TreeNode fileNode = new TreeNode(fileInfo.Name);
                e.Node.Nodes.Add(fileNode);
            }
        }

    }
}