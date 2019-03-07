using UnityEngine;

namespace Assets.Scripts
{
    public class Actor : MonoBehaviour
    {
        InputHandler _input;
        Command _inputCommand;

        private void Start()
        {
            _input = gameObject.AddComponent<InputHandler>();
        }

        public void Jump()
        {
            Debug.Log("Jump");
        }

        internal void Fire()
        {
            Debug.Log("Fire");
        }

        private void Update()
        {
            _inputCommand = _input.HandleInput();

            if (_inputCommand != null)
                _inputCommand.Execute(this);
        }
    }
}
