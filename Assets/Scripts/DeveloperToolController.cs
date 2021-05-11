using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeveloperToolController : MonoBehaviour
{
    public bool isNoClip = false;
    public Text statText;
    public Text fpsText;
    bool isInFuel = false;
    private float timer;
    private float hudRefreshRate = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if(!isInFuel)
            {
                isInFuel = true;
                GameObject drill = GameObject.FindWithTag("Player");
                drill.GetComponent<DrillController>().fuelBleed = 0;
                drill.GetComponent<DrillController>().fuelAmount = 999;
                drill.GetComponent<DrillController>().obsFuelLoss = 0;
            } else
            {
                isInFuel = false;
                GameObject drill = GameObject.FindWithTag("Player");
                drill.GetComponent<DrillController>().fuelBleed = 5;
                drill.GetComponent<DrillController>().fuelAmount = 600;
                drill.GetComponent<DrillController>().obsFuelLoss = 50;
            }
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            if(!isNoClip)
            {
                isNoClip = true;
                GameObject[] obs = GameObject.FindGameObjectsWithTag("Obstacle");
                foreach (GameObject obstacle in obs)
                {
                    obstacle.GetComponent<BoxCollider2D>().enabled = false;
                }

            } else
            {
                isNoClip = false;
                GameObject[] obs = GameObject.FindGameObjectsWithTag("Obstacle");
                foreach (GameObject obstacle in obs)
                {
                    obstacle.GetComponent<BoxCollider2D>().enabled = true;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("StartMenu");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("Level2Start");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene("Level3Start");
        }
        statText.text = "Number of objects in scene: " + (GameObject.FindGameObjectsWithTag("Obstacle").Length + GameObject.FindGameObjectsWithTag("Ore").Length + 1);
        if (Time.unscaledTime > timer)
        {
            int fps = (int)(1f / Time.unscaledDeltaTime);
            fpsText.text = "FPS: " + fps;
            timer = Time.unscaledTime + hudRefreshRate;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if(statText.gameObject.activeSelf)
            {
                statText.gameObject.SetActive(false);
                fpsText.gameObject.SetActive(false);
            } else
            {
                statText.gameObject.SetActive(true);
                fpsText.gameObject.SetActive(true);
            }
        }

        /*if(isNoClip)
        {
            GameObject[] obs = GameObject.FindGameObjectsWithTag("Obstacle");
            foreach (GameObject obstacle in obs) {
                obstacle.GetComponent<BoxCollider2D>().enabled = false;
            }
        }*/

    }
}
