using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
namespace ZombieShooter.InventorySystem.SO
{
    [CreateAssetMenu(fileName = "ShellEjectConfig", menuName = "Configs/Shell Ejector Config")]
    public class ShellEjectConfig : ScriptableConfig
    {
        [SerializeField] private GameObject _shellPrefab;
        [SerializeField, MinValue(0.1f)] private float _ejectForce = 5f;
        [SerializeField, MinValue(0.3f)] private float _fadeDuration = 1f;
        [SerializeField, MinValue(0.3f)] private float _lifeTime = 2f;   

        public float EjectForce => _ejectForce;
        public float FadeDuration => _fadeDuration;
        public float LifeTime => _lifeTime;
        

    }
}

