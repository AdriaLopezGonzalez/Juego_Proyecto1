using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementAndRespawn : MonoBehaviour
{
    [SerializeField] private Transform respawn;

    private float speed = 3f;

    private Vector2 moveInput;
    private Rigidbody2D playerRigidBody;

    private Animator playerAnimator;

    public float smooth = 1.2f;

    public GameObject[] lifes;

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
        playerRigidBody.MovePosition(playerRigidBody.position + moveInput * speed * smooth * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "spikes" || collision.gameObject.tag == "enemy")
        {
            Debug.Log("player death");
            PlayerRespawn();
        }
    }

    private void PlayerRespawn()
    {
        transform.position = respawn.position;
    }

}
