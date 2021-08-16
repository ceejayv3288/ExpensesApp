using ExpensesApp.Models;
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
    public partial class ExpenseDetailsPage : ContentPage
    {
        ExpenseDetailsPageViewModel _expenseDetailsPageViewModel = new ExpenseDetailsPageViewModel();

        public ExpenseDetailsPage(Expense expense)
        {
            InitializeComponent();

            _expenseDetailsPageViewModel = Resources["vm"] as ExpenseDetailsPageViewModel;
            _expenseDetailsPageViewModel.Expense = expense;
        }
    }
}