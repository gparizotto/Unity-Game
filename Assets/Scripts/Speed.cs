using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Speed : MonoBehaviour
{
    public float speed;
    public float prev;
    public TextMeshProUGUI scoreText;

    // void Start()
    // {
    //     StartCoroutine(CalcSpeed());
    // }

    // IEnumerator CalcSpeed()
    // {
    //     bool isPlaying = true;

    //     while(isPlaying)
    //     {
    //         Vector3 prevPos = transform.position;
    //         yield return new WaitForFixedUpdate();
    //         speed = Mathf.RoundToInt(Vector3.Distance(transform.position, prevPos) / Time.deltaTime);
    //         Debug.Log(speed);
    //         if(speed != 0)
    //             scoreText.text = "speed: " + speed.ToString();
    //         prev = speed;
    //         Debug.Log(speed);
    //     }
    // }

    void Start()
    {

    }

    void Update()
    {
        StartCoroutine(CalculateSpeed());
        if(speed != 0)
        {
            float aux = speed * 3;
            if(speed > 1)
                scoreText.text = aux.ToString("0");
            else    
                scoreText.text = "0";
        }
    }

    IEnumerator CalculateSpeed()
    {
        Vector3 lastPosition = transform.position;
        yield return new WaitForFixedUpdate();
        speed = (lastPosition - transform.position).magnitude / Time.deltaTime;
    }
}
