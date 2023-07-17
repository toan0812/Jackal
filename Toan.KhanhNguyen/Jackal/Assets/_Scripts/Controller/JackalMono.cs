using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackalMono : MonoBehaviour
{
    protected virtual void Reset()
    {
        LoadComponent();
    }
    protected virtual void Awake()
    {
        LoadComponent();
    }

    public virtual void LoadComponent()
    {
        // LoadComponent()
    }
}
