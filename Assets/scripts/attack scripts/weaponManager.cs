using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponManager : MonoBehaviour
{
    [SerializeField]
    public weapon[] AllWeapons;
    public GameObject[] weaponIcons;

    int _currentWeaponIndex;

    weapon CurrentWeapon => AllWeapons[_currentWeaponIndex];
    GameObject CurrentWeaponIndex => weaponIcons[_currentWeaponIndex];

    private void Start()
    {
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            NextWeapon();
        }
    }
    public void NextWeapon()
    {
        DeactivateAll();
        _currentWeaponIndex++;
        _currentWeaponIndex = _currentWeaponIndex % AllWeapons.Length;
        CurrentWeapon.gameObject.SetActive(true);
        CurrentWeaponIndex.gameObject.SetActive(true);
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
