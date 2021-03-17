using AppXamarin3.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppXamarin3
{
    public partial class MainPage : ContentPage
    {

        public int seachedVal;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OpenEnregistrerUser(Object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new EnregistrerUtilisateur());
        }

        private async void OpenCalculatrice(Object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new Calculatirce());
        }

        private async void VerifierValue(Object sender, EventArgs e)
        {
            const string msgVerifier = "verifier";
            if (btnVerifier.Text.Equals(msgVerifier))
            {
                int value;
                int.TryParse(valueSearch.Text, out value);
                string resultMsg = "";
                if (value > seachedVal)
                {
                    resultMsg = "plus petit";
                    result.BackgroundColor = Color.Red;
                }
                else if (value < seachedVal)
                {
                    resultMsg = "plus grand";
                    result.BackgroundColor = Color.Red;
                }
                else
                {
                    btnVerifier.Text = "rejouer";
                    resultMsg = "gagner ! un nouveau chiffre est génré aléatoirement entre 1 et 100. ";
                    result.BackgroundColor = Color.Green;
                }
                result.TextColor = Color.White;
                result.Text = resultMsg;
            }
            else {
                initValueSearched();
                result.TextColor = Color.Black;
                result.BackgroundColor = Color.White;
                result.Text = "C'est partie nouvelle partie";
                btnVerifier.Text = msgVerifier;
            }
        }

        public void SetWelcomeMessage() {
            if (Application.Current.Properties.ContainsKey("username"))
            {
                string myUser = Application.Current.Properties["username"] as string;
                welcomeMessage.Text = "Bienvenue dans l'application, " + myUser;
            }
            else {
                welcomeMessage.Text = "Bienvenue dans l'application,utilisateur non enregistré ";
            }
        }

        protected override void OnAppearing()
        {
            initValueSearched();
            SetWelcomeMessage();
        }

        public void initValueSearched() {
            Random rnd = new Random();
            seachedVal = rnd.Next(1, 101);
        }
    }
}
