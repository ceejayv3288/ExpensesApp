using ExpensesApp.Models;
using ExpensesApp.Views;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class ExpensesPageViewModel : BaseViewModel
    {
        public ObservableCollection<Expense> expenses;
        public ObservableCollection<Expense> Expenses
        {
            get { return expenses; }
            set
            {
                expenses = value;
                OnPropertyChanged("Expenses");
            }
        }
        public Command AddExpenseCommand { get; set; }

        public ExpensesPageViewModel()
        {
            Expenses = new ObservableCollection<Expense>();
            AddExpenseCommand = new Command(AddExpense);

            GetExpenses();
        }

        public void GetExpenses()
        {
            var expenses = Expense.GetExpenses();
            Expenses.Clear();

            foreach (var expense in expenses)
            {
                Expenses.Add(expense);
            }
        }

        public void AddExpense()
        {
            Application.Current.MainPage.Navigation.PushAsync(new NewExpensePage());
        }
    }
}
