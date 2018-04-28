using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttacks : MonoBehaviour
{
    public Image[] theFillImages;
    private int[] fadeImages = new int[] { 0, 0, 0, 0, 0, 0 };
    public float[] fadeTimes= new float[] { 1.0f, 0.7f, 0.3f, 0.1f, 0.2f, 0.3f, 0.08f };
    private Animator anim;
    private bool canAttack = true;
    private PlayerMove playerMove;

    void Awake()
    {
        this.anim = GetComponent<Animator>();
        this.playerMove = GetComponent<PlayerMove>();
    }

    void Update()
    {
        if (!anim.IsInTransition(0) && anim.GetCurrentAnimatorStateInfo(0).IsName("Stand"))
        {
            this.canAttack = true;
        }
        else
        {
            this.canAttack = false;
        }

        CheckToFade();
        CheckInput();
    }

    void CheckToFade()
    {
        for(int i = 0; i < this.theFillImages.Length; i++)
        {
            if(this.fadeImages[i] == 1)
            {
                if(this.FadeAndWait(this.theFillImages[i], this.fadeTimes[i]))
                {
                    this.fadeImages[i] = 0;
                }
            }
        }
    }

    bool FadeAndWait(Image fadeImages, float fadeTime)
    {
        bool faded = false;

        if(fadeImages == null)
        {
            return faded;
        }
        if (!fadeImages.gameObject.activeInHierarchy)
        {
            fadeImages.gameObject.SetActive(true);
            fadeImages.fillAmount = 1f;
        }
        fadeImages.fillAmount -= fadeTime * Time.deltaTime;
        if(fadeImages.fillAmount <= 0.0f)
        {
            fadeImages.gameObject.SetActive(false);
            faded = true;
        }
        return faded;
    }

    void CheckInput()
    {
        if (this.anim.GetInteger("Atk") == 0)
        {
            this.playerMove.FinishedMovement = false;
            if (!this.anim.IsInTransition(0) && this.anim.GetCurrentAnimatorStateInfo(0).IsName("Stand"))
            {
                this.playerMove.FinishedMovement = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            this.playerMove.TargetPosition = transform.position;

            if (playerMove.FinishedMovement && this.fadeImages[0] != 1 && this.canAttack)
            {
                this.fadeImages[0] = 1;
                this.anim.SetInteger("Atk", 1);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playerMove.TargetPosition = transform.position;

            if (playerMove.FinishedMovement && fadeImages[1] != 1 && canAttack)
            {
                fadeImages[1] = 1;
                anim.SetInteger("Atk", 2);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            playerMove.TargetPosition = transform.position;

            if (playerMove.FinishedMovement && fadeImages[2] != 1 && canAttack)
            {
                fadeImages[2] = 1;
                anim.SetInteger("Atk", 3);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            playerMove.TargetPosition = transform.position;

            if (playerMove.FinishedMovement && fadeImages[3] != 1 && canAttack)
            {
                fadeImages[3] = 1;
                anim.SetInteger("Atk", 4);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            playerMove.TargetPosition = transform.position;

            if (playerMove.FinishedMovement && fadeImages[4] != 1 && canAttack)
            {
                fadeImages[4] = 1;
                anim.SetInteger("Atk", 5);
            }
        }
        else if (Input.GetMouseButtonDown (1))
        {
			playerMove.TargetPosition = transform.position;

			if (playerMove.FinishedMovement && fadeImages[5] != 1 && canAttack)
            {
				fadeImages[5] = 1;
				anim.SetInteger("Atk", 6);
			}
	    }
        else
        {
			anim.SetInteger("Atk", 0);
		}
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 targetPos = Vector3.zero;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider is TerrainCollider)
                {
                    targetPos = new Vector3(hit.point.x, this.transform.position.y, hit.point.z);
                }
            }
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(targetPos -
                transform.position), 15f * Time.deltaTime);
        }
    }
}
