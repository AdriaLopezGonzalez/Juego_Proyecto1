using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioMixer musicMixer, sfxMixer;

    public AudioSource backgroundMusic, stingerShoot, boomerangBounce, fireball, bigEnemyAttack, keyGrabbed, playerDamaged;

    public static AudioManager instance;

    [Range (-40, 10)]
    public float musicVolume, sfxVolume;
    public Slider musicSlider, sfxSlider;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayAudio(backgroundMusic);

        musicSlider.value = musicVolume;
        sfxSlider.value = sfxVolume;

        musicSlider.minValue = -40;
        musicSlider.maxValue = 10;

        sfxSlider.minValue = -40;
        sfxSlider.maxValue = 10;
    }

    // Update is called once per frame
    void Update()
    {
        MusicVolume();
        SfxVolume();
    }

    public void MusicVolume()
    {
        musicMixer.SetFloat("musicMasterVolume", musicSlider.value);
    }

    public void SfxVolume()
    {
        sfxMixer.SetFloat("sfxMasterVolume", sfxSlider.value);
    }

    public void PlayAudio(AudioSource Audio)
    {
        Audio.Play();
    }
}
