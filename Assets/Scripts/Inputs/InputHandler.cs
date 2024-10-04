using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputHandling
{
    public class InputHandler : MonoBehaviour
    {
        private Inputs _inputs;

        public static ButtonTrigger attack = new ButtonTrigger();
        public static VectorTrigger move = new VectorTrigger();

        private void Awake()
        {
            _inputs = new Inputs();
            _inputs.Enable();

            _inputs.Player.Movement.performed += OnMove;
            _inputs.Player.Attack.performed += OnAttack;

        }
        private void OnEnable()
        {
            attack.Reset();
            move.Reset();
        }
        private void OnAttack(InputAction.CallbackContext context)
        {
            StartCoroutine(attack.Trigger_Cor());
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            move.Trigger(context.ReadValue<UnityEngine.Vector2>());
        }

        private void OnDestroy()
        {
            _inputs.Disable();
            _inputs.Player.Movement.performed -= OnMove;
            _inputs.Player.Attack.performed -= OnAttack;
        }




    }
}
