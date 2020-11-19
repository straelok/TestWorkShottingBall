using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCreater : MonoBehaviour
{
    GameObject bulletPrefab;
    GameObject bullet;
    public GameObject player;
    string bulletPath = "Prefabs/Bullet";
    float powerSpeed = 0.15f;

    public float distanceOfPlayerToSpawn = 1f;
    public void Awake()
    {
        bulletPrefab = (GameObject)Resources.Load<GameObject>(bulletPath);
        if (bulletPrefab == null)
            Debug.LogError("Wrong bullet prefab path");
    }

    private void Update()
    {
        if(PlayerController.Instance.isWinning == true && bullet != null)
        {
            Destroy(bullet);
        }
    }

    public void CreateBullet()
    {
        if (player == null)
            Debug.LogError("Wrong player instance of object in BulletController");

        Vector3 spawnPosition = player.transform.position;
        spawnPosition.z += distanceOfPlayerToSpawn;
        bullet = Instantiate(bulletPrefab, spawnPosition, new Quaternion());
    }

    public void AddPower()
    {
        Vector3 scalingVector = new Vector3(powerSpeed, powerSpeed, powerSpeed);
        bullet.transform.localScale += scalingVector * Time.deltaTime;
        player.GetComponent<PlayerController>().RemoveHealth(powerSpeed);
    }

    public void LaunchBullet()
    {
        bullet.GetComponent<BulletController>().isLaunched = true;
    }

}
