using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Editor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        Color UsualColor = Colors.White;
        Color InstrColor = Colors.Orange;
        Color RegColor = Colors.OrangeRed;
        Color SpecWordColor = Colors.Blue;
        Color NumColor = Colors.DarkGray;
        Color DirectiveColor = Colors.Violet;
        Color CharColor = Colors.DarkGreen;
        Color StringColor = Colors.DarkGreen;
        Color ComentColor = Colors.LightGray;

        Color ForegroundColor = (Color)ColorConverter.ConvertFromString("#2E2D38");
        Color BackgroundColor = (Color)ColorConverter.ConvertFromString("#4D455C");
    }
}
