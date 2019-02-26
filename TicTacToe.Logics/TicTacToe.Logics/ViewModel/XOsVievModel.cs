using GalaSoft.MvvmLight;
using TicTacToe.Logics.Interfaces.ViewModel;

namespace TicTacToe.Logics.ViewModel
{
    public class XOsVievModel : ViewModelBase, IXOsVievModel
    {
        private bool? _value = null;

        public bool? Value
        {
            get => _value;
            protected set => Set(ref _value, value);
        }

        public void SetXorO(bool isX)
        {
            if (Value == null)
            {
                Value = isX;
            }
        }

        public void ResetValue()
        {
            Value = null;
        }
    }
}