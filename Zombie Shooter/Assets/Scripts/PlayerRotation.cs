using System.Collections;
using UnityEngine;
    public class PlayerRotation : MonoBehaviour
    {
        [SerializeField, Min(0.1f)] private float _rotationSpeed = 5;

    void Update()
    {
        // Вращение по позиции мыши
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }

public void Rotate(Vector3 targetPosition)
    {
        // Get the direction to the target position
        Vector3 direction = targetPosition - transform.position;

        // Calculate the angle in degrees (using Y and X for Z-axis rotation)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Create a Quaternion representing the target rotation
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle); // Rotate around Z-axis

        // Smoothly rotate the character towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }
}