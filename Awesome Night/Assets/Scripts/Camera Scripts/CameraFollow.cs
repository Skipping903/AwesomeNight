using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float follow_height = 8f;
    public float follow_distance = 6f;
    private Transform Player;
    private float target_height;
    private float current_height;
    private float current_rotation;

	// Use this for initialization
	void Awake ()
    {
        this.Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void OnEnable()
    {
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update ()
    {
        target_height = Player.position.y + this.follow_height;
        this.current_rotation = this.transform.eulerAngles.y;
        this.current_height = Mathf.Lerp(transform.position.y, target_height, 0.9f * Time.deltaTime);
        Quaternion euler = Quaternion.Euler(0f, current_rotation, 0f);
        Vector3 targetPosition = this.Player.position - (euler * Vector3.forward) * this.follow_distance;
        targetPosition.y = current_height;
        this.transform.position = targetPosition;
        this.transform.LookAt(this.Player);
	}
}//class
