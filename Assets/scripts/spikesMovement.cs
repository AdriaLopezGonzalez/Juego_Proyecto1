using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikesMovement : MonoBehaviour
{
    [SerializeField] private Transform destination;
    [SerializeField] private float speed;
    [SerializeField] private float timeStopped;

    private Vector3 startPos, endPos;
    private bool moving;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        destination.parent = null;

        startPos = transform.position;
        endPos = destination.position;

        moving = true;
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination.position, speed * Time.deltaTime);

            if (transform.position == destination.position)
            {
                if (destination.position == endPos)
                {
                    destination.position = startPos;
                }
                else
                {
                    destination.position = endPos;
                }
                moving = false;
            }
        }
        else
        {
            time += Time.deltaTime;
            if (time >= timeStopped)
            {
                time = 0.0f;
                moving = true;
            }
        }
    }
}
