using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelectable
{
    void Start(); // Must call `Selection.Selector.AddSelectable(this);`
    GameObject gameObject { get; }
    void OnSelect();
    void OnDeselect();
    void OnDestroy(); // Must call `Selection.Selector.RemoveSelectable(this);` and `UnitHUD.HUD.RemoveUnitHUD(gameObject);`
}
