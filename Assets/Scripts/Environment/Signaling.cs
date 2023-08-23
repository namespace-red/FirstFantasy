using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Signaling : MonoBehaviour
{
    [SerializeField] private float _volumeChangeRate = 0.5f;
    
    private Coroutine _activeCoroutine;
    private AudioSource _audioSource;
    private float _targetVolume;
    
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0f;
    }

    private void StartVolumeChangeCoroutine()
    {
        if (_activeCoroutine != null)
        {
            StopCoroutine(_activeCoroutine);
        }
        
        _activeCoroutine = StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        while (_audioSource.volume != _targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _volumeChangeRate * Time.deltaTime);
            yield return null;
        }
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
