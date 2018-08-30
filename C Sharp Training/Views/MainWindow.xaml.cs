using C_Sharp_Training.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IViewFor<MainWindowViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register("ViewModel", typeof(MainWindowViewModel), typeof(MainWindow));
        public MainWindowViewModel ViewModel
        {
            get => GetValue(ViewModelProperty) as MainWindowViewModel;
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = value as MainWindowViewModel;
        }

        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new MainWindowViewModel();

            this.WhenActivated(d =>
            {
                d(this.BindCommand(ViewModel, vm => vm.SearchProductCommand, v => v.btnSearchProduct));
                d(ViewModel.SearchProductCommand.Subscribe(x =>
                {
                    Hide();
                    SearchProductDialog spd = new SearchProductDialog();
                    spd.ShowDialog();
                    Show();
                }));
            });
        }
    }
}
