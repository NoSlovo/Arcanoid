using UnityEngine;

public class PlatformReflection : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out ReflectionСomponent reflectionСomponent))
        {
            var hitPoint = other.contacts[0].point;
            float difference = transform.position.x - hitPoint.x;

            if (hitPoint.x < transform.position.x)
            {
                reflectionСomponent.SetMovementDirection(new Vector2(Mathf.Abs(difference * 200), 100));
            }
            else
            {
                reflectionСomponent.SetMovementDirection(new Vector2(-Mathf.Abs(difference * 200), 100));
            }
        }
    }
}