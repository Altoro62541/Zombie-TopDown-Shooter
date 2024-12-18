
using System.Collections.Generic;
using UnityEngine;
namespace ZombieShooter.ZombieEntity.SO
{
    [CreateAssetMenu(menuName = "Zombies/ZombieSpawnerConfig")]
    public class ZombieSpawnerConfig : ScriptableConfig
    {
        [SerializeField] private ZombieSpawnConfigElement[] _elements;
        public  IEnumerable<ZombieSpawnConfigElement> Elements => _elements;
    }
}

