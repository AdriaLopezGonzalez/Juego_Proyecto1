using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovementAndRespawn : MonoBehaviour
{
    [SerializeField] private Transform respawn;

    private float speed = 3f;

    private Vector2 moveInput;
    private Rigidbody2D playerRigidBody;

    private Animator playerAnimator;

    public float smooth = 1.2f;

    public GameObject[] playerLifes;
    private int life;
    private float cooldownTakeDamage = 0f;
    private float lastHit;

    void Start()
    {
        life = playerLifes.Length;
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

    private void CheckLifes()
    {
        if (life < 1)
        {
            playerLifes[0].gameObject.SetActive(false);
            PlayerRespawn();
        }
        else if (life < 2)
        {
            playerLifes[1].gameObject.SetActive(false);
            playerAnimator.Play("Hit");
            speed = speed / 1.3f;
        }
        else if (life < 3)
        {
            playerLifes[2].gameObject.SetActive(false);
            playerAnimator.Play("Hit");
        }
        else if (life < 4)
        {
            playerLifes[3].gameObject.SetActive(false);
            playerAnimator.Play("Hit");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "spikes" || collision.gameObject.tag == "enemy" || collision.gameObject.tag == "fireball")
        {
            if (CanGetHit())
            {
                PlayerDamaged();
                cooldownTakeDamage = 0.8f;
                lastHit = Time.time;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "spikes" || collision.gameObject.tag == "enemy")
        {
            if (CanGetHit())
            {
                PlayerDamaged();
                cooldownTakeDamage = 0.8f;
                lastHit = Time.time;
            }
        }
    }

    private void PlayerRespawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void PlayerDamaged()
    {
        life--;
        CheckLifes();
    }

    private bool CanGetHit()
    {
        return (lastHit + cooldownTakeDamage) < Time.time;
    }

}
