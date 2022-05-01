using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectRoute : MonoBehaviour
{
    [SerializeField] private Transform startPosition;
    [SerializeField] private Transform endPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(startPosition.position, endPosition.position);
        Gizmos.DrawSphere(startPosition.position, 0.1f);
        Gizmos.DrawSphere(endPosition.position, 0.1f);
    }
}
