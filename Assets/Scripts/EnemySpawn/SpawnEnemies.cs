using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] List<GameObject> enemies = new List<GameObject>();
    [SerializeField] Transform enemyTargetLocation;
    [SerializeField] GameObject heroNpcControllerRaycast;
    HeroNpcController heroNpcControllerScript;

    public float timeInterval = 2;
    public int maxEnemyNumber = 5;
    public int currentEnemyNum = 0;
    public float timePassed = 0;


    // Start is called before the first frame update
    void Start()
    {
        heroNpcControllerScript = heroNpcControllerRaycast.GetComponent<HeroNpcController>();
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        currentEnemyNum = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (timePassed >= timeInterval && currentEnemyNum < maxEnemyNumber)
        {
            int randomEnemyIndex = Random.Range(0, enemies.Count);
            GameObject newEnemy = Instantiate(enemies[randomEnemyIndex], transform.position, Quaternion.identity);
            //SoundManager.Instance.PlayEffectSound(SoundManager.Instance.DyingPlayerSound, 0.01f);

            Transform gunTransform = newEnemy.transform.Find("Gun");

            newEnemy.GetComponent<enemyType1MovementAndShoot>().InitAttributes(gunTransform, enemyTargetLocation,heroNpcControllerScript);
            timePassed = 0;
            timeInterval = Random.Range(1, 5);
        }
    }
}
