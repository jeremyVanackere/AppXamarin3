using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppXamarin3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnregistrerUtilisateur : ContentPage
    {
        public EnregistrerUtilisateur()
        {
            InitializeComponent();
        }

        public async void EnregisterUser(object sender, EventArgs args)
        {
            Application.Current.Properties["username"] = this.prenom.Text;
            this.Navigation.PopAsync();
        }
    }
}