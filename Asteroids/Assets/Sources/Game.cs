using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

    public Enemy enemyPrefab; // Set from editor

    public float reloadTime = 1;

    float timer;

    
    void Update() {
        timer -= Time.deltaTime;

        if (timer < 0) {
            timer = reloadTime;
            Enemy e = Instantiate(enemyPrefab);
            e.transform.position = new Vector3(20, Random.Range(-5f, 5f));
        }
    }

    public void Restart() {
        SceneManager.LoadScene(0);
    }
}
