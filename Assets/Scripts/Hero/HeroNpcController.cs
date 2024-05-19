using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class HeroNpcController : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    [SerializeField] float distance;

    [SerializeField] GameObject raycast;
    public enemyType1MovementAndShoot enemyShoot;
    [SerializeField] Transform HeroTransform;
    public bool isAttack = true;
    
    [SerializeField] float isAttackTime = 1f;

    private void Awake()
    {
        //enemyShoot = GetComponentInChildren<enemyType1MovementAndShoot>(); 

        
    }
    private void Update()
    {

        if (isAttack)
        {
            HitEnemy();
            RaycastRotate();
            
        }
           
    }
    public void HitEnemy()
    {
        LayerMask Main = LayerMask.GetMask("Enemies");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, raycast.transform.right, distance, Main);

        if (hit.collider != null && hit.collider.CompareTag("Enemy"))
        {
            
            enemyType1MovementAndShoot enemyComponent = hit.collider.GetComponent<enemyType1MovementAndShoot>();
            if (enemyComponent != null)
            {
                enemyComponent.EnemyAttack(transform.position);
            }
            Debug.DrawLine(transform.position, hit.point, Color.red); // Hit noktasýna kadar çizgi çek
            StartCoroutine(FireCooldown());
        }
    }


    private IEnumerator FireCooldown()
    {
        isAttack = false; // Ateþ edilemez durumu ayarla
        yield return new WaitForSeconds(isAttackTime); // Belirlenen süre kadar bekle
        isAttack = true; // Ateþ edilebilir durumu ayarla
    }

    private void RaycastRotate()
    {
        raycast.transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);

        raycast.transform.right = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z) * Vector2.right;

        Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);

    }
    
}
