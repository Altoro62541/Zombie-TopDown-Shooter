using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using ZombieShooter.AI.ZombieAI;

namespace ZombieShooter.ZombieEntity
{
    public class ZombieRotation : MonoBehaviour
    {

        private IZombieAI _ai;
        private float _rotationSpeed = 5f;

        private void Awake()
        {
            _ai = GetComponent<IZombieAI>();
            float randomZRotation = Random.Range(0f, 360f);
            transform.rotation = Quaternion.Euler(0f, 0f, randomZRotation);
        }

        private void Update()
        {
            if (!_ai.IsEndingMove)
            {
                Vector3 direction = (_ai.SteeringTarget - transform.position).normalized; // Получаем направление к целевой точке
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Вычисляем угол
                Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle); // Создаем кватернион для поворота
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime); // Плавный поворот
            }
        }
    }
}