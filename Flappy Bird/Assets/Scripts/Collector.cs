using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void Update()
    {
        transform.SetPositionAndRotation(new Vector3(transform.position.x,0,transform.position.z), Quaternion.Euler(0,0,0));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ColumnHolder"))
            Destroy(collision.gameObject);
    }
}
