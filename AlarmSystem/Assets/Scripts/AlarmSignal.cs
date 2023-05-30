using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class AlarmSignal : MonoBehaviour
{
    [SerializeField] private float _step;
    [SerializeField] private Trigger _trigger;
    [SerializeField] private AudioSource _audioSource;

    private Coroutine _coroutine;

    private const float MaxVolume = 1;
    private const float MinVolume = 0;

    private void OnEnable()
    {
        _trigger.Entered += Activate;
        _trigger.Exited += DeActivate;
    }

    private void OnDisable()
    {
        _trigger.Entered -= Activate;
        _trigger.Exited -= DeActivate;
    }

    private void Activate()
    {
        StopCoroutine();
        _coroutine = StartCoroutine(ChangeVolume(MaxVolume));
    }

    private void DeActivate()
    {
        StopCoroutine();
        _coroutine = StartCoroutine(ChangeVolume(MinVolume));
    }

    private void StopCoroutine()
    {
        if(_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator ChangeVolume(float targgetValue)
    {
        _audioSource.Play();

        while (Math.Abs(_audioSource.volume - targgetValue) > Mathf.Epsilon)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targgetValue, _step * Time.deltaTime);

            yield return null;
        }

        if (_audioSource.volume == 0)
            _audioSource.Stop();
    }
}