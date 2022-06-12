using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomerang : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    private bool returning = false;
    public float timer;
    private float velocity;

    public GameObject particlePrefab;
    private void Update()
    {
        timer += 1.0f + Time.deltaTime;
        if (timer >= 60f)
        {
            GameObject.Destroy(gameObject);
        }
        else if (timer >= 25f && returning==false)
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
        if (!collision.collider.CompareTag("player") && !collision.collider.CompareTag("key") && !collision.collider.CompareTag("boomerang") && !collision.collider.CompareTag("water"))
        {
            if(!collision.collider.CompareTag("player") && !collision.collider.CompareTag("key") && !collision.collider.CompareTag("boomerang") && !collision.collider.CompareTag("enemy"))
            {
                AudioManager.instance.PlayAudio(AudioManager.instance.boomerangBounce);
                var particle = Instantiate(particlePrefab, GetComponent<Transform>().position, GetComponent<Transform>().rotation);
            }

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
