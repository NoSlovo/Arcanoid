using System;
using UnityEngine;

public class ReflectionСomponent : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _forceImpulse;

    private Vector2 _direction = Vector2.up;
    private int _maxSpeed = 3000;
    private int _additionalSpeed = 100;

    public Rigidbody2D Rigidbody => _rigidbody;

    private void FixedUpdate()
    {
        _rigidbody.velocity = _direction * (_speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _direction = Vector2.Reflect(_direction, other.contacts[0].normal);
        _rigidbody.AddForce(_direction * _forceImpulse * (_speed * Time.fixedDeltaTime), ForceMode2D.Impulse);
        _speed = _speed < _maxSpeed ? _speed += _additionalSpeed : _speed;
    }

    public void SetMovementDirection(Vector2 direction)
    {
        if (direction == Vector2.zero)
        {
            throw new ArgumentException("The motion vector cannot be zero");
        }

        _direction = direction;
    }
}