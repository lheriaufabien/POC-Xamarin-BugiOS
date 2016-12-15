using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace App5
{
    public class MainPage : ContentPage
    {
        Label labelCurrent;
        Label labelLast;

        public MainPage()
        {
            Title = "AppPOC BugiOS (NewPage)";
            BackgroundColor = Color.White;

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
                            this.Title = "AppPOC BugiOS";
                            labelCurrent.Text = "CurrentPage : " + App.NavPage.CurrentPage.GetType().ToString();
                            labelLast.Text = "NavigationStack : \n";
                            foreach (var item in Navigation.NavigationStack)
                            {
                                labelLast.Text += item.GetType().ToString() + "\n";
                            }                            
                        })
                    },
                    new Button
                    {
                        Text = "Next Page",
                        Command = new Command(() =>
                        {
                            this.Title = "AppPOC BugiOS";
                            Navigation.PushAsync(new SecondPage());
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
