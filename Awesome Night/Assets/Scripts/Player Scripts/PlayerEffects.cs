using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    public GameObject groundImpact_Spawn, kickFX_Spawn, fireTornado_Spawn, fireShield_Spawn;
    public GameObject groundImpact_Prefab, kickFX_Prefab, fireTornado_Prefab, fireShield_Prefab, healFX_Prefab, thunderFX_Prefab;

    void Start ()
    {
		
	}

    void GroundImpact()
    {
        GameObject obj = Instantiate(groundImpact_Prefab, groundImpact_Spawn.transform.position, Quaternion.identity) as GameObject;
    }

    void Kick()
    {
        GameObject obj = Instantiate(kickFX_Prefab, kickFX_Spawn.transform.position, Quaternion.identity) as GameObject;
    }

    void FireTornado()
    {
        GameObject obj = Instantiate(fireTornado_Prefab, fireTornado_Spawn.transform.position, Quaternion.identity) as GameObject;
    }

    void FireShield()
    {
        GameObject fireObj = Instantiate(fireShield_Prefab, fireShield_Spawn.transform.position,
                                 Quaternion.identity) as GameObject;
        fireObj.transform.SetParent(transform);
    }

    void Heal()
    {
        Vector3 temp = this.transform.position;
        temp.y += 2;
        GameObject obj = Instantiate(healFX_Prefab, temp, Quaternion.identity) as GameObject;
        obj.transform.SetParent(this.transform);
    }

    void ThunderAttack()
    {
        float x = this.transform.position.x;
        float y = this.transform.position.y;
        float z = this.transform.position.y;
        float[] xs = {x-4f, x+4f, x,x, x+2.5f, x}
    }

    void update() 
    {
		
	}
}//class
