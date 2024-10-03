using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectAdjustSortingLayer : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer= GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        spriteRenderer.sortingOrder = (int)(transform.position.z * -1);
    }
}
