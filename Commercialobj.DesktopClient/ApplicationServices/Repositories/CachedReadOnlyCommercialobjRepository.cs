using Commercialobj.ApplicationServices.Ports.Cache;
using Commercialobj.DomainObjects;
using Commercialobj.DomainObjects.Ports;
using Commercialobj.DomainObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Commercialobj.ApplicationServices.Repositories
{
    public class CachedReadOnlyCommercialobjRepository : ReadOnlyCommercialobjRepositoryDecorator
    {
        private readonly IDomainObjectsCache<commercialobj> _commercialobjsCache;

        public CachedReadOnlyCommercialobjRepository(IReadOnlyCommercialobjRepository commercialobjRepository, 
                                             IDomainObjectsCache<commercialobj> commercialobjsCache)
            : base(commercialobjRepository)
            => _commercialobjsCache = commercialobjsCache;

        public async override Task<commercialobj> GetCommercialobj(long id)
            => _commercialobjsCache.GetObject(id) ?? await base.GetCommercialobj(id);

        public async override Task<IEnumerable<commercialobj>> GetAllCommercialobjs()
            => _commercialobjsCache.GetObjects() ?? await base.GetAllCommercialobjs();

        public async override Task<IEnumerable<commercialobj>> QueryCommercialobjs(ICriteria<commercialobj> criteria)
            => _commercialobjsCache.GetObjects()?.Where(criteria.Filter.Compile()) ?? await base.QueryCommercialobjs(criteria);

    }
}
