using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPersonenverwaltungTest.Database;

namespace WpfPersonenverwaltungTest.Model
{
    class RepoAbteilung
    {
        private PersonManagementTestEntities _context;

        public RepoAbteilung()
        {
            _context = new PersonManagementTestEntities();
        }

        //Read
        public List<Abteilung> GetAbteilungList()
        {
            return _context.Abteilung.Include("Person").ToList();
        }
    }
}
