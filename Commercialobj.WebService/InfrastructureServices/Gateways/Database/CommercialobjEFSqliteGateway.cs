using Commercialobj.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Commercialobj.ApplicationServices.Ports.Gateways.Database;

namespace Commercialobj.InfrastructureServices.Gateways.Database
{
    public class CommercialobjEFSqliteGateway : ICommercialobjDatabaseGateway
    {
        private readonly CommercialobjContext _commercialobjContext;

        public CommercialobjEFSqliteGateway(CommercialobjContext CommercialobjContext)
            => _commercialobjContext = CommercialobjContext;

        public async Task<commercialobj> GetCommercialobj(long id)
           => await _commercialobjContext.Commercialobjs.Where(b => b.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<commercialobj>> GetAllCommercialobjs()
            => await _commercialobjContext.Commercialobjs.ToListAsync();
          
        public async Task<IEnumerable<commercialobj>> QueryCommercialobjs(Expression<Func<commercialobj, bool>> filter)
            => await _commercialobjContext.Commercialobjs.Where(filter).ToListAsync();

        public async Task AddCommercialobj(commercialobj commercialobj)
        {
            _commercialobjContext.Commercialobjs.Add(commercialobj);
            await _commercialobjContext.SaveChangesAsync();
        }

        public async Task UpdateCommercialobj(commercialobj commercialobj)
        {
            _commercialobjContext.Entry(commercialobj).State = EntityState.Modified;
            await _commercialobjContext.SaveChangesAsync();
        }

        public async Task RemoveCommercialobj(commercialobj commercialobj)
        {
            _commercialobjContext.Commercialobjs.Remove(commercialobj);
            await _commercialobjContext.SaveChangesAsync();
        }

    }
}
