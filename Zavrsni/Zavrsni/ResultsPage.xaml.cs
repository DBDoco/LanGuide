using System;
using System.Collections.Generic;
using System.Globalization;
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

        private async void searchID_TextChanged(object sender, EventArgs e)
        {
            var keyword = searchID.Text;
            var results = await Result.GetResults();
            if (keyword == "")
                resultListView.ItemsSource = results;
            else
                resultListView.ItemsSource = from x in results
                                         where x.id_user == Int16.Parse(keyword)
                                         select x;
        }

        public async void searchExerciseID_TextChanged(object sender, EventArgs e)
        {
            var keyword = searchExerciseID.Text;
            var results = await Result.GetResults();
            if (keyword == "")
                resultListView.ItemsSource = results;
            else
                resultListView.ItemsSource = results.Where(result => result.id_exercise.ToLower().StartsWith(keyword.ToLower()));
        }


        private async void searchSkill_TextChanged(object sender, EventArgs e)
        {
            var keyword = searchSkill.Text;
            var results = await Result.GetResults();
            if (keyword == "")
                resultListView.ItemsSource = results;
            else
                resultListView.ItemsSource = results.Where(result => result.skill.ToLower().Contains(keyword.ToLower()));
        }


        private async void searchLanguage_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = searchLanguage.Text;
            var results = await Result.GetResults();
            if (keyword == "")
                resultListView.ItemsSource = results;
            else
                resultListView.ItemsSource = results.Where(result => result.language.ToLower().Contains(keyword.ToLower()));
        }   

        private async void ImageButton_Pressed(object sender, EventArgs e)
        {
            base.OnAppearing();
            var results = await Result.GetResults();
            resultListView.ItemsSource = from result in results
                                         orderby result.id_user ascending
                                         select result;
        }

        private async void ImageButton_Pressed_1(object sender, EventArgs e)
        {
            base.OnAppearing();
            var results = await Result.GetResults();
            resultListView.ItemsSource = results.OrderBy(result => result.create_time);
        }

        private async void ImageButton_Pressed_2(object sender, EventArgs e)
        {
            base.OnAppearing();
            var results = await Result.GetResults();
            resultListView.ItemsSource = results.OrderBy(result => result.id_exercise);
        }

        private async void ImageButton_Pressed_3(object sender, EventArgs e)
        {
            base.OnAppearing();
            var results = await Result.GetResults();
            resultListView.ItemsSource = from result in results
                                         orderby result.result_percent ascending
                                         select result;
        }

        private async void ImageButton_Pressed_4(object sender, EventArgs e)
        {
            base.OnAppearing();
            var results = await Result.GetResults();
            resultListView.ItemsSource = from result in results
                                         orderby result.result_score ascending
                                         select result;
        }

        private async void ImageButton_Pressed_5(object sender, EventArgs e)
        {
            base.OnAppearing();
            var results = await Result.GetResults();
            resultListView.ItemsSource = from result in results
                                         orderby result.result_max ascending
                                         select result;
        }

        private async void ImageButton_Pressed_6(object sender, EventArgs e)
        {
            base.OnAppearing();
            var results = await Result.GetResults();
            resultListView.ItemsSource = results.OrderBy(result => result.skill);
        }

        private async void ImageButton_Pressed_7(object sender, EventArgs e)
        {
            base.OnAppearing();
            var results = await Result.GetResults();
            resultListView.ItemsSource = results.OrderBy(result => result.language);
        }

        private async void ImageButton_Pressed_8(object sender, EventArgs e)
        {
            base.OnAppearing();
            var results = await Result.GetResults();
            resultListView.ItemsSource = results.OrderBy(result => result.result_date);
        }

        private async void resultPercentMax_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = resultPercentMax.Text;
            base.OnAppearing();
            var results = await Result.GetResults();
            if (keyword == "")
                resultListView.ItemsSource = results;
            else
                resultListView.ItemsSource = from result in results
                                             where result.result_percent <= Int16.Parse(keyword)
                                             select result;
        }

        private async void resultPercentMin_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = resultPercentMin.Text;
            base.OnAppearing();
            var results = await Result.GetResults();
            if (keyword == "")
                resultListView.ItemsSource = results;
            else
                resultListView.ItemsSource = from result in results
                                             where result.result_percent >= Int16.Parse(keyword)
                                             select result;
        }

        private async void resultScoreMax_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = resultScoreMax.Text;
            base.OnAppearing();
            var results = await Result.GetResults();
            if (keyword == "")
                resultListView.ItemsSource = results;
            else
                resultListView.ItemsSource = from result in results
                                             where result.result_score <= Int16.Parse(keyword)
                                             select result;
        }

        private async void resultScoreMin_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = resultScoreMin.Text;
            base.OnAppearing();
            var results = await Result.GetResults();
            if (keyword == "")
                resultListView.ItemsSource = results;
            else
                resultListView.ItemsSource = from result in results
                                             where result.result_score >= Int16.Parse(keyword)
                                             select result;
        }

        private async void scoreMax_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = scoreMax.Text;
            base.OnAppearing();
            var results = await Result.GetResults();
            if (keyword == "")
                resultListView.ItemsSource = results;
            else
                resultListView.ItemsSource = from result in results
                                             where result.result_max <= Int16.Parse(keyword)
                                             select result;
        }

        private async void scoreMin_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = scoreMin.Text;
            base.OnAppearing();
            var results = await Result.GetResults();
            if (keyword == "")
                resultListView.ItemsSource = results;
            else
                resultListView.ItemsSource = from result in results
                                             where result.result_max >= Int16.Parse(keyword)
                                             select result;
        }

    }
}