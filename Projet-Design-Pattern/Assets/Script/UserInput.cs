using System;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    CommandInvoker commandInvoker;
    private float axisValue;

    private void Start()
    {
        commandInvoker = new CommandInvoker();
    }

    private void FixedUpdate()
    {
        axisValue = Input.GetAxis("Horizontal");

        if (axisValue is > 0 or < 0)
        {
            ICommand moveCommand = new MoveCommands(playerMovement, axisValue);
            commandInvoker.Execute(moveCommand);
        }
    }
}
