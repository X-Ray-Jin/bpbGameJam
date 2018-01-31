using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splashBall : MonoBehaviour {
    
    public GameObject splashPrefab;
    Vector2 target = new Vector2();
    Vector2 ownPos = new Vector2();
    Vector3 splashPos = new Vector3();
    float distanceTarget = 0;

	// Use this for initialization
	void Start ()
    {
    }
	
	// Update is called once per frame
	void Update () {
        ownPos.Set(transform.position.x, transform.position.y);
        distanceTarget = Vector3.Distance(target, ownPos);
        if (distanceTarget < 1)
        {
            this.gameObject.SetActive(false);

            GameObject splash = Instantiate<GameObject>(splashPrefab);

            SpriteRenderer img = splash.transform.Find("splash_img").GetComponent<SpriteRenderer>();
            // rotate splash
            img.transform.Rotate(0, 0, Random.Range(0, 360));

            // scale splash
            Vector3 scale = img.transform.localScale;
            scale.x *= Random.Range(.5f, 2f);
            scale.y *= Random.Range(.5f, 2f);
            img.transform.localScale = scale;
            setColor(img);

            // translate splash to target pos
            splash.transform.Translate(target.x, target.y, -1);

            Destroy(this.gameObject);
        }
	}

    private void setColor(SpriteRenderer img)
    {
        switch ((int) Random.Range(0, 5))
        {
            case 0:
                
                img.color = new Color(21 / 255f, 88 / 255f, 110 / 255f, .5f);
                break;
            case 1:
                img.color = new Color(251 / 255f, 210 / 255f, 91 / 255f, .5f);
                break;
            case 2:
                img.color = new Color(11 / 255f, 33 / 255f, 69 / 255f, .5f);
                break;
            case 3:
                img.color = new Color(234 / 255f, 75 / 255f, 49 / 255f, .5f);
                break;
            case 4:
                img.color = new Color(184 / 255f, 19 / 255f, 19 / 255f, .5f);
                break;
        }
    }

    public void setTarget(Vector2 target) {
        this.target.Set(target.x, target.y);
    }
}
