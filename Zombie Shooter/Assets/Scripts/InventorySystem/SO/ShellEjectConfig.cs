using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZombieShooter.InventorySystem.SO
{
    [CreateAssetMenu(fileName = "ShellEjectConfig", menuName = "Configs/Shell Ejector Config")]
    public class ShellEjectConfig : ScriptableConfig
    {
        public GameObject shellPrefab;
        public float ejectForce = 5f;
        public float fadeDuration = 1f;
        public float lifeTime = 2f;      
    }
}

