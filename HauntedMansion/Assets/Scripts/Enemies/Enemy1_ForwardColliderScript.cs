using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1_ForwardColliderScript : MonoBehaviour {

    BoxCollider2D enemyCollider;
    Enemy1_Behaviour behaviour;

    private void Start()
    {
        enemyCollider = GetComponent<BoxCollider2D>();
        behaviour = GetComponentInParent<Enemy1_Behaviour>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        behaviour.GoRight();
    }
}
