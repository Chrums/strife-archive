using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierManager : MonoBehaviour
{
    private List<Modifier> modifiers = new List<Modifier>();
    
    public T Add<T>(params object[] args) where T : Modifier
    {
        T modifier = gameObject.AddComponent<T>();
        this.modifiers.Add(modifier);
        modifier.Added();
        return modifier;
    }

    public void Remove<T>(T modifier) where T : Modifier
    {
        modifier.Removed();
        this.modifiers.Remove(modifier);
        GameObject.Destroy(modifier);
    }
}
