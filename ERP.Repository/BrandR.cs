using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Infrastructure.Data;
using ERP.Domain.Entity;
using ERP.Domain.IRepository;

namespace ERP.Repository
{
    public class BrandR : RepositoryBaseT<Brand>, IBrandR
    {
        public BrandR()
        {
            base.SetCacheKey("brand");
        }
    }
}
