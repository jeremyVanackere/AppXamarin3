using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;
using Xamarin.Forms.Xaml;

namespace AppXamarin3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Calculatirce : ContentPage
    {
        string operation = null;
        string lastValue = null;
        string actuelValue = "";
        List<string> historiqueList = new List<string>();
        public Calculatirce()
        {
            InitializeComponent();
        }

        public void TouchNumber(Object sender, EventArgs e) {
            Button btnNumber = sender as Button;
            val.Text += btnNumber.Text;
            actuelValue += btnNumber.Text;
        }

        public void TouchOperation(Object sender, EventArgs e) {
            if (null != operation) {
                return;
            }
            Button btnOperation = sender as Button;
            operation = btnOperation.Text;
            lastValue = val.Text;
            val.Text = lastValue + " " + operation + " \n";
            actuelValue = "";
        }

        public void showHistorique()
        {
            string result = "";
            historiqueList.ForEach(histo => result += histo + " \n");
            historique.Text = result;
        }

        public void Calculate(Object sender, EventArgs e) {
            if (null == operation || null == lastValue) {
                return;
            }
            double result = 0;
            double val1;
            double.TryParse(lastValue, out val1);
            double val2;
            double.TryParse(actuelValue, out val2);
            switch (operation)
            {
                case "+":
                    result = val1 + val2;
                    break;
                case "-":
                    result = val1 - val2;
                    break;
                case "x":
                    result = val1 * val2;
                    break;
                case "/":
                    result = val1 / val2;
                    break;
            }
            val.Text = "" + result;
            actuelValue = "" + result;
            operation = null;
            lastValue = null;
            if (historiqueList.Count >= 3) {
                historiqueList.RemoveAt(0);
            }
            historiqueList.Add("" + result);
            showHistorique();
        }

        public void removeOperation(Object sender, EventArgs e) { 
            if (null == operation || null == lastValue)
            {
                return;
            }

            actuelValue = lastValue;
            val.Text = actuelValue;
            operation = null;
            lastValue = null;
        }

        public void removeAll(Object sender, EventArgs e)
        {
            actuelValue = "";
            val.Text = actuelValue;
            operation = null;
            lastValue = null;
        }
    }
}