using System;
using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;

//using System.Diagnostics;

//using System.Diagnostics;
using UnityEngine;

public class BowlingPinManager : MonoBehaviour
{
    [SerializeField] GameObject pinPrefab;
    [SerializeField] Vector3 startPosition = new Vector3(0, 0, 10);
    [SerializeField] float pinSpacing = 0.2f;

    void Start()
    {
        SetupPins();
    }

    void SetupPins()
    {
        int totalRows = 4;
        int pinCount = 0;
        for (int row = 0; row < totalRows; row++)
        {
            for (int column = 0; column <= row; column++)

            {
                if (pinCount <= 10)
                {
                    Vector3 position = startPosition + new Vector3(column * pinSpacing - (row * pinSpacing / 2), 0,  row * pinSpacing);
                    GameObject pin =Instantiate(pinPrefab, position, Quaternion.Euler(0, 0, 0));
                    pin.transform.rotation = Quaternion.Euler(0, 0, 0);
                  pinCount++;
                }
            }

        }

    }

   
}
