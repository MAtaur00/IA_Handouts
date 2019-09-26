using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeMouse : MonoBehaviour {

    public float speed = 5.0f;

    public GameObject objective;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, objective.transform.position, speed * Time.deltaTime);
        transform.LookAt(objective.transform.position, Vector3.right);
    }
}
