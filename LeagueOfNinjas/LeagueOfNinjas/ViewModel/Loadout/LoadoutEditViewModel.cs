using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LeagueOfNinjas.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace LeagueOfNinjas.ViewModel.Loadout
{
    public class LoadoutEditViewModel : ViewModelBase
    {
        private Data.Loadout _loadout;
        private string _loadoutName;
        private LoadoutListViewModel _listViewModel;
        private LONEntities _database;
        private LoadoutItems _loadoutItem;
        private LoadoutItems _newItem;
        private PurchasedItems _purchasedItem;
        private ICollection<LoadoutItems> _allLoadoutItems;
        private ICollection<LoadoutItems> _finalLoadOut;
        private List<LoadoutItems> _itemList;
        private List<LoadoutItems> _removedItemList;
        public ICommand CancelCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand addCommand { get; set; }
        public ICommand removeCommand { get; set; }

        public LoadoutEditViewModel(LoadoutListViewModel listViewModel, LONEntities database)
        {
            _loadout = listViewModel.SelectedLoadout;
            _loadoutName = _loadout.Name;
            _listViewModel = listViewModel;
            _database = database;
            _allLoadoutItems = _loadout.LoadoutItems;
            _removedItemList = new List<LoadoutItems>();

            CancelCommand = new RelayCommand(Cancel);
            SaveCommand = new RelayCommand(Save);
            addCommand = new RelayCommand(addItem);
            removeCommand = new RelayCommand(removeItem);
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

        public ObservableCollection<LoadoutItems> loadOutItems {
            get
            {
                _itemList = new List<LoadoutItems>();
                ObservableCollection<LeagueOfNinjas.Data.LoadoutItems> collection = new ObservableCollection<LeagueOfNinjas.Data.LoadoutItems>();
                foreach (var item in _allLoadoutItems)
                {
                    collection.Add(item);
                    _itemList.Add(item);
                }
                return collection;
            }
        }

        public ICollection<PurchasedItems> ownedItems {
            get
            {
                return _listViewModel.getSelectedNinja().PurchasedItems;
            }
        }

        public PurchasedItems OwnedEquipment
        {
            get
            {
                return _purchasedItem;
            }
            set
            {
                _purchasedItem = value;
                _loadoutItem = null;
                RaisePropertyChanged("isOwnedSelected");
                RaisePropertyChanged("isDifferentCategory");
            }
        }

        public LoadoutItems currentItemSelected
        {
            get
            {
                return _loadoutItem;
            }
            set
            {
                _loadoutItem = value;
                _purchasedItem = null;
                RaisePropertyChanged("isCurrentSelected");
                RaisePropertyChanged("isDifferentCategory");
            }
        }

        private void removeItem()
        {
            foreach (var item in _allLoadoutItems)
            {
                if (_loadoutItem.Id == item.Id)
                {
                    _allLoadoutItems.Remove(item);
                    _itemList.Remove(item);
                    _removedItemList.Add(item);
                    break;
                }
            }
            RaisePropertyChanged("loadOutItems");
        }

        private void addItem()
        {
            _newItem = new LoadoutItems();
            _newItem.Equipment = _purchasedItem.Equipment;
            _newItem.Equipment1 = _purchasedItem.Equipment1;
            _newItem.Loadout = _loadout.Id;
            _newItem.Loadout1 = _loadout;

            _allLoadoutItems.Add(_newItem);
            _itemList.Add(_newItem);
            RaisePropertyChanged("loadOutItems");
        }

        public bool isDifferentCategory
        {
            get
            {
                bool diffCategory = true;
                foreach (var item in _itemList)
                {
                    if (item.Equipment1.Category == _purchasedItem.Equipment1.Category)
                    {
                        diffCategory = false;
                    }
                }
                return diffCategory;
            }
        }

        public bool isOwnedSelected
        {
            get
            {
                return _purchasedItem != null;
            }
        }

        public bool isCurrentSelected
        {
            get
            {
                return _loadoutItem != null;
            }
        }

        public void Cancel()
        {
            _listViewModel.CloseEditWindow();
        }

        public void Save()
        {
            foreach (var removedItem in _removedItemList)
            {
                _database.LoadoutItems.Remove(removedItem);
            }
            _database.Loadout.Remove(_loadout);
            _database.SaveChanges();
            _loadout.Name = LoadoutName;
            _loadout.LoadoutItems = _itemList;
            _database.Loadout.Add(_loadout);
            _database.SaveChanges();
            _listViewModel.CloseEditWindow();
        }
    }
}
