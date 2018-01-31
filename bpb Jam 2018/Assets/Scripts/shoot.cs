using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {

    public float power = 2000;

    public Vector2 splashPos = new Vector2();
    public GameObject crossHair;
    public GameObject splashPrefab;
    Vector2 playerPos = new Vector2();
    Vector2 target = new Vector2();

    // Use this for initialization
    void Start () {
		    
	}

    bool mousDown = false;
    public float reloadTime = .25f;
    float timer = 0;

	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) || (mousDown && timer > reloadTime))
        {
            mousDown = true;
            GameObject pl = GameObject.FindGameObjectWithTag("Player");
            playerPos.Set(pl.transform.position.x, pl.transform.position.y);
            bool flip = pl.transform.localScale.x < 0;
            if (flip) playerPos.x -= 5;
            else playerPos.x += 5;

            if (playerPos.x > crossHair.transform.position.x && !flip
                || playerPos.x < crossHair.transform.position.x && flip)
            {
                pl.GetComponent<PlayerController>().Flip();
            }


             GameObject splashBall = Instantiate<GameObject>(splashPrefab);

            target.Set(crossHair.transform.position.x, crossHair.transform.position.y);
            splashBall.GetComponent<splashBall>().setTarget(target);

            splashPos.Set(splashBall.transform.position.x, splashBall.transform.position.y);
            target = target - splashPos;
            target.Normalize();
            target.x *= power;
            target.y *= power;
            splashBall.GetComponent<Rigidbody2D>().AddForce(target);
            timer = 0;
        }

        if (Input.GetMouseButtonUp(0)) mousDown = false;
	}
}
