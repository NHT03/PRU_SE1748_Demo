using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//PQ3
public class BackgroundLoop : MonoBehaviour
{
    [SerializeField]
    GameObject backgroundPref;
    [SerializeField]
    float backgroundWidth;

    int bgCount;
    float cameraWidth;
    List<GameObject> backgroundPool;
    bool isFacingRight;
    // Start is called before the first frame update
    void Start()
    {
        isFacingRight = gameObject.GetComponent<PlayerMovementAnimator>();
        backgroundPool = new List<GameObject>();
        cameraWidth = Camera.main.orthographicSize * Camera.main.aspect*2;
        bgCount = (int)Mathf.Ceil((cameraWidth+backgroundWidth)/backgroundWidth);
        for (int i = 0; i < bgCount; i++)
        {
            GameObject bg = Instantiate(backgroundPref);
            Vector3 position = new Vector3(
                    Camera.main.transform.position.x - cameraWidth / 2 + backgroundWidth / 2 + i * backgroundWidth,
                    Camera.main.transform.position.y,
                    backgroundPref.transform.position.z
                );
            bg.transform.position = position;
            backgroundPool.Add(bg);

        }
    }

    // Update is called once per frame
    void Update()
    {
        // Lấy Cinemachine Brain từ Camera.main
        CinemachineBrain brain = Camera.main.GetComponent<CinemachineBrain>();
        CinemachineVirtualCamera activeVirtualCamera = brain.ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>();
        isFacingRight = activeVirtualCamera.Follow.gameObject.GetComponent<PlayerMovementAnimator>().facingRight;
        //Debug.LogWarning(activeVirtualCamera.Follow.gameObject.GetComponent<PlayerMovementAnimator>());
        //isFacingRight = gameObject.GetComponent<CinemachineVirtualCamera>().gameObject.GetComponent<PlayerMovementAnimator>().facingRight;
        foreach (GameObject bg in backgroundPool)
        {
            if (isFacingRight)
            {
                if (bg.transform.position.x + backgroundWidth / 2 <= Camera.main.transform.position.x - cameraWidth / 2)
                {
                    bg.transform.position = new Vector3(
                            bg.transform.position.x + bgCount * backgroundWidth,
                            bg.transform.position.y,
                            bg.transform.position.z
                        );
                }
            } else
            {
                if (bg.transform.position.x - backgroundWidth / 2 >= Camera.main.transform.position.x + cameraWidth / 2)
                {
                    bg.transform.position = new Vector3(
                            bg.transform.position.x - bgCount * backgroundWidth,
                            bg.transform.position.y,
                            bg.transform.position.z
                        );
                }
            }
            
        }
    }
}
