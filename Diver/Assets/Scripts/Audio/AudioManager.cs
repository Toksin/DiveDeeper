using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private void Awake() { instance = this; }
    


    [Header("Компоненты")]
    public GameObject soundObject;

    [Header("Звуковые эффекты")]
    public AudioClip sfx_jump;
    public AudioClip sfx_rope;
    public AudioClip sfx_take;
    public AudioClip sfx_put;
    public AudioClip sfx_click;

    [Header("Музыка")]
    public AudioClip music_firstLayerBack;
    public AudioClip music_secondLayerBack;

    [Header("Музыка которая играет")]
    public GameObject currentMusicObj;

    public void PlaySFX(string sfxName)
    {
        switch(sfxName)
        {
            case "jump":
                SoundObjCreation(sfx_jump);
                break;
            case "rope":
                SoundObjCreation(sfx_rope);
                break;
            case "take":
                SoundObjCreation(sfx_take);
                break;
            case "put":
                SoundObjCreation(sfx_put);
                break;
            case "sfx_click":
                SoundObjCreation(sfx_click);
                break;           
        }
    }

    void SoundObjCreation(AudioClip clip)
    {
        GameObject newObj = Instantiate(soundObject, transform);
        newObj.GetComponent<AudioSource>().clip = clip;
        newObj.GetComponent <AudioSource>().Play();
    }

    public void PlayMusic(string musicName)
    {
        switch (musicName)
        {
            case "firstLayerBack":
                MusicObjCreation(music_firstLayerBack);
                break;
            case "secondLayerBack":
                MusicObjCreation(music_firstLayerBack);
                break;

        }
    }

    void MusicObjCreation(AudioClip clip)
    {
        if (currentMusicObj)
        {
            Destroy(currentMusicObj);
        }

        currentMusicObj = Instantiate(soundObject, transform);
        currentMusicObj.GetComponent<AudioSource>().clip = clip;
        currentMusicObj.GetComponent <AudioSource>().loop = true;
        currentMusicObj.GetComponent<AudioSource>().volume = 0.018f;
        currentMusicObj.GetComponent<AudioSource>().Play();
    }


}
