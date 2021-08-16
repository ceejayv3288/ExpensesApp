using ExpensesApp.Models;
using ExpensesApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ExpensesApp.Behaviors
{
    public class ListViewbehavior : Behavior<ListView>
    {
        ListView listview;
        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);

            listview = bindable;
            listview.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Expense selectedExpense = listview.SelectedItem as Expense;
            Application.Current.MainPage.Navigation.PushAsync(new ExpenseDetailsPage(selectedExpense));
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);
            listview.ItemSelected -= ListView_ItemSelected;
        }
    }
}
