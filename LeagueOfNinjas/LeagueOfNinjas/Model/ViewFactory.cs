using LeagueOfNinjas.View.Equipment;
using LeagueOfNinjas.View.Ninjas;
using System.Collections.Generic;
using System.Windows.Controls;

namespace LeagueOfNinjas.Model
{
    public class ViewFactory
    {
        private IDictionary<string, UserControl> _views;

        public ViewFactory()
        {
            _views = new Dictionary<string, UserControl>();
            _views["ninja"] = new NinjaListView();
            _views["shop"] = new ShopView();
            _views["equipment"] = new EquipmentListView();
        }

        public UserControl GetView(string name)
        {
            return _views[name];
        }
    }
}
