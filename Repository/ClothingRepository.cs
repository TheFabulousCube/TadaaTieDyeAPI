﻿using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class ClothingRepository : RepositoryBase<Clothing>, IClothingRepository
    {
        public ClothingRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
