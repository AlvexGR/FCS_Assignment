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
    /// Interaction logic for SearchProductDialog.xaml
    /// </summary>
    public partial class SearchProductDialog : Window, IViewFor<SearchProductDialogViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register("ViewModel", typeof(SearchProductDialogViewModel), typeof(SearchProductDialog));
        public SearchProductDialogViewModel ViewModel
        {
            get => GetValue(ViewModelProperty) as SearchProductDialogViewModel;
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = value as SearchProductDialogViewModel;
        }
        public SearchProductDialog()
        {
            InitializeComponent();
            ViewModel = new SearchProductDialogViewModel();
            
            this.WhenActivated(d =>
            {
                // Binds
                d(this.Bind(ViewModel, vm => vm.Barcode, v => v.tbxBarcode.Text));
                d(this.Bind(ViewModel, vm => vm.SupplierCode, v => v.tbxSupplierCode.Text));
                d(this.Bind(ViewModel, vm => vm.Name, v => v.tbxName.Text));
                d(this.Bind(ViewModel, vm => vm.CategorySelected, v => v.cbxCategory.SelectedValue));
                d(this.Bind(ViewModel, vm => vm.SupplierSelected, v => v.cbxSupplier.SelectedValue));
                
                // OneWaybinds
                d(this.OneWayBind(ViewModel, vm => vm.ProductDetail, v => v.dgProduct.ItemsSource));
                d(this.OneWayBind(ViewModel, vm => vm.Suppliers, v => v.cbxSupplier.ItemsSource));
                d(this.OneWayBind(ViewModel, vm => vm.Categories, v => v.cbxCategory.ItemsSource));

                // BindCommands
                d(this.BindCommand(ViewModel, vm => vm.CloseCommand, v => v.btnCancel));
                d(this.BindCommand(ViewModel, vm => vm.CloseCommand, v => v.btnClose));
                d(this.BindCommand(ViewModel, vm => vm.SearchCommand, v => v.btnSearch));

                //Execute Commands
                d(ViewModel.CloseCommand.Subscribe(x => { Close(); }));

                // Observables
                d(this.WhenAnyValue(v => v.ViewModel.ProductDetail)
                    .Subscribe(x =>
                    {
                        List<string> lst = new List<string>() { "Name", "Barcode", "PriceUnit" };
                        for (int i = dgProduct.Columns.Count - 1; i >= 0; i--)
                        {
                            if (!lst.Contains(dgProduct.Columns[i].Header))
                            {
                                dgProduct.Columns.RemoveAt(i);
                            }
                        }
                    }));
                
            });
            cbxCategory.DisplayMemberPath = "Name";
            cbxCategory.SelectedValuePath = "Id";
            cbxSupplier.DisplayMemberPath = "Name";
            cbxSupplier.SelectedValuePath = "Id";
        }
    }
}
