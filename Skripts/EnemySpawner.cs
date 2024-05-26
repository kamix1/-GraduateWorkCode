using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    float timer;
    public List<Transform> points;
    public GameObject enemy;
    int enemycount;

    void Start()
    {
        enemycount = 0;
        Transform pointObjects = GameObject.FindGameObjectWithTag("points").transform;
        foreach (Transform t in pointObjects)
            points.Add(t);
        StartCoroutine(EnemySpawn());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator EnemySpawn()
    {
        while (enemycount < 10) // Этот цикл будет повторяться, пока условие не будет выполнено
        {
            Debug.Log("done");
            Instantiate(enemy, points[Random.Range(0, points.Count)].position, Quaternion.identity);
            enemycount++;
            yield return new WaitForSeconds(5f);
        }
    }

}
