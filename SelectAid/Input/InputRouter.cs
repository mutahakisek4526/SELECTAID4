using System;
using System.Windows.Threading;

namespace SelectAid.Input;

public sealed class InputRouter
{
    public event EventHandler<InputAction>? ActionRaised;

    public void RaiseAction(InputAction action)
    {
        if (Dispatcher.CurrentDispatcher.CheckAccess())
        {
            ActionRaised?.Invoke(this, action);
            return;
        }

        Dispatcher.CurrentDispatcher.Invoke(() => ActionRaised?.Invoke(this, action));
    }
}
