using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 3f;

    private Vector2 moveInput;
    private Rigidbody2D playerRigidBody;

    private Animator playerAnimator;

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;

        playerAnimator.SetFloat("Horizontal", moveX);
        playerAnimator.SetFloat("Vertical", moveY);
        playerAnimator.SetFloat("Speed", moveInput.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        playerRigidBody.MovePosition(playerRigidBody.position + moveInput * speed * Time.fixedDeltaTime);
    }
}
