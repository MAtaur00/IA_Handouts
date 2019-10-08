using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;

public class FollowCurve : MonoBehaviour
{
    public BansheeGz.BGSpline.Components.BGCcMath path;
    float ratio = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ratio += 0.01f;
        if (ratio > 1.0f)
        {
            ratio = 0.0f;
        }
        transform.position = path.CalcPositionByDistanceRatio(ratio);
    }
}
