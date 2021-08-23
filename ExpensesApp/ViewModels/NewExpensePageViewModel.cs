using ExpensesApp.Helpers;
using ExpensesApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class NewExpensePageViewModel : BaseViewModel
    {
        #region Properties
        public string expenseName;
        public string ExpenseName 
        { 
            get { return expenseName; }
            set 
            {
                expenseName = value;
                OnPropertyChanged("ExpenseName");
            }
        }
        public string expenseDescription;
        public string ExpenseDescription
        {
            get { return expenseDescription; }
            set
            {
                expenseDescription = value;
                OnPropertyChanged("ExpenseDescription");
            }
        }
        public float expenseAmount;
        public float ExpenseAmount
        {
            get { return expenseAmount; }
            set
            {
                expenseAmount = value;
                OnPropertyChanged("ExpenseAmount");
            }
        }
        public DateTime expenseDate;
        public DateTime ExpenseDate
        {
            get { return expenseDate; }
            set
            {
                expenseDate = value;
                OnPropertyChanged("ExpenseDate");
            }
        }
        public string expenseCategory;
        public string ExpenseCategory
        {
            get { return expenseCategory; }
            set
            {
                expenseCategory = value;
                OnPropertyChanged("ExpenseCategory");
            }
        }
        public ObservableCollection<string> categories;
        public ObservableCollection<string> Categories
        {
            get { return categories; }
            set
            {
                categories = value;
                OnPropertyChanged("Categories");
            }
        }
        public ObservableCollection<ExpenseStatus> expenseStatuses;
        public ObservableCollection<ExpenseStatus> ExpenseStatuses
        {
            get { return expenseStatuses; }
            set
            {
                expenseStatuses = value;
                OnPropertyChanged("ExpenseStatuses");
            }
        }

        public Command SaveExpenseCommand { get; set; }
        #endregion

        public NewExpensePageViewModel()
        {
            ExpenseDate = DateTime.Today;
            SaveExpenseCommand = new Command(SaveExpense);
            Categories = new ObservableCollection<string>();
            ExpenseStatuses = new ObservableCollection<ExpenseStatus>();
            GetCategories();
        }

        public void SaveExpense()
        {
            try
            {
                //throw (new Exception("Sample error report"));

                Expense expense = new Expense()
                {
                    Name = ExpenseName,
                    Amount = ExpenseAmount,
                    Category = ExpenseCategory,
                    Date = ExpenseDate,
                    Description = ExpenseDescription
                };

                int response = Expense.InsertExpenses(expense);
                if (response > 0)
                {
                    Application.Current.MainPage.Navigation.PopAsync();

                    var properties = new Dictionary<string, string>
                    {
                        {"New Expenses Page", "Save Expense Command"}
                    };
                    AppCenterHelpers.TrackEvent("Expenses Saved", properties);
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Error", "No items were inserted", "Ok");

                    var properties = new Dictionary<string, string>
                    {
                        {"New Expenses Page", "Save Expense Command"}
                    };
                    AppCenterHelpers.TrackEvent("No Expenses Saved", properties);
                }
            }
            catch (Exception ex)
            {
                var properties = new Dictionary<string, string>
                {
                    {"New Expenses Page", "Save Expense Command"}
                };
                AppCenterHelpers.TrackError(ex, properties);
            }
        }
        private void GetCategories()
        {
            Categories.Clear();
            Categories.Add("Housing");
            Categories.Add("Debt");
            Categories.Add("Health");
            Categories.Add("Food");
            Categories.Add("Personal");
            Categories.Add("Travel");
            Categories.Add("Other");
        }

        public void GetExpenseStatus()
        {
            ExpenseStatuses.Clear();
            ExpenseStatuses.Add(new ExpenseStatus() 
            {
                Name = "Random",
                Status = true
            });
            ExpenseStatuses.Add(new ExpenseStatus()
            {
                Name = "Random 2",
                Status = true
            });
            ExpenseStatuses.Add(new ExpenseStatus()
            {
                Name = "Random 3",
                Status = true
            });
        }

        public class ExpenseStatus
        {
            public string Name { get; set; }
            public bool Status { get; set; }
        }
    }
}
