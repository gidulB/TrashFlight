using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;

    private float[] arrPosX = { -2.2f, -1.1f, 0f, 1.1f, 2.2f };

    [SerializeField]
    private float spawnInterval = 1.5f;

    //[SerializeField]
    //private Enemy enemy;

    //[SerializeField]
    //private ObjectPool enemyPool;

    //[SerializeField]
    //private float createEnemyInterval = 0.5f;

    //private float lastCreateTime = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartEnemyRoutine();
    }
    void StartEnemyRoutine()
    {
        StartCoroutine("EnemyRoutine");
    }

    IEnumerator EnemyRoutine()
    {
        yield return new WaitForSeconds(3f);

        float moveSpeed = 5f;
        int spawnCount = 0;
        int enemyIndex = 0;
        while (true)
        {
            foreach (float posX in arrPosX)
            {
                SpawnEnemy(posX, enemyIndex, moveSpeed);
            }

            spawnCount++;

            if (spawnCount % 10 == 0)
            {
                enemyIndex++;
                moveSpeed += 2;
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy(float posX, int index, float moveSpeed)
    {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);

        if (Random.Range(0, 5) == index)
        {
            index += 1;
        }

        if(index >= enemies.Length)
        {
            index = enemies.Length - 1;
        }

        GameObject enemyObject = Instantiate(enemies[index], spawnPos, Quaternion.identity);
        Enemy enemy = enemyObject.GetComponent<Enemy>();
        enemy.SetMoveSpeed(moveSpeed);
    }

    // Update is called once per frame
    //void Update()
    //{
    //    transform.position = new Vector3(0f, 5.5f, 0f);

    //    DropDown();
    //}

    //void DropDown()
    //{
    //    if (Time.time - lastCreateTime > createEnemyInterval)
    //    {
    //        GameObject pooledEnemy = enemyPool.Get();
    //        pooledEnemy.transform.position = transform.position;
    //        pooledEnemy.transform.rotation = Quaternion.identity;

    //        Enemy enemyScript = pooledEnemy.GetComponent<Enemy>();
    //        enemyScript.Init(enemyPool);

    //        lastCreateTime = Time.time;
    //    }
    //}
}
