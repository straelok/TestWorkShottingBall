using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public bool isLaunched = false;
    string barrierTag = "Barrier";
    public GameObject explosion;
    public float explosionCoef = 3f;
    public float explosionSpriteScaleCoef = 0.2f;

    string bulletPath = "Prefabs/Explosion";

    [SerializeField] float speed = 1f;
    [SerializeField] float explodeRadius = 2f;
    // Start is called before the first frame update
    void Awake()
    {
        explosion = (GameObject)Resources.Load<GameObject>(bulletPath);
        if (explosion == null)
            Debug.LogError("Wrong explosion prefab path");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isLaunched == true)
        {
            transform.Translate(Vector3.forward * Time.fixedDeltaTime * speed); 
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(barrierTag))
        {
            Collider[] objectInRadiusColliders = Physics.OverlapSphere(gameObject.transform.position, transform.localScale.x * explodeRadius);
            foreach(Collider objectInRadius in objectInRadiusColliders)
            {
                if(objectInRadius.CompareTag(barrierTag))
                    Destroy(objectInRadius.gameObject);
            }
            GameObject explosionBuffer;
            explosionBuffer = Instantiate(explosion, transform.position, new Quaternion());
            var psMain = explosionBuffer.GetComponent<ParticleSystem>().main;
            psMain.startSpeed = transform.localScale.x * explosionCoef;
            psMain.startSize = new ParticleSystem.MinMaxCurve(transform.localScale.x * explosionSpriteScaleCoef);
            Destroy(gameObject);
        }
        if (other.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
    }
}
