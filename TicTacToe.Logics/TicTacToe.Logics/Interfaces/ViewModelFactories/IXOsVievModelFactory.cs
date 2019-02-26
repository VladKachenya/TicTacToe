using System.Collections.ObjectModel;
using TicTacToe.Logics.Interfaces.ViewModel;

namespace TicTacToe.Logics.Interfaces.ViewModelFactories
{
    public interface IXOsVievModelFactory
    {
        ObservableCollection<IXOsVievModel> CreateXoCollection();
    }
}