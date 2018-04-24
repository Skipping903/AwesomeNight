using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObjectWithDelay : MonoBehaviour
{
    public float timeToWait = 0.1f;

    IEnumerator Killmyself()
    {
        yield return new WaitForSeconds(this.timeToWait);
        Destroy(this.gameObject);
    }

    void Start()
    {
        StartCoroutine(Killmyself());
    }
    // Update is called once per frame
    void Update ()
    {
		
	}
}
