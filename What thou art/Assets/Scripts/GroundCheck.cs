﻿using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

    private Player player;

	// Use this for initialization
	void Start () {
        player = gameObject.GetComponentInParent<Player>();
	}
	
    void OnTriggerEnter2D(Collider2D col)
    {
        player.grounded = true;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        player.grounded = false;
    }

}
