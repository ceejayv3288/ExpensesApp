using ExpensesApp.Interfaces;
using ExpensesApp.Models;
//using PCLStorage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class CategoriesPageViewModel : BaseViewModel
    {
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

        public ObservableCollection<CategoryExpenses> categoryExpensesCollection;
        public ObservableCollection<CategoryExpenses> CategoryExpensesCollection
        {
            get { return categoryExpensesCollection; }
            set
            {
                categoryExpensesCollection = value;
                OnPropertyChanged("CategoryExpensesCollection");
            }
        }

        public Command ExportCommand { get; set; }

        public CategoriesPageViewModel()
        {
            Categories = new ObservableCollection<string>();
            CategoryExpensesCollection = new ObservableCollection<CategoryExpenses>();
            //ExportCommand = new Command(ShareReport);
            GetCategories();
            GetExpensesPerCategory();
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

        public void GetExpensesPerCategory()
        {
            CategoryExpensesCollection.Clear();
            float totalExpensesAmount = Expense.TotalExpensesAmount();
            foreach (var category in Categories)
            {
                var expenses = Expense.GetExpensesPerCategory(category);
                float expensesAmountInCategory = expenses.Sum(x => x.Amount);

                CategoryExpenses categoryExpenses = new CategoryExpenses()
                {
                    Category = category,
                    ExpensesPercentage = expensesAmountInCategory / totalExpensesAmount
                };

                CategoryExpensesCollection.Add(categoryExpenses);
            }
        }

        //public async void ShareReport()
        //{
        //    IFileSystem fileSystem = FileSystem.Current;
        //    IFolder rootFolder = fileSystem.LocalStorage;
        //    IFolder reportsFolder = await rootFolder.CreateFolderAsync("reports", CreationCollisionOption.OpenIfExists);

        //    var txtFile = await reportsFolder.CreateFileAsync("report.txt", CreationCollisionOption.ReplaceExisting);

        //    using (StreamWriter sw = new StreamWriter(txtFile.Path))
        //    {
        //        foreach (var ce in CategoryExpensesCollection)
        //        {
        //            sw.WriteLine($"{ce.Category} - {ce.ExpensesPercentage}");
        //        }
        //    }

        //    IShare shareDependency = DependencyService.Get<IShare>();
        //    await shareDependency.Show("Expense Report", "Here is your expense report", txtFile.Path);
        //}

        public class CategoryExpenses
        {
            public string Category { get; set; }
            public float ExpensesPercentage { get; set; }
        }
    }
}
