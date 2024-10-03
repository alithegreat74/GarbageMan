using System.Collections;
using UnityEngine;

public class GarbageEnemyVisualEffects : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    

    public void ChangeColor(Color color, float time)
    {
        StartCoroutine(ChangeColor_Cor(color, time));
    }

    private IEnumerator ChangeColor_Cor(Color color,float time)
    {
        sr.color = color;
        yield return new WaitForSeconds(time);
        sr.color=Color.white;
    }

}
