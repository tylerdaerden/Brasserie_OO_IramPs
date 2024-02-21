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

        



    }

}
