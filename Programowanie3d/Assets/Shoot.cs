using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject Ammo;
    [SerializeField] Transform FirePoint;

    public float ammoForce = 20f;
    private Vector3 FirePointPosition;

    public int shotForSecond = 1;
    float timeBetweenShoots;
    float timeSinceLastShot;

    enum GunMode
    {
        OnBulletShot,
        SeriesBullet,
        RayShot,
    }

    GunMode gunMode = GunMode.OnBulletShot;

    public int damage = 10;
    public float range = 100f;
    public Camera cam;

    void BulletShot()
    {
        FirePointPosition = FirePoint.position;
        GameObject bullet = Instantiate(Ammo, FirePointPosition, Quaternion.identity * FirePoint.transform.rotation);

        Rigidbody bulletRigB = bullet.GetComponentInChildren<Rigidbody>();

        bulletRigB.AddForce(transform.forward * ammoForce, ForceMode.Impulse);

        foreach (Transform child in bullet.transform)
        {
            Destroy(child.gameObject, 5);
        }

        Destroy(bullet, 5);
    }

    void OneShot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            BulletShot();
        }
    }
    void SeriesShoot()
    {
        CoutTimeBetweenShoots();
        if (timeSinceLastShot >= timeBetweenShoots && Input.GetButton("Fire1"))
        {
            BulletShot();
            timeSinceLastShot = 0;
        }
        timeSinceLastShot += Time.deltaTime;
    }
    void RayCastShoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);
                if (hit.rigidbody)
                {
                    hit.rigidbody.AddForce(cam.transform.forward * ammoForce, ForceMode.Impulse);
                }
                if (hit.transform.GetComponent<Target>())
                {
                    hit.transform.GetComponent<Target>().TakeDamage(damage);
                }
            }
        }
    }


    void CoutTimeBetweenShoots()
    {
        timeBetweenShoots = (float)1 / shotForSecond;
    }
    void GunChoice()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gunMode = GunMode.OnBulletShot;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gunMode = GunMode.SeriesBullet;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            gunMode = GunMode.RayShot;
        }
    }

    void Update()
    {
        GunChoice();
        switch (gunMode)
        {
            case GunMode.OnBulletShot:
                OneShot();
                break;
            case GunMode.SeriesBullet:
                SeriesShoot();
                break;
            case GunMode.RayShot:
                RayCastShoot();
                break;
            default:
                break;
        }

    }
}
