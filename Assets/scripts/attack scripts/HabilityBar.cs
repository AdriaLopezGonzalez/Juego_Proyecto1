using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HabilityBar : MonoBehaviour
{
    Slider _slider;

    public Gradient MyGradient;

    public Image FillImage;

    private float specialWeaponCooldown = 0;

    private float specialWeaponTimeInWeapon = 0;

    bool specialWeaponIsActive = false;

    void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    void Update()
    {
        if(!specialWeaponIsActive)
            specialWeaponCooldown += Time.deltaTime * 10f;

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (specialWeaponIsActive)
            {
                specialWeaponCooldown = 0;
                specialWeaponIsActive = false;
            }
        }

        if (specialWeaponCooldown >= 100.0f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                specialWeaponCooldown = 0f;

                specialWeaponIsActive = true;
            }
        }

        if (specialWeaponIsActive)
        {
            specialWeaponTimeInWeapon += Time.deltaTime * 8f;

            if (specialWeaponTimeInWeapon >= 50.0f)
            {
                specialWeaponCooldown = 0;
                specialWeaponTimeInWeapon = 0;
                specialWeaponIsActive = false;
            }
        }

        float fillBar = specialWeaponCooldown / 100.0f;
        _slider.value = fillBar;
        Color color = MyGradient.Evaluate(specialWeaponCooldown);
        FillImage.color = color;
    }
}
