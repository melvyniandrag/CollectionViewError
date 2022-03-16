using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CollectionViewTest
{
    public partial class MainPage : ContentPage
    {
        public static ObservableCollection<Int16> MyObjects{get; set;}
        public MainPage()
        {
            InitializeComponent();
            MyObjects = new ObservableCollection<short>(); // Just a random observable collection.
            MyCollection.ItemsSource = MyObjects;
            MyObjects.Add(100);
            MyObjects.Add(100);
            MyObjects.Add(100);
        }

        // NOTE: If you comment out this layout changing code, then
        // we can change device orientation. Try it!
        // Comment out all the following stuff and recompile.
        // Then change device orientation. The app does not crash.
        // Put this logic back and recompile - then the app crashes on
        // change of orientation.
        
        private double width;
        private double height;

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width != this.width || height != this.height)
            {
                this.width = width;
                this.height = height;
                if (width > height)
                {
                    innerGrid.RowDefinitions.Clear();
                    innerGrid.ColumnDefinitions.Clear();
                    innerGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    innerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    innerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    innerGrid.Children.Remove(MyCollection);
                    innerGrid.Children.Add(MyCollection, 1, 0);
                }
                else
                {
                    innerGrid.RowDefinitions.Clear();
                    innerGrid.ColumnDefinitions.Clear();
                    innerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    innerGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                    innerGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    innerGrid.Children.Remove(MyCollection);
                    innerGrid.Children.Add(MyCollection, 0, 1);
                }
            }
        }
        
    }
}
