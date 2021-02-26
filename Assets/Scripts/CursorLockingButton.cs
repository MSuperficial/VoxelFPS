using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CursorLockingButton : Selectable
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
