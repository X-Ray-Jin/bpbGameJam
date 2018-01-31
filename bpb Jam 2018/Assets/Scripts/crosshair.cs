using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crosshair : MonoBehaviour {

    public float range = 25;
    Vector2 mouse = new Vector2();
    Vector2 playerPos = new Vector2();
    Vector2 crossPos = new Vector2();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        mouse.Set(Input.mousePosition.x, Input.mousePosition.y);
        mouse = Camera.main.ScreenToWorldPoint(mouse);

        GameObject pl = GameObject.FindGameObjectWithTag("Player");
        playerPos.Set(pl.transform.position.x, pl.transform.position.y);

        Vector2 tmp = mouse - playerPos;
        if (tmp.magnitude <= range)
        {
            crossPos = playerPos + tmp;
            transform.SetPositionAndRotation(tmp, transform.rotation);
        } else
        {
            tmp.Normalize();
            crossPos.x = tmp.x * range;
            crossPos.y = tmp.y * range;
            crossPos = playerPos + crossPos;
        }
        transform.SetPositionAndRotation(crossPos, transform.rotation);
    }

    public Vector2 getPos()
    {
        return crossPos;
    }
}
