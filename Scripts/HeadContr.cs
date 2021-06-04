using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadContr : MonoBehaviour
{
    Transform head_tr;

    float MouseX;
    float MouseY;
    public float sens = 3f;
    public GameObject firstCam;
    public GameObject secondCam;
    bool isActive = false;
    
    void Start()
    {
        head_tr = GetComponent<Transform>();
    }


    void Update()
    {
        MouseX = MouseX + Input.GetAxis("Mouse X") * sens;
        MouseY = MouseY - Input.GetAxis("Mouse Y") * sens;

        MouseY = Mathf.Clamp(MouseY, -90, 90);

        head_tr.rotation = Quaternion.Euler(MouseY, MouseX, 0);

        FindObjectOfType<BodyContr>().Poluchatel(MouseX);

        if(Input.GetKeyDown("c"))
        {
            isActive = !isActive;
            secondCam.SetActive(isActive);
            firstCam.SetActive(!isActive);
            /*if(isActive == false)
            {
                secondCam.SetActive(true);
                firstCam.SetActive(false);
                isActive = true;
            }else if(isActive == true)
            {
                secondCam.SetActive(false);
                firstCam.SetActive(true);
                isActive = false;
            }*/
        }
    }
}
