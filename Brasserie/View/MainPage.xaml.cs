using Brasserie.Model;
using Brasserie.Model.Restaurant.Catering;
using Brasserie.Model.Restaurant.People;
using System.Collections.ObjectModel;

namespace Brasserie.View
{
    public partial class MainPage : ContentPage
    {
        Counter myCounter;

        public MainPage()
        {
            InitializeComponent();
            myCounter = new Counter();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {

            myCounter.IncrementCounter();


            EntryCount.Text = myCounter.CounterValue.ToString();
            //texte de la case de clics ↓↓↓
            CounterBtn.Text = "Nombre de Clics :" + myCounter.CounterValue.ToString();

            //SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void buttonTestCreateFirstPersons_Clicked(object sender, EventArgs e)
        {
            Person firstPerson = new Person(id: 1, lastName: "Beumier", firstName: "Damien", gender: true, email: "dambeumier@gmail.com", mobilePhoneNumber: "0489142293");
            Person secondPerson = new Person(id: 2, lastName: "Deroisin", firstName: "Sophie", gender: false, email: "sophiederoisin@gmail.com", mobilePhoneNumber: "0473121314");
            Person thirdPerson = new Person(3, "Jandrin", "Marc", true, "jandrinmarc@gmail.com", mobilePhoneNumber: "0485556678");
            Person fourthPerson = new Person(4, "Lupant", "Sebasien");
            Person fifthPerson = new Person();

            //petit ajout perso (réaction au click sur bouton)
            lblDebug.Text = "Personnes Crées";

            //Person p;
            //p = new Person(6, "Tardif", "Jean");


        } //end buttonTestCreateFirstPersons_Clicked


        private void buttonTestEncapsulation_Clicked(object sender, EventArgs e)
        {
            Person p = new Person(id: 2, lastName: "Deroisin", firstName: "Sophie", gender: false, email: "sophiederoisin@gmail.com", mobilePhoneNumber: "0473121314");
            p.FirstName = "Marie-Sophie";
            lblDebug.Text = p.FirstName;

        }

        private void buttonTestStatic_Clicked(object sender, EventArgs e)
        {
            string mail = "monmail@gmail.com";
            bool testMail = Person.CheckEMail(mail);
            //lblDebug.Text = $" résultat du test de validité du mail {mail} : { testMail.ToString()} ";
            lblDebug.Text = $"Nombres d'instances de classe Person : {Person.TotalPersons}";

        }

        private void buttonTestCreateItem_Clicked(object sender, EventArgs e)
        {
            Item trucComestible = new Item("chose", "c'est comestible", 1, 1.70, 6.50, "comestible.jpg");
            Item trucBuvable = new Item("machin", "bois", 2, 1.78, 6.47, "buvable.gif");

            //petit ajout perso (réaction au click sur bouton)
            lblDebug.Text = "Item Crées";
        }


        private void ButtonTestCateringClasses_Clicked(object sender, EventArgs e)
        {
            Item trucComestible = new Item("chose", "c'est comestible", 1, 1.70, 6.50, "comestible.jpg");
            Drink UnDemiBelge = new Drink("Une50", "Un demi mais façon belge", 1, 50, 4.81, 6.07, "UnDemiBelge.jpg");
            Dish CarbonnadeAuFaro = new Dish("Carbonnade Au Faro", "Carbonnade Sauce Faro , un délice !", 1, 10.45, 6.14, "unebonnecarbonnadefieu.jpg");
            Soft RomanCola = new Soft("Roman Cola", "Cola Made in Belgium", 1, 33.45, 2.14, 6.12, "UnbonverredeRomanColaGlacé.png");
            Alcohol EauDeVillee = new Alcohol("Eau de Villée", "Eau de vie de Biercée ", 1, 6.15, 31.25, 7.14, 21.45, "eaudeVillée.jpg");
            Aperitif MojitoRoyal = new Aperitif("Mojito Royal", "Cocktail Mojito avec ajout de Champagne", 1, 45.12, 21.78, 10.21, 21.14, "mojitoroyal.png ");
            Beer Orval = new Beer("Orval", "Biere trappiste Orval", 1, 25.11, 8.01, false, true, 5.45, 21.14, "Unbonverredorval.jpg");

            lblDebug.Text = "instanciation des 7 classes faites ! ";
        }


        public void ButtonTestCollection_Clicked(object sender, EventArgs e)
        {
            StaffMember staffm1 = new StaffMember(10, "Vandenberg", "Caroline", true, "carovan@gmail.com", "0476893029", "BE81 7345 1290 1038", "10, rue del'eglise 7030 Ghlin", 3050.0);
            StaffMember staffm2 = new StaffMember(11, "Dries", "Francois", true, "francoisdries@gmail.com", "0485113289", "BE83 2378 9876 2390", "130, rue debinche 7030 Ghlin", 3275.0);
            Manager m = new Manager(12, "Legars", "Flavien", true, "legafla@gmail.com", "0482426671", "BE83 4435 1893 1450", "5, rue de la cle 7000Mons", 5500.0, "Password01");
            ObservableCollection<StaffMember> staffmCol = new ObservableCollection<StaffMember>();
            staffmCol.Add(staffm1);
            staffmCol.Add(staffm2);
            staffmCol.Add(m);
            string s = $"nombre d'éléments dans la collection : {staffmCol.Count}";
            foreach (StaffMember sm in staffmCol)
            {
                s += $"\n{sm.FirstName} {sm.LastName} : {sm.GetType().ToString()}";
            }
            lblDebug.Text = s;
        }
    }



}
