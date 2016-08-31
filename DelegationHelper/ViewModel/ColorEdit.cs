using DelegationHelper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DelegationHelper.ViewModel
{
    public class ColorEdit
    {
        private readonly Model.Colors colors = Settings.Read();

        public byte R
        {
            get { return colors.R; }
            set { colors.R = value; }
        }
        public byte G
        {
            get { return colors.G; }
            set { colors.G = value; }
        }
        public byte B
        {
            get { return colors.B; }
            set { colors.B = value; }
        }

        public void Save()
        {
            Settings.Save(colors);
        }
    
        public Color Color
        {
            get { return colors.ToColor(); }
        }
    }

    static class MyExtensions
    {
        public static Color ToColor(this Model.Colors colors)
        {
            return new Color()
            {
                A = 255,
                R = colors.R,
                G = colors.G,
                B = colors.B

            };
        }


    }
}
