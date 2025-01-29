using POC.Piezas.Models.BomAggregate;
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
        private BomItem _data;

        private byte[]? _assemblyImage;

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

        public void SetImage(byte[] image)
        {
            _assemblyImage = image;
        }

        public void SetData(BomItem data)
        {
            _data = data;
        }

        public BomItem GetData()
        {
            return _data ?? throw new InvalidDataException();
        }

        public byte[]? GetImage()
        {
            return _assemblyImage ?? null;
        }
    }
}
