using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LeagueOfNinjas.Data;
using LeagueOfNinjas.ViewModel.Loadout;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace LeagueOfNinjas.ViewModel.Loadout
{
    public class LoadoutCreateViewModel : ViewModelBase
    {
        private Data.Loadout _loadout;
        private string _loadoutName;
        private LoadoutListViewModel _listViewModel;
        private LONEntities _database;
        private Ninja _ninja;
        private Data.Equipment _selectedItem;
        private ICollection<Data.Equipment> _loCollection;
        private string itemName;
        private List<LoadoutItems> _loadOutList;
        private ICollection<LoadoutItems> _loadOutItems;
        private LoadoutItems _newItem;
        public ICommand CancelCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand addItemCommand { get; set; }

        public LoadoutCreateViewModel(LoadoutListViewModel listViewModel, LONEntities database)
        {
            _loadout = new Data.Loadout();
            _loadoutName = "New Loadout";
            _listViewModel = listViewModel;
            _database = database;
            _ninja = _listViewModel.getSelectedNinja();
            _loadOutList = new List<LoadoutItems>();
            
            CancelCommand = new RelayCommand(Cancel);
            SaveCommand = new RelayCommand(Save);
            addItemCommand = new RelayCommand(addItem);
        }

        public void addItem()
        {
            _newItem = new LoadoutItems();
            _newItem.Equipment = selectedItem.Id;
            _newItem.Equipment1 = selectedItem;
            _newItem.Loadout = _loadout.Id;
            _newItem.Loadout1 = _loadout;

            _loadOutList.Add(_newItem);

            RaisePropertyChanged("addItem");
            RaisePropertyChanged("isLoadOutNull");
        }

        public bool isItemSeleceted
        {
            get { return _selectedItem != null; }
        }

        public ObservableCollection<Data.Equipment> loCollection
        {
            get
            {
                ObservableCollection<Data.Equipment> purchasedItems =  new ObservableCollection<LeagueOfNinjas.Data.Equipment>();
                foreach (var item in _ninja.PurchasedItems)
                {
                    purchasedItems.Add(item.Equipment1);
                }
                return purchasedItems;
            }
        }

        public bool isLoadOutNull
        {
            get { return _loadOutList != null; }
        }

        public bool isDifferentCategory
        {
            get
            {
                bool diffCategory = true;
                foreach (var item in _loadOutList)
                {
                    if (item.Equipment1.Category == _selectedItem.Category)
                    {
                        diffCategory = false;
                    }
                }
                return diffCategory;
            }
        }

        public Data.Equipment selectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                RaisePropertyChanged("selectedItem");
                RaisePropertyChanged("isItemSeleceted");
                RaisePropertyChanged("isDifferentCategory");
            }
        }

        public Data.Loadout Loadout
        {
            get
            {
                return _loadout;
            }

            set
            {
                _loadout = value;
                RaisePropertyChanged("Loadout");
            }
        }

        public string LoadoutName
        {
            get
            {
                return _loadoutName;
            }

            set
            {
                _loadoutName = value;
                RaisePropertyChanged("LoadoutName");
            }
        }

        public void Cancel()
        {
            _listViewModel.CloseCreateWindow();
        }

        public void Save()
        {
            _loadout.Name = LoadoutName;
            _loadOutItems = _loadOutList;
            _loadout.LoadoutItems = _loadOutItems;
            _loadout.Ninja = _ninja.Id;


            _database.Loadout.Add(_loadout);
            _database.SaveChanges();
            _listViewModel.CloseCreateWindow();
        }
    }
}
