using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class mouseController : MonoBehaviour
{
    private Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        if (mousePos.x <= Screen.width/2)
        {
            playerAnimator.SetFloat("AttackDirection",1);
        }
        else
        {
            playerAnimator.SetFloat("AttackDirection", 0);
        }
        Debug.Log(mousePos.x);
    }
}
