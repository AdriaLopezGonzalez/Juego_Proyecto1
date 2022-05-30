using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleLife : MonoBehaviour
{
    public float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer>=1f)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
