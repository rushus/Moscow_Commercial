using Commercialobj.DomainObjects;
using Commercialobj.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Commercialobj.ApplicationServices.Repositories
{
    public class InMemoryCommercialobjRepository : IReadOnlyCommercialobjRepository,
                                           ICommercialobjRepository 
    {
        private readonly List<commercialobj> _commercialobjs = new List<commercialobj>();

        public InMemoryCommercialobjRepository(IEnumerable<commercialobj> commercialobjs = null)
        {
            if (commercialobjs != null)
            {
                _commercialobjs.AddRange(commercialobjs);
            }
        }

        public Task AddCommercialobj(commercialobj commercialobj)
        {
            _commercialobjs.Add(commercialobj);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<commercialobj>> GetAllCommercialobjs()
        {
            return Task.FromResult(_commercialobjs.AsEnumerable());
        }

        public Task<commercialobj> GetCommercialobj(long id)
        {
            return Task.FromResult(_commercialobjs.Where(pn => pn.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<commercialobj>> QueryCommercialobjs(ICriteria<commercialobj> criteria)
        {
            return Task.FromResult(_commercialobjs.Where(criteria.Filter.Compile()).AsEnumerable());
        }

        public Task RemoveCommercialobj(commercialobj commercialobj)
        {
            _commercialobjs.Remove(commercialobj);
            return Task.CompletedTask;
        }

        public Task UpdateCommercialobj(commercialobj commercialobj)
        {
            var foundCommercialobj = GetCommercialobj(commercialobj.Id).Result;
            if (foundCommercialobj == null)
            {
                AddCommercialobj(commercialobj);
            }
            else
            {
                if (foundCommercialobj != commercialobj)
                {
                    _commercialobjs.Remove(foundCommercialobj);
                    _commercialobjs.Add(commercialobj);
                }
            }
            return Task.CompletedTask;
        }
    }
}
