using UnityEngine;

public class LevelButton : MonoBehaviour {
    
    // Массив объектов, которыми будем управлять
    public GameObject[] controlObjects;

    // Флаг, показывающий включены или нет управляемые объекты
    public bool isOnbjectEnabled = true;

    // При вхождении какого-либо объекта в триггер кнопки
    private void OnTriggerEnter(Collider other) {
        
        // Если этот объект - не герой, то выходим из функции
        if (other.GetComponent<Hero>() == null)
            return;
        
        // Инвертируем флаг включения
        isOnbjectEnabled = !isOnbjectEnabled;
        
        // Если существует список контролируемых объектов
        if (controlObjects != null)
            
            // Для каждого объекта в массиве выставляем "включенность" согласно флагу
            foreach(var obj in controlObjects)
                obj.SetActive(isOnbjectEnabled);
    }

  //  private void OnTriggerExit(Collider other) {
  //      isOnbjectEnabled = !isOnbjectEnabled;
  //      if (controlObject != null)
  //          controlObject.SetActive(isOnbjectEnabled);
  //  }

    // При запуске игры
    void Start() {
        
        // Если существует список контролируемых объектов
        if (controlObjects != null)
            
            // Для каждого объекта выставляем начальное состояние
            foreach (var obj in controlObjects)
                obj.SetActive(isOnbjectEnabled);
    }
}
