using UnityEngine;

namespace Asteroids
{
    public class MainInitializator
    {
        public MainInitializator(GameController mainController)
        {
            
            var inputInitialization = new InputKeyBoardInitialization();
            var enemyFactory = new EnemyTypeLowFactory(Resources.Load<EnemyInfo>("EnemyInfo").GetTypeOfEnemy);//
            var timerModel = new TimerModel();
            var playerHealthModel = new PlayerHealthModel();
            var playerMoveModel = new PLayerMoveModel(inputInitialization);
            var playerWeaponModel = new PlayerWeaponModel();
            var poolModel = new PoolModel();
            var enemyWeaponModel = new EnemyWeaponMOdel();
            new PlayerHealthInitialization(playerHealthModel, playerMoveModel.GetTransform.gameObject);
            var enemyPoolContainerInitialization = new EnemyPoolContainerInitialization(enemyFactory, enemyWeaponModel);//
            var ammopoolInitialization = new AmmoPoolInitialize(poolModel, playerMoveModel, enemyPoolContainerInitialization.Enemies);
            var enemyFireInitialization = new EnemyFireInitialization(timerModel);

            mainController.Add(new TimerController(timerModel));
            mainController.Add(new InputKeyBoardController(inputInitialization));
            mainController.Add(new PLayerMoveController(playerMoveModel));
            mainController.Add(new PlayerAccelerationController(playerMoveModel));
            mainController.Add(new PlayerRotationController(playerMoveModel));
            mainController.Add(new PlayerFireController(playerWeaponModel, inputInitialization, ammopoolInitialization.GetAmmoPool, timerModel));
            mainController.Add(new RocketsController(playerWeaponModel, timerModel));
            mainController.Add(new EnemyMoveController(enemyPoolContainerInitialization.Enemies, playerMoveModel, enemyFireInitialization, timerModel));
            mainController.Add(new EnemyPoolsController(enemyPoolContainerInitialization, timerModel, playerMoveModel));
            mainController.Add(new EnemyFireController(enemyPoolContainerInitialization.Enemies, enemyFireInitialization, playerMoveModel, timerModel));
        }
    }
}