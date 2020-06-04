using Commercialobj.DomainObjects;
using Commercialobj.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Commercialobj.ApplicationServices.GetAdmAreaListUseCase
{
    public class AdmAreaCriteria : ICriteria<commercialobj>
    {
        public string AdmArea { get; }

        public AdmAreaCriteria (string admarea)
            => AdmArea = admarea;

        public Expression<Func<commercialobj, bool>> Filter
            => (b => b.District == AdmArea);
    }
}
