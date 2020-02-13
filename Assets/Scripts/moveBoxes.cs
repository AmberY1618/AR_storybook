using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moveBoxes : MonoBehaviour
{

    [SerializeField] private GameObject box1, box2, box3, box4;
    [SerializeField] float speed;
    private Vector3 pos1, pos2, pos3, pos4; //4 original box positions


    private Ray ray;
    private RaycastHit hit;
    private GameObject currentBox;
    private GameObject targetBox = null;
    private Vector3 originalPos;
    public GameObject instruction;
    public Button endingButton;
    public GameObject endingScene;


    // Start is called before the first frame update
    void Start()
    {
        instruction.SetActive(false);
        endingButton.gameObject.SetActive(false);
        endingScene.SetActive(false);
        pos1 = box1.transform.position;
        pos2 = box2.transform.position;
        pos3 = box3.transform.position;
        pos4 = box4.transform.position;
    }


    void Update()
    {

        if (box1.transform.position == pos4 && box2.transform.position == pos1 && box3.transform.position == pos2 && box4.transform.position == pos3)
        {
            instruction.SetActive(false);
            endingButton.gameObject.SetActive(true);
        }

        //only enter when 4 boxes are all ready to be moved
        bool allMovable = box1.tag == "movable" && box2.tag == "movable" && box3.tag == "movable" && box4.tag == "movable";
        if (allMovable)
        {
            instruction.SetActive(true);

            if (Input.touchCount > 0)
            {
                Touch t = Input.GetTouch(0);

                switch (t.phase)
                {
                    case TouchPhase.Began:
                        ray = Camera.main.ScreenPointToRay(t.position);
                        if (Physics.Raycast(ray.origin, ray.direction, out hit, float.MaxValue))
                        {
                            currentBox = hit.collider.gameObject;
                            originalPos = currentBox.transform.position;
                        }

                        break;

                    case TouchPhase.Moved:
                        if (currentBox)
                        {
                            currentBox.gameObject.transform.Translate(Time.deltaTime * speed * new Vector3(t.deltaPosition.x, 0, t.deltaPosition.y), Space.World);
                        }

                        break;

                    case TouchPhase.Ended:

                        if (currentBox)
                        {
                            Debug.Log("in ended");
                            if (currentBox.name.Equals("box1"))
                            {
                                targetBox = FindNearest(currentBox, box2, box3, box4);
                            }
                            else if (currentBox.name.Equals("box2"))
                            {
                                targetBox = FindNearest(currentBox, box1, box3, box4);
                            }
                            else if (currentBox.name.Equals("box3"))
                            {
                                targetBox = FindNearest(currentBox, box1, box2, box4);
                            }
                            else if (currentBox.name.Equals("box4"))
                            {
                                targetBox = FindNearest(currentBox, box1, box2, box3);
                            }
                            if (targetBox == null) //if not switching place the box back to original position
                            {
                                currentBox.transform.position = originalPos;
                            }
                            else //actually switching
                            {
                                Vector3 targetPos = targetBox.transform.position;
                                targetBox.transform.position = originalPos;
                                currentBox.transform.position = targetPos;
                            }
                        }

                        break;

                    default:
                        break;
                }
            }
        }
    }

    private GameObject FindNearest(GameObject currentBox, GameObject boxFirst, GameObject boxSec, GameObject boxThird)
    {
        float distance1 = Vector3.Distance(boxFirst.transform.position, currentBox.transform.position);
        float distance2 = Vector3.Distance(boxSec.transform.position, currentBox.transform.position);
        float distance3 = Vector3.Distance(boxThird.transform.position, currentBox.transform.position);

        float[] distances = new float[] { distance1, distance2, distance3 };
        float min = Mathf.Min(distances);

        if (min < 0.07f)
        {
            if (distance1 == min)
            {
                return boxFirst;
            }
            else if (distance2 == min)
            {
                return boxSec;
            }
            else
            {
                return boxThird;
            }
        }
        else
        {
            return null;
        }
    }

    public void showEnding()
    {
        endingButton.gameObject.SetActive(false);
        instruction.SetActive(false);
        GameObject.Find("box1").SetActive(false);
        GameObject.Find("box2").SetActive(false);
        GameObject.Find("box3").SetActive(false);
        GameObject.Find("box4").SetActive(false);
        endingScene.SetActive(true);

    }

    public void debugger()
    {
        Debug.Log("YOOOOOOOOOO~~~~");
    }
}
