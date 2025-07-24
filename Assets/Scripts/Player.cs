using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private GameObject weapon;

    [SerializeField]
    private Transform shootTransform;

    [SerializeField]
    private ObjectPool weaponPool;

    [SerializeField]
    private float shootInterval = 0.05f;

    private float lastShootTime = 0f;

    // Update is called once per frame
    void Update()
    {
        //float horizontalInput = Input.GetAxisRaw("Horizontal");
        //float verticalInput = Input.GetAxisRaw("Vertical");
        //Vector3 moveTo = new Vector3(horizontalInput, verticalInput, 0f);

        //transform.position += moveTo * moveSpeed * Time.deltaTime;

        //Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

        //if(Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.position -= moveTo;
        //    //if (transform.position.x > -2.3f)
        //    //{
        //    //    transform.position -= moveTo;
        //    //}
        //}
        //else if(Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.position += moveTo;
        //    //if (transform.position.x < 2.3f)
        //    //{
        //    //    transform.position += moveTo;
        //    //}
        //}

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float toX = Mathf.Clamp(mousePos.x, -2.35f, 2.35f);
        transform.position = new Vector3(toX, transform.position.y, transform.position.z);

        Shoot();
    }

    void Shoot()
    {
        if (Time.time - lastShootTime > shootInterval)
        {
            GameObject pooledWeapon = weaponPool.Get();
            pooledWeapon.transform.position = shootTransform.position;
            pooledWeapon.transform.rotation = Quaternion.identity;

            Weapon weaponScript = pooledWeapon.GetComponent<Weapon>();
            weaponScript.Init(weaponPool);

            lastShootTime = Time.time;
        }

        //if(Time.time - lastShootTime > shootInterval)
        //{
        //    Instantiate(weapon, shootTransform.position, Quaternion.identity);
        //    lastShootTime = Time.time;
        //}

    }
}