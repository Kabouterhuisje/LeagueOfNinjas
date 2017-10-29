using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using LeagueOfNinjas.Data;
using LeagueOfNinjas.ViewModel.Equipment;

namespace LeagueOfNinjas.ViewModel.Equipment
{
    public class EquipmentEditViewModel : ViewModelBase
    {
        private LONEntities _database;
        private EquipmentListViewModel _viewModel;
        public Data.Equipment Equipment { get; set; }
        public List<Category> EquipmentTypes { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public EquipmentEditViewModel(EquipmentListViewModel viewModel, LONEntities database)
        {
            _database = database;
            _viewModel = viewModel;

            Equipment = viewModel.SelectedEquipment;
            EquipmentTypes = database.Category.ToList();

            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(Cancel);
        }

        public void Save()
        {
            _database.SaveChanges();
            _viewModel.CloseEditEquipment();
        }

        public void Cancel()
        {
            _viewModel.CloseEditEquipment();
        }
    }
}