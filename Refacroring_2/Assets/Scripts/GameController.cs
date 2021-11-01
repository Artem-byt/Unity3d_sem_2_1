using UnityEngine;

namespace Asteroids
{
    public class GameController : IController
    {
        private GameControllerModel _model;

        public GameController()
        {
            _model = new GameControllerModel();
        }

        public void Add(IController controller)
        {
            if (controller is IExecute executeController)
            {
                _model.ExecuteControllers.Add(executeController);
            }


        }

        public void Execute(float deltaTime)
        {
            for (var element = 0; element < _model.ExecuteControllers.Count; ++element)
            {
                _model.ExecuteControllers[element].Execute(deltaTime);
            }
        }
    }
}