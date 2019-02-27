using UnityEngine;

namespace Sources {
    public class Sword : MonoBehaviour {

        public float Damage;
        
        // При столкновении меча с каким-либо другим объектом
        private void OnTriggerEnter(Collider other) {
            
            // Пытаемся получить у этого объекта компонент "Enemy"
            var victim = other.GetComponent<Enemy>();
            
            // Если его нет, выходим из функции
            if (victim == null)
                return;
            
            // Если мы до сюда дошли, наносим урон врагу
            victim.DealDamage(Damage);
        }
    }
}