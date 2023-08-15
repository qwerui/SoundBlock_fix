using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIInterface
{
    public interface IKeyboardAction
    {
        void OnNavigate(Vector2 input);
        void OnSubmit();
    }

    public interface IMouseAction
    {
        void OnClick();
        void OnDrag();
        void OnRelease();
    }
}

