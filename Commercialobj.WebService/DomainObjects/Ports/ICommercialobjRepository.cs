using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Commercialobj.DomainObjects.Ports
{
    public interface IReadOnlyCommercialobjRepository
    {
        Task<commercialobj> GetCommercialobj(long id);

        Task<IEnumerable<commercialobj>> GetAllCommercialobjs();

        Task<IEnumerable<commercialobj>> QueryCommercialobjs(ICriteria<commercialobj> criteria);

    }

    public interface ICommercialobjRepository
    {
        Task AddCommercialobj(commercialobj commercialobj);

        Task RemoveCommercialobj(commercialobj commercialobj);

        Task UpdateCommercialobj(commercialobj commercialobj);
    }
}
