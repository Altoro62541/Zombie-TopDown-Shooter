﻿using UnityEngine;
using Zenject;
using ZombieShooter.PlayerEntity;

namespace ZombieShooter.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        [Inject] private DiContainer _container;
        public IPlayer Create(Player prefab, Vector3 position, Quaternion rotation, Transform parent = null)
        {
            var player = _container.InstantiatePrefabForComponent<Player>(prefab, position, Quaternion.identity, null);
            return player;
        }
    }
}
