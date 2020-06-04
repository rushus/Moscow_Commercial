using Commercialobj.DomainObjects;
using Commercialobj.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Commercialobj.DomainObjects.Repositories
{
    public abstract class ReadOnlyCommercialobjRepositoryDecorator : IReadOnlyCommercialobjRepository
    {
        private readonly IReadOnlyCommercialobjRepository _commercialobjRepository;

        public ReadOnlyCommercialobjRepositoryDecorator(IReadOnlyCommercialobjRepository commercialobjRepository)
        {
            _commercialobjRepository = commercialobjRepository;
        }

        public virtual async Task<IEnumerable<commercialobj>> GetAllCommercialobjs()
        {
            return await _commercialobjRepository?.GetAllCommercialobjs();
        }

        public virtual async Task<commercialobj> GetCommercialobj(long id)
        {
            return await _commercialobjRepository?.GetCommercialobj(id);
        }

        public virtual async Task<IEnumerable<commercialobj>> QueryCommercialobjs(ICriteria<commercialobj> criteria)
        {
            return await _commercialobjRepository?.QueryCommercialobjs(criteria);
        }
    }
}
