using System;

namespace BinaryDataDecoders.ToolKit.Input
{
    public abstract class CommandBase : ICommand
    {
        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public virtual void RaiseCanExecuteChanged()
        {
            this.CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        public abstract void Execute(object parameter);
    }
}
