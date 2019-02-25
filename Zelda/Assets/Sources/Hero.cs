using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Hero : MonoBehaviour {
    public float speed = 1;
    public Animation swordAnimation;
    public Transform rotateTransform;

    void Start() {

    }

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
}
