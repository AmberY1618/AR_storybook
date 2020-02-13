using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PickChair : MonoBehaviour
{
    [SerializeField] private List<GameObject> _chairIcons = new List<GameObject>();

    [SerializeField] private List<GameObject> _otherObjects = new List<GameObject>();

    private Collider _chair;

    private bool _canMove;

    [SerializeField] private GameObject _videoQuad;

    private void Start()
    {
        _videoQuad.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            RaycastHit hit;

            if (Physics.Raycast(ray.origin, ray.direction, out hit, 1000.0f))
            {
                GameObject go = hit.collider.gameObject;

                if (go.tag == "Chair1")
                {
                    if (CheckIfChairIsHidden(go))
                    {
                        go.SetActive(false);
                        _chairIcons[0].SetActive(true);
                    }
                }
                else if (go.tag == "Chair2")
                {
                    if (CheckIfChairIsHidden(go))
                    {
                        go.SetActive(false);
                        _chairIcons[1].SetActive(true);
                    }
                }
                else if (go.tag == "Chair3")
                {
                    if (CheckIfChairIsHidden(go))
                    {
                        go.SetActive(false);
                        _chairIcons[2].SetActive(true);
                    }
                }
            }
        }

        int icons = 0;
        foreach (GameObject chair in _chairIcons)
        {
            if (chair.activeInHierarchy)
            {
                icons++;
            }
        }

        if (icons == 3)
        {
            _videoQuad.SetActive(true);
            _videoQuad.GetComponent<VideoPlayer>().Play();
        }
    }

    // Can maybe be done by checking the layer of the object instead
    private bool CheckIfChairIsHidden(GameObject chair)
    {
        foreach (GameObject obj in _otherObjects)
        {
            if (Vector3.Distance(obj.transform.position, chair.transform.position) > 10f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }
}
