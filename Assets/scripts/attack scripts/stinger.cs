using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stinger : MonoBehaviour
{
    Rigidbody2D _rigidbody;

    // Start is called before the first frame update
   public void Init(float speed)
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
