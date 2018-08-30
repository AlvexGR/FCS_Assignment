using C_Sharp_Training.DataAccess;
using C_Sharp_Training.Models;
using ReactiveUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Training.ViewModels
{
    public class SearchProductDialogViewModel : BaseViewModel
    {
        #region Properties
        private string barcode;
        private string supplierCode;
        private string name;
        private object supplierSelected;
        private object categorySelected;

        private List<Category> categories;
        private List<Supplier> suppliers;
        private List<Product> productDetail;
        #endregion

        #region ReactiveCommands
        public ReactiveCommand<Unit, Unit> CloseCommand { get; protected set; } // For Close and Cancel button
        public ReactiveCommand<Unit, Unit> SearchCommand { get; protected set; } // For Search button
        public ReactiveCommand<Unit, Unit> SearchProductCommand { get; protected set; } // For SearchProduct button
        #endregion

        #region Setters and Getters
        public string Barcode { get => barcode; set { this.RaiseAndSetIfChanged(ref barcode, value); } }
        public string SupplierCode { get => supplierCode; set { this.RaiseAndSetIfChanged(ref supplierCode, value); } }
        public string Name { get => name; set { this.RaiseAndSetIfChanged(ref name, value); } }
        public object SupplierSelected { get => supplierSelected; set { this.RaiseAndSetIfChanged(ref supplierSelected, value); } }
        public object CategorySelected { get => categorySelected; set { this.RaiseAndSetIfChanged(ref categorySelected, value); } }
        public List<Product> ProductDetail { get => productDetail; set { this.RaiseAndSetIfChanged(ref productDetail, value); } }
        public List<Category> Categories { get => categories; set { this.RaiseAndSetIfChanged(ref categories, value); } }
        public List<Supplier> Suppliers { get => suppliers; set { this.RaiseAndSetIfChanged(ref suppliers, value); } }
        #endregion

        #region Constructors
        public SearchProductDialogViewModel()
        {
            // Init Lists
            ProductDetail = ProductDataAccess.GetFirst50Product();
            Categories = CategoryDataAccess.GetAll();
            Suppliers = SupplierDataAccess.GetAll();

            // Init Commands
            CloseCommand = ReactiveCommand.Create(() => { });
            SearchCommand = ReactiveCommand.Create(Search);
            SearchProductCommand = ReactiveCommand.Create(() => { });
        }
        #endregion

        #region Methods
        public void Search()
        {
            ProductDetail = ProductDataAccess.GetProduct(Barcode, SupplierCode, Name, Convert.ToInt32(SupplierSelected), Convert.ToInt32(CategorySelected));
        }
        #endregion
    }
}
