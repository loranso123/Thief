using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;

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
        while (_alarm.volume < 0.2)
        {
            _alarm.volume += 0.0003f;
            yield return null;
        }
    }

    private IEnumerator DecreceVolumeCoroutine()
    {
        while (_alarm.volume > 0)
        {
            _alarm.volume -= 0.0003f;
            yield return null;
        }
    }
}
