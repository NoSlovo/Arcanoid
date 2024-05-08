using UnityEngine;

public class CameraEdgeReflector : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private ReflectionСomponent reflectionСomponent;


    private void Update()
    {
        Vector3 viewportPosition = _mainCamera.WorldToViewportPoint(reflectionСomponent.transform.position);
        var motionVector = CalculateMotionVector(viewportPosition);

        if (motionVector != Vector2.zero)
        {
            motionVector = Quaternion.AngleAxis(45, Vector3.forward) * motionVector;
            reflectionСomponent.SetMovementDirection(motionVector);
        }
    }

    private Vector2 CalculateMotionVector(Vector3 viewportPosition)
    {
        Vector2 newDirection = Vector2.zero;

        if (viewportPosition.y < 0f ||  viewportPosition.y > 1f)
        {
            newDirection.y = Mathf.Sign(viewportPosition.y - 0.5f) * -1;
        }

        if (viewportPosition.x < 0f ||   viewportPosition.x > 1f)
        {
            newDirection.x = Mathf.Sign(viewportPosition.x - 0.5f) * -1;
        }

        return Vector2.Reflect(newDirection, Vector2.right);
    }
}