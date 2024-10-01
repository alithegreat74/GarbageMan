using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputHandling
{
    
    public class ButtonTrigger
    {
        private bool Trigger;

        public IEnumerator Trigger_Cor()
        {
            Trigger = true;
            yield return new WaitForSeconds(0.1f);
            Trigger = false;
#if UNITY_EDITOR
            Debug.Log("Attacked");
#endif
        }
        public bool GetValue() => Trigger;
       
    }
    public class VectorTrigger
    {
        private Vector2 Value;

        public void Trigger(Vector2 val)
        {
            this.Value = val;
#if UNITY_EDITOR
            Debug.Log($"Movemnt value: {val}");
#endif
        }
        public Vector2 GetValue() => Value;
    }
}
