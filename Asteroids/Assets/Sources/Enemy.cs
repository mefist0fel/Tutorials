using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float speed = 20;
    public float deathX = -20;

    void Update() {
        transform.position += new Vector3(-speed * Time.deltaTime, 0);

        if (transform.position.x < deathX)
            Destroy(gameObject);
    }
}
