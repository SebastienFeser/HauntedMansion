using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLeftScript : MonoBehaviour {

    Enemy1_Behaviour behaviour;
    bool canTurnLeft = false;
    Collider2D hit = null;

    private void Start()
    {
        behaviour = GetComponentInParent<Enemy1_Behaviour>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        behaviour.GoLeft();
    }
}
