using DelegationHelper.Model;
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
        private readonly ColorEdit _viewModel;
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
            this._viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {

            return (_viewModel.A != 0) || (_viewModel.R != 0) || (_viewModel.G != 0) || (_viewModel.B != 0) ;
        }

        public void Execute(object parameter)
        {
            System.Console.WriteLine("reset");
            _viewModel.A = 0;
            _viewModel.R = 0;
            _viewModel.G = 0;
            _viewModel.B = 0;
        }
    }
    public class CloseCommand : ICommand
    {
        private readonly ColorEdit _viewModel;
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

        public CloseCommand(ColorEdit viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException("viewModel");
            this._viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            App.Current.MainWindow.Close();
        }
    }

    public class SaveCommand :ICommand
    {
        private readonly ColorEdit _viewModel;
        public SaveCommand(ColorEdit _viewModel)
        {
            if (_viewModel == null) throw new ArgumentNullException(nameof(_viewModel));
            this._viewModel = _viewModel;
        }

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

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Settings.Save(_viewModel.Color);
        }
    }
}
