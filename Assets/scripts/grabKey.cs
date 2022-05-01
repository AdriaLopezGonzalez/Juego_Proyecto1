using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabKey : MonoBehaviour
{
    [SerializeField] private Transform key;

    private Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("key"))
        {
            Debug.Log("grab key");
            playerAnimator.SetTrigger("keyGrabbed");
            KeyGrabbed();
        }
    }

    private void KeyGrabbed()
    {
        transform.tag = "key";
    }
}
