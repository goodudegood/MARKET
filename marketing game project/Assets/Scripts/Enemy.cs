﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public LayerMask enemyMask;
	Rigidbody2D myBody;
	Transform myTrans;
	float myWidth;
	public float speed;

	// Use this for initialization
	void Start () {
		myTrans = this.transform;
		myBody = this.GetComponent<Rigidbody2D>();
		myWidth = this.GetComponent<SpriteRenderer> ().bounds.extents.x;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		Vector2 lineCastPos = myTrans.position - myTrans.right * myWidth;
		Debug.DrawLine (lineCastPos, lineCastPos + -Vector2.up*10);

		bool isGrounded = Physics2D.Linecast (lineCastPos, lineCastPos + -Vector2.up*10, enemyMask);

		if (!isGrounded) {
			Vector3 currRot = myTrans.eulerAngles;
			currRot.y += 180;
			myTrans.eulerAngles = currRot;
		}

		Vector2 myVel = myBody.velocity;
		myVel.x = -myTrans.right.x * speed;
		myBody.velocity = myVel;
	
	}
}
