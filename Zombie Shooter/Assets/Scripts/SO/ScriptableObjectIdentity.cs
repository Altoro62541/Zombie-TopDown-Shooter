using System;
using UnityEngine;

namespace ZombieShooter.SO
{
    public class ScriptableObjectIdentity : ScriptableObject, IIdentity
    {
        [SerializeField] private string _guidObject = Guid.NewGuid().ToString();

        public string GUID => _guidObject;
    }
}
