using C_Sharp_Training.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace C_Sharp_Training.Views
{
    public class BaseView<T> : Window, IViewFor<BaseViewModel>
        where T : BaseViewModel, new()
    {
        public static T viewModel { set; get; } = new T();
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register("ViewModel", typeof(T), typeof(BaseView<T>));

        public BaseViewModel ViewModel
        {
            get => GetValue(ViewModelProperty) as T;
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = value as BaseViewModel;
        }
    }
}
