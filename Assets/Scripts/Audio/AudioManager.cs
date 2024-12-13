using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clips")]

    public AudioClip EnemySpawnSFX;
    public AudioClip EnemyGetsToBaseSFX;
    public AudioClip NextWaveSFX;
    public AudioClip TowerPlacementSFX;

    public void PlaySFX(AudioClip clip) {
        SFXSource.PlayOneShot(clip);
    }

}
