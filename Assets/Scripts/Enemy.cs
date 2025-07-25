using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;

    //[SerializeField]
    //private float returnTime = 2f;

    //private ObjectPool enemyPool;

    //public void Init(ObjectPool pool)
    //{
    //    enemyPool = pool;
    //    Invoke(nameof(ReturnToPool), returnTime);
    //}

    //void ReturnToPool()
    //{
    //    enemyPool.Return(gameObject);
    //}

    private float minY = -7f;

    private float hp = 1f;

    public void SetMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            Weapon weapon = collision.gameObject.GetComponent<Weapon>();
            hp -= weapon.damage;

            if (hp <= 0f)
            {
                Destroy(gameObject);
            }
            Destroy(collision.gameObject);
        }
    }
}
