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
            
            if (controller is IFixedExecute fixedExecuteController)
            {
                _model.FixedExecudeController.Add(fixedExecuteController);
            }


        }

        public void Execute(float deltaTime)
        {
            for (var element = 0; element < _model.ExecuteControllers.Count; ++element)
            {
                _model.ExecuteControllers[element].Execute(deltaTime);
            }
        }

        public void FixedExecute(float deltatime)
        {
            for (var element = 0; element < _model.FixedExecudeController.Count; ++element)
            {
                _model.FixedExecudeController[element].FixedExecute(deltatime);
            }
        }
    }
}