using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ZombieShooter.Extensions
{
    public static class EventSystemExtensions
    {
        public static bool IsPointerOverUIObject(this EventSystem eventSystem)
        {
            Vector2 position = Vector2.zero;
#if UNITY_STANDALONE
             position = new(Input.mousePosition.x, Input.mousePosition.y);
#endif
#if UNITY_ANDROID || UNITY_IOS
            var positionTouch = Input.GetTouch(0).position;
            position = new(position.x, positionTouch.y);
#endif
            var eventDataCurrentPosition = new PointerEventData(eventSystem);
            eventDataCurrentPosition.position = new(Input.mousePosition.x, Input.mousePosition.y);
            List<RaycastResult> results = new();
            eventSystem.RaycastAll(eventDataCurrentPosition, results);
            return results.Count > 0;
        }
    }
}
