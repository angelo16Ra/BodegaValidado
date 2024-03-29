using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Generic
{
    public class RequestFilterGeneric
    {
        public int NumeroPagina { get; set; } = 0;
        public int Cantidad { get; set; } = 0;
        public List<ItemFilter> Filtros { get; set; } = new List<ItemFilter>();
    }
    public class ItemFilter
    {
        public string Name { get; set; } = "";
        public string Value { get; set; } = "";
    }
}
