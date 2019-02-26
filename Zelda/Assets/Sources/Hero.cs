﻿using UnityEngine;

public sealed class Hero : MonoBehaviour {
    public float speed = 1;
    public float health = 100;
    public Animation swordAnimation;
    public Transform rotateTransform;

    void Update() {
        ControlPlayer();
    }

    private void ControlPlayer() {
        if (Input.GetKey(KeyCode.Space)) {
            swordAnimation.Play();
        }
        if (Input.GetKey(KeyCode.W)) {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            rotateTransform.localEulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.S)) {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
            rotateTransform.localEulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            rotateTransform.localEulerAngles = new Vector3(0, 90, 0);
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            rotateTransform.localEulerAngles = new Vector3(0, 270, 0);
        }
    }

    public void DealDamage(float damage) {
        health -= damage;
        if (health <= 0)
            Debug.Log("I AM DEAD");
    }
}
