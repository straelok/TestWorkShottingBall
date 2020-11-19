using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MouseInput();
    }

    void MouseInput()
    {
        if (PlayerController.Instance.isWinning == false)
        {
            /*
            if (Input.GetMouseButtonDown(0))
            {
                PlayerController.Instance.bulletCreater.CreateBullet();
            }
            if (Input.GetMouseButton(0))
            {
                PlayerController.Instance.bulletCreater.AddPower();
            }
            if (Input.GetMouseButtonUp(0))
            {
                PlayerController.Instance.bulletCreater.LaunchBullet();
            }*/

            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if(touch.phase == TouchPhase.Began)
                {
                    PlayerController.Instance.bulletCreater.CreateBullet();
                }
                if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                {
                    PlayerController.Instance.bulletCreater.AddPower();
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    PlayerController.Instance.bulletCreater.LaunchBullet();
                }
            }
        }
    }
}
