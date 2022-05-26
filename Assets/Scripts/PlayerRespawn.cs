using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour

{
    private PlayerHealth hb;

    // Start is called before the first frame update
    void Start()
    {
        hb = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hb.isDead)
        {
            SceneManager.LoadScene(0);
        }
    }
}
