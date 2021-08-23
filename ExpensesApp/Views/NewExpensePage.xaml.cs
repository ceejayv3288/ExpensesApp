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
    public partial class NewExpensePage : ContentPage
    {
        NewExpensePageViewModel _newExpensePageViewModel = new NewExpensePageViewModel();

        public NewExpensePage()
        {
            InitializeComponent();

            _newExpensePageViewModel = Resources["vm"] as NewExpensePageViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //_newExpensePageViewModel.GetExpenseStatus();

            int count = 0;
            foreach (var es in _newExpensePageViewModel.ExpenseStatuses)
            {
                var cell = new SwitchCell { Text = es.Name };

                Binding binding = new Binding();
                binding.Source = _newExpensePageViewModel.ExpenseStatuses[count];
                binding.Path = "Status";
                binding.Mode = BindingMode.TwoWay;
                cell.SetBinding(SwitchCell.OnProperty, binding);

                var section = new TableSection("Statuses");
                section.Add(cell);
                expenseTableView.Root.Add(section);

                count++;
            }
        }
    }
}