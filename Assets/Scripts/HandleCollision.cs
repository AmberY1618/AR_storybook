using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class HandleCollision : MonoBehaviour
{
    [SerializeField] private TextMesh _popUpText;
    [SerializeField] private GameObject _normalFace, _happyFace, _unhappyFace, _goldilocks, _hand;
    public static bool animationPlaying;
    private double _timer;
    private void Start()
    {
        //_goldilocks.SetActive(false);
    }
    private void Update()
    {
        if (animationPlaying)
        {
            _timer += Time.deltaTime;
        }
        if (_timer >= 3)
        {
            animationPlaying = false;
            _timer = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //_goldilocks.SetActive(true);
        if (other.gameObject.CompareTag("mediumPorridge"))
        {
            animationPlaying = true;
            _unhappyFace.SetActive(false);
            _happyFace.SetActive(true);
            _hand.GetComponent<Animation>().Play();
            _normalFace.GetComponent<Animation>().Play();
            new WaitForSeconds(1);
            _happyFace.GetComponent<Animation>().Play();
            _popUpText.text = "Just right!";
            DragObject.canStay = true;
            other.gameObject.GetComponent<Animator>().SetTrigger("Disappear");
            StartCoroutine(WaitAndRestorePosition(other.gameObject, DragObject.startPos, 1f));
        }
        else if (other.gameObject.CompareTag("hotPorridge"))
        {
            animationPlaying = true;
            _unhappyFace.SetActive(true);
            _happyFace.SetActive(false);
            _hand.GetComponent<Animation>().Play();
            _normalFace.GetComponent<Animation>().Play();
            new WaitForSeconds(1);
            _unhappyFace.GetComponent<Animation>().Play();
            _popUpText.text = "Too hot!";
            DragObject.canStay = true;
            other.gameObject.GetComponent<Animator>().SetTrigger("Disappear");
            StartCoroutine(WaitAndRestorePosition(other.gameObject, DragObject.startPos, 1f));
        }
        else if (other.gameObject.CompareTag("coldPorridge"))
        {
            animationPlaying = true;
            _unhappyFace.SetActive(true);
            _happyFace.SetActive(false);
            _hand.GetComponent<Animation>().Play();
            _normalFace.GetComponent<Animation>().Play();
            new WaitForSeconds(1);
            _unhappyFace.GetComponent<Animation>().Play();
            _popUpText.text = "Too cold!";
            DragObject.canStay = true;
            other.gameObject.GetComponent<Animator>().SetTrigger("Disappear");
            StartCoroutine(WaitAndRestorePosition(other.gameObject, DragObject.startPos, 1f));
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("coldPorridge") || other.gameObject.tag == "hotPorridge" || other.gameObject.tag == "mediumPorridge")
        {
            _popUpText.text = "";
        }
    }
    IEnumerator WaitAndRestorePosition(GameObject go, Vector3 pos, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        go.transform.localPosition = pos;
        DragObject.canStay = false;
    }
}