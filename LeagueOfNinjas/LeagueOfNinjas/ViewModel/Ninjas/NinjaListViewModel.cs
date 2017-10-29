using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using LeagueOfNinjas.View.Ninjas;
using LeagueOfNinjas.View.Loadout;
using LeagueOfNinjas.Data;

namespace LeagueOfNinjas.ViewModel.Ninjas
{
    public class NinjaListViewModel : ViewModelBase
    {
        private LONEntities _database;
        private Ninja _selectedNinja;
        private NinjaCreateView _createView;
        private NinjaEditView _editView;
        private LoadoutListView _loadOutView;
        public ICommand NinjaAddCommand { get; set; }
        public ICommand NinjaEditCommand { get; set; }
        public ICommand NinjaDeleteCommand { get; set; }
        public ICommand NinjaSelectCommand { get; set; }
        public ICommand openLoadOutCommand { get; set; }

        public NinjaListViewModel(LONEntities database)
        {
            _database = database;

            NinjaAddCommand = new RelayCommand(OpenCreateWindow);
            NinjaEditCommand = new RelayCommand(EditNinja);
            NinjaDeleteCommand = new RelayCommand(DeleteNinja);
            openLoadOutCommand = new RelayCommand(openLoadOut);
        }

        public ObservableCollection<Ninja> Ninjas
        {
            get
            {
                return new ObservableCollection<Ninja>(_database.Ninja);
            }
        }

        public bool IsNinjaSelected
        {
            get
            {
                return _selectedNinja != null;
            }
        }

        public void openLoadOut()
        {
            _loadOutView = new LoadoutListView();
            _loadOutView.ShowDialog();
        }

        public Ninja SelectedNinja
        {
            get
            {
                return _selectedNinja;
            }

            set
            {
                _selectedNinja = value;
                RaisePropertyChanged("SelectedNinja");
                RaisePropertyChanged("IsNinjaSelected");
            }
        }

        public void OpenCreateWindow()
        {
            _createView = new NinjaCreateView();
            _createView.ShowDialog();
        }

        public void CloseCreateWindow()
        {
            _createView.Close();
            RaisePropertyChanged("Ninjas");
        }

        public void CloseLoadOutWindow()
        {
            _loadOutView.Close();
            RaisePropertyChanged("LoadOut");
        }

        public void EditNinja()
        {
            _editView = new NinjaEditView();
            _editView.ShowDialog();
        }

        public void CloseEditWindow()
        {
            _editView.Close();
            RaisePropertyChanged("Ninjas");
        }

        public void DeleteNinja()
        {
            _database.Ninja.Remove(_selectedNinja);
            _database.SaveChanges();
            RaisePropertyChanged("Ninjas");
        }
    }
}
