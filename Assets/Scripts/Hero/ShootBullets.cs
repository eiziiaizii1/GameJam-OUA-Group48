using UnityEngine;
using System.Collections;

public class ShootBullets : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 3f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    private Vector2 directionShot = Vector2.right;
    public HeroMovement HeroMovement;

    [SerializeField] private float attackDelay = 0.5f;
    [SerializeField] private float reloadTime = 2f;
    [SerializeField] private byte bulletLimit = 7;

    private byte bulletCount;
    private bool isReloading = false;
    private bool isShooting = false;
    
    //anim
    private int animAttackID;
    private int animReloadID;
    private Animator anim;
    private bool shooting;
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        HeroMovement = GetComponent<HeroMovement>();
        bulletCount = bulletLimit;
    }
    private void Start()
    {
        AssingHeroAnimatorID();
    }
    public void AssingHeroAnimatorID()
    {
        animAttackID = Animator.StringToHash("attack");
        animReloadID = Animator.StringToHash("reload");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && bulletCount > 0 && !isReloading) // Mouse'un sol tuþuna basýldýðýnda
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 shootDirection = new Vector2(mouseWorldPosition.x - bulletSpawnPoint.position.x, mouseWorldPosition.y - bulletSpawnPoint.position.y).normalized;
            StartCoroutine(ShootLoop(shootDirection));
        }

        if (Input.GetMouseButtonUp(0))
        {
            isShooting = false;
            anim.SetBool(animAttackID, isShooting);
        }

    }


    public void FireBullet()
    {
        anim.SetTrigger(animAttackID);
        Quaternion rotation = Quaternion.Euler(0, 0, HeroMovement.flip ? -90 : 90);//bullet rotate
        Vector2 shootDirection = HeroMovement.flip ? directionShot : -directionShot; //referance heroMovement

        GameObject bulletInstance = Instantiate(bulletPrefab, bulletSpawnPoint.position, rotation);
        BulletHero bullet = bulletInstance.GetComponent<BulletHero>();
        //anim.SetTrigger(animAttackID);
        bullet.Shoot(shootDirection * bulletSpeed);
        Destroy(bulletInstance.gameObject, 6f);
        
    }

    public IEnumerator ShootLoop(Vector2 direction)
    {
        isShooting = true; //start fire
        anim.SetTrigger(animAttackID);
        while (isShooting && bulletCount > 0 && !isReloading)
        {
            FireBullet(direction); //fire

            bulletCount--;

            if (bulletCount == 0)
            {
                StartCoroutine(Reload());
                break;
            }

            yield return new WaitForSeconds(attackDelay);
        }
    }

   /* public void PushAttackMobile()
    {
        if ( bulletCount > 0 && !isReloading)
        {
            StartCoroutine(ShootLoop());
        }

        if (isReloading)
        {
            isShooting = false;
            
        }
        
    }*/

    public void ReleaseAttackMobile()
    {
        isShooting = false;
    }

private IEnumerator Reload()
    {
        isReloading = true; //reload start
        anim.SetBool(animReloadID, true);
        yield return new WaitForSeconds(reloadTime); //reloadtime

        bulletCount = bulletLimit; 
        isReloading = false;
        anim.SetBool(animReloadID, false);
    }
    public void FireBullet(Vector2 direction)
    {
        HeroMovement.FlipTowards(direction);
        anim.SetTrigger(animAttackID);
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90); // Bullet rotation adjusted to shoot direction

        GameObject bulletInstance = Instantiate(bulletPrefab, bulletSpawnPoint.position, rotation);
        BulletHero bullet = bulletInstance.GetComponent<BulletHero>();
        bullet.Shoot(direction * bulletSpeed);
        Destroy(bulletInstance.gameObject, 6f);
    }


}
