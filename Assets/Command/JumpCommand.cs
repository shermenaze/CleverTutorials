namespace Assets.Scripts
{
    public class JumpCommand : Command
    {
        public override void Execute(Actor actor)
        {
            actor.Jump();
        }
    }
}