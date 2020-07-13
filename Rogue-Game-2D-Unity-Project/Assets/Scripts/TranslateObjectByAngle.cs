using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TranslateObjectByAngle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private Vector2 RotateVector2(Vector2 vector, float angle)
    {
        double angleRadians = (Math.PI / 180.0) * (double)(angle);
        double vector2Length = vector.magnitude;
        double newX = Math.Cos(angleRadians) * vector2Length;
        double newY = Math.Sin(angleRadians) * vector2Length;

        return new Vector2((float)(newX), (float)(newY));
    }

}
