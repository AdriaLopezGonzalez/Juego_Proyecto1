﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAI : MonoBehaviour
{
    public enum EState
    {
        Idle,
        Wander,
        Attack

    }
    FSM<EState> brain;

    public float speed;

    float _currentTime;
    Vector3 _direction;
    Transform _player;

    [SerializeField]
    private Transform[] movementPoints;
    [SerializeField]
    private float minDistance;

    private int nextStep;

    private SpriteRenderer spriteRenderer;

    public fireball fireballPrefab;
    public Transform FirePoint;
    public float FireballSpeed = 5;

    private float cooldownAttack = 2.0f;
    private float counterAttack;

    public GameObject particlePrefab;

    // Start is called before the first frame update
    void Start()
    {
        InitFSM();
        _player = GameObject.FindGameObjectWithTag("player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        Flip();
    }

    void InitFSM()
    {
        brain = new FSM<EState>(EState.Idle);

        brain.SetOnEnter(EState.Idle, () => _currentTime = 0);
        brain.SetOnEnter(EState.Wander, () => {
            _currentTime = 0;
            _direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
        });

        brain.SetOnStay(EState.Idle, UpdateIdle);
        brain.SetOnStay(EState.Wander, UpdateWander);
        brain.SetOnStay(EState.Attack, UpdateAttack);
    }

    // Update is called once per frame
    void Update()
    {
        brain.Update();
        Flip();
    }

    private void UpdateIdle()
    {
        if (_currentTime > 0)
        {
            brain.ChangeState(EState.Wander);
        }
        if (IsPLayerNear())
        {
            brain.ChangeState(EState.Attack);
        }

        _currentTime += Time.deltaTime;
    }

    private void UpdateWander()
    {
        transform.position = Vector2.MoveTowards(transform.position, movementPoints[nextStep].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, movementPoints[nextStep].position) < minDistance)
        {
            nextStep += 1;
            if (nextStep >= movementPoints.Length)
            {
                nextStep = 0;
            }
            Flip();
        }
        if (IsPLayerNear())
        {
            brain.ChangeState(EState.Attack);
        }
    }

    private void UpdateAttack()
    {
        counterAttack += Time.deltaTime;

        if(counterAttack > cooldownAttack)
        {
            AudioManager.instance.PlayAudio(AudioManager.instance.fireball);
            var particle = Instantiate(particlePrefab, GetComponent<Transform>().position, GetComponent<Transform>().rotation);
            Fire();
        }

        if (!IsPLayerNear())
        {
            brain.ChangeState(EState.Idle);
        }
    }

    void Fire()
    {
        fireball fireball = Instantiate(fireballPrefab, FirePoint.position, FirePoint.rotation);

        fireball.Init(FireballSpeed);

        counterAttack = 0;
    }

    private bool IsPLayerNear()
    {
        return Vector2.Distance(transform.position, _player.position) < 4;
    }

    private void Flip()
    {
        if (IsPLayerNear())
        {
            if (transform.position.x < _player.position.x)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
        }
        else
        {
            if (transform.position.x < movementPoints[nextStep].position.x)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
        }
    }
}
