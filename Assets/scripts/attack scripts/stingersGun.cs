using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stingersGun : weapon
{
    public stinger BulletPrefab;
    public Transform FirePoint;
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

     //Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    void Fire()
    {
        var bullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);

        bullet.Init(speed);
    }

    public override void TryFire()
    {
        Fire();
    }
}
