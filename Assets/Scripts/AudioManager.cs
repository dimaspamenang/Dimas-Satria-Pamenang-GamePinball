using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource bgmAudioSource;
    public GameObject sfxAudioSource;
    public GameObject SwitchsfxAudioSource;

    // Start is called before the first frame update
    void Start()
    {   
        PlayBGM();
    }

    private void PlayBGM()
    {
        bgmAudioSource.Play();
    }

    public void PlaySFX(Vector3 spawnPosition)
    {
        GameObject.Instantiate(sfxAudioSource, spawnPosition, Quaternion.identity);
    }
    public void PlaySSFX(Vector3 spawnPosition)
    {
        GameObject.Instantiate(SwitchsfxAudioSource, spawnPosition, Quaternion.identity);
    }
}
