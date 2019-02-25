using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeGun : MonoBehaviour {
    [SerializeField]
    private Orange orangePrefab;
    [SerializeField]
    private float fireStartSpeed = 10f;
    [SerializeField]
    private float angularSpeed = 80f;
    [SerializeField]
    private float angle = 0;
    [SerializeField]
    private float startDistance = 0.5f;
    [SerializeField]
    private float rechargeTime = 0.2f;

    private float timer = 0;

    private ComponentCache<Orange> cache;

    private void Start() {
        SetAngle(angle);
        cache = new ComponentCache<Orange>(orangePrefab);
    }

    private void FixedUpdate() {
        PlayerControl();
        if (timer > 0)
            timer -= Time.fixedDeltaTime;
    }

    private void PlayerControl() {
        var shifted = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ? 0.1f : 1f;
        if (Input.GetKey(KeyCode.A)) {
            Rotate(1f * shifted);
        }
        if (Input.GetKey(KeyCode.D)) {
            Rotate(-1f * shifted);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            Rotate(1f * shifted);
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            Rotate(-1f * shifted);
        }
        if (Input.GetKey(KeyCode.Space)) {
            Fire();
        }
        if (Input.GetKey(KeyCode.W)) {
            Fire();
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            Fire();
        }
    }

    private void Fire() {
        if (timer > 0)
            return;
        timer = rechargeTime;
        var orange = cache.Get();
        orange.Fire(transform.position + transform.up * startDistance, transform.up * fireStartSpeed);
    }

    private void Rotate(float direction = 1f) {
        angle += direction * angularSpeed * Time.fixedDeltaTime;
        SetAngle(angle);
    }

    private void SetAngle(float angle) {
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
