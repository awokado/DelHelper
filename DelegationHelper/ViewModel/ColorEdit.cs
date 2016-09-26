using DelegationHelper.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace DelegationHelper.ViewModel 
{
    public class ColorEdit : INotifyPropertyChanged
    {
        private readonly Model.Colors colors = Settings.Read();

        public event PropertyChangedEventHandler PropertyChanged;

        public byte A
        {
            get { return colors.A; }
            set { colors.A = value; onPropertyChanged("A", "Color"); }
        }

        public byte R
        {
            get { return colors.R; }
            set { colors.R = value; onPropertyChanged("R", "Color"); }
        }
        public byte G
        {
            get { return colors.G; }
            set { colors.G = value; onPropertyChanged("G", "Color"); }
        }
        public byte B
        {
            get { return colors.B; }
            set { colors.B = value; onPropertyChanged("B", "Color"); }
        }


    
        public Model.Colors Color
        {
            get { return colors; }
        }

        private ICommand resetCommand;
        private ICommand saveCommand;
        private ICommand closeCommand;

        public ICommand Close
        {
            get
            {
                if (closeCommand == null) closeCommand = new CloseCommand(this);
                return closeCommand;
            }
        }
        public ICommand Save
        {
            get
            {
                if (saveCommand == null) saveCommand = new SaveCommand(this);// dummy singletone :)
                return saveCommand;
            }
        }

        public ICommand Reset
        {
            get
            {
                if (resetCommand == null) resetCommand = new ResetCommand(this);  // dummy singletone :)
                return resetCommand;
            }
        }


        private void onPropertyChanged(params string[] propertyNames)
        {
            if(PropertyChanged != null)
            {
                foreach (string propertyName in propertyNames)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    static class MyExtensions
    {
        public static Color ToColor(this Model.Colors colors)
        {
            return new Color()
            {
                A = colors.A,
                R = colors.R,
                G = colors.G,
                B = colors.B
            };
        }
    }
}
