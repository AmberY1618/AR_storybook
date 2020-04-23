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

    private static bool _placedJackie = false;
    public static bool PlacedJackie { get => _placedJackie; set => _placedJackie = value; }

    private Ray ray;
    private RaycastHit hit;
    private MovableObject currentObject;


    void FixedUpdate()
    {
        if (Input.touchCount > 0)
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
                        }
                    }  
                    break;
                      case TouchPhase.Moved:

                    if (currentObject && !canStay)
                    {
                        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Page5"))
                        {
                            currentObject.gameObject.transform.Translate(Time.deltaTime * speed * new Vector3(t.deltaPosition.x, 0, 0), Space.World);
                        }
                        else
                        {
                            currentObject.gameObject.transform.Translate(Time.deltaTime * speed * new Vector3(t.deltaPosition.x, 0, t.deltaPosition.y), Space.World);
                        }
                    }
                    break;

                case TouchPhase.Ended:
                    if (currentObject && !canStay)
                    {
                        //if (!PlacedJackie)
                        //{
                        //    currentObject.transform.localPosition = startPos;
                        //}

                        currentObject = null;
                    }
                    break;
            }

        }


    }
}
