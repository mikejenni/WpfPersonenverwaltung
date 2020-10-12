using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfPersonenverwaltung.BusinessObject;
using WpfPersonenverwaltungTest.Controller;
using WpfPersonenverwaltung.ViewModel;
using WpfPersonenverwaltungTest.Database;
using WpfPersonenverwaltungTest.Helper;

namespace WpfPersonenverwaltungTest.TestPage
{
    [TestClass]
    public class UTestPersonManagement
    {
        private CtrPersonTest _ctrPersonTest;
        private VmPersonManagement _vmPersonManagement;

        public UTestPersonManagement()
        {
            ExecuteScript.LoadScript();

            _ctrPersonTest = new CtrPersonTest();
            _vmPersonManagement = new VmPersonManagement(true);

            GetPersonList();
            GetAbteilungList();
        }

        //Searching
        [TestMethod]
        public void A_SearchingTest()
        {
            GetPersonList();
            Assert.AreEqual(4, _vmPersonManagement.PersonList.Count);
            GetPersonList("be");
            Assert.AreEqual(2, _vmPersonManagement.PersonList.Count);
        }

        //Update
        [TestMethod]
        public void B_UpdateTest()
        {
            _vmPersonManagement.SelectedPerson = _vmPersonManagement.PersonList.FirstOrDefault(x=>x.Name.Equals("Beller"));
            if (_vmPersonManagement.SelectedPerson == null)
                return;
            _vmPersonManagement.SelectedPerson.Street = "Stationsstrasse 29";
            Person editPers;
            if (!CreateNewPerson(_vmPersonManagement.SelectedPerson, out editPers))
                return;
            _ctrPersonTest.UpdatePerson(editPers);

            GetPersonList();
            _vmPersonManagement.SelectedPerson = _vmPersonManagement.PersonList.FirstOrDefault(x => x.Name.Equals("Beller"));
            Assert.IsTrue(_vmPersonManagement.SelectedPerson != null && _vmPersonManagement.SelectedPerson.Street.Equals("Stationsstrasse 29"));
        }

        //NewEntry
        [TestMethod]
        public void C_NewEntryTest()
        {
            var newPers = new PersonViewModel()
            {
                Name = "NameTest",
                SecondName = "VornameTest",
                Street = "StreetTest",
                Plz = "PlzTest",
                Place = "PlaceTest",
                AbteilungName = "Informatik"
            };
            Person editPers;
            if (!CreateNewPerson(newPers, out editPers))
                return;
            _ctrPersonTest.EntryPerson(editPers);

            GetPersonList();
            _vmPersonManagement.SelectedPerson = _vmPersonManagement.PersonList.LastOrDefault();
            Assert.IsTrue(_vmPersonManagement.SelectedPerson != null && _vmPersonManagement.SelectedPerson.Place.Equals("PlaceTest"));
        }

        //NewEntry
        [TestMethod]
        public void D_DeleteTest()
        {
            GetPersonList();
            var countBefore = _vmPersonManagement.PersonList.Count;

            _vmPersonManagement.SelectedPerson = _vmPersonManagement.PersonList.LastOrDefault();
            if (_vmPersonManagement.SelectedPerson == null)
                return;
            _ctrPersonTest.DeletePerson(_vmPersonManagement.SelectedPerson.Id);
            GetPersonList();
            var countAfter = _vmPersonManagement.PersonList.Count;

            Assert.IsTrue(countBefore != countAfter);
        }

        #region Helper
        private bool CreateNewPerson(PersonViewModel persView, out Person editPers)
        {
            if (string.IsNullOrEmpty(persView.Name) ||
                string.IsNullOrEmpty(persView.SecondName) ||
                string.IsNullOrEmpty(persView.Street) ||
                string.IsNullOrEmpty(persView.Plz) ||
                string.IsNullOrEmpty(persView.Place))
            {
                Console.WriteLine("Bitte alle Felder komplett ausfüllen!");
                editPers = null;
                return false;
            }
            editPers = new Person()
            {
                Id = persView.Id,
                Name = persView.Name,
                SecondName = persView.SecondName,
                Street = persView.Street,
                Plz = persView.Plz,
                Place = persView.Place,
                AbteilungId = _vmPersonManagement.AbteilungList.FirstOrDefault(x => x.Name.Equals(persView.AbteilungName))?.AbteilungId
            };
            return true;
        }

        public void GetPersonList(string searchWord = null)
        {
            _vmPersonManagement.PersonList.Clear();
            var tmpPersonList = string.IsNullOrEmpty(searchWord)
                ? _ctrPersonTest.GetPersonList()
                : _ctrPersonTest.GetPersonList().Where(x => x.Name.ToUpper().Contains(searchWord.ToUpper()));

            foreach (var item in tmpPersonList)
            {
                _vmPersonManagement.PersonList.Add(new PersonViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    SecondName = item.SecondName,
                    Street = item.Street,
                    Plz = item.Plz,
                    Place = item.Place,
                    AbteilungId = item.AbteilungId,
                    AbteilungName = item.Abteilung.Name
                });
            }
        }
        private void GetAbteilungList()
        {
            var tmpABteilungList = _ctrPersonTest.GetAbteilungList();
            foreach (var item in tmpABteilungList)
            {
                _vmPersonManagement.AbteilungList.Add(new AbteilungViewModel()
                {
                    AbteilungId = item.AbteilungId,
                    Name = item.Name
                });
            }
        }
        #endregion
    }
}
