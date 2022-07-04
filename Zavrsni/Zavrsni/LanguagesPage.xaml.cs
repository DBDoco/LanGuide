using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zavrsni.Model;

namespace Zavrsni
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LanguagesPage : ContentPage
    {
        public LanguagesPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var languages = await Result.GetResults();
            languageListView.ItemsSource = languages.GroupBy(x => x.language).Select(x => x.First());
        }
    }


}