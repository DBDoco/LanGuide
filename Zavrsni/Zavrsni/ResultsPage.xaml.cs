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
    public partial class ResultsPage : ContentPage
    {
        public ResultsPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var results = await Result.GetResults();
            resultListView.ItemsSource = results;
        }

        private async void searchID_SearchButtonPressed(object sender, EventArgs e)
        {
            var keyword = searchID.Text;
            var results = await Result.GetResults();
            resultListView.ItemsSource = results.Where(result => result.id_user.ToLower().StartsWith(keyword.ToLower()));
        }

        private async void searchExerciseID_SearchButtonPressed(object sender, EventArgs e)
        {
            var keyword = searchExerciseID.Text;
            var results = await Result.GetResults();
            resultListView.ItemsSource = results.Where(result => result.id_exercise.ToLower().StartsWith(keyword.ToLower()));
        }

        private async void searchResultPercent_SearchButtonPressed(object sender, EventArgs e)
        {
            var keyword = searchResultPercent.Text;
            var results = await Result.GetResults();
            resultListView.ItemsSource = results.Where(result => result.result_percent.ToLower().StartsWith(keyword.ToLower()));
        }

        private async void searchResultScore_SearchButtonPressed(object sender, EventArgs e)
        {
            var keyword = searchResultScore.Text;
            var results = await Result.GetResults();
            resultListView.ItemsSource = results.Where(result => result.result_score.ToLower().StartsWith(keyword.ToLower()));
        }

        private async void searchResultMax_SearchButtonPressed(object sender, EventArgs e)
        {
            var keyword = searchResultMax.Text;
            var results = await Result.GetResults();
            resultListView.ItemsSource = results.Where(result => result.result_max.ToLower().StartsWith(keyword.ToLower()));
        }

        private async void searchSkill_SearchButtonPressed(object sender, EventArgs e)
        {
            var keyword = searchSkill.Text;
            var results = await Result.GetResults();
            resultListView.ItemsSource = results.Where(result => result.skill.ToLower().Contains(keyword.ToLower()));
        }

        private async void searchLanguage_SearchButtonPressed(object sender, EventArgs e)
        {
            var keyword = searchLanguage.Text;
            var results = await Result.GetResults();
            resultListView.ItemsSource = results.Where(result => result.language.ToLower().Contains(keyword.ToLower()));
        }
    }
}