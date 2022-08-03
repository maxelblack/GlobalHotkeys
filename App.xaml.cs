using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Wpf.Ui.Controls;

namespace GlobalHotkeys
{
    public partial class App : Application
    {
        internal static Configuration? config;

        private void AppStartup(object sender, StartupEventArgs e)
        {
            if (StaticUtils.AppAlreadyRunning())
            {
                System.Windows.MessageBox.Show("There is already a running instance");
                Current.Shutdown();
            }

            LoadConfig();

            Window main = new MainWindow();
            Current.MainWindow = main;

            //TODO if modernNotifyIcon
            if (config!.modernNotifyIcon)
            {
                main.Loaded += (sender, e) =>
                {
                    main.Visibility = Visibility.Hidden;
                };
                main.Show();
            }
        }

        private static void LoadConfig()
        {
            // read config json & convert to object
            string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                + "\\MaxelTech\\GlobalHotkeys";
            if (!Directory.Exists(dataPath)) { Directory.CreateDirectory(dataPath); }

            string configFile = dataPath + "\\config.json";
            if (File.Exists(configFile))
            {
                string configJson = File.ReadAllText(configFile);
                config = JsonConvert.DeserializeObject<Configuration>(configJson);
            } 
            else
            {
                config = Configuration.DefaultConfig();
                File.WriteAllText(configFile, JsonConvert.SerializeObject(config));
            }

        }
    }
}
