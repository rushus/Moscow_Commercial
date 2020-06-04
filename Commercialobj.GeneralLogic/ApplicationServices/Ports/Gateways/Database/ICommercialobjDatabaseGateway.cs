using Commercialobj.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Commercialobj.ApplicationServices.Ports.Gateways.Database
{
    public interface ICommercialobjDatabaseGateway
    {
        Task AddCommercialobj(commercialobj commercialobj);

        Task RemoveCommercialobj(commercialobj commercialobj);

        Task UpdateCommercialobj(commercialobj commercialobj);

        Task<commercialobj> GetCommercialobj(long id);

        Task<IEnumerable<commercialobj>> GetAllCommercialobjs();

        Task<IEnumerable<commercialobj>> QueryCommercialobjs(Expression<Func<commercialobj, bool>> filter);

    }
}
