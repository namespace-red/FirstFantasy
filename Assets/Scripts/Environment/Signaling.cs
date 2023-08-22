using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Signaling : MonoBehaviour
{
    [SerializeField] private float _volumeChangeRate = 0.5f;
    
    private Coroutine _activeCoroutine;
    private AudioSource _audioSource;
    private float _targetVolume;
    private bool _isCoroutineRunning = false;
    
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0f;
    }

    private void StartVolumeChangeCoroutine()
    {
        if (_isCoroutineRunning)
        {
            StopCoroutine(_activeCoroutine);
        }
        else
        {
            _activeCoroutine = StartCoroutine(ChangeVolume());
        }
    }

    private IEnumerator ChangeVolume()
    {
        _isCoroutineRunning = true;
        
        while (_audioSource.volume != _targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _volumeChangeRate * Time.deltaTime);
            yield return null;
        }
        
        _isCoroutineRunning = false;
    }
    
    public void PlaySignal()
    {
        _audioSource.loop = true;
        _audioSource.Play();
        _targetVolume = 1f;
        
        StartVolumeChangeCoroutine();
    }

    public void StopSignal()
    {
        _audioSource.loop = false;
        _audioSource.Stop();
        _audioSource.Play();
        _targetVolume = 0f;
        
        StartVolumeChangeCoroutine();
    }
}
