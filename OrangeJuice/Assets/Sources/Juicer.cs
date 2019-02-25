using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Juicer : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        var orange = collision.GetComponent<Orange>();
        if (orange != null) {
            orange.Kill();
            Collect();
        }
    }

    public void Collect() {
        Debug.Log("Collect orange");
    }

    private void Start() {
        
    }

    private void Update() {
        
    }
}
