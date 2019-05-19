﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        ICartRepository Cart { get; }
        ICatagoryLookupRepository CatagoryLookup { get; }
        IClothingRepository Clothing { get; }
        IDownloadsRepository Downloads { get; }
        IMagnetsRepository Magnets { get; }
        IRoleLookupRepository RoleLookup { get; }
        ISizeLookupRepository SizeLookup { get; }
        ISleeveLookupRepository SleeveLookup { get; }
        IUsersRepository Users { get; }

        void Save();
    }
}
