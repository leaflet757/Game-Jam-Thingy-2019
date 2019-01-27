using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetCollider : MonoBehaviour 
{
    [SerializeField]
    private StreetManager streetManager;

    private bool isStartZone = false;

    private void OnTriggerEnter(Collider other)
    {
        streetManager.OnStreetColliderHit(this, other);
    }

    public void Setup(StreetManager setStreetManager, bool setStartZone)
    {
        streetManager = setStreetManager;
        isStartZone = setStartZone;
    }

    public bool IsStartZone()
    {
        return isStartZone;
    }
}
