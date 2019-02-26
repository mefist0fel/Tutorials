using UnityEngine;

public class LevelButton : MonoBehaviour {
    public GameObject[] controlObjects;

    public bool isOnbjectEnabled = true;

    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<Hero>() == null)
            return;
        isOnbjectEnabled = !isOnbjectEnabled;
        if (controlObjects != null)
            foreach(var obj in controlObjects)
                obj.SetActive(isOnbjectEnabled);
    }

  //  private void OnTriggerExit(Collider other) {
  //      isOnbjectEnabled = !isOnbjectEnabled;
  //      if (controlObject != null)
  //          controlObject.SetActive(isOnbjectEnabled);
  //  }

    void Start() {
        if (controlObjects != null)
            foreach (var obj in controlObjects)
                obj.SetActive(isOnbjectEnabled);
    }
}
