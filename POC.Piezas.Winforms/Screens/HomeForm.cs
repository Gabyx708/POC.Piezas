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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace POC.Piezas.Winforms.Screens
{
    public partial class HomeForm : Form
    {
        private readonly IBomItemRepository repository;
        private readonly IAssemblyFactory assemblyFactory;
        private ImageList imageList;
        public HomeForm()
        {
            InitializeComponent();

            repository = new BomItemRepository();
            assemblyFactory = new AssemblyFactory();

            imageList = new ImageList();
            SetupSystemIcons();
        }
        private void SetupSystemIcons()
        {

            // Obtener iconos del sistema
            imageList.Images.Add("folder", SystemIcons.Exclamation.ToBitmap());  // Icono genérico de Windows
            imageList.Images.Add("file", SystemIcons.Shield.ToBitmap());  // Icono de aplicación

            treeViewAssembly.ImageList = imageList;
        }


        private void LoadTreeView(System.Windows.Forms.TreeView treeView, Assembly rootAssembly)
        {
            treeView.Nodes.Clear(); // Limpiamos nodos existentes
            TreeNode rootNode = CreateTreeNode(rootAssembly);
            treeView.Nodes.Add(rootNode);


            AssignIconsToNodes(treeView.Nodes[0]);
            CustomizeTreeNodes(treeView.Nodes[0]);

        }

        private TreeNode CreateTreeNode(Assembly assembly)
        {
            string name;

            try
            {
                name = assembly.GetData().GetPartNumber();

            }catch(InvalidDataException)
            {
                name = assembly.GetName();
            }

            TreeNode node = new TreeNode(name);
            node.Tag = assembly;


            // Iteramos sobre los subensamblajes y los añadimos recursivamente
            foreach (var part in assembly.GetParts())
            {
                node.Nodes.Add(CreateTreeNode(part));
            }

            return node;
        }

        private void ButtonExportarBom_Click(object sender, EventArgs e)
        {
            string filePath = "";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Seleccionar Archivo";
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName; // Mostrar ruta en el TextBox
                    MessageBox.Show("Ruta seleccionada:\n" + openFileDialog.FileName);
                }
            }

            var items = repository.GetItemsFromFile(filePath).ToList();
            var assembly = assemblyFactory.CreateAssembly(items);

            LoadTreeView(treeViewAssembly, assembly);
        }

        private void SelectAssembly(object sender, TreeViewEventArgs e)
        {
            var assemblyNode = e.Node.Tag as Assembly;
            if (assemblyNode != null)
            {
                CargarDatosPiezas(assemblyNode.GetData());   
            }
        }

        private void CargarDatosPiezas(BomItem item)
        {
            textBoxPartNumber.Text = item.GetPartNumber();
            textBoxMaterial.Text = item.GetMaterial();
            textBoxDestiny.Text = item.GetDestiny();
            textBoxQuantity.Text = item.GetQuantity().ToString();

            CargarImagen(item.GetImage());
        }

        private void CargarImagen(byte[]? imageData)
        {

            if (imageData != null && imageData.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    pictureBoxThumbnail.Image = Image.FromStream(ms);
                }
            }
            else
            {
                pictureBoxThumbnail.Image = null;
            }
        }



        private void CustomizeTreeNodes(TreeNode node)
        {
            var assembly = node.Tag as Assembly;
            if (assembly != null)
            {
                if (assembly.IsPart())
                {
                    node.ForeColor = Color.Blue;
                }
                else // Si es una pieza, pintar de rojo
                {
                    node.ForeColor = Color.Red;
                }
            }

            foreach (TreeNode child in node.Nodes)
            {
                CustomizeTreeNodes(child);
            }
        }

        private void AssignIconsToNodes(TreeNode node)
        {
            var assembly = node.Tag as Assembly;
            if (assembly != null)
            {
                if (assembly.IsPart())
                {
                    node.ImageKey = "folder";   // Icono de carpeta
                    node.SelectedImageKey = "folder";
                }
                else
                {
                    node.ImageKey = "file";     // Icono de archivo
                    node.SelectedImageKey = "file";
                }
            }

            foreach (TreeNode child in node.Nodes)
            {
                AssignIconsToNodes(child);
            }
        }


    }
}
