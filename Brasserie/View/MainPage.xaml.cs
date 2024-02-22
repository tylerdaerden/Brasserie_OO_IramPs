using Brasserie.Model;
using Brasserie.Model.Restaurant.Catering;
using Brasserie.Model.Restaurant.People;

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
            Person firstPerson = new Person(id: 1 , lastName: "Beumier" , firstName : "Damien" , gender: true, email:"dambeumier@gmail.com" , mobilePhoneNumber:"0489142293") ;
            Person secondPerson = new Person(id: 2, lastName: "Deroisin", firstName: "Sophie", gender: false, email: "sophiederoisin@gmail.com", mobilePhoneNumber: "0473121314");
            Person thirdPerson = new Person(3, "Jandrin", "Marc", true, "jandrinmarc@gmail.com", mobilePhoneNumber: "0485556678") ;
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
            Item trucComestible = new Item("chose" , "c'est comestible" , 1 , 1.70 , 6.50 , "comestible.jpg");
            Item trucBuvable = new Item("machin" , "bois" , 2 , 1.78 , 6.47 ,"buvable.gif" );

            //petit ajout perso (réaction au click sur bouton)
            lblDebug.Text = "Item Crées";
        }

        private void buttonTestCreateDrink_Clicked(object sender, EventArgs e)
        {
            Drink UnDemiBelge = new Drink("Une50" ,"Un demi mais façon belge" , 1 , 50 , 4.81 , 6.07 , "UnDemiBelge.jpg" );
            Drink UnDemiFrance = new Drink("UnDemi", "Un demi mais français soit 33cl", 2, 33, 8.78, 6.14, "UnDemiFrançais.png");

            //petit ajout perso (réaction au click sur bouton)
            lblDebug.Text = "Drink Crées";


        }

        private void buttonTestCreateDish_Clicked(object sender, EventArgs e)
        {
            Dish CarbonnadeAuFaro = new Dish("Carbonnade Au Faro" , "Carbonnade Sauce Faro , un délice !" , 1 , 10.45 , 6.14 , "unebonnecarbonnadefieu.jpg");

            lblDebug.Text = "Plat Crée";

        }

        private void ButtonTestCreateSoft_Clicked(object sender, EventArgs e)
        {
            Soft RomanCola = new Soft("Roman Cola" , "Cola Made in Belgium" , 1 , 33.45 , 2.14 , 6.12 , "UnbonverredeRomanColaGlacé.png");

            lblDebug.Text = "Soft Crée";

        }

        private void ButtonTestCreateAlcohol_Clicked(object sender, EventArgs e)
        {
            Alcohol EauDeVillee = new Alcohol("Eau de Villée" , "Eau de vie de Biercée " , 1 , 6.15 , 31.25 , 7.14 , 21.45 , "eaudeVillée.jpg" );
            Alcohol EauDeVilleeNA = new Alcohol("Eau de Villée Sans Alcool" , "Eau de vie de Biercée sans alcool , la fête est plus folle ? " , 2 , 6.15 , 0.00 , 6.54 , 6.14 , "Villéesansalcool.png"  );

            lblDebug.Text = "Alcool Crée (ne pas abuser hein ! ) ";

        }

        private void ButtonTestCreateAperitif_Clicked(object sender, EventArgs e)
        {
            Aperitif MojitoRoyal = new Aperitif("Mojito Royal" , "Cocktail Mojito avec ajout de Champagne" , 1 , 45.12 , 21.78 , 10.21 , 21.14 , "mojitoroyal.png ");
            Aperitif MojitoNA = new Aperitif("Mojito NA" , "Mojito Sans Alcool" , 2 , 50.14 , 0.00 , 9.21 , 6.14 ,"Unmojitopourlesbob.jpg" );

            lblDebug.Text = "Aperitif Crée";

        }

        private void ButtonTestCreateBeer_Clicked(object sender, EventArgs e)
        {
            Beer Orval = new Beer("Orval" , "Biere trappiste Orval" , 1 , 25.11 , 8.01 , false , true , 5.45 , 21.14 , "Unbonverredorval.jpg");
            Beer Maredsous = new Beer("Maredsous" , "Biere d'abbaye de Maredsous" , 2 , 25.11 , 7.10 , true , false , 4.78 , 21.15 ,"UnmagnumdeMaredsous.png");
            Beer JupilerNA = new Beer("JupilerNA" , "Biere Jupiler Sans alcool" , 3 , 33.14 , 0.00 , false , false , 2.04 , 6.14 , "JupilerNA.jpg ");

            lblDebug.Text = "Biere Crée";

        }
    }

}
