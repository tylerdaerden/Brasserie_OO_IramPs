using Brasserie.Utilities.DataAccess;
using Brasserie.Utilities.DataAccess.Files;
using Brasserie.Utilities.Interfaces;
using Brasserie.Utilities.Services;
using Brasserie.View;
using Brasserie.ViewModel;
using Microsoft.Extensions.Logging;

namespace Brasserie
{
    public static class MauiProgram
    {
        //chemin pour TOUR
        //private const string CONFIG_FILE = @"D:\IRAM\2023_2024\0_POO\MAUI_Projects\Brasserie\Configuration\Datas\Config.txt";
        //chemin pour portable
       private const string CONFIG_FILE = @"C:\Users\denys\Desktop\POO\MAUI Projects\Brasserie\Brasserie\Configuration\Datas\Config.txt";

        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            DataFilesManager dataFilesManager = new DataFilesManager(CONFIG_FILE);
            /*
            Services.AddSingleton() permet de faire de l'injection de dépendance dans le constructeur des ViewModel par exemple
            sans devoir faire un new DataAccessJsonFile() dans celui-ci
            une instance est créée à ce stade et rendue disponible dans les constructeurs des classes. L'instance est permanente pour la méthode AddSingleton
            tandis qu'elle est recréée à chaque fois qu'on en a besoin quand on fait du .AddTransient()
            Les Services doivent être vu comme un conteneur de services disponibles ailleurs. Il contient toutes les instances spécifiées dans les <>
            */
            //Singleton for AlertServiceDisplay
            builder.Services.AddSingleton<IAlertService>(new AlertServiceDisplay());
            builder.Services.AddSingleton<IDataAccess>(new DataAccessJsonFile(dataFilesManager));

            //permet de faire de l'injection de dépendance dans le constructeur de la MainPage sans devoir faire un new MainPageViewModel() dans celui-ci
            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<MainPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
