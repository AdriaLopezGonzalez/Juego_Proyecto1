using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform Target;
    public Vector3 Offset;

    public float Smoothing = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(Target.position + Offset, transform.position, Smoothing * Time.deltaTime); 
    }
}
