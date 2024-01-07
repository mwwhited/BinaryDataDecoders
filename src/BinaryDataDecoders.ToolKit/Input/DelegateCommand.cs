using System;

namespace BinaryDataDecoders.ToolKit.Input;

public class DelegateCommand : CommandBase
{
    private readonly Predicate<object?>? _canExecute;
    private readonly Action<object?> _execute;

    public DelegateCommand(Action<object?> execute, Predicate<object?>? canExecute = default)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public override bool CanExecute(object? parameter) =>
        _canExecute?.Invoke(parameter) ?? true;

    public override void Execute(object? parameter)=>
        _execute(parameter);
}
