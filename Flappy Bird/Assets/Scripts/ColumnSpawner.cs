using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    private float columnposition;
    private GameObject column;
    [SerializeField] private GameObject columnholder;
    private Vector3 v;
    [SerializeField] private Transform spawner;
    void Start()
    {
        StartCoroutine(Columnspawner());
    }

    IEnumerator Columnspawner()
    {
        while (Bird.isAlive)
        {
            yield return new WaitForSeconds(2.5f);
            columnposition = Random.Range(-1.0f,3.0f);
            column = Instantiate(columnholder);
            column.transform.position = new Vector3(spawner.position.x,columnposition,spawner.position.z);
        }
    }
}
