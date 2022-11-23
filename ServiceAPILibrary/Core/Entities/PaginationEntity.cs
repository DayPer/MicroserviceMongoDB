using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIServiceCard.Core.Entities
{
    public class PaginationEntity<TDocument>
    {
        public int PegesSize { get; set; }

        public int Pege{ get; set; }

        public string Sort { get; set; }

        public string SottiDirecction { get; set; }

        public string Filter { get; set; }

        public FiltervalueClass Filtervalue { get; set; }

        public int PegesQuantity { get; set; }

        public IEnumerable<TDocument> Data { get; set; }

        public int totalRow { get; set; }

    }
}
