using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class GameObjectBuilder
    {
        public GameObject _gameObject;

        public GameObjectBuilder() => _gameObject = new GameObject();
        public GameObjectBuilder(GameObject gameObject) => _gameObject = gameObject;

        public GameObjectVisualBuilder Visual => new GameObjectVisualBuilder(_gameObject);
        public GameObjectPhysicsBuilder Physics => new GameObjectPhysicsBuilder(_gameObject);

        public static implicit operator GameObject(GameObjectBuilder builder)
        {
            return builder._gameObject;
        }
    }
}


