using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCheckController : MonoBehaviour
{
    float timer;
    string barrierTag = "Barrier";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            timer = 0;
            Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity);
            int counter = 0;
            foreach(Collider collider in hitColliders)
            {
                if (collider.gameObject.CompareTag(barrierTag))
                {
                    counter++;
                }
            }
            if(counter == 0)
            {
                PlayerController.Instance.WinAnimation();
            }
        }
    }
}
