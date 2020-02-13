using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{

    public void Box1Buttons(Material material)
    {
        Debug.Log("button1");
        GameObject.Find("box1").GetComponent<MeshRenderer>().material = material;
        if (material.name.Contains("bears"))
        {
            GameObject.Find("box1").tag = "movable";
            GameObject.Find("Box1Buttons").SetActive(false);
        }

    }

    public void Box2Buttons(Material material)
    {
        Debug.Log("button2");
        GameObject.Find("box2").GetComponent<MeshRenderer>().material = material;
        if (material.name.Contains("porridge"))
        {
            GameObject.Find("box2").tag = "movable";
            GameObject.Find("Box2Buttons").SetActive(false);
        }

    }

    public void Box3Buttons(Material material)
    {
        Debug.Log("button3");
        GameObject.Find("box3").GetComponent<MeshRenderer>().material = material;
        if (material.name.Contains("Chair"))
        {
            GameObject.Find("box3").tag = "movable";
            GameObject.Find("Box3Buttons").SetActive(false);
        }

    }


    public void Box4Buttons(Material material)
    {
        Debug.Log("button4");
        GameObject.Find("box4").GetComponent<MeshRenderer>().material = material;
        if (material.name.Contains("bed"))
        {
            GameObject.Find("box4").tag = "movable";
            GameObject.Find("Box4Buttons").SetActive(false);
        }

    }

    public void SayYeah()
    {
        Debug.Log("YEAH!!!!");
    }
}
