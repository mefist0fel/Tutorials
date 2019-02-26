using UnityEngine;

public class Enemy : MonoBehaviour {

    public float Health;
    
    public void DealDamage(float damage) {
        Health -= damage;

        if (Health < 0) {
            Health = 0;
            Destroy(gameObject);
        }
    }
}
