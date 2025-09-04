using UnityEngine;
using System.Collections.Generic;

public class AnimationSound : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> _audioClips;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(int audioClipIndex)
    {
        AudioClip audioClip = _audioClips[audioClipIndex];
        _audioSource.clip = audioClip;
        _audioSource.Play();
    }
}