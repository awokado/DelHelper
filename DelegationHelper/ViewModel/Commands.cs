using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DelegationHelper.ViewModel
{
    public class ResetCommand : ICommand
    {
        private readonly ColorEdit viewModel;
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }



        public ResetCommand(ColorEdit viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException("viewModel");
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {

            return (viewModel.A != 0) || (viewModel.R != 0) || (viewModel.G != 0) || (viewModel.B != 0) ;
        }

        public void Execute(object parameter)
        {
            System.Console.WriteLine("reset");
            viewModel.A = 0;
            viewModel.R = 0;
            viewModel.G = 0;
            viewModel.B = 0;
        }
    }
}
