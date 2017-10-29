/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:LeagueOfNinjas"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using LeagueOfNinjas.Data;
using LeagueOfNinjas.ViewModel.Equipment;
using LeagueOfNinjas.ViewModel.Loadout;
using LeagueOfNinjas.ViewModel.Ninjas;
using Microsoft.Practices.ServiceLocation;

namespace LeagueOfNinjas.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ShopViewModel>();
            SimpleIoc.Default.Register<LONEntities>();
            SimpleIoc.Default.Register<NinjaListViewModel>();
            SimpleIoc.Default.Register<EquipmentListViewModel>();
            SimpleIoc.Default.Register<LoadoutListViewModel>();
        }

        public MainViewModel MainViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public ShopViewModel ShopViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ShopViewModel>();
            }
        }

        public LONEntities Database
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LONEntities>();
            }
        }

        public NinjaVisualViewModel NinjaVisualViewModel
        {
            get
            {
                return new NinjaVisualViewModel(Database);
            }
        }

  
        public EquipmentListViewModel EquipmentListViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EquipmentListViewModel>();
            }
        }

        public EquipmentEditViewModel EquipmentEditViewModel
        {
            get
            {
                return new EquipmentEditViewModel(EquipmentListViewModel, Database);
            }
        }

        public EquipmentCreateViewModel EquipmentCreateViewModel
        {
            get
            {
                return new EquipmentCreateViewModel(EquipmentListViewModel, Database);
            }
        }



        public NinjaListViewModel NinjaListViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NinjaListViewModel>();
            }
        }

        public NinjaCreateViewModel NinjaCreateViewModel
        {
            get
            {
                return new NinjaCreateViewModel(NinjaListViewModel, Database);
            }
        }

        public NinjaEditViewModel NinjaEditViewModel
        {
            get
            {
                return new NinjaEditViewModel(NinjaListViewModel, Database);
            }
        }


        public LoadoutListViewModel LoadoutListViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoadoutListViewModel>();
            }
        }

        public LoadoutCreateViewModel LoadoutCreateViewModel
        {
            get
            {
                return new LoadoutCreateViewModel(LoadoutListViewModel, Database);
            }
        }

        public LoadoutEditViewModel LoadoutEditViewModel
        {
            get
            {
                return new LoadoutEditViewModel(LoadoutListViewModel, Database);
            }
        }


        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}