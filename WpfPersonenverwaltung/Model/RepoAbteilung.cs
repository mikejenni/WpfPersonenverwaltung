using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPersonenverwaltung.Database;

namespace WpfPersonenverwaltung.Model
{
    class RepoAbteilung
    {
        private PersonManagementEntities _context;

        public RepoAbteilung()
        {
            _context = new PersonManagementEntities();
        }

        //Read
        public List<Abteilung> GetAbteilungList()
        {
            return _context.Abteilung.Include("Person").ToList();
        }
    }
}
