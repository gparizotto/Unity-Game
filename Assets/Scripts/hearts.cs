using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hearts : MonoBehaviour
{
    public GameObject heartsss;
    public bool perdeu_vida = false;
    public int vida = 3;
    [SerializeField] private Image img1, img2, img3;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(perdeu_vida)
        {
            Debug.Log("PerdeuVida");
            if(vida == 3)
            {
                img3.enabled = false;
                // vida--;
                // Destroy(img3);
            }
            if(vida == 2)
            {
                img2.enabled = false;
                // vida--;
                // Destroy(img2);
            }
            if(vida == 1)
            {
                img1.enabled = false;
                // vida--;
                // Destroy(img1);
            }
            perdeu_vida = false;
        }
    }
}
