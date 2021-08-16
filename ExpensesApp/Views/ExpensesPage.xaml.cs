using ExpensesApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpensesPage : ContentPage
    {
        ExpensesPageViewModel _expensesPageViewModel = new ExpensesPageViewModel();

        public ExpensesPage()
        {
            InitializeComponent();

            _expensesPageViewModel = Resources["vm"] as ExpensesPageViewModel;
            //BindingContext = _expensesPageViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _expensesPageViewModel.GetExpenses();

            //(this.BindingContext as ExpensesPageViewModel).GetExpenses();

            //_expensesPageViewModel.GetExpenses();
        }
    }
}