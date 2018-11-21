﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private Rigidbody myRigidbody;

    public float enemySpeed;
    // Use this for initialization
    void Start () {
        myRigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        MoveToPlayer();
	}
    void MoveToPlayer()
    {

        Vector3 direction = PlayerController.playerObject.transform.position - this.transform.position;
        direction = direction.normalized;

        myRigidbody.velocity = Vector3.Normalize(new Vector3(direction.x , 0f, direction.z)) * enemySpeed;
        


    }
    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag == ("Player"))
            Destroy(collision.gameObject);
        else if(collision.gameObject.tag == ("Bullet"))
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}