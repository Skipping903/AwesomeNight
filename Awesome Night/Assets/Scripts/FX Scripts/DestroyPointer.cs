using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPointer : MonoBehaviour
{
    private Transform thePlayer;
	// Use this for initialization
	void Start ()
    {
        this.thePlayer = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Vector3.Distance(this.transform.position, this.thePlayer.position) < 1.5f)
        {
            Destroy(this.gameObject);
        }
	}
}
