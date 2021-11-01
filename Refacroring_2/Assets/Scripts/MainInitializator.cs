using UnityEngine;

namespace Asteroids
{
    public class MainInitializator
    {
        public MainInitializator(GameController mainController)
        {
            var inputInitialization = new InputKeyBoardInitialization();
            var playerHealthModel = new PlayerHealthModel();
            var playerMoveModel = new PLayerMoveModel(inputInitialization);
            var playerWeaponModel = new PlayerWeaponModel();
            var playerHealthInitialization = new PlayerHealthInitialization(playerHealthModel, playerMoveModel.GetTransform.gameObject);

            mainController.Add(new InputKeyBoardController(inputInitialization));
            mainController.Add(new PlayerMoveController(playerMoveModel));
            mainController.Add(new PlayerRotationController(playerMoveModel));
            mainController.Add(new PlayerFireController(playerWeaponModel, inputInitialization));
        }
    }
}