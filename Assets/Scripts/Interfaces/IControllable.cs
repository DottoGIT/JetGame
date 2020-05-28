using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControllable
{
    void OnBPerformed();
    void OnAPerformed();
    void OnACancelled();
    void OnBCancelled();
}
