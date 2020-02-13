using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LyricScript : MonoBehaviour
{
    [SerializeField] private TextMeshPro _lyrics;

    [SerializeField] private GameObject _audioTrigger, _pauseBtn;

    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private List<GameObject> _audioCubes = new List<GameObject>();

    public static bool musicStarted = false;

    private double timer;

    private bool _playMusic = false;
    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            RaycastHit hit;

            if (_audioTrigger.GetComponent<Collider>().Raycast(ray, out hit, 1000.0f))
            {
                _audioSource.Play();
                _playMusic = true;
                _audioTrigger.SetActive(false);
                _pauseBtn.SetActive(true);
            }
            else if (_pauseBtn.GetComponent<Collider>().Raycast(ray, out hit, 1000.0f))
            {
                _playMusic = false;
                _audioSource.Stop();
                _audioTrigger.SetActive(true);
                _pauseBtn.SetActive(false);
                _lyrics.text = "";
                musicStarted = false;
                timer = 0;

                foreach (GameObject cube in _audioCubes)
                {
                    cube.SetActive(false);
                }
            }
        }
        if (_playMusic)
        {
            timer += Time.deltaTime;
            if (timer < 12 && timer > 4)
            {
                _lyrics.text = "Sing along to make Goldilocks fall asleep";
                foreach (GameObject cube in _audioCubes)
                {
                    cube.SetActive(true);
                }
                musicStarted = true;
            }
            if (timer >= 13)
            {
                _lyrics.text = "Brille, brille, petite étoile, Au coeur";
            }
            if (timer >= 18)
            {
                _lyrics.text = "de la nuit trés noire Loin loin loin ta";
            }
            if (timer >= 24)
            {
                _lyrics.text = "lumiére Comme un diamant au ciel";
            }
            if (timer >= 30.5)
            {
                _lyrics.text = "Brille, brille, petite étoile, Au coeur";
            }
            if (timer >= 36)
            {
                _lyrics.text = "de la nuit trés noire";
            }
            if (timer >= 48)
            {
                _lyrics.text = "Brille, brille, petite étoile, Au coeur";
            }
            if (timer >= 55)
            {
                _lyrics.text = "de la nuit trés noire Loin loin loin ta";
            }
            if (timer >= 61)
            {
                _lyrics.text = "lumiére Comme un diamant au ciel";
            }
            if (timer >= 66.5)
            {
                _lyrics.text = "Brille, brille, petite étoile, Au coeur";
            }
            if (timer >= 71.5)
            {
                _lyrics.text = "de la nuit trés noire";
            }
            if (timer >= 76)
            {
                foreach (GameObject cube in _audioCubes)
                {
                    cube.SetActive(false);
                }
                musicStarted = false;
                _audioTrigger.SetActive(true);
                _lyrics.text = "";
                timer = 0;
                _playMusic = false;
            }
        }
    }

}
