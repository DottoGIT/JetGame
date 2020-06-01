using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelTank : MonoBehaviour , ICollectable
{
    public float FuelAdded;

    private AbstractJetpack Taker;

    public void Collect()
    {
        Taker.ActualFuelLevel += FuelAdded;
        Destruct();
    }

    public void Destruct()
    {
        Destroy(gameObject);
    }

    public void OnSpawn()
    {
        return;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<AbstractJetpack>() != null)
        {
            Taker = collision.GetComponent<AbstractJetpack>();
            Collect();
        }
    }
}
