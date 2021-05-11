using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicOreSpawner : MonoBehaviour
{
    public GameObject[] ores;
    public GameObject obstacle;
    public float spawnTimer;
    public float spawnTimerStart;
    public int goldChance;
    public int rubyChance;
    public int emeraldChance;
    public int diamondChance;
    public int fuelChance;
    public int magicChance;


    private int patternCounter;
    private int patternMax = 4;
    private int side = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Level.LevelNum == 1)
        {
            spawnOresAndObs();
        }
        else if (Level.LevelNum == 2)
        {
            level2Patterns();
        }
        else if (Level.LevelNum == 3)
        {
            level3Patterns();
        }
    }

        private GameObject orePicker()
    {
        int chanceTotal = goldChance + rubyChance + emeraldChance + diamondChance + fuelChance + magicChance;
        int x = Random.Range(0, chanceTotal);
        if((x -= goldChance) < 0)
        {
            return ores[0];
        } else if ((x -= rubyChance) < 0)
        {
            return ores[1];
        } else if ((x -= emeraldChance) < 0)
        {
            return ores[2];
        } else if ((x-=diamondChance) < 0)
        {
            return ores[3];
        } else if ((x-=fuelChance) < 0)
        {
            return ores[4];
        } else
        {
            return ores[5];
        }
    }

    private void spawnOresAndObs()
    {
        if (spawnTimer <= 0)
        {
            int remainingPostions = 6;
            bool[] positions = { false, false, false, false, false, false };
            int randNumObs = Random.Range(1, 4);
            remainingPostions -= randNumObs;
            int randNumOres = Random.Range(0, remainingPostions + 1);
            for (int i = 0; i < randNumOres; i++)
            {
                int randPos = Random.Range(0, 6);
                while (positions[randPos])
                {
                    randPos = Random.Range(0, 6);
                }
                positions[randPos] = true;
                Instantiate(orePicker(), transform.position + new Vector3(-2.5f + (randPos * 1), 0, 0), Quaternion.identity);
            }
            for (int i = 0; i < randNumObs; i++)
            {
                int randPos = Random.Range(0, 6);
                while (positions[randPos])
                {
                    randPos = Random.Range(0, 6);
                }
                positions[randPos] = true;
                Instantiate(obstacle, transform.position + new Vector3(-2.5f + (randPos * 1), 0, 0), Quaternion.identity);
            }
            spawnTimer = 0.5f;
        }
        else
        {
            spawnTimer -= Time.deltaTime;
        }
    }

    private void level2Patterns()
    {
        if(spawnTimer <= 0)
        {
            if(patternCounter == patternMax)
            {
                patternMax = Random.Range(4, 9);
                patternCounter = 0;
                if(side == 0)
                {
                    side = Random.Range(1, 4);
                } else
                {
                    side = 0;
                }
                

            } else
            {
                if (side == 0)
                {
                    Instantiate(obstacle, transform.position + new Vector3(-2.5f, 0, 0), Quaternion.identity);
                    Instantiate(obstacle, transform.position + new Vector3(2.5f, 0, 0), Quaternion.identity);
                    int chance = Random.Range(0, 2);
                    if (chance == 0)
                    {
                        Instantiate(orePicker(), transform.position + new Vector3(1.5f - Random.Range(0, 2), 0, 0), Quaternion.identity);
                        Instantiate(orePicker(), transform.position + new Vector3(-1.5f + Random.Range(0, 2), 0, 0), Quaternion.identity);
                    }
                } else if (side == 1)
                {
                    Instantiate(obstacle, transform.position + new Vector3(-1.5f, 0, 0), Quaternion.identity);
                    Instantiate(obstacle, transform.position + new Vector3(1.5f, 0, 0), Quaternion.identity);
                    Instantiate(obstacle, transform.position + new Vector3(-2.5f, 0, 0), Quaternion.identity);
                    Instantiate(obstacle, transform.position + new Vector3(2.5f, 0, 0), Quaternion.identity);
                    if(Random.Range(0,3) == 0)
                    {
                        Instantiate(orePicker(), transform.position + new Vector3(0.5f, 0, 0), Quaternion.identity);
                        Instantiate(orePicker(), transform.position + new Vector3(-0.5f, 0, 0), Quaternion.identity);
                    }
                }
                else if (side == 2)
                {
                    Instantiate(obstacle, transform.position + new Vector3(-0.5f, 0, 0), Quaternion.identity);
                    Instantiate(obstacle, transform.position + new Vector3(0.5f, 0, 0), Quaternion.identity);
                    Instantiate(obstacle, transform.position + new Vector3(1.5f, 0, 0), Quaternion.identity);
                    Instantiate(obstacle, transform.position + new Vector3(2.5f, 0, 0), Quaternion.identity);
                    int chance = Random.Range(0, 3);
                    if (chance == 0)
                    {
                        Instantiate(orePicker(), transform.position + new Vector3(-2.5f + Random.Range(0, 2), 0, 0), Quaternion.identity);
                    } else if (chance == 1)
                    {
                        Instantiate(obstacle, transform.position + new Vector3(-2.5f + Random.Range(0, 2), 0, 0), Quaternion.identity);
                    }
                } else if (side == 3)
                {
                    Instantiate(obstacle, transform.position + new Vector3(-2.5f, 0, 0), Quaternion.identity);
                    Instantiate(obstacle, transform.position + new Vector3(-1.5f, 0, 0), Quaternion.identity);
                    Instantiate(obstacle, transform.position + new Vector3(-0.5f, 0, 0), Quaternion.identity);
                    Instantiate(obstacle, transform.position + new Vector3(0.5f, 0, 0), Quaternion.identity);
                    int chance = Random.Range(0, 3);
                    if (chance == 0)
                    {
                        Instantiate(orePicker(), transform.position + new Vector3(2.5f - Random.Range(0, 2), 0, 0), Quaternion.identity);
                    }
                    else if (chance == 1)
                    {
                        Instantiate(obstacle, transform.position + new Vector3(2.5f - Random.Range(0, 2), 0, 0), Quaternion.identity);
                    }
                }
                patternCounter++;
            }
            spawnTimer = 0.3f;

        }
        else
        {
            spawnTimer -= Time.deltaTime;
        }
    }

    private void level3Patterns()
    {
        if (spawnTimer <= 0)
        {
            if (patternCounter == patternMax)
            {
                patternMax = Random.Range(7, 11);
                patternCounter = 0;
                if (side == 0)
                {
                    side = 1;
                }
                else
                {
                    side = 0;
                }
            }
            else
            {
                if (side == 0)
                {
                    Instantiate(obstacle, transform.position + new Vector3(-2.5f, 0, 0), Quaternion.identity);
                    Instantiate(obstacle, transform.position + new Vector3(2.5f, 0, 0), Quaternion.identity);
                    int chance = Random.Range(0, 2);
                    if (chance == 0)
                    {
                        Instantiate(orePicker(), transform.position + new Vector3(1.5f - Random.Range(0, 2), 0, 0), Quaternion.identity);
                        Instantiate(orePicker(), transform.position + new Vector3(-1.5f + Random.Range(0, 2), 0, 0), Quaternion.identity);
                    }
                }
                else if (side == 1)
                {
                    Instantiate(obstacle, transform.position + new Vector3(-0.5f, 0, 0), Quaternion.identity);
                    Instantiate(obstacle, transform.position + new Vector3(0.5f, 0, 0), Quaternion.identity);
                    Instantiate(obstacle, transform.position + new Vector3(-2.5f, 0, 0), Quaternion.identity);
                    Instantiate(obstacle, transform.position + new Vector3(2.5f, 0, 0), Quaternion.identity);
                    if (Random.Range(0, 3) == 0)
                    {
                        Instantiate(orePicker(), transform.position + new Vector3(1.5f, 0, 0), Quaternion.identity);
                        Instantiate(orePicker(), transform.position + new Vector3(-1.5f, 0, 0), Quaternion.identity);
                    }
                }
                patternCounter++;
            }
            spawnTimer = 0.3f;

        }
        else
        {
            spawnTimer -= Time.deltaTime;
        }
    }
}
