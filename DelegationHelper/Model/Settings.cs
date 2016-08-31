using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// DAL - data access layer
/// </summary>
namespace DelegationHelper.Model
{
    class Settings
    {
        public static Colors Read()
        {
            Properties.Settings settings = Properties.Settings.Default;
            return new Colors(settings.R, settings.G, settings.B);
        }
        public static void Save(Colors color)
        {
            Properties.Settings settings = Properties.Settings.Default;
            settings.R = color.R;
            settings.G = color.G;
            settings.B = color.B;
            settings.Save();
        }
    }
}
