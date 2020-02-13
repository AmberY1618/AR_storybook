using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Collider _coll;
    public GameObject door;


    void FixedUpdate()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            RaycastHit hit;

            if (_coll.Raycast(ray, out hit, 1000.0f))
            {
                door.GetComponent<Animator>().SetTrigger("rotate");

                //_coll.gameObject.GetComponent<Animator>().SetTrigger("Test");
                Debug.Log("Touch Hit");
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (_coll.Raycast(ray, out hit, 100.0f))
            {

                //Debug.Log(_coll.gameObject.GetComponentInChildren<Animator>());

                door.GetComponent<Animator>().SetTrigger("rotate");
                Debug.Log("Mouse Hit");
            }
        }
    }
}
