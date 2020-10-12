using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPersonenverwaltung.Database;
using WpfPersonenverwaltung.Helper;

namespace WpfPersonenverwaltung.BusinessObject
{
    public class AbteilungViewModel : ObservableObject
    {
        private Abteilung _abteilung;

        public Abteilung Abteilung
        {
            get { return _abteilung; }
            set { _abteilung = value; }
        }
        public AbteilungViewModel()
        {
            _abteilung = new Abteilung();
        }
        public int AbteilungId
        {
            get { return _abteilung.AbteilungId; }
            set
            {
                _abteilung.AbteilungId = value;
                //RaisePropertyChanged("AbteilungId");
            }
        }
        public string Name
        {
            get { return _abteilung.Name; }
            set
            {
                _abteilung.Name = value;
                //RaisePropertyChanged("Name");
            }
        }
    }
}
