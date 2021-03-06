using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using WpfPersonenverwaltung.Database;

namespace WpfPersonenverwaltung.Model
{
    class RepoPerson
    {
        private PersonManagementEntities _context;

        public RepoPerson()
        {
            _context = new PersonManagementEntities();
        }

        //Read
        public List<Person> GetPersonList()
        {
            return _context.Person.Include("Abteilung").ToList();
        }

        //Create
        public void EntryPerson(Person pers)
        {
            _context.Person.Add(pers);
            _context.SaveChanges();
        }

        //Update
        public void UpdatePerson(Person pers)
        {
            if (pers == null)
                return;

            _context.Person.AddOrUpdate(pers);
            _context.SaveChanges();
        }

        //Delete
        public void DeletePerson(int persId)
        {
            var pers = _context.Person.SingleOrDefault(x => x.Id == persId);
            _context.Person.Remove(pers);
            _context.SaveChanges();
        }
    }
}
