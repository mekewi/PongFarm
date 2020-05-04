using UnityEngine;

public class MoveContoller : MonoBehaviour
{
    public float speed = 30;
    private Rigidbody2D body;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float vDir = Input.GetAxisRaw("Vertical");
        body.velocity = new Vector2(0, vDir * speed);
    }
}
