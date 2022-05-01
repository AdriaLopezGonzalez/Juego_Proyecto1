using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateMessage : MonoBehaviour
{
    [SerializeField] private GameObject messageWithoutKey;
    [SerializeField] private GameObject messageWithKey;
    // Start is called before the first frame update
    void Start()
    {
        messageWithoutKey.SetActive(false);
        messageWithKey.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            messageWithoutKey.SetActive(true);
        }
        if (collision.gameObject.tag == "key")
        {
            messageWithKey.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            messageWithoutKey.SetActive(false);
        }
        if (collision.gameObject.tag == "key")
        {
            messageWithKey.SetActive(false);
        }
    }
}
