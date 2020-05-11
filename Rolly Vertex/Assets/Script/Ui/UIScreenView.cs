using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScreenView : MonoBehaviour
{
    Canvas canvas;
    // Start is called before the first frame update
    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }
    public virtual void Show()
    {
        canvas.enabled = true;
    }
    public virtual void Hide()
    {
        canvas.enabled = false;
    }
    public virtual void Disable()
    {
        canvas.enabled = false;
    }
}
