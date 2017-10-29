using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LeagueOfNinjas.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace LeagueOfNinjas.ViewModel
{
    public class ShopViewModel : ViewModelBase
    {
        private LONEntities _database;
        private Category _selectedCategory;
        private Data.Equipment _selectedEquipment;

        public ShopViewModel(LONEntities database)
        {
            _database = database;

            Categories = new List<Category>(_database.Category);

            BuyCommand = new RelayCommand(Buy);
        }

        public List<Category> Categories { get; set; }

        public ObservableCollection<Data.Equipment> Equipment { get; set; }

        public ICommand BuyCommand { get; set; }
        public ICommand RefreshCommand { get; set; }

        public Category SelectedCategory
        {
            get
            {
                return _selectedCategory;
            }

            set
            {
                _selectedCategory = value;
                UpdateEquipment();
            }
        }

        public Data.Equipment SelectedEquipment
        {
            get
            {
                return _selectedEquipment;
            }

            set
            {
                _selectedEquipment = value;
                RaisePropertyChanged("SelectedEquipment");
                RaisePropertyChanged("IsEquipmentSelected");
            }
        }

        public bool IsEquipmentSelected
        {
            get
            {
                return _selectedEquipment != null;
            }
        }

        public void UpdateEquipment()
        {
            if (MainViewModel.CurrentNinja == null)
            {
                Equipment = new ObservableCollection<Data.Equipment>();
                RaisePropertyChanged("Equipment");
                return;
            }

            Equipment = new ObservableCollection<Data.Equipment>();

            foreach (var equipment in _database.Equipment)
            {
                if (!equipment.Type.Equals(SelectedCategory.Type)) continue;

                bool bought = false;

                foreach (var purchasedItem in MainViewModel.CurrentNinja.PurchasedItems)
                {
                    if (equipment.Id == purchasedItem.Equipment)
                    {
                        bought = true;
                        break;
                    }
                }

                if (bought) continue;

                Equipment.Add(equipment);
            }

            RaisePropertyChanged("Equipment");
        }

        public void Buy()
        {
            if (MainViewModel.CurrentNinja.Gold < SelectedEquipment.Value)
            {
                MessageBox.Show("You don't have that much money!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            PurchasedItems item = new PurchasedItems();
            item.Ninja = MainViewModel.CurrentNinja.Id;
            item.Equipment = SelectedEquipment.Id;
            _database.PurchasedItems.Add(item);

            MainViewModel.CurrentNinja.Gold -= SelectedEquipment.Value;

            _database.SaveChanges();

            UpdateEquipment();
        }
    }
}