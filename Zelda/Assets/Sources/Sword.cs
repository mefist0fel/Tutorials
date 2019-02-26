using UnityEngine;

namespace Sources {
    public class Sword : MonoBehaviour {

        public float Damage;
        
        private void OnTriggerEnter(Collider other) {
            var victim = other.GetComponent<Enemy>();
            if (victim == null)
                return;
            
            victim.DealDamage(Damage);
        }
    }
}