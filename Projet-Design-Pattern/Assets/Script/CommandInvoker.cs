using UnityEngine;

public class CommandInvoker 
{
    public void Execute(ICommand command)
    {
        command.Execute();
    }
}
