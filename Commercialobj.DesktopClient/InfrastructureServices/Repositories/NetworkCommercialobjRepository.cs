using Commercialobj.ApplicationServices.Ports.Cache;
using Commercialobj.DomainObjects;
using Commercialobj.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Commercialobj.InfrastructureServices.Repositories
{
    public class NetworkCommercialobjRepository : NetworkRepositoryBase, IReadOnlyCommercialobjRepository
    {
        private readonly IDomainObjectsCache<commercialobj> _commercialobjCache;

        public NetworkCommercialobjRepository(string host, ushort port, bool useTls, IDomainObjectsCache<commercialobj> commercialobjCache)
            : base(host, port, useTls)
            => _commercialobjCache = commercialobjCache;

        public async Task<commercialobj> GetCommercialobj(long id)
            => CacheAndReturn(await ExecuteHttpRequest<commercialobj>($"commercialobjs/{id}"));

        public async Task<IEnumerable<commercialobj>> GetAllCommercialobjs()
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<commercialobj>>($"commercialobjs"), allObjects: true);

        public async Task<IEnumerable<commercialobj>> QueryCommercialobjs(ICriteria<commercialobj> criteria)
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<commercialobj>>($"commercialobjs"), allObjects: true)
               .Where(criteria.Filter.Compile());


        private IEnumerable<commercialobj> CacheAndReturn(IEnumerable<commercialobj> commercialobjs, bool allObjects = false)
        {
            if (allObjects)
            {
                _commercialobjCache.ClearCache();
            }
            _commercialobjCache.UpdateObjects(commercialobjs, DateTime.Now.AddDays(1), allObjects);
            return commercialobjs;
        }

        private commercialobj CacheAndReturn(commercialobj commercialobj)
        {
            _commercialobjCache.UpdateObject(commercialobj, DateTime.Now.AddDays(1));
            return commercialobj;
        }
    }
}
