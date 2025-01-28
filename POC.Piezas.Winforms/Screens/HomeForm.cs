using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POC.Piezas.Application.Implementation;
using POC.Piezas.Application.Interfaces;
using POC.Piezas.Infrastructure.Repositories;
using POC.Piezas.Models.AssemblyAggregate;
using POC.Piezas.Models.BomAggregate;

namespace POC.Piezas.Winforms.Screens
{
    public partial class HomeForm : Form
    {
        private readonly IBomItemRepository repository;
        private readonly IAssemblyFactory assemblyFactory;
        public HomeForm()
        {
            InitializeComponent();

            repository = new BomItemRepository();
            assemblyFactory = new AssemblyFactory();
        }

        private void LoadTreeView(TreeView treeView, Assembly rootAssembly)
        {
            treeView.Nodes.Clear(); // Limpiamos nodos existentes
            TreeNode rootNode = CreateTreeNode(rootAssembly);
            treeView.Nodes.Add(rootNode);
        }

        private TreeNode CreateTreeNode(Assembly assembly)
        {
            TreeNode node = new TreeNode(assembly.GetName());

            // Iteramos sobre los subensamblajes y los añadimos recursivamente
            foreach (var part in assembly.GetParts())
            {
                node.Nodes.Add(CreateTreeNode(part));
            }

            return node;
        }

        private void ButtonTest_Click(object sender, EventArgs e)
        {
           var items = repository.GetItemsFromFile(textBoxFilePath.Text).ToList();
            var assembly = assemblyFactory.CreateAssembly(items);

            LoadTreeView(treeViewAssembly, assembly);
        }
    }
}
