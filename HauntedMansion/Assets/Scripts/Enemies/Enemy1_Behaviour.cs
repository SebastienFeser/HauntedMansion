using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1_Behaviour : MonoBehaviour {

    [SerializeField] Rigidbody2D monsterRigidbody;
    [SerializeField] float enemySpeed = 1.0f;

    public void GoRight()
    {
        transform.Rotate(new Vector3(0,0,-90));
    }

    public void GoLeft()
    {
        transform.Rotate(new Vector3(0, 0, 90));
    }

    public void Center(GameObject colliderGO)
    {
        if (colliderGO.tag == "RightCollider")
        {
            Vector3 newVelocity = Vector3.left * enemySpeed;
            monsterRigidbody.velocity = newVelocity;
        }
        else
        {
            Vector3 newVelocity = Vector3.right * enemySpeed;
            monsterRigidbody.velocity = newVelocity;
        }
    }

    private void Update()
    {
        Vector3 newVelocity = transform.up;
        monsterRigidbody.velocity = newVelocity * enemySpeed;
    }
}
