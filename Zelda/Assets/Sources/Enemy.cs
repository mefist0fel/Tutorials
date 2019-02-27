using UnityEngine;

public class Enemy : MonoBehaviour {

    public float Health;
    public float Speed;

    // Ссылка не героя
    private Hero hero;

    private void Start() {
        
        // Поиск на сцене объекта с компонентом "Hero" и запоминание его
        hero = FindObjectOfType<Hero>();
    }

    public void DealDamage(float damage) {
        Health -= damage;

        // Если жизни упали ниже нуля, уничтожаем объект
        if (Health < 0) {
            Health = 0;
            Destroy(gameObject);
        }
    }

    private void Update() {
        
        // Каждой кадр мы поворачиваем объект в сторону героя и движемся вперёд
        transform.LookAt(hero.transform);
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
    }
    
    // При столкновении м каким-либо объектом
    private void OnCollisionEnter(Collision other) {
        
        // Пытаемся получитсь о объекта компонент "Hero".
        // Если этот объект не имеет компонента "Hero", то сразу выходим из функции
        var collidedHero = other.gameObject.GetComponent<Hero>();
        if (collidedHero == null)
            return;
        
        // Если мы не вышли, наносим
        collidedHero.DealDamage(10);
    }
}
