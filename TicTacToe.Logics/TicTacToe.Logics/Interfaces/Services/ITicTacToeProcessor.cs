using System.Collections.Generic;
using TicTacToe.Logics.Interfaces.ViewModel;

namespace TicTacToe.Logics.Interfaces.Services
{
    
    public interface ITicTacToeProcessor
    {
        /// <summary>
        /// Determine the winner in Tic-Tac-Toe Game
        /// </summary>
        /// <param name="oXsCollection"></param>
        /// <returns>
        /// If result is true - Cross (X) is winer
        /// If result is false - Circle (O) is winer
        /// If result is null - no winer
        /// </returns>
        bool? CheckWinner(IEnumerable<IXOsVievModel> xOsCollection);
    }
}