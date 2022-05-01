using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRoute : MonoBehaviour
{
    [SerializeField] private Transform startPosition;
    [SerializeField] private Transform actualPosition;

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
        Gizmos.DrawLine(startPosition.position, actualPosition.position);
        Gizmos.DrawSphere(startPosition.position, 0.1f);
        Gizmos.DrawSphere(actualPosition.position, 0.1f);
    }
}
