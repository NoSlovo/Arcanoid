using InputComponent;
using UnityEngine;

public class PlayerMoveComponent : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _moveSpeed = 1000;
    
    private readonly IPlayerInput _plauerPlayerInput = new PlayerInput();

    private void FixedUpdate()
    {
        var moveDirection= _plauerPlayerInput.GetMoveDirection();
        _rigidbody.velocity = moveDirection * (_moveSpeed * Time.fixedDeltaTime);
    }
}
