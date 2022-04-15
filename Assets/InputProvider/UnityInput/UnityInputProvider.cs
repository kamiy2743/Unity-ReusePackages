using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputProvider
{
    public class UnityInputProvider : IInputProvider
    {
        private static UnityInputProvider _instance;
        public static UnityInputProvider Instance {
            get {
                if (_instance == null)
                    _instance = new UnityInputProvider();
                return _instance;
            }
        }

        public Vector3 MoveVector()
        {
            var horizontal = Input.GetAxisRaw("Horizontal");
            var vertical = Input.GetAxisRaw("Vertical");
            return new Vector3(horizontal, 0,  vertical).normalized;
        }

        public Vector2 LookVector()
        {
            var mouseX = Input.GetAxis("Mouse X");
            var mouseY = Input.GetAxis("Mouse Y");
            return new Vector2(mouseX, mouseY);
        }
    }
}
