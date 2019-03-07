using UnityEngine;

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
<<<<<<< HEAD
=======
            Debug.Log(_button1);
>>>>>>> c948a8b402f88a5876146f7a5c06f95549f3a6ce
        }

        public Command HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.Space)) return _button1;
            else if (Input.GetKeyDown(KeyCode.V)) return _button2;

            return null;
        }
    }
}