using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVectors = new Vector3(10f, 10f, 10f);
    [SerializeField] float period = 2f;  
    // 設定週期每秒幾次。
    [Range(0,1)] [SerializeField] float movementFactor;

    Vector3 starterpos;

    // Start is called before the first frame update
    void Start()
    {
        starterpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; } //[DEBUG]去除當period為0時一直跳出的bug
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2f;
        float SinWave = Mathf.Sin(cycles * tau);
        //設定出基本sin震盪函數


        movementFactor = SinWave / 2f + 0.5f; 
        //將震盪範圍限制在0~1之間。

        Vector3 offset = movementVectors * movementFactor;
        transform.position = starterpos + offset;
        //print(transform.position);
    }
}
