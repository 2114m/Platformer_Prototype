using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject spiderBulletPrefab;
    public float shotInterval = 1f;
    public float shotForce = 10f;

    public void Start()
    {
        Invoke("Shot", shotInterval);
    }

    void Shot()
    {
        var spider = Instantiate(spiderBulletPrefab, firePoint.position, Quaternion.Euler(0, 0, Random.value * 360));

        var rigid = spider.GetComponent<Rigidbody2D>();

        rigid.AddForce(transform.up * shotForce);

        Destroy(spider, 3f);

        Invoke("Shot", shotInterval);
    }

}
