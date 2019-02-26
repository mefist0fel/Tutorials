using UnityEngine;

public class Enemy : MonoBehaviour {

    public float Health;
    public float Speed;

    private Hero hero;

    private void Start() {
        hero = FindObjectOfType<Hero>();
    }

    public void DealDamage(float damage) {
        Health -= damage;

        if (Health < 0) {
            Health = 0;
            Destroy(gameObject);
        }
    }

    private void Update() {
        transform.LookAt(hero.transform);
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
    }
}
