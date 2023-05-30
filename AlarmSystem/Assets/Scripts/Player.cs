using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof (Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector2 _direction;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _direction.x = Input.GetAxisRaw("Horizontal");
        _direction.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + _direction * _speed * Time.fixedDeltaTime);
    }
}
