using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocation : MonoBehaviour
{
    public static Vector3 SpawnPosition(float xMax, float zMax, float xMin, float zMin, float y)
    {
        Camera camera = Camera.main;
        float cameraY=camera.transform.position.y;
        Vector3 cameraBottomLeft = camera.ViewportToWorldPoint(new Vector3(0, cameraY, 0));
        Vector3 cameraTopRight = camera.ViewportToWorldPoint(new Vector3(1, cameraY, 1));

        float xRight = UnityEngine.Random.Range(cameraTopRight.x, xMax);
        float xLeft = UnityEngine.Random.Range(xMin, cameraBottomLeft.x);

        float zBottom = UnityEngine.Random.Range(zMin, cameraBottomLeft.z);


        int choice = UnityEngine.Random.Range(0, 2);

        switch (choice)
        {
            case 0:
                return new Vector3(xLeft, y, zBottom);
            case 1:
                return new Vector3(xRight, y, zBottom);

            default:
                return Vector3.zero;
        }
    }
}
