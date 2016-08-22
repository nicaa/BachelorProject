using BLToolkit.DataAccess;
using Garia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garia.Core.DAO
{
    public abstract class PersonDAO : DataAccessor
    {
        [SprocName("Person_GetAllPersons")]
        public abstract List<Person> GetAllPersons();

    }
}
