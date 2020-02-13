using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCubeScript : MonoBehaviour
{
    [SerializeField] private int _band;

    [SerializeField] private float _startScale, _scaleMultiplier;

    void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x, (AudioInputManager._frequencyBands[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
    }
}
