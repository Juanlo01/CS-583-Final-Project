using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clips")]

    public AudioClip TurretFireSFX;
    public AudioClip PlaceTurretSFX;
    public AudioClip NextWaveSFX;

    public void PlaySFX(AudioClip clip) {
        SFXSource.PlayOneShot(clip);
    }

}
