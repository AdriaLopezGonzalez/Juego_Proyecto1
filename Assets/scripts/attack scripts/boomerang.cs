using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomerang : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    private bool returning = false;
    public float timer;
    private float velocity;

    private void Update()
    {
        timer += 1.0f + Time.deltaTime;
        if (timer >= 200f)
        {
            GameObject.Destroy(gameObject);
        }
        else if (timer >= 100f && returning==false)
        {
            _rigidbody.velocity = transform.right * -velocity;
            returning = true;
        }
        Debug.Log(timer);
    }
    public void Init(float speed)
    {
        
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = transform.right * speed;
        
        velocity = speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("player") && !collision.collider.CompareTag("key") && !collision.collider.CompareTag("boomerang"))
        {
            _rigidbody.velocity = transform.right * -velocity;
            returning = true;

        }
        if ((collision.collider.CompareTag("player") || collision.collider.CompareTag("key")) && returning == true)
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
