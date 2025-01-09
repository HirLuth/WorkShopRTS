using System;
using UnityEngine;

public class CameraInstance : MonoBehaviour
{
    public static CameraInstance instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
