﻿using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindAPI.DAL.Repositories.Concrete.EntityFramework
{
    public class EFRegionRepository : EFGenericRepository<Region, int, NorthwindContext>, IRegionRepository
    {
    }
}