using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponManager : MonoBehaviour
{
    [SerializeField]
    public weapon[] AllWeapons;
    public GameObject[] weaponIcons;

    public weapon specialWeapon;
    public GameObject specialWeaponIcon;

    private float specialWeaponCooldown = 0;
    private float specialWeaponTimeInWeapon = 0;

    private bool specialWeaponIsActive = false;

    int _currentWeaponIndex;

    weapon CurrentWeapon => AllWeapons[_currentWeaponIndex];
    GameObject CurrentWeaponIcons => weaponIcons[_currentWeaponIndex];

    private void Start()
    {
        
    }

    public void Update()
    {
        specialWeaponCooldown += Time.deltaTime * 10f;

        if (Input.GetKeyDown(KeyCode.R))
        {
            NextWeapon();

            if(specialWeaponIsActive == true)
            {
                specialWeaponCooldown = 0;
                specialWeaponIsActive = false;
            }

            specialWeapon.gameObject.SetActive(false);
            specialWeaponIcon.SetActive(false);
        }

        if (specialWeaponCooldown >= 100.0f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ActivateSpecialWeapon();

                specialWeaponIsActive = true;
            }
        }

        if(specialWeaponIsActive == true)
        {
            specialWeaponTimeInWeapon += Time.deltaTime * 8f;

            if(specialWeaponTimeInWeapon >= 50.0f)
            {
                specialWeapon.gameObject.SetActive(false);
                specialWeaponIcon.SetActive(false);

                specialWeaponCooldown = 0;
                specialWeaponTimeInWeapon = 0;
                specialWeaponIsActive = false;

                NextWeapon();
            }
        }
    }

    public void NextWeapon()
    {
        DeactivateAll();
        _currentWeaponIndex++;
        _currentWeaponIndex = _currentWeaponIndex % AllWeapons.Length;
        CurrentWeapon.gameObject.SetActive(true);
        CurrentWeaponIcons.gameObject.SetActive(true);
    }

    public void ActivateSpecialWeapon()
    {
        CurrentWeapon.gameObject.SetActive(false);
        CurrentWeaponIcons.gameObject.SetActive(false);

        specialWeapon.gameObject.SetActive(true);
        specialWeaponIcon.SetActive(true);
    }

    void DeactivateAll()
    {
        foreach(var weapon in AllWeapons)
        {
            weapon.gameObject.SetActive(false);
        }

        foreach (var weaponIcon in weaponIcons)
        {
            weaponIcon.gameObject.SetActive(false);
        }
    }
}
