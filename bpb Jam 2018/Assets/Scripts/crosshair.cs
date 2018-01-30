using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crosshair : MonoBehaviour {

    public float range = 2;
    Vector3 tmp = new Vector3();
    Vector3 tmp2 = new Vector3();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        tmp.Set(Input.mousePosition.x, Input.mousePosition.y, 0);
        tmp = Camera.main.ScreenToWorldPoint(tmp);
        Debug.Log("mouse " + tmp);
        // tmp.x = tmp.x;
        // tmp.y = tmp.y;

        GameObject pl = GameObject.FindGameObjectWithTag("Player");
        tmp2.Set(pl.transform.position.x, pl.transform.position.y, 0);
        Debug.Log("player " + tmp2);

        tmp = tmp - tmp2;
        Debug.Log("off " + tmp);
        if (Mathf.Abs(tmp.x) <= range)
        {
            tmp2.x += tmp.x;
        } else tmp2.x += Mathf.Sign(tmp.x) * range;

        if (Mathf.Abs(tmp.y) <= range)
        {
            tmp2.y += tmp.y;
        } else tmp2.y += Mathf.Sign(tmp.y) * range;

    Debug.Log("cross " + tmp2);

        //tmp2.z = 0;

        transform.SetPositionAndRotation(tmp2, transform.rotation);

    }
}
