using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stinger : MonoBehaviour
{
    Rigidbody2D _rigidbody;

    public float timer;

    private void Update()
    {
        timer += 1.0f + Time.deltaTime;
        if (timer >= 500.0f)
        {
            GameObject.Destroy(gameObject);
        }
    }
    public void Init(float speed)
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("player") && !collision.collider.CompareTag("key") && !collision.collider.CompareTag("stinger"))
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
