using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ExtendedModels
{
    public class MagnetsExtended
    {
        public string ProdId { get; set; }
        public string ProdPicture { get; set; }
        public decimal ProdPrice { get; set; }
        public int ProdQty { get; set; }
        public string Catagory { get; set; }
        public string ProdName { get; set; }
        public string Capital { get; set; }
        public string Statehood { get; set; }

        public IEnumerable<Cart> Carts { get; set; }

        public MagnetsExtended()
        { }

        public MagnetsExtended(Magnets magnet)
        {
            ProdId = magnet.ProdId;
            ProdPicture = magnet.ProdPicture;
            ProdPrice = magnet.ProdPrice;
            ProdQty = magnet.ProdQty;
            Catagory = magnet.Catagory;
            ProdName = magnet.ProdName;
            Capital = magnet.Capital;
            Statehood = magnet.Statehood;
        }
    }
}
