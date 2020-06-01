using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthScript : MonoBehaviour
{
    private RawImage Icon;

    private static readonly int R = 255;
    private static float G;
    private static float B;

    private void Start()
    {
        Icon = gameObject.GetComponent<RawImage>();
        Icon.color = new Color(R, G, B);
    }

    private void Update()
    {
        float hpProc;

        hpProc = GameInfo.ActualJetPack.ActualHealthLevel / GameInfo.ActualJetPack.MaxHealthLevel;


        B = 255 * hpProc;
        G = 255 * hpProc;

        Debug.Log(B);

        Icon.color = new Color(R,G,B);
    }


}
