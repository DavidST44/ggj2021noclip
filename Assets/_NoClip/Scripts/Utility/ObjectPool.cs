using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : UnityEngine.Object, IPoolable
{
    private GameObject parent;
    public List<T> List { get; } = new List<T>();

    public int poolCapacity = 20;
    private int nextTestIndex = 0;
    private int NextTestIndex
    {
        get { return nextTestIndex; }
        set
        {
            nextTestIndex = value;
            if (nextTestIndex >= poolCapacity)
                nextTestIndex = 0;
        }
    }

    private bool isPopulated = false;
    private bool toDestroy;
    private int stragglerCount;

    public bool TryActivate(Vector2 position, out T activatedObject)
    {
        activatedObject = default;
        if (!isPopulated)
        {
            Debug.LogError("Object pool " + parent.name + " isPopulated is FALSE");
            return false;
        }
        if (toDestroy)
        {
            Debug.LogError("Cannot activate pooled objects in list " + parent.name + " (toDestroy)");
            return false;
        }
        GameObject go = List[NextTestIndex].GameObject;
        // see if the next logical item is good...
        if (go && !go.activeSelf)
        {
            go.SetActive(true);
            activatedObject = List[NextTestIndex];
            activatedObject.Activate(position);
            ++NextTestIndex;
            return true;
        }
        // otherwise iterate for one...
        for (int i = 0; i < poolCapacity; i++)
        {
            if (this == null)
                break;
            go = List[i].GameObject;
            if (go && !go.activeSelf)
            {
                go.SetActive(true);
                activatedObject = List[i];
                activatedObject.Activate(position);
                NextTestIndex = i + 1;
                return true;
            }
        }
        // otherwise out null and return false
        activatedObject = default; 
        return false; 
    }

    public void Empty(int newCapacity)
    {
        if (List == null)
            return;
        List.ForEach(o => { if (this != null && o != null) GameObject.Destroy(o.GameObject); });
        List.Clear();
        List.Capacity = poolCapacity = newCapacity;
        GameObject.Destroy(parent);
        isPopulated = false;
    }

    public void MarkForDestruction()
    {
        toDestroy = true;

        for (int i = 0; i < List.Count; i++)
        {
            //if (this != null && list != null && list[i] != null && list[i].GameObject != null && list[i].GameObject.activeSelf)
            if (List[i].GameObject != null && List[i].GameObject.activeSelf)
            {
                ++stragglerCount;
                List[i].OnDeactivate += HandleStragglerDeactivated;
            }
        }
        if(stragglerCount == 0)
        {
            Empty(0);
        }
    }

    private void HandleStragglerDeactivated()
    {
        --stragglerCount;
        if (stragglerCount <= 0)
        {
            Empty(0);
        }
    }

    public void Populate(T original, string suffix = "", Action<T> forEach = null)
    {
        if (isPopulated)
            Empty(poolCapacity);
        parent = new GameObject(string.Format("OBJECT POOL [{0}][{1}]", original.GameObject.name, suffix));
        for (int i = 0; i < poolCapacity; i++)
        {
            T g = UnityEngine.Object.Instantiate(original, parent.transform);
            g.GameObject.SetActive(false);
            forEach?.Invoke(g);
            List.Add(g);
        }
        isPopulated = true;
    }

    public ObjectPool() { }

    public ObjectPool(int capacity)
    {
        List.Capacity = poolCapacity = capacity;
    }
}
