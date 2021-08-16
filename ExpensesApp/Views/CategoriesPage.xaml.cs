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
    public partial class CategoriesPage : ContentPage
    {
        CategoriesPageViewModel _categoriesPageViewModel = new CategoriesPageViewModel();

        public CategoriesPage()
        {
            InitializeComponent();

            _categoriesPageViewModel = Resources["vm"] as CategoriesPageViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _categoriesPageViewModel.GetExpensesPerCategory();
        }
    }
}