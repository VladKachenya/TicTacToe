namespace TicTacToe.Logics.Interfaces.ViewModel
{
    public interface IXOsVievModel
    {
        bool? Value { get; }

        void SetXorO(bool isX);

        void ResetValue();
    }
}