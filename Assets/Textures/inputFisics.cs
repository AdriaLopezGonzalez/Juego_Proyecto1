using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class inputFisics : MonoBehaviour
{
    float _horizontal;
    float _vertical;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(_horizontal + " / " + _vertical);
    }

    private void OnMove(InputValue inputValue)
    {
        _horizontal = inputValue.Get<Vector2>().x;
        _vertical = inputValue.Get<Vector2>().y;
    }
}
