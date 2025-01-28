using POC.Piezas.Models.AssemblyAggregate;

namespace POC.Piezas.Application.Interfaces
{
    public interface IAssemblyTraversal
    {
        public void LevelOrderTraversal(Assembly assembly);
    }
}
