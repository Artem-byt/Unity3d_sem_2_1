namespace Asteroids
{
    public interface IExecute: IController
    {
        public void Execute(float deltaTime);
    }
}