using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    private float volumeDelta = 0.1f;
    [SerializeField] private AudioSource _alarm;
    [SerializeField] private float _maxVolume;
    [SerializeField] private float _minVolume;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            _alarm.Play();
            IncreceVolume();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            DecreceVolume();
        }
    }

    public void IncreceVolume()
    {
       var increceVolume = StartCoroutine(IncreceVolumeCoroutine());

    }

    public void DecreceVolume()
    {
        var decreceVolume = StartCoroutine(DecreceVolumeCoroutine());
    }

    private IEnumerator IncreceVolumeCoroutine()
    {
        while (_alarm.volume < _maxVolume)
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, _maxVolume, volumeDelta * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator DecreceVolumeCoroutine()
    {
        while (_alarm.volume > _minVolume)
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, _minVolume, volumeDelta * Time.deltaTime);
            yield return null;
        }
    }
}
