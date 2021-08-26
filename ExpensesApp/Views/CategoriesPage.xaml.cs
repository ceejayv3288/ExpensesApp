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

            SizeChanged += Categories_SizeChanged;
        }

        private void Categories_SizeChanged(object sender, EventArgs e)
        {
            string visualState = Width > Height ? "Landscape" : "Portrait";
            VisualStateManager.GoToState(titleLabel, visualState);
        }

        private void Button_Pressed(object sender, EventArgs e)
        {
            VisualStateManager.GoToState((Button)sender, "Focused");
        }

        private void Button_Released(object sender, EventArgs e)
        {
            VisualStateManager.GoToState((Button)sender, "Normal");
        }
    }
}