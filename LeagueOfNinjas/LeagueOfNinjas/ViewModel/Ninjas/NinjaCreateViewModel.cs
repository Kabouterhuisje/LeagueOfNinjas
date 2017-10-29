using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LeagueOfNinjas.Data;
using System.Windows.Input;

namespace LeagueOfNinjas.ViewModel.Ninjas
{
    public class NinjaCreateViewModel : ViewModelBase
    {
        private Ninja _loadout;
        private string _loadoutName;
        private int _loadoutGold;
        private NinjaListViewModel _listViewModel;
        private LONEntities _database;
        public ICommand CancelCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public NinjaCreateViewModel(NinjaListViewModel listViewModel, LONEntities database)
        {
            _loadout = new Ninja();
            _loadoutName = "New Ninja";
            _loadoutGold = 500;
            _listViewModel = listViewModel;
            _database = database;

            CancelCommand = new RelayCommand(Cancel);
            SaveCommand = new RelayCommand(Save);
        }

        public Ninja Ninja
        {
            get
            {
                return _loadout;
            }

            set
            {
                _loadout = value;
                RaisePropertyChanged("Ninja");
            }
        }

        public string NinjaName
        {
            get
            {
                return _loadoutName;
            }

            set
            {
                _loadoutName = value;
                RaisePropertyChanged("NinjaName");
            }
        }

        public int NinjaGold
        {
            get
            {
                return _loadoutGold;
            }

            set
            {
                _loadoutGold = value;
                RaisePropertyChanged("NinjaGold");
            }
        }

        public void Cancel()
        {
            _listViewModel.CloseCreateWindow();
        }

        public void Save()
        {
            _loadout.Name = NinjaName;
            _loadout.Gold = NinjaGold;
            _database.Ninja.Add(_loadout);
            _database.SaveChanges();
            _listViewModel.CloseCreateWindow();
        }
    }
}
