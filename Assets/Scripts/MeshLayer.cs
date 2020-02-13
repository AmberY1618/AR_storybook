using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshLayer : MonoBehaviour
{
    [SerializeField] private string _layerName;

    [SerializeField] private int _sortingOrder;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().sortingLayerName = _layerName;
        GetComponent<MeshRenderer>().sortingOrder = _sortingOrder;
    }
}
