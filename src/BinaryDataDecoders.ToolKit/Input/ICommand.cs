namespace BinaryDataDecoders.ToolKit.Input;

public interface ICommand : System.Windows.Input.ICommand
{
    void RaiseCanExecuteChanged();
}
