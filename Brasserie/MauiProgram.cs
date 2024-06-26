﻿using Brasserie.Utilities.DataAccess;
using Brasserie.Utilities.DataAccess.Files;
using Brasserie.Utilities.Interfaces;
using Brasserie.Utilities.Services;
using Brasserie.View;
using Brasserie.ViewModel;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace Brasserie
{
    public static class MauiProgram
    {
        //chemin config file pour PORTABLE ↓↓↓
        //private const string CONFIG_FILE = @"C:\Users\denys\Desktop\POO\MAUI Projects\Brasserie\Brasserie\Configuration\Datas\Config.txt";
        //chemin config file pour TOUR ↓↓↓
        private const string CONFIG_FILE = @"D:\IRAM\2023_2024\0_POO\MAUI_Projects\Brasserie\Configuration\Datas\Config.txt";
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .UseMauiCommunityToolkit();
            DataFilesManager dataFilesManager = new DataFilesManager(CONFIG_FILE);

            //dependency injection for AlertServiceDisplay 
            builder.Services.AddSingleton<IAlertService>(new AlertServiceDisplay());
            AlertServiceDisplay alertService = new AlertServiceDisplay();

            /*
            Services.AddSingleton() permet de faire de l'injection de dépendance dans le constructeur des ViewModel par exemple
            sans devoir faire un new DataAccessJsonFile() dans celui-ci
            une instance est créée à ce stade et rendue disponible dans les constructeurs des classes. L'instance est permanente pour la méthode AddSingleton
            tandis qu'elle est recréée à chaque fois qu'on en a besoin quand on fait du .AddTransient()
            Les Services doivent être vu comme un conteneur de services disponibles ailleurs. Il contient toutes les instances spécifiées dans les <>
            */

            //builder.Services.AddSingleton<IDataAccess>(new DataAccessJsonFile(dataFilesManager));
            builder.Services.AddSingleton<IDataAccess>(new DataAccessSql(dataFilesManager,alertService));

            //permet de faire de l'injection de dépendance dans le constructeur de la MainPage sans devoir faire un new MainPageViewModel() dans celui-ci
            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<StaffMembersPageViewModel>();
            builder.Services.AddTransient<StaffMembersPage>();
#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}