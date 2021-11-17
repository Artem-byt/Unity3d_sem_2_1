using System.Collections.Generic;

namespace Asteroids
{
    public class GameControllerModel
    {
        private readonly List<IExecute> _executeControllers;
        public GameControllerModel()
        {
            _executeControllers = new List<IExecute>(8);
        }

        public List<IExecute> ExecuteControllers => _executeControllers;

    }
}