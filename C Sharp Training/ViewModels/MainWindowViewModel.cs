using C_Sharp_Training.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Training.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Properties
        #endregion

        #region ReactiveCommands
        public ReactiveCommand<Unit, Unit> SearchProductCommand { get; protected set; } // For Search button
        #endregion

        #region Constructors
        public MainWindowViewModel()
        {
            SearchProductCommand = ReactiveCommand.Create(() => { });
        }
        #endregion

        #region Methods
        #endregion

    }
}
