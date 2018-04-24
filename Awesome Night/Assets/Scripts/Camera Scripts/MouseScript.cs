using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    public Texture2D cursorTexture;
    private CursorMode mode = CursorMode.ForceSoftware;
    private Vector2 hotSpot = Vector2.zero;
    public GameObject mousePoint;
    private GameObject instantiatedMouse;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Cursor.SetCursor(this.cursorTexture, this.hotSpot, this.mode);
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider is TerrainCollider)
                {
                    Vector3 temp = hit.point;
                    temp.y = 0.25f;
                    if(this.instantiatedMouse == null)
                    {
                        this.instantiatedMouse = Instantiate(this.mousePoint, temp, Quaternion.identity);
                    }
                    else
                    {
                        this.instantiatedMouse.transform.position = temp;
                    }
                }
            }
        }
	}
}
