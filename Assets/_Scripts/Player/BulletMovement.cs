using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

    private float speed;

    void Start()
    {
        if (gameObject.tag == "DefaultBullet")
            speed = 10;
        if (gameObject.tag == "UpgradedBullet")
            speed = 15;

        Destroy(gameObject, 3);
    }

	void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
