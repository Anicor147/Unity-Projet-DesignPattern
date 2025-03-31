using UnityEngine;

public class MoveCommands : ICommand
{
    PlayerMovement playerMovement;
    private float movement;

    public MoveCommands(PlayerMovement playerMovement, float movement)
    {
        this.playerMovement = playerMovement;
        this.movement = movement;
    }
    public void Execute()
    {
        playerMovement.Move(movement);
    }
}
