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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ICommand shieldCommand = new ShieldCommands(playerMovement);
            commandInvoker.Execute(shieldCommand);
        }
    }
}
