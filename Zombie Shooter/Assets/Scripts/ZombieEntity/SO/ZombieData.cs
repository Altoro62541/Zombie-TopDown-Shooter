using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.ZombieEntity.SO
{
    public class ZombieData : ScriptableObject
    {
        [SerializeField] private float _health;
        [SerializeField] private float _speedMove;
    }
}