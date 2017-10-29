using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using LeagueOfNinjas.Data;

namespace LeagueOfNinjas.ViewModel.Equipment
{
    public class EquipmentCreateViewModel : ViewModelBase
    {
        private LONEntities _database;
        private EquipmentListViewModel _viewModel;
        public Data.Equipment Equipment { get; set; }
        public List<Category> EquipmentTypes { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public EquipmentCreateViewModel(EquipmentListViewModel viewModel, LONEntities database)
        {
            _database = database;
            _viewModel = viewModel;

            Equipment = new Data.Equipment();
            EquipmentTypes = database.Category.ToList();

            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(Cancel);

            Equipment.Name = "New Item";
            Equipment.Category = EquipmentTypes.First();
            Equipment.Value = 1;
        }

        public void Save()
        {
            _database.Equipment.Add(Equipment);
            _database.SaveChanges();
            _viewModel.CloseCreateEquipment();
        }

        public void Cancel()
        {
            _viewModel.CloseCreateEquipment();
        }
    }
}
