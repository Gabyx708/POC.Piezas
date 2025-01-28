using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Piezas.Models.BomAggregate
{
    public class BomItem
    {
        private string _item;
        private string _partNumber;
        private int _quantity;
        private string _material;
        private string _destino;
        private string _tratamiento;
        private string _description;
        private string _vendor;
        private byte[]? _thumbnail;

        public BomItem(string item,
                       string partNumber,
                       int quantity,
                       string material,
                       string destino,
                       string tratamiento,
                       string description,
                       string vendor)
        {
            _item = item;
            _partNumber = partNumber;
            _quantity = quantity;
            _material = material;
            _destino = destino;
            _tratamiento = tratamiento;
            _description = description;
            _vendor = vendor;
        }


        public override string ToString()
        {
            return $"{_item} | {_description} | {_material}";
        }

        public string GetName()
        {
            return _item;
        }

        public void SetImagen(byte[] imageBytes)
        {
            this._thumbnail = imageBytes;
        }
    }
}
