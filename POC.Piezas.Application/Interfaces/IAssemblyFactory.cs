using POC.Piezas.Models.AssemblyAggregate;
using POC.Piezas.Models.BomAggregate;

namespace POC.Piezas.Application.Interfaces
{
    public interface IAssemblyFactory
    {
        Assembly CreateAssembly(List<BomItem> bomItems);
    }
}
