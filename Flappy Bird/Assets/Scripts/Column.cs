using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    private float speed = 3f;
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
    }
}
