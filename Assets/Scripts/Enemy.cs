using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;

    [SerializeField]
    private float returnTime = 2f;

    private ObjectPool enemyPool;

    public void Init(ObjectPool pool)
    {
        enemyPool = pool;
        Invoke(nameof(ReturnToPool), returnTime);
    }

    void ReturnToPool()
    {
        enemyPool.Return(gameObject);
    }

    //private float minY = -7f;
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        //if (transform.position.y < minY)
        //{
        //    Destroy(gameObject);
        //}
    }
}
