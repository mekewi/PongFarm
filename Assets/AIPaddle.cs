using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddle : MonoBehaviour
{
    public Transform ball;
    private Rigidbody2D _rigidbody;
    public float speed = 30;
    private float _lerpTweak = 2f;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (ball.position.y > transform.position.y)
        {
            Vector2 dir = new Vector2(0,1).normalized;
            _rigidbody.velocity = Vector2.Lerp(_rigidbody.velocity,dir*speed,_lerpTweak * Time.deltaTime);
        }
        else if (ball.position.y < transform.position.y)
        {
            Vector2 dir = new Vector2(0,-1).normalized;
            _rigidbody.velocity = Vector2.Lerp(_rigidbody.velocity,dir*speed,_lerpTweak * Time.deltaTime);
        }
        else
        {
            Vector2 dir = new Vector2(0,0).normalized;
            _rigidbody.velocity = Vector2.Lerp(_rigidbody.velocity,dir*speed,_lerpTweak * Time.deltaTime);
        }
    }
}
