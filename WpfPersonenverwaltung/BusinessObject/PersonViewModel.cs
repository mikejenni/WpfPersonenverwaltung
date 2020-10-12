using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPersonenverwaltung.Database;
using WpfPersonenverwaltung.Helper;

namespace WpfPersonenverwaltung.BusinessObject
{
    public class PersonViewModel : ObservableObject
    {
        private Person _person;

        public Person Person
        {
            get { return _person; }
            set { _person = value; }
        }

        public PersonViewModel()
        {
            _person = new Person();
        }

        public int Id
        {
            get { return _person.Id; }
            set
            {
                _person.Id = value;
                //RaisePropertyChanged("Id");
            }
        }
        public string Name
        {
            get { return _person.Name; }
            set
            {
                _person.Name = value;
                //RaisePropertyChanged("Name");
            }
        }
        public string SecondName
        {
            get { return _person.SecondName; }
            set
            {
                _person.SecondName = value;
                //RaisePropertyChanged("SecondName");
            }
        }
        public string Street
        {
            get { return _person.Street; }
            set
            {
                _person.Street = value;
                //RaisePropertyChanged("Street");
            }
        }
        public string Plz
        {
            get { return _person.Plz; }
            set
            {
                _person.Plz = value;
                //RaisePropertyChanged("Plz");
            }
        }
        public string Place
        {
            get { return _person.Place; }
            set
            {
                _person.Place = value;
                //RaisePropertyChanged("Place");
            }
        }
        public int? AbteilungId
        {
            get { return _person.AbteilungId; }
            set
            {
                _person.AbteilungId = value;
                //RaisePropertyChanged("AbteilungId");
            }
        }
        public Abteilung Abteilung
        {
            get { return _person.Abteilung; }
            set
            {
                _person.Abteilung = value;
                //RaisePropertyChanged("Abteilung");
            }
        }
        public string AbteilungName { get; set; }
    }
}
