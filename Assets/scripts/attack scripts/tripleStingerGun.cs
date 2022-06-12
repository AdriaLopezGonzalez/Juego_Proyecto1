using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tripleStingerGun : weapon
{
    public stinger stingerPrefab;
    public Transform FirePoint1;
    public Transform FirePoint2;
    public Transform FirePoint3;
    public float speed = 5;

    private float cooldownShoot = 0f;
    private float lastShoot;
    public Animator playerAnimator;
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
        var stinger1 = Instantiate(stingerPrefab, FirePoint1.position, FirePoint1.rotation);
        var stinger2 = Instantiate(stingerPrefab, FirePoint2.position, FirePoint2.rotation);
        var stinger3 = Instantiate(stingerPrefab, FirePoint3.position, FirePoint3.rotation);

        stinger1.Init(speed);
        stinger2.Init(speed);
        stinger3.Init(speed);

        playerAnimator.SetTrigger("IsAttacking");

    }

    public override void TryFire()
    {
        if (CanShoot())
        {
            AudioManager.instance.PlayAudio(AudioManager.instance.stingerShoot);
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
