using System.Collections.Generic;
using WpfPersonenverwaltungTest.Database;
using WpfPersonenverwaltungTest.Model;

namespace WpfPersonenverwaltungTest.Controller
{
    class CtrPersonTest
    {
        private RepoPerson _modelPerson;
        private RepoAbteilung _modelAbteilung;

        public CtrPersonTest()
        {
            //Entity Framework
            _modelPerson = new RepoPerson();
            _modelAbteilung = new RepoAbteilung();
        }

        #region Person
        public List<Person> GetPersonList()
        {
            return _modelPerson.GetPersonList();
        }

        public void EntryPerson(Person pers)
        {
            _modelPerson.EntryPerson(pers);
        }

        public void UpdatePerson(Person pers)
        {
            _modelPerson.UpdatePerson(pers);
        }

        public void DeletePerson(int persId)
        {
            _modelPerson.DeletePerson(persId);
        }
        #endregion

        #region Abteilung
        public List<Abteilung> GetAbteilungList()
        {
            return _modelAbteilung.GetAbteilungList();
        }
        #endregion
    }
}
