using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [HideInInspector] public SpriteRenderer Target;
    [SerializeField] private float _duration;

    [SerializeField] private Color _targetColor;
    private float _ranningTime;
    private Color _startColor;

    private void Start()
    {
        Target = GetComponent<SpriteRenderer>();
        _startColor = Target.color;
    }


    private void Update()
    {
        if (_ranningTime <= _duration)
        {
            _ranningTime += Time.deltaTime;

            float normalizeRunningTime = _ranningTime / _duration;

            
            Target.color = Color.Lerp(_startColor, _targetColor, normalizeRunningTime);
        }
    }
}
