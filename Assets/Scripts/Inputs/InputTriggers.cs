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
            yield return new WaitForSeconds(0.05f);
            Trigger = false;
        }
        public bool GetValue() => Trigger;

        public void Reset()
        {
            Trigger= false;
        }
       
    }
    public class VectorTrigger
    {
        private Vector2 Value;

        public void Trigger(Vector2 val)
        {
            this.Value = val;
        }
        public void Reset()
        {
            Value = Vector2.zero;
        }
        public Vector2 GetValue() => Value;
    }
}
