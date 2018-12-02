using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1_SideCollidersScript : MonoBehaviour {

    BoxCollider2D sideCollider;
    Enemy1_Behaviour behaviour;

    private void Start()
    {
        sideCollider = GetComponent<BoxCollider2D>();
        behaviour = GetComponentInParent<Enemy1_Behaviour>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        behaviour.Center(gameObject);
    }
}
