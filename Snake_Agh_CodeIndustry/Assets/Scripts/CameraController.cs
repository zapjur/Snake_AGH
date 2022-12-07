using System.ComponentModel;
using UnityEngine;
[ExecuteInEditMode]
public class CameraController : MonoBehaviour
{

    public Transform snake;
    public Vector3 offset;
    public float smoothSpeed = 5f;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPosition = snake.TransformPoint(offset);
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothPosition;
        transform.LookAt(snake);
    }
}
