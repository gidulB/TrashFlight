using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Pool;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;

    [SerializeField]
    private float returnTime = 1f;

    private ObjectPool weaponPool;

    public void Init(ObjectPool pool)
    {
        weaponPool = pool;
        Invoke(nameof(ReturnToPool), returnTime);
    }

    void ReturnToPool()
    {
        weaponPool.Return(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{
    //    Destroy(gameObject, 1f);
    //}

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }
}
