using C_Sharp_Training.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace C_Sharp_Training.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window, IViewFor<LoginWindowViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register("ViewModel", typeof(LoginWindowViewModel), typeof(LoginWindow));
        public LoginWindowViewModel ViewModel
        {
            get => GetValue(ViewModelProperty) as LoginWindowViewModel;
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = value as LoginWindowViewModel;
        }

        public LoginWindow()
        {
            InitializeComponent();
            ViewModel = new LoginWindowViewModel();

            this.WhenActivated(d =>
            {
                // Bind the Pin with tbxPin
                d(this.OneWayBind(ViewModel, vm => vm.Pin, v => v.tbxPin.Text));

                // Bind the numpad
                d(this.BindCommand(ViewModel, vm => vm.RecieveInputCommand, v => v.btnOne, Observable.Return('1')));
                d(this.BindCommand(ViewModel, vm => vm.RecieveInputCommand, v => v.btnTwo, Observable.Return('2')));
                d(this.BindCommand(ViewModel, vm => vm.RecieveInputCommand, v => v.btnThree, Observable.Return('3')));
                d(this.BindCommand(ViewModel, vm => vm.RecieveInputCommand, v => v.btnFour, Observable.Return('4')));
                d(this.BindCommand(ViewModel, vm => vm.RecieveInputCommand, v => v.btnFive, Observable.Return('5')));
                d(this.BindCommand(ViewModel, vm => vm.RecieveInputCommand, v => v.btnSix, Observable.Return('6')));
                d(this.BindCommand(ViewModel, vm => vm.RecieveInputCommand, v => v.btnSeven, Observable.Return('7')));
                d(this.BindCommand(ViewModel, vm => vm.RecieveInputCommand, v => v.btnEight, Observable.Return('8')));
                d(this.BindCommand(ViewModel, vm => vm.RecieveInputCommand, v => v.btnNine, Observable.Return('9')));
                d(this.BindCommand(ViewModel, vm => vm.RecieveInputCommand, v => v.btnZero, Observable.Return('0')));
                // Bind the clear button
                d(this.BindCommand(ViewModel, vm => vm.ClearPinCommand, v => v.btnClear));

                // Validate the input pin
                d(this.WhenAnyObservable(v => v.ViewModel.ValidatePinCommand)
                    .Subscribe(x =>
                    {
                        if (x)
                        {
                            Hide(); // Hide the LoginWindowDialog
                            MainWindow mw = new MainWindow();
                            mw.ShowDialog(); // Open MainWindow
                            // Reaches here mean that the user close the MainWindow
                            Close(); // Close the Application
                        }
                    }));
            });
        }
    }
}
