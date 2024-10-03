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
       
    }
    public class VectorTrigger
    {
        private Vector2 Value;

        public void Trigger(Vector2 val)
        {
            this.Value = val;
        }
        public Vector2 GetValue() => Value;
    }
}
