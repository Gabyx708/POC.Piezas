using POC.Piezas.Application.Interfaces;
using POC.Piezas.Models.AssemblyAggregate;
using POC.Piezas.Models.BomAggregate;

namespace POC.Piezas.Application.Implementation
{
    public class AssemblyFactory : IAssemblyFactory
    {
        private  Assembly _rootAssembly;
        private List<BomItem> _items;

        public AssemblyFactory()
        {
            _rootAssembly = new Assembly("master");
            _items = new List<BomItem>();
        }

        public Assembly CreateAssembly(List<BomItem> bomItems)
        {
            _items = bomItems;
            var roots = BuildRootsAssembly();

            foreach (var assembly in roots)
            {
                _rootAssembly.AddPart(assembly);
            }

            return _rootAssembly;
        }

        private List<Assembly> BuildRootsAssembly()
        {
            var rootAssemblies = GetRootsAssemblies();
           
            foreach (var root in rootAssemblies)
            {
                var rootImage = _items.FirstOrDefault(item => item.GetName() == root.GetName())?.GetImage();
                root.SetImage(rootImage);
                BuildChildren(root);
            }

            return rootAssemblies;
        }

        private void BuildChildren(Assembly parent)
        {
            var parentName = parent.GetName();
            var children = _items
                .Where(item => IsDirectChild(item.GetName(), parentName))
                .Select(item => CreateParts(item))
                .ToList();

            foreach (var child in children)
            {
                parent.AddPart(child);
                BuildChildren(child); // Llamada recursiva para construir los hijos del hijo
            }
        }

        private bool IsDirectChild(string childName, string parentName)
        {
            // Verificar si el nombre del hijo tiene un nivel más que el del padre
            var parentParts = parentName.Split(',');
            var childParts = childName.Split(',');

            return childParts.Length == parentParts.Length + 1 && childName.StartsWith(parentName + ",");
        }


        private List<Assembly> GetRootsAssemblies()
        {
            var rootItemNames = _items
               .Where(bomItem => !bomItem.GetName().Contains(","))
               .ToList();

            return rootItemNames.Select(item => CreateParts(item)).ToList();
        }

        private Assembly CreateParts(BomItem item)
        {
            var assemb = new Assembly(item.GetName());

            assemb.SetData(item);
            assemb.SetImage(item.GetImage());

            return assemb;
        }

    }
}
