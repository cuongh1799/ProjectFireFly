using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public Transform target; // reference the player
    private Transform gun_transform;
    private SpriteRenderer spriteRenderer;

    public GameObject bullet;
    public Transform bulletSpawnPoint1;
    public Transform bulletSpawnPoint2;
    public Transform bulletSpawnPoint3;

    [HideInInspector]
    private const float MAX_AMMO = 6;
    bool RELOADING = false;
    public float bulletCount;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform.position = target.position;
        gun_transform = this.transform;
        bulletCount = MAX_AMMO;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position; 
        LookToMouse();

        if (bulletCount > 0 && RELOADING)
        {
            return;
        }
        else if (bulletCount > 0 && !RELOADING)
        {
            shoot();
        }
        else if (bulletCount == 0 && !RELOADING | Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(reload());   
        }

    }

    private void LookToMouse()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gun_transform.position;
        float angleRotate = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angleRotate, Vector3.forward);
        gun_transform.rotation = rotation;

        // Flip the sprite based on the mouse position
        if (direction.x >= 0)
        {
            // Mouse is on the right, so ensure the sprite is not flipped
            spriteRenderer.flipY = false;
        }
        else
        {
            // Mouse is on the left, so flip the sprite
            spriteRenderer.flipY = true;
        }
    }

    private void shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, bulletSpawnPoint1.position, bulletSpawnPoint1.rotation);
            Instantiate(bullet, bulletSpawnPoint2.position, Quaternion.Euler(bulletSpawnPoint2.rotation.eulerAngles + new Vector3(0, 0, 45)));
            Instantiate(bullet, bulletSpawnPoint3.position, Quaternion.Euler(bulletSpawnPoint3.rotation.eulerAngles + new Vector3(0, 0, -45)));
            bulletCount = bulletCount - 3; 
            //bulletCount--;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Instantiate(bullet, bulletSpawnPoint1.position, bulletSpawnPoint1.rotation);
            Instantiate(bullet, bulletSpawnPoint2.position, Quaternion.Euler(bulletSpawnPoint2.rotation.eulerAngles + new Vector3(0, 0, 0)));
            Instantiate(bullet, bulletSpawnPoint3.position, Quaternion.Euler(bulletSpawnPoint3.rotation.eulerAngles + new Vector3(0, 0, 0)));
            bulletCount = bulletCount - 3;
            //bulletCount--;
        }
    }
    IEnumerator reload()
    {
        RELOADING = true;
        yield return new WaitForSeconds(2f);
        bulletCount = MAX_AMMO;
        RELOADING = false;  
    }

    public float getBulletCount()
    {
        return bulletCount;
    }
}
