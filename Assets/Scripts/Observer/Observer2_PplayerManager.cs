using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Observer2_PplayerManager : MonoBehaviour
{
    [SerializeField] private GameObject m_player;
    private float m_speed;

    private void OnEnable()
    {
        Observer2_NameManager.OnContactSayYourNameEvent += SayYourName;
    }

    private void OnDisable()
    {
        Observer2_NameManager.OnContactSayYourNameEvent -= SayYourName;
    }


    private void SayYourName(string name) => print(name);


    
    // Start is called before the first frame update
    void Start()
    {
        m_speed = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("z"))
        {
            m_player.transform.position += Vector3.forward * Time.deltaTime * m_speed;
        }
        if(Input.GetKey("s"))
        {
            m_player.transform.position += Vector3.back * Time.deltaTime * m_speed;
        }
        if(Input.GetKey("d"))
        {
            m_player.transform.position += Vector3.right * Time.deltaTime * m_speed;
        }
        if (Input.GetKey("q"))
        {
            m_player.transform.position += Vector3.left * Time.deltaTime * m_speed;
        }
    }
}
