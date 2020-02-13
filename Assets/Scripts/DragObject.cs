using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;
public class DragObject : MonoBehaviour
{
    [SerializeField] private float speed;
    public static Vector3 startPos;
    public static bool canStay;
    private Ray ray;
    private RaycastHit hit;
    private MovableObject currentObject;
    void FixedUpdate()
    {
        if (Input.touchCount > 0 && !HandleCollision.animationPlaying)
        {
            Touch t = Input.GetTouch(0);
            switch (t.phase)
            {
                case TouchPhase.Began:
                    ray = Camera.main.ScreenPointToRay(t.position);
                    if (Physics.Raycast(ray.origin, ray.direction, out hit, float.MaxValue))
                    {
                        MovableObject m_Object = hit.collider.gameObject.GetComponent<MovableObject>();
                        if (m_Object)
                        {
                            currentObject = m_Object;
                            startPos = m_Object.transform.localPosition;
                            currentObject.GetComponent<Outline>().enabled = true;
                        }
                    }
                    break;
                case TouchPhase.Moved:
                    if (currentObject && !canStay)
                    {
                        currentObject.gameObject.transform.Translate(Time.deltaTime * speed * new Vector3(t.deltaPosition.x, 0, t.deltaPosition.y), Space.World);
                    }
                    break;
                case TouchPhase.Ended:
                    currentObject.GetComponent<Outline>().enabled = false;
                    if (currentObject && !canStay && (currentObject.CompareTag("mediumPorridge") || currentObject.CompareTag("hotPorridge") || currentObject.CompareTag("coldPorridge")))
                    {
                        currentObject.transform.localPosition = startPos;
                        currentObject = null;
                    }
                    break;
            }
        }
    }
}


