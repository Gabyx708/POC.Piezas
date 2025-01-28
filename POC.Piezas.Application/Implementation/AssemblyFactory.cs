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
                BuildChildren(root);
            }

            return rootAssemblies;
        }

        private void BuildChildren(Assembly parent)
        {
            var parentName = parent.GetName();
            var children = _items
                .Where(item => item.GetName().StartsWith(parentName + ","))
                .Select(item => new Assembly(item.GetName()))
                .ToList();

            foreach (var child in children)
            {
                parent.AddPart(child);
                BuildChildren(child);
            }
        }

        private List<Assembly> GetRootsAssemblies()
        {
            var rootItemNames = _items
               .Select(item => item.GetName())
               .Where(name => !name.Contains(","))
               .ToList();

            return rootItemNames.Select(name => new Assembly(name)).ToList();
        }

    }
}
