using System.Collections.Generic;

namespace Asteroids
{
    public class GameControllerModel
    {
        private readonly List<IExecute> _executeControllers;
        private readonly List<IFixedExecute> _fixedExecuteControllers;
        public GameControllerModel()
        {
            _executeControllers = new List<IExecute>();
            _fixedExecuteControllers = new List<IFixedExecute>();
        }

        public List<IExecute> ExecuteControllers => _executeControllers;
        public List<IFixedExecute> FixedExecudeController => _fixedExecuteControllers;

    }
}