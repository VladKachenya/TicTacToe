using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using TicTacToe.Logics.Interfaces.Services;
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
        private readonly ITicTacToeProcessor _ticTacToeProcessor;
        private bool _isX = true;
        private bool _haveWinner = false;


        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IXOsVievModelFactory xOsVievModelFactory, ITicTacToeProcessor ticTacToeProcessor)
        {
            _xOsVievModelFactory = xOsVievModelFactory;
            _ticTacToeProcessor = ticTacToeProcessor;
            XOsVievModels = _xOsVievModelFactory.CreateXoCollection();
            MoveCommand = new RelayCommand<IXOsVievModel>(OnMoveCommand);
            RestartCommand = new RelayCommand(OnResetCommand);
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
        public RelayCommand RestartCommand { get; }


        public ObservableCollection<IXOsVievModel> XOsVievModels { get;}

        public bool IsX
        {
            get => _isX;
            set =>  Set(ref _isX, value);
        }

        public bool HaveWinner
        {
            get => _haveWinner;
            set =>Set(ref _haveWinner, value);
        }

        #region private methods

        private void OnMoveCommand(IXOsVievModel osVievModel)
        {
            if (osVievModel.Value == null)
            {
                osVievModel.SetXorO(IsX);
                if (_ticTacToeProcessor.CheckWinner(XOsVievModels) != null)
                {
                    HaveWinner = true;
                }
                IsX = !IsX;
            }
        }

        private void OnResetCommand()
        {
            foreach (var xOsVievModel in XOsVievModels)
            {
                xOsVievModel.ResetValue();
            }

            IsX = true;
            HaveWinner = false;
        }
        #endregion
    }
}