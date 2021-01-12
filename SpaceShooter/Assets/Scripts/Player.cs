using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] int health = 1000;
    [SerializeField] GameObject playerExplosion;

    [Header("Shooting")]
    [SerializeField] float timeBetweenShots;
    [SerializeField] GameObject lazerShot;
    [SerializeField] GameObject lazerGun;
    [SerializeField] GameObject lazerShotSmallL;
    [SerializeField] GameObject lazerShotSmallR;
    [SerializeField] GameObject lazerGunRight;
    [SerializeField] GameObject lazerGunLeft;

    [Header("Movement")]
    [SerializeField] float speed;
    [SerializeField] float tilt;
    [SerializeField] float xMin, xMax, zMin, zMax;

    Rigidbody ship;
    float deltaX, deltaZ;
    
    void Start()
    {
        ship = GetComponent<Rigidbody>();
        InvokeRepeating("Shoot", 1f, timeBetweenShots);
        InvokeRepeating("ShootSmallGuns", 1f, timeBetweenShots / 2);
    }

    void Update()
    {
        MoveControl();
        TouchControl();
    }


    void MoveControl()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        ship.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;

        float clampedX = Mathf.Clamp(ship.position.x, xMin, xMax);
        float clampedZ = Mathf.Clamp(ship.position.z, zMin, zMax);

        ship.position = new Vector3(clampedX, 0, clampedZ);

        ship.rotation = Quaternion.Euler(ship.velocity.z * tilt, 0, -ship.velocity.x * tilt);
    }

   
    void TouchControl()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    deltaX = touchPos.x - transform.position.x;
                    deltaZ = touchPos.z - transform.position.z;
                    break;

                case TouchPhase.Moved:
                    ship.MovePosition(new Vector3(touchPos.x - deltaX, 0, touchPos.z - deltaZ));
                    break;

                case TouchPhase.Ended:
                    ship.velocity = Vector3.zero;
                    break;
            }

        }  
    }

    void Shoot()
    {
        Instantiate(lazerShot, lazerGun.transform.position, Quaternion.identity);
    }

    void ShootSmallGuns()
    {
        Instantiate(lazerShotSmallL, lazerGunLeft.transform.position, Quaternion.Euler(0f, 45f, 0f));
        Instantiate(lazerShotSmallR, lazerGunRight.transform.position, Quaternion.Euler(0f, -45f, 0f));
    }

    private void OnTriggerEnter(Collider other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            health = 0;
            Destroy(gameObject);
            Instantiate(playerExplosion, transform.position, Quaternion.identity);
            FindObjectOfType<SceneLoader>().LoadGameOver();
        }
    }

    public int GetHealth() { return health; }
}
