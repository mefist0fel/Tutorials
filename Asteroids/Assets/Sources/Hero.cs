using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour {
    
    public int lives = 3;

    public float speed = 1f;
    public GameObject loseObject;
    public Text livesText;

    void Start() {
        Time.timeScale = 1;
        loseObject.SetActive(false);
        livesText.text = lives.ToString();
    }

    private void OnTriggerEnter(Collider other) {
        lives -= 1;
        if (lives <= 0) {
            Time.timeScale = 0;
            loseObject.SetActive(true);
        }
        livesText.text = lives.ToString();
    }

    void Update() {
        if (Input.GetKey(KeyCode.W)) {
            transform.position += new Vector3(0, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S)) {
            transform.position += new Vector3(0, -speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.position += new Vector3(-speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.position += new Vector3(speed * Time.deltaTime, 0);
        }
    }
}
