using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DrillController : MonoBehaviour
{
    Vector2 newPos;
    public float speed;
    public float upperLim;
    public float lowerLim;
    public float fuelAmount;
    public float fuelBleed;
    public int obsFuelLoss;
    float curScore = 0;
    public Text score;
    public Text fuel;
    private AudioSource soundSource;
    public AudioClip oreSound;
    public AudioClip obsSound;
    public AudioClip fuelSound;
    public AudioClip magicSound;
    public GameObject diamondOre;
    private Animator cameraAnim;
    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score: 0";
        fuel.text = "Fuel: " + fuelAmount.ToString();
        soundSource = GetComponent<AudioSource>();
        cameraAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, newPos, speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > lowerLim)
        {
            newPos = new Vector2(lowerLim, transform.position.y);

        } else if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < upperLim)
        {
            newPos = new Vector2(upperLim, transform.position.y);
        } else
        {
            newPos = transform.position;
        }
        fuelAmount -= fuelBleed * Time.deltaTime;
        fuel.text = "Fuel: " + fuelAmount.ToString("F0");
        if (fuelAmount <= 0.0f)
        {
            SceneManager.LoadScene("DeathScreen");
        }
        if(curScore > 200 && Level.LevelNum == 1)
        {
            SceneManager.LoadScene("Level2Start");
        } else if (curScore > 300 && Level.LevelNum == 2)
        {
            SceneManager.LoadScene("Level3Start");
        }

        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ore")
        {
            curScore += other.gameObject.GetComponent<OreController>().value;
            score.text = "Score: " + curScore.ToString();
            soundSource.PlayOneShot(oreSound);
        } else if (other.tag == "Obstacle")
        {
            soundSource.PlayOneShot(obsSound);
            cameraAnim.SetTrigger("shake");
            fuelAmount -= obsFuelLoss;
        } else if (other.tag == "Fuel")
        {
            soundSource.PlayOneShot(fuelSound);
            fuelAmount += 50;
        } else if (other.tag == "Magic")
        {
            soundSource.PlayOneShot(magicSound);
            GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
            GameObject[] ores = GameObject.FindGameObjectsWithTag("Ore");
            foreach (GameObject obj in obstacles)
            {
                Instantiate(diamondOre, obj.transform.position, Quaternion.identity);
                Destroy(obj);
            }
            foreach(GameObject obj in ores)
            {
                Instantiate(diamondOre, obj.transform.position, Quaternion.identity);
                Destroy(obj);
            }
        }
    }
}
