using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Video;

[RequireComponent (typeof (AudioSource))]
public class AudioInputManager : MonoBehaviour
{
    [SerializeField] private AudioSource _micAudio;

    [SerializeField] private float _minVolume;

    [SerializeField] private float[] _samples = new float[512];

    [SerializeField] private GameObject _eyes1, _eyes2, _sleepyFace;

    public static float[] _frequencyBands = new float[8];

    private string _device;

    private float _micVolume;

    private double _timer;

    // Start is called before the first frame update
    void Start()
    {
        //Application.RequestUserAuthorization(UserAuthorization.Microphone);
        //if (Application.HasUserAuthorization(UserAuthorization.Microphone))
        //{
        //    if (Microphone.devices.Length > 0)
        //    {
        //        _device = Microphone.devices[0].ToString();
        //        Debug.Log(_device);
        //        _micAudio.clip = Microphone.Start(_device, true, 100, AudioSettings.outputSampleRate);
        //        _micAudio.loop = true;
        //    }
        //    _micAudio.Play();

        //}
    }

    private void Update()
    {

        if (LyricScript.musicStarted)
        {
            _sleepyFace.SetActive(true);
            _eyes2.SetActive(true);
            //HandleVoiceInput();
            //CreateFrequencyBands();
        }
        else if (!LyricScript.musicStarted)
        {
            _timer += Time.deltaTime;
            _sleepyFace.SetActive(false);
            _eyes1.SetActive(false);
            _eyes2.SetActive(false);
        }
    }

    private void HandleVoiceInput()
    {
       // _micAudio.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
        _micVolume = GetInputVolume();

        if (_micVolume > _minVolume)
        {
            _timer = 0;
            _eyes2.SetActive(true);
            _eyes1.SetActive(false);
        }
        else
        {
            _timer += Time.deltaTime;
            if (_timer >= 2)
            {
                _eyes2.SetActive(false);
                _eyes1.SetActive(true);
            }
        }         
    }

    private float GetInputVolume()
    {
        float highestVolume = 0;

        for (int i = 0; i < _samples.Length; i++)
        {
            float peak = _samples[i] * _samples[i];

            if (highestVolume < peak)
            {
                highestVolume = peak;
            }
        }

        return highestVolume;
    }

    //private void CreateFrequencyBands()
    //{
    //    int count = 0;

    //    for (int i = 0; i < _frequencyBands.Length; i++)
    //    {
    //        int sampleCount = (int)Mathf.Pow(2, i) * 2;

    //        float average = 0;

    //        if (i == 7)
    //        {
    //            sampleCount += 2;
    //        }

    //        for (int j = 0; j < sampleCount; j++)
    //        {
    //            average += _samples[count] * (count + 1);
    //            count++;
    //        }

    //        average /= count;

    //        _frequencyBands[i] = average * 10;
    //    }
    //}
}
