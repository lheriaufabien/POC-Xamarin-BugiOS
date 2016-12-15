using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace App5
{
    public class ThirdPage : ContentPage
    {
        Label labelCurrent;
        Label labelLast;

        public ThirdPage()
        {
            Title = "Third Page(NewPage)";
            labelCurrent = new Label
            {
                Text = "",
                TextColor = Color.Black
            };

            labelLast = new Label
            {
                Text = "",
                TextColor = Color.Black
            };

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                    new Button
                    {                        
                        Text = "Show Current and Last Page",
                        Command = new Command(() =>
                        {
                            this.Title = "Third Page";
                            labelCurrent.Text = "CurrentPage : " + App.NavPage.CurrentPage.GetType().ToString();
                            labelLast.Text = "NavigationStack : \n";
                            foreach (var item in Navigation.NavigationStack)
                            {
                                labelLast.Text += item.GetType().ToString() + "\n";
                            }
                        })
                    },
                    labelCurrent, labelLast
                }
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            labelCurrent.Text = "";
            labelLast.Text = "";

        }
    }
}
