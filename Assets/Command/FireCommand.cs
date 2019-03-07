namespace Assets.Scripts
{
    public class FireCommand : Command
    {
        public override void Execute(Actor actor)
        {
            actor.Fire();
        }
    }
}