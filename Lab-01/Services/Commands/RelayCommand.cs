﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab_01.Services.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute; 
        private readonly Predicate<object> _canExecute;
        public RelayCommand(Action <object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute.Invoke(parameter);

        public void Execute(object parameter)
        {
            _execute?.Invoke(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}