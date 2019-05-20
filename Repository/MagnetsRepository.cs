using Contracts;
using Entities;
using Entities.ExtendedModels;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class MagnetsRepository : RepositoryBase<Magnets>, IMagnetsRepository
    {
        public MagnetsRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Magnets> GetAllMagnets()
        {
            return FindAll()
                .OrderBy(mag => mag.ProdName)
                .ToList();
        }

        public Magnets GetMagnetById(string magnetId)
        {
            return FindByCondition(mag => mag.ProdId.Equals(magnetId))
                .DefaultIfEmpty(new Magnets() { ProdId = ""})
                .FirstOrDefault();
        }

        public MagnetsExtended GetMagnetsInACart(string magnetId)
        {
            return new MagnetsExtended(GetMagnetById(magnetId))
            {
                Carts = RepositoryContext.Cart
                .Where(c => c.ProdId == magnetId)
            };
        }
    }
}