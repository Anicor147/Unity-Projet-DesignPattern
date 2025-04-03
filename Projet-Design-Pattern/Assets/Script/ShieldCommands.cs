public class ShieldCommands : ICommand
{
    private PlayerMovement playerMovement;

    public ShieldCommands(PlayerMovement playerMovement)
    {
        this.playerMovement = playerMovement;
    }
    
    public void Execute()
    {
        playerMovement.OnShield();
    }
}
