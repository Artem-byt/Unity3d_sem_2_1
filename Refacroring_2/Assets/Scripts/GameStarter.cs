using UnityEngine;

namespace Asteroids
{
    public class GameStarter : MonoBehaviour
    {
        private GameController _mainController;

        private void Awake()
        {
            _mainController = new GameController();
            new MainInitializator(_mainController);
        }

        void Update()
        {
            var time = Time.deltaTime;
            _mainController.Execute(time);
        }
    }
}