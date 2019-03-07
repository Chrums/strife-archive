using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ModifierManager : MonoBehaviour
{
    private List<Modifier> modifiers = new List<Modifier>();
    
    public T Add<T>() where T : Modifier
    {
        T modifier = gameObject.AddComponent<T>();
        this.Add(modifier);
        return modifier;
    }

    public void Add(Modifier modifier)
    {
        this.modifiers.Add(modifier);
        modifier.Added();
    }

    public void Remove<T>() where T : Modifier
    {
        List<Modifier> modifiers = this.modifiers.Where(modifier => modifier.GetType() == typeof(T)).ToList();
        foreach (Modifier modifier in modifiers)
        {
            this.Remove(modifier);
        }
    }

    public void Remove(Modifier modifier)
    {
        modifier.Removed();
        this.modifiers.Remove(modifier);
        GameObject.Destroy(modifier);
    }
}
