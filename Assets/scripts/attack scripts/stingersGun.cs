﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stingersGun : weapon
{
    public stinger stingerPrefab;
    public Transform FirePoint;
    public float speed = 5;

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
        var stinger = Instantiate(stingerPrefab, FirePoint.position, FirePoint.rotation);

        stinger.Init(speed);
    }

    public override void TryFire()
    {
        if (CanShoot())
        {
            Fire();
            cooldownShoot = 0.5f;
            lastShoot = Time.time;
        }
    }

    private bool CanShoot()
    {
        return (lastShoot + cooldownShoot) < Time.time;
    }
}
