using Brasserie.Model;
using Brasserie.Model.Restaurant.Activity;
using Brasserie.Model.Restaurant.Catering;
using Brasserie.Model.Restaurant.People;
using Brasserie.Utilities.DataAccess;
using Brasserie.Utilities.DataAccess.Files;
using Brasserie.Utilities.Interfaces;
using Brasserie.ViewModel;



//using Phase;
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

        MainPageViewModel mainPageViewModel;
        public MainPage(MainPageViewModel mainPageVM, IDataAccess dataAccessService)
        {
            dataAccess = dataAccessService;
            //MainVM = new MainPageViewModel(); remplacé par l'injection de dépendance, le paramètre dans le constructeur et le service ajouté dans MauiProgram
            mainPageViewModel = mainPageVM ?? throw new ArgumentNullException(nameof(MainPageViewModel));
            // Définition du BindingContext avec le ViewModel
            BindingContext = mainPageVM;

            InitializeComponent();
        }

        /// <summary>
        /// Manager to the data access (Csv, Json, XAML, SQL...)
        /// </summary>
        private IDataAccess dataAccess;

        //private void OnCounterClicked(object sender, EventArgs e)
        //{

        //    myCounter.IncrementCounter();


        //    EntryCount.Text = myCounter.CounterValue.ToString();
        //    //texte de la case de clics ↓↓↓
        //    CounterBtn.Text = "Nombre de Clics :" + myCounter.CounterValue.ToString();

        //    //SemanticScreenReader.Announce(CounterBtn.Text);
        //}

        private void buttonTestCreateFirstPersons_Clicked(object sender, EventArgs e)
        {
            //Person firstPerson = new Person(id: 1, lastName: "Beumier", firstName: "Damien", gender: true, email: "dambeumier@gmail.com", mobilePhoneNumber: "0489142293");
            //Person secondPerson = new Person(id: 2, lastName: "Deroisin", firstName: "Sophie", gender: false, email: "sophiederoisin@gmail.com", mobilePhoneNumber: "0473121314");
            //Person thirdPerson = new Person(3, "Jandrin", "Marc", true, "jandrinmarc@gmail.com", mobilePhoneNumber: "0485556678");
            //Person fourthPerson = new Person(4, "Lupant", "Sebasien");
            //Person fifthPerson = new Person();

            //petit ajout perso (réaction au click sur bouton)
            lblDebug.Text = "CODE DEPRECIE !!! (Personnes Crées)";

            //Person p;
            //p = new Person(6, "Tardif", "Jean");


        } //end buttonTestCreateFirstPersons_Clicked


        private void buttonTestEncapsulation_Clicked(object sender, EventArgs e)
        {
            //Person p = new Person(id: 2, lastName: "Deroisin", firstName: "Sophie", gender: false, email: "sophiederoisin@gmail.com", mobilePhoneNumber: "0473121314");
            //p.FirstName = "Marie-Sophie";
            lblDebug.Text = "CODE DEPRECIE";

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
            //Item trucComestible = new Item(1, "chose", "c'est comestible", 1.70, "comestible.jpg", 6.50);
            //Item trucBuvable = new Item(2, "machin", "bois", 1.78, "buvable.gif", 6.47);

            //petit ajout perso (réaction au click sur bouton)
            lblDebug.Text = "CODE DEPRECIE !!! (Item Crées)";
        }


        private void ButtonTestCateringClasses_Clicked(object sender, EventArgs e)
        {
            //Item trucComestible = new Item(1, "chose", "c'est comestible", 1.70, "comestible.jpg", 6.50);
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

        private void buttonTestLambdasOnCollection_Clicked(object sender, EventArgs e)
        {
            ObservableCollection<Drink> drinks = new ObservableCollection<Drink>();

            drinks.Add(new Soft(1, name: "Coca 25", "", 3.30, "coca.jpg" , 21.0, 25));
            drinks.Add(new Soft(2, name: "Fanta 25", "", 3.30, "fanta.jpg", 21.0, 25));
            drinks.Add(new Soft(3, name: "Coca 33", "", 4.20, "coca.jpg", 21.0, 33));
            drinks.Add(new Soft(4, name: "Fanta 33", "", 4.20, "fanta.jpg", 21.0, 33));
            drinks.Add(new Soft(5, name: "Water 25cl", "", 3.10, "water25.jpg", 21.0, 25));
            drinks.Add(new Soft(6, name: "Water 50cl", "", 5.50, "water.jpg", 21.0, 50));
            drinks.Add(new Soft(7, name: "Water 1L", "", 7.00, "water.jpg", 21.0, 100));
            drinks.Add(new Soft(8, name: "Coca Zero", "", 3.50, "coca.jpg", 21.0, 25));
            drinks.Add(new Soft(9, name: "IceTea Zero", "", 3.50, "coca.jpg", 21.0, 25));
            drinks.Add(new Beer(10, name: "Ambrasse Temps 25", "", 4.20, "amb25.jpg", 21.0, 25, 6.00, false, false));
            drinks.Add(new Beer(11, name: "Troll 25", "", 4.20, "troll25.jpg" , 21.0, 25.00, 5.50, false, false));

            // match Criteria ?;
            bool boolResult;
            boolResult = drinks.All(d => d.UnitPrice < 5.00);//all elements respect the criteria ?
            boolResult = drinks.Any(d => d.UnitPrice >= 6.00);//exist at least one element that respect the criteria

            //sorted collections
            ObservableCollection<Drink> orderByNameDesc = new
            ObservableCollection<Drink>(drinks.OrderByDescending(d => d.Name));
            ObservableCollection<Drink> orderByUnitPriceAsc = new
            ObservableCollection<Drink>(drinks.OrderBy(d => d.UnitPrice));

            //collection with selection
            ObservableCollection<Drink> select25Cl = new
            ObservableCollection<Drink>(drinks.Where(d => d.Volume == 25.00));
            ObservableCollection<Drink> waters = new ObservableCollection<Drink>(drinks.Where(d
            => d.Name.Contains("Water")));
            ObservableCollection<Drink> beers = new
            ObservableCollection<Drink>(drinks.OfType<Beer>());

            //find element with one or more (logical expression) criteria
            Drink coca33 = drinks.First(d => d.Name.Contains("Coca 33"));
            Drink d = drinks.First(d => d.Volume > 25.00 && d.PictureName.EndsWith(".jpg"));

            //build new list from another collection
            List<string> s = drinks.Select(d =>
            $"{d.Id};{d.Name};{d.Description};{d.UnitPrice};{d.Volume}").ToList();

            //compute
            double maxUnitPrice = drinks.Max(d => d.UnitPrice);
            double average = drinks.Average(d => d.UnitPrice);
            double sum = drinks.Sum(d => d.UnitPrice);

            //do something foreach element
            drinks.ToList().ForEach(d => d.VatRate = 22.0);
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

        private void ButtonTestItemsCollection_Clicked(object sender, EventArgs e)
        {
            Soft coca = new Soft(1, name: "Coca cola", "", 3.30, "coca.jpg", 21.0, 25);
            Soft fanta = new Soft(2, name: "Fanta", "", 3.30, "fanta.jpg", 21.0, 25);
            Beer brassTemps = new Beer(3, name: "Ambrasse Temps", "", 3.30, "biere.jpg", 21.0, 25, 6.0, false, false);
            Dish spaghBolo = new Dish(4, "Spaghetti bolo", "", 15.30, "bolo.jpg", 21.0);
            Soft coca2 = new Soft(5, name: "Coca cola", "", 3.30, "coca.jpg", 21.0, 25);
            ItemsCollection itCol = new ItemsCollection();
            itCol.AddItem(coca);
            itCol.AddItem(fanta);
            itCol.AddItem(brassTemps);
            itCol.AddItem(spaghBolo);
            itCol.AddItem(coca2);//test to add an item who have the same name as another already in the list
            itCol.DeleteItem(brassTemps);//delete one item
            itCol.IndexPrices(5.00); //index 5% all prices

            lblDebug.Text = "Collection Item crée";

        }

        private void ButtonTestCustomerCollection_Clicked(object sender, EventArgs e)
        {
           
            Customer riri = new Customer(1, "Duck", "Riri", true, "riri@disney.com", "555-897", Customer.CustomerType.New);
            Customer fifi = new Customer(2, "Duck", "Fifi", true, "fifi@disney.com", "555-898", Customer.CustomerType.Occasional);
            Customer loulou = new Customer(3, "Duck", "Loulou", true, "loulou@disney.com", "555-899", Customer.CustomerType.Regular);
            Customer zaza = new Customer(4, "Duck", "Zaza", false, "zaza@disney.com", "555-900", Customer.CustomerType.Regular);

            CustomersCollection cuscoll = new CustomersCollection();

            cuscoll.AddCustomer(riri);
            cuscoll.AddCustomer(fifi);
            cuscoll.AddCustomer(loulou);
            cuscoll.AddCustomer(zaza);

            string s = "";
            s = $"nombre de clients : {cuscoll.Count}";
            s += $"\nPourcentage nouveaux : {cuscoll.NewCustomersPercentage}";
            s += $"\nPourcentage occasionels : {cuscoll.OccasionalCustomersPercentage}";
            s += $"\nPourcentage réguliers : {cuscoll.RegularCustomersPercentage}";
            lblDebug.Text = s;


        }

        private void ButtonTestReadWriteTextFileWithList_Clicked(object sender, EventArgs e)
        {
            //chemin pour tour ↓↓
            string csvFilePath = @"D:\IRAM\2023_2024\0_POO\MAUI_Projects\Brasserie\Configuration\Datas\Csv\Persons.csv";
            //chemin pour portable ↓↓
            //string csvFilePath = "C:\\Users\\denys\\Desktop\\POO\\MAUI Projects\\Brasserie\\Brasserie\\Configuration\\Datas\\Csv\\Persons.csv";
            List<string> personsList = new List<string>();//create empty collection of string
            personsList = File.ReadAllLines(csvFilePath).ToList(); // copy each line in the collection
            string s = "";
            foreach (string line in personsList)
            {
                s += $"\n{line}";
            }
            lblDebug.Text = s; //print collection's content
                               //Add persons to collection.
            personsList.Add("Customer;10;Maggi;Toni;true;maggiton@gmail.com;0491609830;Occasional");
            personsList.Add("Customer;11;Fernez;Jean;true;jeanfernez@gmail.com;0480458801;Regular");
            //write all lines in a new csv file.
            //chemin pour tour ↓↓
            File.WriteAllLines(@"D:\IRAM\2023_2024\0_POO\MAUI_Projects\Brasserie\Configuration\Datas\Csv\PersonsRewrite.csv", personsList);
            //chemin pour portable ↓↓
            //File.WriteAllLines(@"C:\\Users\\denys\\Desktop\\POO\\MAUI Projects\\Brasserie\\Brasserie\\Configuration\\Datas\\Csv\\PersonsRewrite.csv", personsList);


        }

        private void ButtonTestPolymorphism_Clicked(object sender, EventArgs e)
        {
            Beer brasseTemps = new Beer(3, name: "Brasse Temps", "", 3.30, "biere.jpg", 21.0, 25, 6.0, false, false);
            Alcohol al = brasseTemps;
            Drink d = brasseTemps;
            Item it = brasseTemps;

            //brasseTemps = it;

            lblDebug.Text = it.GetType().ToString();

            Beer b = (Beer)it;


        }

        private void ButtonTestNew_Clicked(object sender, EventArgs e)
        {
            StaffMember Lalande = new StaffMember(2, "Lalande", "Vanessa", false, "", "0485667098", "BE80 6581 1145 3496", "16, rue de la loi 7080 Nivelles", 4000);
            Manager Jenlain = new Manager(3, "Jenlain", "Fabienne", false, "jenfab23@gmail.com", "0478901322", "BE80 4394 7739 1234", "13, rue de Mons 6000 Beaumont", 4000, "Password01");
            lblDebug.Text = $"\n Calcul du salaire depuis une référence de StaffMember pour {Lalande.LastName} : {Lalande.WageCalculation()}";
            lblDebug.Text = $"\n Calcul du salaire depuis une référence de Manager pour {Jenlain.LastName} : {Jenlain.WageCalculation()}";

            ObservableCollection<StaffMember> staff = new ObservableCollection<StaffMember>();
            staff.Add(Lalande);
            staff.Add(Jenlain);
            staff.ToList().ForEach(s => lblDebug.Text += $"\n Salaire de {s.LastName} de type {s.GetType()}: {s.WageCalculation()}");

            staff.ToList().ForEach(s => lblDebug.Text += $"\n {s.GetMainInformations()}");
            lblDebug.Text += $"\n A partir d'une ref de type Manager pour {Jenlain.LastName} cela donne : \n{Jenlain.GetMainInformations()}";

        }

        private void ButtonTestInterfaceAndDataAccess_Clicked(object sender, EventArgs e)
        {
            // CONFIG_FILE POUR TOUR ↓↓↓
            //string CONFIG_FILE = @"D:\IRAM\2023_2024\0_POO\MAUI_Projects\Brasserie\Configuration\Datas\Config.txt";
            // CONFIG_FILE POUR PORTABLE ↓↓↓
            string CONFIG_FILE = @"C:\Users\denys\Desktop\POO\MAUI Projects\Brasserie\Brasserie\Configuration\Datas\Config.txt";
            DataFilesManager dataFilesManager = new DataFilesManager(CONFIG_FILE);
            DataAccessCsvFile daCsv = new DataAccessCsvFile(dataFilesManager);
            ItemsCollection items = daCsv.GetAllItems();
            items.ToList().ForEach(it => lblDebug.Text += $"\n Item: {it.Name} - prix {it.UnitPrice.ToString()}€ - {it.AutoDescription()}");
            CustomersCollection customers = daCsv.GetAllCustomers();
            customers.ToList().ForEach(c => lblDebug.Text += $"\n Client:{c.Id} {c.FirstName} {c.LastName}");

        }

        private void ButtonTestExerciceGetAllStaffMembers_Clicked(object sender, EventArgs e)
        {
            // CONFIG_FILE POUR TOUR ↓↓↓
            //string CONFIG_FILE = @"D:\IRAM\2023_2024\0_POO\MAUI_Projects\Brasserie\Configuration\Datas\Config.txt";
            // CONFIG_FILE POUR PORTABLE ↓↓↓
            string CONFIG_FILE = @"C:\Users\denys\Desktop\POO\MAUI Projects\Brasserie\Brasserie\Configuration\Datas\Config.txt";
            DataFilesManager dataFilesManager = new DataFilesManager(CONFIG_FILE);
            DataAccessCsvFile daCsv = new DataAccessCsvFile(dataFilesManager);
            StaffMembersCollection staffmembers = daCsv.GetAllStaffMembers();
            //Ci dessous penser à trouver sur le GetType comment n'afficher que manager ou staffmember ↓↓↓
            staffmembers.ToList().ForEach(sm => lblDebug.Text += $"\n {sm.GetType()} firstname : {sm.FirstName} , lastname : {sm.LastName} ");
        }

        private void buttonTestDataAccessJsonFile_Clicked(object sender, EventArgs e)
        {
            // CONFIG_FILE POUR TOUR ↓↓↓
            //string CONFIG_FILE = @"D:\IRAM\2023_2024\0_POO\MAUI_Projects\Brasserie\Configuration\Datas\Config.txt";
            // CONFIG_FILE POUR PORTABLE ↓↓↓
            string CONFIG_FILE = @"C:\Users\denys\Desktop\POO\MAUI Projects\Brasserie\Brasserie\Configuration\Datas\Config.txt";
            DataFilesManager dataFilesManager = new DataFilesManager(CONFIG_FILE);
            DataAccessJsonFile da = new DataAccessJsonFile(dataFilesManager);
            ItemsCollection items = da.GetAllItems();
            items.ToList().ForEach(it => lblDebug.Text += $"\n Item: {it.Name} - prix {it.UnitPrice.ToString()}€ - {it.AutoDescription()}");
            items[0].Description = "on a change la description du 1er item";
            items[5].UnitPrice = 99.9; //changement du prix du 6ème item
            //test de Add Item
            //items.AddItem(new Soft(24, "Roman Cola", "Cola Made in Belgium", 2.14, "UnbonverredeRomanColaGlacé.png", 6.12, 33.45));
            //test de Delete Item
            //items.DeleteItem(items[0]);
            da.UpdateAllItemsDatas(items);//sauvegarde des données

        }

        private void buttonTestViewModel_Clicked(object sender, EventArgs e)
        {

            ItemsCollection items = mainPageViewModel.Items;
            lblDebug.Text = mainPageViewModel.ItemSelected.Name;


        }
    }



}
