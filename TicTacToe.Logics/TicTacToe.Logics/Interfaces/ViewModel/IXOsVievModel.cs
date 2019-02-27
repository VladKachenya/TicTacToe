namespace TicTacToe.Logics.Interfaces.ViewModel
{
    public interface IXOsVievModel
    {
        bool? Value { get; }

        bool IsWinner { get; set; }


        void SetXorO(bool isX);

        void ResetValue();
    }
}