using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Enemy enemy;

    [SerializeField]
    private ObjectPool enemyPool;

    [SerializeField]
    private float createEnemyInterval = 0.5f;

    private float lastCreateTime = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0f, 5.5f, 0f);

        DropDown();
    }

    void DropDown()
    {
        if (Time.time - lastCreateTime > createEnemyInterval)
        {
            GameObject pooledEnemy = enemyPool.Get();
            pooledEnemy.transform.position = transform.position;
            pooledEnemy.transform.rotation = Quaternion.identity;

            Enemy enemyScript = pooledEnemy.GetComponent<Enemy>();
            enemyScript.Init(enemyPool);

            lastCreateTime = Time.time;
        }
    }
}
