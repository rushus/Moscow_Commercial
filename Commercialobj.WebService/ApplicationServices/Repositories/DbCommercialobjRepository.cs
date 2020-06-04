using Commercialobj.ApplicationServices.Ports.Gateways.Database;
using Commercialobj.DomainObjects;
using Commercialobj.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Commercialobj.ApplicationServices.Repositories
{
    public class DbCommercialobjRepository : IReadOnlyCommercialobjRepository,
                                     ICommercialobjRepository
    {
        private readonly ICommercialobjDatabaseGateway _databaseGateway;

        public DbCommercialobjRepository(ICommercialobjDatabaseGateway databaseGateway)
            => _databaseGateway = databaseGateway;

        public async Task<commercialobj> GetCommercialobj(long id)
            => await _databaseGateway.GetCommercialobj(id);

        public async Task<IEnumerable<commercialobj>> GetAllCommercialobjs()
            => await _databaseGateway.GetAllCommercialobjs();

        public async Task<IEnumerable<commercialobj>> QueryCommercialobjs(ICriteria<commercialobj> criteria)
            => await _databaseGateway.QueryCommercialobjs(criteria.Filter);

        public async Task AddCommercialobj(commercialobj commercialobj)
            => await _databaseGateway.AddCommercialobj(commercialobj);

        public async Task RemoveCommercialobj(commercialobj commercialobj)
            => await _databaseGateway.RemoveCommercialobj(commercialobj);

        public async Task UpdateCommercialobj(commercialobj commercialobj)
            => await _databaseGateway.UpdateCommercialobj(commercialobj);
    }
}
