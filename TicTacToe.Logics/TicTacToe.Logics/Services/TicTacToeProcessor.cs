using System.Collections.Generic;
using System.Linq;
using TicTacToe.Logics.Interfaces.Services;
using TicTacToe.Logics.Interfaces.ViewModel;

namespace TicTacToe.Logics.Services
{
    
    public class TicTacToeProcessor : ITicTacToeProcessor
    {
        private int[,] combinations = 
        {
            {0, 3, 6},
            {1, 4, 7},
            {2, 5, 8},

            {0, 1, 2},
            {3, 4, 5},
            {6, 7, 8},

            {0, 4, 8},
            {2, 4, 6}
        };

        public bool? CheckWinner(IEnumerable<IXOsVievModel> xOsCollection)
        {
            var XOs = xOsCollection.ToArray();
            int j0, j1, j2;
            for (int i = 0; i < combinations.Length / 3; i++)
            {
                j0 = combinations[i, 0];
                j1 = combinations[i, 1];
                j2 = combinations[i, 2];

                if (XOs[j0].Value != null && 
                    XOs[j0].Value == XOs[j1].Value && 
                    XOs[j1].Value == XOs[j2].Value)
                {
                    XOs[j0].IsWinner = true;
                    XOs[j1].IsWinner = true;
                    XOs[j2].IsWinner = true;

                    return XOs[j0].Value;
                }
            }
            return null;
        }

    }
}