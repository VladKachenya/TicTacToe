using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using TicTacToe.Logics.Interfaces.ViewModel;
using TicTacToe.Logics.Interfaces.ViewModelFactories;

namespace TicTacToe.Logics.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IXOsVievModelFactory _xOsVievModelFactory;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IXOsVievModelFactory xOsVievModelFactory )
        {
            _xOsVievModelFactory = xOsVievModelFactory;
            XOsVievModels = _xOsVievModelFactory.CreateXoCollection();
            MoveCommand = new RelayCommand<IXOsVievModel>(OnMoveCommand, CanMove());
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }

        public RelayCommand<IXOsVievModel> MoveCommand { get; }

        public ObservableCollection<IXOsVievModel> XOsVievModels { get; set; }

        public string Title => "Hello TicTacToe Game";

        #region private methods

        private void OnMoveCommand(IXOsVievModel osVievModel)
        {
            if (osVievModel.Value == null)
            {
                osVievModel.SetXorO(true);
            }
        }

        private bool CanMove()
        {
            return true;
        }

        #endregion
    }
}