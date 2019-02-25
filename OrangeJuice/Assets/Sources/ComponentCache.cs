using System.Collections.Generic;
using UnityEngine;

public sealed class ComponentCache<T> where T: MonoBehaviour {

    private readonly T prefab;
    private readonly Transform parent;
    private List<T> items = new List<T>();

    public ComponentCache(T prefab, Transform parent = null) {
        this.prefab = prefab;
        this.parent = parent;
    }

    public T Get() {
        foreach (var item in items) {
            if (item == null) {
                Debug.LogError("item in cache is deleted from outside");
                continue;
            }
            if (!item.gameObject.activeSelf) {
                return item;
            }
        }
        var newItem = GameObject.Instantiate(prefab, parent);
        items.Add(newItem);
        newItem.gameObject.SetActive(false);
        return newItem;
    }
}
