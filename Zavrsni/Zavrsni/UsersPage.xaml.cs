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
    public partial class UsersPage : ContentPage
    {
        public UsersPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var users = await User.GetUsers();
            userListView.ItemsSource = users;
        }

        protected async void SearchBar_TextChanged(object sender, EventArgs e)
        {
            var keyword = searchID.Text;
            var users = await User.GetUsers();
            if (keyword == "")
                userListView.ItemsSource = users;
            int y = 0;
            if (Int32.TryParse(keyword, out y))
            {
                userListView.ItemsSource = from user in users
                                           where user.id_user == Int32.Parse(keyword)
                                           select user;
            }
            else
                return;
        }

        private async void ImageButton_Pressed(object sender, EventArgs e)
        {
            base.OnAppearing();
            var users = await User.GetUsers();
            userListView.ItemsSource = from user in users
                                         orderby user.id_user ascending
                                         select user;
        }

        private async void ImageButton_Pressed_2(object sender, EventArgs e)
        {
            base.OnAppearing();
            var users = await User.GetUsers();
            userListView.ItemsSource = users.OrderBy(user => user.create_time);
        }
    }
}