using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_collision : MonoBehaviour
{
    int bateu = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision c)
    {
        Debug.Log(bateu++);
    }
}
