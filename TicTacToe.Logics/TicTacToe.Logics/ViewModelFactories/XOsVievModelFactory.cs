using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Ioc;
using TicTacToe.Logics.Interfaces.ViewModel;
using TicTacToe.Logics.Interfaces.ViewModelFactories;

namespace TicTacToe.Logics.ViewModelFactories
{
    public class XOsVievModelFactory : IXOsVievModelFactory
    {
        private readonly Func<IXOsVievModel> _xOsVievModelFactory;

        public XOsVievModelFactory(Func<IXOsVievModel> xOsVievModelFactory)
        {
            _xOsVievModelFactory = xOsVievModelFactory;
        }

        public ObservableCollection<IXOsVievModel> CreateXoCollection()
        {
            var res = new ObservableCollection<IXOsVievModel>();
            for (int i = 0; i < 9; i++)
            {
                res.Add(_xOsVievModelFactory.Invoke());
            }

            return res;
        }
    }
}