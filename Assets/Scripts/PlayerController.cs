using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    public BulletCreater bulletCreater;
    float startHealth;
    float health;
    public bool isWinning = false;

    [SerializeField] float playerLoseHealthCoef = 0.5f;
    [SerializeField] float percentHealthToLoose = 20f;

    // Start is called before the first frame update
    void Start()
    {
        bulletCreater = gameObject.AddComponent<BulletCreater>();
        bulletCreater.player = gameObject;
        Instance = this;
        startHealth = transform.localScale.x;
        health = startHealth;

        PathPredictionController.Instance.player = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveHealth(float powerSpeed)
    {
        Vector3 scalingVector = new Vector3(powerSpeed, powerSpeed, powerSpeed);
        gameObject.transform.localScale -= scalingVector * Time.deltaTime * playerLoseHealthCoef;
        health = transform.localScale.x / startHealth;
        if(health < percentHealthToLoose / 100f)
        {
            GameSceneController.Instance.Defeat();
        }
    }

    public void WinAnimation()
    {
        isWinning = true;
        Animator animator = GetComponent<Animator>();
        animator.SetBool("win", true);
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("End"))
        {
            GameSceneController.Instance.Win();
        }

    }
}
