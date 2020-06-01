using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFuelScript : MonoBehaviour
{
    [SerializeField] private GameObject BarAnchor = null;

    private void Update()
    {
        BarAnchor.transform.localScale = new Vector3(1,GameInfo.ActualJetPack.ActualFuelLevel / GameInfo.ActualJetPack.MaxFuelLevel,1);
    }

}
