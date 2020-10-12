using WpfPersonenverwaltung.Model;
using System.Collections.Generic;
using WpfPersonenverwaltung.Helper;
using WpfPersonenverwaltung.Database;

namespace WpfPersonenverwaltung.Controller
{
    class CtrPerson
    {
        //SQLCOMMAND
        //private ModelPerson _modelPerson;
        //private ModelAbteilung _modelAbteilung;

        //Entity Framework
        private RepoPerson _modelPerson;
        private RepoAbteilung _modelAbteilung;

        public CtrPerson()
        {
            var sqlConnection = CreateSqlConnection.GetSqlConnection();

            //SQLCOMMAND
            //_modelPerson = new ModelPerson(sqlConnection);
            //_modelAbteilung = new ModelAbteilung(sqlConnection);

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
