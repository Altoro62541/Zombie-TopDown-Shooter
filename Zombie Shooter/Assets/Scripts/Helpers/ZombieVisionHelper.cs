using UnityEngine;
using ZombieShooter.PlayerEntity;

namespace ZombieShooter.Helpers
{
    public static class ZombieVisionHelper
    {
        public static bool TryGetPlayerInSphere(Vector3 center, Vector3 direction, float radius, out IPlayer player)
        {
            player = null;

            RaycastHit2D hit = Physics2D.CircleCast(center, radius, direction);
            if (hit.collider != null)
            {
                if (hit.collider.TryGetComponent(out player))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
