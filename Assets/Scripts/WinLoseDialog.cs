using System;
using UnityEngine;

public class WinLoseDialog : MonoBehaviour
{
    [SerializeField] private DialogWindow _dialogWindow;

    public void ShowDialog(string message, string leftText, string rightText, Action onLeftClick, Action onRightClick)
    {
        if (_dialogWindow != null)
        {
            _dialogWindow.Init(message, leftText, rightText, onLeftClick, onRightClick);
            _dialogWindow.SetVisible(true);
        }
    }

    public void SetVisible(bool visible)
    {
        if (_dialogWindow != null)
            _dialogWindow.SetVisible(visible);
    }
}
