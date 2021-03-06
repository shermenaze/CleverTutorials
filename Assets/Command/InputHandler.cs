﻿using UnityEngine;

namespace Assets.Scripts
{
    public class InputHandler : MonoBehaviour
    {
        Command _button1;
        Command _button2;

        public void Start()
        {
            _button1 = new JumpCommand();
            _button2 = new FireCommand();
        }

        public Command HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.Space)) return _button1;
            else if (Input.GetKeyDown(KeyCode.V)) return _button2;

            return null;
        }
    }
}