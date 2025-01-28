using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Piezas.Models.AssemblyAggregate
{
    public class Assembly
    {
        private readonly string _assemblyName;
        private List<Assembly> _assemblyParts;

        public Assembly(string name)
        {
            this._assemblyName = name;
            _assemblyParts = new List<Assembly>();
        }

        public List<Assembly> GetParts()
        { 
            return _assemblyParts; 
        }

        public string GetName()
        {
            return _assemblyName;
        }

        public void AddPart(Assembly part)
        {
            this.GetParts().Add(part);
        }
        public bool IsPart()
        {
            return _assemblyParts.Count > 0;
        }
    }
}
