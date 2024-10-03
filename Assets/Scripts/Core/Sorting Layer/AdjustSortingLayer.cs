using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustSortingLayer : MonoBehaviour
{
    private SpriteRenderer sr;
    void Start()
    {
        sr= GetComponent<SpriteRenderer>();
        sr.sortingOrder = (int)(transform.position.z * -1);
        
    }

}
