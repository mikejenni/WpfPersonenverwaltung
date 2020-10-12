using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using WpfPersonenverwaltung.BusinessObject;
using WpfPersonenverwaltung.Database;
using WpfPersonenverwaltung.Helper;
using WpfPersonenverwaltung.Model;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;

namespace WpfPersonenverwaltung.ViewModel
{
    public class VmPersonManagement : ObservableObject
    {
        #region Fields, Properties
        private enum EditMode { New, Edit };
        private EditMode _eMode;
        private RepoAbteilung _repoAbteilung = new RepoAbteilung();
        private RepoPerson _repoPerson = new RepoPerson();

        private ObservableCollection<PersonViewModel> _personList = new ObservableCollection<PersonViewModel>();
        public ObservableCollection<PersonViewModel> PersonList
        {
            get { return _personList; }
            set
            {
                _personList = value;
                RaisePropertyChanged("PersonList");
            }
        }

        private ObservableCollection<AbteilungViewModel> _abteilungList = new ObservableCollection<AbteilungViewModel>();
        public ObservableCollection<AbteilungViewModel> AbteilungList
        {
            get { return _abteilungList; }
            set
            {
                _abteilungList = value;
                RaisePropertyChanged("AbteilungList");
            }
        }

        private ObservableCollection<string> _abteilungListNamen = new ObservableCollection<string>();
        public ObservableCollection<string> AbteilungListNamen
        {
            get { return new ObservableCollection<string>(_abteilungList.Select(x => x.Name)); }
            set
            {
                _abteilungListNamen = value;
                RaisePropertyChanged("AbteilungListNamen");
            }
        }

        private PersonViewModel _selectedPerson = new PersonViewModel();
        public PersonViewModel SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                RaisePropertyChanged("SelectedPerson");
            }
        }

        private string _searchWord = string.Empty;
        public string SearchWord
        {
            get { return _searchWord; }
            set
            {
                _searchWord = value;
                RaisePropertyChanged("SearchWord");
            }
        }

        #region ViewControl
        private SolidColorBrush _newEntryBackground = new SolidColorBrush(Colors.White);
        public SolidColorBrush NewEntryBackground
        {
            get { return _newEntryBackground; }
            set
            {
                _newEntryBackground = value;
                RaisePropertyChanged("NewEntryBackground");
            }
        }

        private bool _isEnabled = true;
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                RaisePropertyChanged("IsEnabled");
            }
        }
        #endregion
        #endregion

        #region Contsruct
        //Productiv Construct
        public VmPersonManagement()
        {
            GetPersonList();
            GetAbteilungList();
            AbteilungListNamen = new ObservableCollection<string>(_abteilungList.Select(x => x.Name));
            _eMode = EditMode.Edit;
        }

        //Testing Construct
        public VmPersonManagement(bool test)
        {
            AbteilungListNamen = new ObservableCollection<string>(_abteilungList.Select(x => x.Name));
            _eMode = EditMode.Edit;
        }
        #endregion

        #region Helper
        private void RefreshPersonList()
        {
            PersonList.Clear();
            GetPersonList(SearchWord);
        }

        private bool CreateNewPerson(PersonViewModel persView, out Person editPers)
        {
            if (string.IsNullOrEmpty(persView.Name) ||
                string.IsNullOrEmpty(persView.SecondName) ||
                string.IsNullOrEmpty(persView.Street) ||
                string.IsNullOrEmpty(persView.Plz) ||
                string.IsNullOrEmpty(persView.Place))
            {
                MessageBox.Show($"Bitte alle Felder komplett ausfüllen!", "Hinweis", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
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
                AbteilungId = _abteilungList.FirstOrDefault(x => x.Name.Equals(persView.AbteilungName))?.AbteilungId
            };
            return true;
        }

        private bool CanExecute()
        {
            return true;
        }
        #endregion

        #region Create, Read, Update, Delete
        public void GetPersonList(string searchWord = null)
        {
            var tmpPersonList = string.IsNullOrEmpty(searchWord)
                ? _repoPerson.GetPersonList()
                : _repoPerson.GetPersonList().Where(x => x.Name.ToUpper().Contains(searchWord.ToUpper()));
           
            foreach (var item in tmpPersonList)
            {
                PersonList.Add(new PersonViewModel()
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
            var tmpABteilungList = _repoAbteilung.GetAbteilungList();
            foreach (var item in tmpABteilungList)
            {
                AbteilungList.Add(new AbteilungViewModel()
                {
                    AbteilungId = item.AbteilungId,
                    Name = item.Name
                });
            }
        }
        private void NewEntryExecute()
        {
            SelectedPerson = null;
            if (_eMode == EditMode.Edit)
            {
                _eMode = EditMode.New;
                NewEntryBackground = Brushes.Green;
                IsEnabled = false;
            }
            else
            {
                _eMode = EditMode.Edit;
                NewEntryBackground = Brushes.White;
                IsEnabled = true;
            }

            if (SelectedPerson != null)
                return;
            SelectedPerson = new PersonViewModel {AbteilungName = AbteilungListNamen.FirstOrDefault()};
        }

        public ICommand NewEntry
        {
            get { return new RelayCommand(NewEntryExecute, CanExecute);}
        }

        private void SaveExecute()
        {
            Person editPers;
            if (_eMode == EditMode.Edit)
            {
                if (SelectedPerson == null)
                    return;
                if(!CreateNewPerson(SelectedPerson, out editPers))
                    return;
                _repoPerson.UpdatePerson(editPers);
            }
            else
            {
                if (!CreateNewPerson(SelectedPerson, out editPers))
                    return;
                _repoPerson.EntryPerson(editPers);
            }
            RefreshPersonList();
        }

        public ICommand Save
        {
            get { return new RelayCommand(SaveExecute, CanExecute); }
        }

        private void DeleteExecute()
        {
            if(SelectedPerson == null)
                return;

            _repoPerson.DeletePerson(SelectedPerson.Id);
            RefreshPersonList();
        }

        public ICommand Delete
        {
            get { return new RelayCommand(DeleteExecute, CanExecute); }
        }

        private void SearchExecute()
        {
            RefreshPersonList();
        }

        public ICommand Search
        {
            get { return new RelayCommand(SearchExecute, CanExecute); }
        }

        #endregion
    }
}
