using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    Rigidbody2D _rigidbody;

    public float timer;

    private void Update()
    {
        timer += 1.0f + Time.deltaTime;
        if (timer >= 700.0f)
        {
            GameObject.Destroy(gameObject);
        }
    }
    public void Init(float speed)
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = transform.right * speed;
    }

    private void OnColliderEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "enemy" && collision.gameObject.tag != "player" && collision.gameObject.tag != "stinger" && collision.gameObject.tag != "boomerang")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "enemy" && collision.gameObject.tag != "key" && collision.gameObject.tag != "spikes" && collision.gameObject.tag != "stinger" && collision.gameObject.tag != "boomerang")
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
