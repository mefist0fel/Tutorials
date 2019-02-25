using System;
using UnityEngine;

public class Orange : MonoBehaviour {
    [SerializeField]
    private Rigidbody2D controlRigidbody;
    [SerializeField]
    private float startTime = 1f;

    private Rect borders = new Rect(new Vector2(-20f, -20f), new Vector2(40f, 40f));
    private float timer;

    public void Fire(Vector2 position, Vector2 velocity) {
        gameObject.SetActive(true);
        transform.position = position;
        controlRigidbody.velocity = velocity;
        timer = 0;
        SetScale(0);
    }

    public void Kill() {
        gameObject.SetActive(false);
    }

    private void Reset() {
        controlRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        
    }

    private void FixedUpdate() {
        CheckOutOfBorders();
        if (timer < startTime) {
            timer += Time.deltaTime;
            if (timer >= startTime) {
                timer = startTime;
            }
            SetScale(timer / startTime);
        }
    }

    private void SetScale(float scale) {
        transform.localScale = Vector3.one * scale;
    }

    private void CheckOutOfBorders() {
        if (!borders.Contains(transform.position))
            Kill();
    }
}
