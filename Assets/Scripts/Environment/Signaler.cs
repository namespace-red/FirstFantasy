using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Signaler : MonoBehaviour
{
    [SerializeField] private float _volumeChangeRate = 0.5f;
    [SerializeField] private ContactTracker _contactTracker;
     
    private Coroutine _coroutine;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0f;
    }

    private void OnEnable()
    {
        _contactTracker.Entered += PlaySignal;
        _contactTracker.CameОut += StopSignal;
    }

    private void OnDisable()
    {
        _contactTracker.Entered -= PlaySignal;
        _contactTracker.CameОut -= StopSignal;
    }
    
    private void PlaySignal()
    {
        _audioSource.loop = true;
        _audioSource.Play();
        
        ChangeVolume(1f);
    }

    private void StopSignal()
    {
        _audioSource.loop = false;
        _audioSource.Stop();
        _audioSource.Play();
        
        ChangeVolume(0f);
    }

    private void ChangeVolume(float targetVolume)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        
        _coroutine = StartCoroutine(ChangeVolumeCoroutine(targetVolume));
    }

    private IEnumerator ChangeVolumeCoroutine(float targetVolume)
    {
        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, 
                _volumeChangeRate * Time.deltaTime);
            
            yield return null;
        }

        _coroutine = null;
    }
}
