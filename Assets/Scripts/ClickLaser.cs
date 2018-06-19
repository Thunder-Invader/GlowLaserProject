using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickLaser : MonoBehaviour {

    public float sec = 14f;
    public bool laserOn = false;
    public bool laserOff = false;
    public int number;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {

        MeshRenderer m = gameObject.GetComponent<MeshRenderer>();
        
        if (m.enabled)
            m.enabled = false;

        StartCoroutine(LateCall());

    }

    IEnumerator LateCall()
    {
        MeshRenderer m = gameObject.GetComponent<MeshRenderer>();
        yield return new WaitForSeconds(sec);

        m.enabled = true;
        //Do Function here...
    }

    public void LaserOnOff()
    {
        MeshRenderer m = gameObject.GetComponent<MeshRenderer>();

        if (m.enabled)
        {
            laserOn = true;
        }
        else
        {
            laserOff = true;
        }

    }
}






