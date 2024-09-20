using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Lab_01.Model;

namespace Lab_01.ViewModels
{
    public static class ThemesController
    {
        private static ResourceDictionary ThemeDictionary
        {
            // можно получить его по имени с помощью логики запроса.
            get { return Application.Current.Resources.MergedDictionaries[0]; }
            set { Application.Current.Resources.MergedDictionaries[0] = value; }
        }

        private static void ChangeTheme(Uri uri)
        {
            ThemeDictionary = new ResourceDictionary() { Source = uri };
        }
        public static void SetTheme(ThemeTypes theme)
        {
            string themeName = null;
            switch (theme)
            {
                case ThemeTypes.Dark: themeName = "DarkTheme"; break;
                case ThemeTypes.Light: themeName = "LightTheme"; break;
                case ThemeTypes.ColourfulDark: themeName = "ColourfulDarkTheme"; break;
                case ThemeTypes.ColourfulLight: themeName = "ColourfulLightTheme"; break;
            }

            try
            {
                if (!string.IsNullOrEmpty(themeName))
                    ChangeTheme(new Uri($"View/{themeName}.xaml", UriKind.Relative));
            }
            catch { }
        }
    }
}
