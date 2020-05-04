using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public float speed = 30;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = Vector2.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Player") || other.gameObject.tag.Equals("AI"))
        {
            HandlePaddleHit(other.collider);
            SoundManager.Instance.PlayOneSHot(SoundManager.Instance.paddleHit);
        }

        if (other.gameObject.tag.Equals("UpperWall")|| other.gameObject.tag.Equals("BottomWall"))
        {
            SoundManager.Instance.PlayOneSHot(SoundManager.Instance.paddleHit);       
        }

        if (other.collider.tag.Equals("RightWall") || other.collider.tag.Equals("LeftWall"))
        {
            if (other.gameObject.tag.Equals("RightWall"))
            {
                MainUI.Instace.AddScore(PlayerType.player);
            }
            else if (other.gameObject.tag.Equals("LeftWall"))
            {
                MainUI.Instace.AddScore(PlayerType.AI);
            }
            SoundManager.Instance.PlayOneSHot(SoundManager.Instance.goal);
        }
    }

    private void HandlePaddleHit(Collider2D col)
    {
        float y = BallHitPaddleWhere(transform.position,
            col.transform.position,
            col.bounds.size.y);
 
        // Vector ball moves to
        Vector2 dir = new Vector2();

        if(col.gameObject.tag.Equals("Player"))
        {
            dir = new Vector2(1, y).normalized;
        }
 
        if (col.gameObject.tag.Equals("AI"))
        {
            dir = new Vector2(-1, y).normalized;
        }
        _rigidbody2D.velocity = dir * speed;    
    }
    private float BallHitPaddleWhere(Vector2 ball, Vector2 col, float sizeY)
    {
        return (ball.y - col.y) / sizeY;
    }
}
