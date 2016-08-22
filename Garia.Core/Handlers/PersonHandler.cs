
using BLToolkit.Reflection;
using Garia.Core.DAO;
using Garia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garia.Core.Handlers
{
    public class PersonHandler
    {
        public static List<Person> GetAllPersons()
        {
            PersonDAO person = TypeAccessor<PersonDAO>.CreateInstance();
            return person.GetAllPersons();
        }
    }
}
