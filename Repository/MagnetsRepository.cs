using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class MagnetsRepository : RepositoryBase<Magnets>, IMagnetsRepository
    {
        public MagnetsRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}