using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLights : MonoBehaviour
{
    public enum Side
    {
        Front,
        Back
    }

    [System.Serializable]
    public struct Light
    {
        public GameObject lightObj;
        public Material lightMat;
        public Side side;
    }

    public List<Light> lights;
}

