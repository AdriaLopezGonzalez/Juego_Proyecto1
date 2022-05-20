using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangGun : weapon
{
    public boomerang boomerangPrefab;
    public Transform FirePoint;
    public float speed = 5;
    public Animator playerAnimator;

    private float cooldownShoot = 0f;
    private float lastShoot;
    // Start is called before the first frame update
    void Start()
    {

    }

    //Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            TryFire();
        }
    }

    void Fire()
    {
        var boomerang = Instantiate(boomerangPrefab, FirePoint.position, FirePoint.rotation);

        boomerang.Init(speed);
        // Animacion
        playerAnimator.SetTrigger("IsAttacking");
    }

    public override void TryFire()
    {
        if (CanShoot())
        {
            Fire();
            cooldownShoot = 2.0f;
            lastShoot = Time.time;
        }
    }

    private bool CanShoot()
    {
        return (lastShoot + cooldownShoot) < Time.time;
    }
}
