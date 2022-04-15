using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputProvider
{
    public interface IInputProvider
    {
        Vector3 MoveVector();
        Vector2 LookVector();
    }
}

