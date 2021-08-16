using ExpensesApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ExpensesApp.ViewModels
{
    public class ExpenseDetailsPageViewModel : BaseViewModel
    {
        public Expense expense;
        public Expense Expense
        {
            get { return expense; }
            set
            {
                expense = value;
                OnPropertyChanged("Expense");
            }
        }

        public ExpenseDetailsPageViewModel()
        {

        }
    }
}
