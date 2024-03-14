using Brasserie.Model;
using Brasserie.Model.Restaurant.Activity;
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
            Item trucComestible = new Item(1, "chose", "c'est comestible", 1.70, "comestible.jpg", 6.50);
            Item trucBuvable = new Item(2, "machin", "bois", 1.78, "buvable.gif", 6.47);

            //petit ajout perso (réaction au click sur bouton)
            lblDebug.Text = "Item Crées";
        }


        private void ButtonTestCateringClasses_Clicked(object sender, EventArgs e)
        {
            Item trucComestible = new Item(1, "chose", "c'est comestible", 1.70, "comestible.jpg", 6.50);
            Drink UnDemiBelge = new Drink(1, "Une50", "Un Demi Facon Belge", 4.81, "UnDemiBelge.jpg", 6.07, 50.00);
            Dish CarbonnadeAuFaro = new Dish(1, "Carbonnade Au Faro", "Carbonnade Sauce Faro , un délice !", 10.45, "unebonnecarbonnadefieu.jpg", 6.14);
            Soft RomanCola = new Soft(1, "Roman Cola", "Cola Made in Belgium", 2.14, "UnbonverredeRomanColaGlacé.png", 6.12, 33.45);
            Alcohol EauDeVillee = new Alcohol(1, "Eau de Villée", "Eau de vie de Biercée ", 6.15, "eaudeVillée.jpg", 7.14, 6.15, 31.25);
            Aperitif MojitoRoyal = new Aperitif(1, "Mojito Royal", "Cocktail Mojito avec ajout de Champagne", 10.21, "mojitoroyal.png ", 15.21, 45.12, 21.78);
            Beer Orval = new Beer(1, "Orval", "Biere trappiste Orval", 25.11, "Unbonverredorval.jpg", 8.01, 5.45, 21.14, false, true);

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

        private void ButtonTestOrder_Clicked(object sender, EventArgs e)
        {
            Order ord = new Order();
            Soft coca = new Soft(1, name: "Coca cola", "", 3.30, "coca.jpg", 21.0, 25);
            Beer brassTemps = new Beer(2, name: "Coca cola", "", 3.30, "biere.jpg", 21.0, 25, 6.0, false, false);
            Dish spaghBolo = new Dish(3, "Spaghetti bolo", "", 15.30, "bolo.jpg", 21.0);
            OrderItem ordItemCoca_1 = new OrderItem(coca, 1);
            OrderItem ordItemBrassTemps = new OrderItem(brassTemps, 1);
            OrderItem ordItemSpaghBolo = new OrderItem(spaghBolo, 2);
            OrderItem ordItemCoca_2 = new OrderItem(coca, 2);
            ord.AddUpdateOrderItem(ordItemCoca_1);
            ord.AddUpdateOrderItem(ordItemBrassTemps);
            ord.AddUpdateOrderItem(ordItemSpaghBolo);
            ord.AddUpdateOrderItem(ordItemCoca_2); //2 nouveaux cocas commandés plus tard
            string s = "";
            s = $"nombre d'orderItems : {ord.OrderItems.Count}";
            s += $"\nnombre de coca : {ord.OrderItems[0].Quantity} Prix : {ord.OrderItems[0].Price}";
            s += $"\nnombre de brasse temps : {ord.OrderItems[1].Quantity} Prix : {ord.OrderItems[1].Price}";
            s += $"\nnombre de spaghettis : {ord.OrderItems[2].Quantity} Prix : {ord.OrderItems[2].Price}";
            s += $"\nPrix total TVA : {ord.TotalVatCost}€";
            s += $"\nPrix total : {ord.TotalPrice}€";
            lblDebug.Text = s;

        }

        private void ButtonExoLambda_Clicked(object sender, EventArgs e)
        {

            ObservableCollection<StaffMember> staff = new ObservableCollection<StaffMember>();
            staff.Add(new StaffMember(1, "Dutrieu", "Pierre", true, "dutrieur@gmail.com", "0498345678", "BE45 6781 2345 2490", "4, rue de la coupe 7000Mons", 34000));
            staff.Add(new StaffMember(2, "Lalande", "Vanessa", false, "", "0485667098", "BE806581 1145 3496", "16, rue de la loi 7080 Nivelles", 32500));
            staff.Add(new Manager(3, "Jenlain", "Fabienne", false, "jenfab23@gmail.com", "0478901322", "BE80 4394 7739 1234", "13, rue de Mons 6000 Beaumont", 59000, "Password01"));
            staff.Add(new StaffMember(4, "Baulieu", "Jean", true, "", "", "BE23 1189 1390 1193", "5, rue des tilleus 7030 Ghlin", 36500));
            staff.Add(new StaffMember(5, "Gerardin", "Isabelle", false, "", "0475671038", "BE801782 4490 9113", "120, rue des drapiers 7000 Mons", 41000));
            staff.Add(new Manager(6, "Balkan", "Fred", true, "balkan@gmail.com", "0479001280", "BE89 1190 1127 2280", "10, rue grande 6340 Nimy", 54000, "TrucMachin01"));
            staff.Add(new StaffMember(7, "Gutierez", "Manolo", true, "manolo140@gmail.com", "0498671011", "BE70 9012 1034 1931", "8, rue de la riviere 7000 Mons", 29800));


            int EmplyeesNumber = staff.Count();
            bool allHaveMobile = staff.All(s => !string.IsNullOrEmpty(s.MobilePhoneNumber));

            //Est-ce qu’il y a un membre injoignable, qui n’a pas de N° de téléphone ni d’Email renseignés ?
            bool isSomeoneUnjoinable = staff.Any(s => string.IsNullOrEmpty(s.MobilePhoneNumber) && string.IsNullOrEmpty(s.Email));

            //Le premier membre (celui du c)) (sa référence) qui n’a pas de N° de téléphone ni d’Email renseignés
            StaffMember firstUnJoingnable = staff.FirstOrDefault(s => string.IsNullOrEmpty(s.MobilePhoneNumber) && string.IsNullOrEmpty(s.Email));

            //La collection des employés n’ayant pas d’email renseigné.
            ObservableCollection<StaffMember> employeWithNoMail = new ObservableCollection<StaffMember>(staff.Where(s => string.IsNullOrEmpty(s.Email)));

            //La collection des employées(de genre féminin).
            ObservableCollection<StaffMember> womens = new ObservableCollection<StaffMember>(staff.Where(s => !s.Gender));

            //La collection des employés résidant à Mons.
            ObservableCollection<StaffMember> liveInMons = new ObservableCollection<StaffMember>(staff.Where(s => !string.IsNullOrEmpty(s.Address) && s.Address.Contains("7000")));
            // La collection des managers
            ObservableCollection<StaffMember> onlyManagers = new ObservableCollection<StaffMember>(staff.OfType<Manager>());
            //La collection des employés triés par ordre alphabétique de nom de famille.
            ObservableCollection<StaffMember> orderByNameAsc = new ObservableCollection<StaffMember>(staff.OrderBy(s => s.LastName));
            //Le pourcentage d’hommes dans le personnel (en une seule ligne de code).
            double pourcentMen = (100 * staff.Count(s => s.Gender)) / staff.Count;
            //Les employés par ordre croissant de salaire.
            //Pas possible depuis la main page car la prop Salary est protected 

            lblDebug.Text = "Exo effectué";

        }





    }



}
