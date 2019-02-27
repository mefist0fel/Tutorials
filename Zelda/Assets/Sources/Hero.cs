using UnityEngine;
using UnityEngine.UI;

public sealed class Hero : MonoBehaviour {
    public float speed = 1;
    public float health = 100;
    
    // Ссылка на анимацию меча
    public Animation swordAnimation;
    
    // Ссылка на вращаемую часть героя
    public Transform rotateTransform;
    
    // Ссылка на текстовое поле - хелсбар
    public Text healthBar;

    private bool isAlive;

    void Start() {
        
        // Ставим флаг "Живой" в истину, обновляем значение хелсбара
        isAlive = true;
        healthBar.text = "HP: " + health;
    }

    void Update() {
        
        // Если герой жив, выполяем функцию управления
        if (isAlive)
            ControlPlayer();
    }

    private void ControlPlayer() {
        
        // По нажатию на пробел играем анимацию удара мечом
        if (Input.GetKey(KeyCode.Space)) {
            swordAnimation.Play();
        }
        
        // При нажатии клавиш управления, поворачиваем героя в соответствующуюю сторону и двигаем его туда
        if (Input.GetKey(KeyCode.W)) {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            rotateTransform.localEulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.S)) {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
            rotateTransform.localEulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            rotateTransform.localEulerAngles = new Vector3(0, 90, 0);
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            rotateTransform.localEulerAngles = new Vector3(0, 270, 0);
        }
    }

    // Функция нанесения урона герою
    public void DealDamage(float damage) {
        
        // Если герой не жив, выходим из функции
        if (!isAlive)
            return;
        
        // Вычитаем урон из жизней и обновляем хелсбар
        health -= damage;
        healthBar.text = "HP: " + health;

        // Если жизни равны нулю или опускаются ниже нуля, то ставим флаг "жив" в ложь и
        // пишем в хелсбаре "Мёртв"
        if (health <= 0) {
            isAlive = false;
            healthBar.text = "DEAD";
        }
    }
}
