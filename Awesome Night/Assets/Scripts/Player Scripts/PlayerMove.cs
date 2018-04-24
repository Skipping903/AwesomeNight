using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Animator anim;
    private CharacterController CharController;
    private CollisionFlags collisionFlags = CollisionFlags.None;

    private float movespeed = 5f;
    private Vector3 target_Pos = Vector3.zero;
    private Vector3 player_Move = Vector3.zero;
    private float player_ToPointDistance;
    private float gravity = 9.8f;
    private bool canMove;
    private bool finished_Movement = true;
    private float height;

	// Use this for initialization
	void Awake ()
    {
        this.anim = this.GetComponent<Animator>();
        this.CharController = this.GetComponent<CharacterController>();
        this.collisionFlags = this.CharController.collisionFlags;
	}
	
	// Update is called once per frame
	void MoveThePlayer ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider is TerrainCollider)
                {
                    this.player_ToPointDistance = Vector3.Distance(this.transform.position, hit.point);
                    if (this.player_ToPointDistance >= 1f)
                    {
                        this.target_Pos = hit.point;
                        this.canMove = true;
                    }
                }
            }           
        }
        if (this.canMove)
        {
            this.anim.SetFloat("Walk", 1f);
            Vector3 target_Temp = new Vector3(this.target_Pos.x, this.transform.position.y, this.target_Pos.z);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                Quaternion.LookRotation(target_Temp - this.transform.position), 15f * Time.deltaTime);
            this.player_Move = this.transform.forward * this.movespeed * Time.deltaTime;
            if (Vector3.Distance(target_Pos, this.transform.position) <= 0.5f)
            {
                this.canMove = false;
            }
        }
        else
        {
            this.player_Move.Set(0f, 0f, 0f);
            this.anim.SetFloat("Walk", 0f);
        }
    }

    bool IsGrounded()
    {
        return this.collisionFlags == CollisionFlags.Below ? true : false;
    }

    void CalculateHeight()
    {
        if (this.IsGrounded())
        {
            this.height = 0f;
        }
        else
        {
            this.height -= this.gravity * Time.deltaTime;
            // Uses a compound opperator; the above code is == to    this.height = this.height - this.gravity * Time.deltaTime;
        }
    }
    void CheckIfFinishedMovement()
    {
        if (!this.finished_Movement)
        {
            if (!this.anim.IsInTransition(0) && !this.anim.GetCurrentAnimatorStateInfo(0).IsName("Stand") &&
                      this.anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
            {
                this.finished_Movement = true;
            }
        }
        else
        {
            this.MoveThePlayer();
            this.player_Move.y = this.height * Time.deltaTime;
            this.collisionFlags = CharController.Move(this.player_Move);
        }
    }

    void Update()
    {
        this.CalculateHeight();
        this.CheckIfFinishedMovement();
    }
}//Class
