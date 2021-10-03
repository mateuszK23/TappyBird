using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject topPipe;
    public GameObject bottomPipe;

    private float timeElapsed;
    private float timeBetweenSpawns;

    private int pipesSpawned;
    private Difficulty currentDifficulty;
    private float gap;

    public enum Difficulty{
        SuperEasy,
        Easy,
        Medium,
        AlmostHard,
        Hard,
        SuperHard,
    };

    void Start()
    {   
        currentDifficulty = Difficulty.SuperEasy;
        setGap(currentDifficulty);
        pipesSpawned = 0;
        timeElapsed = timeBetweenSpawns;
        timeBetweenSpawns = 1f;
    }

    private void Update()
    {
        trackPipesSpawned();
        setGap(currentDifficulty);
        spawnPipe();    
    }

    private void spawnPipe()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed >= timeBetweenSpawns)
        {
            GameObject topP = Instantiate(topPipe);
            GameObject botP = Instantiate(bottomPipe);
            float y = transform.position.y + Random.Range(0, 5 - gap);
            topP.transform.position = new Vector3(transform.position.x, y + gap, transform.position.z);
            botP.transform.position = new Vector3(transform.position.x, y - gap, transform.position.z);
            timeElapsed = 0;
            pipesSpawned++;
        }
    }

    private void trackPipesSpawned()
    {
        if(pipesSpawned >= 50) currentDifficulty = Difficulty.SuperHard;
        else if (pipesSpawned >= 40) currentDifficulty = Difficulty.Hard;
        else if (pipesSpawned >= 30) currentDifficulty = Difficulty.AlmostHard;
        else if (pipesSpawned >= 20) currentDifficulty = Difficulty.Medium;
        else if (pipesSpawned >= 10) currentDifficulty = Difficulty.Easy;
    }

    private void setGap(Difficulty difficulty)
    {
        switch (difficulty)
        {
            case Difficulty.SuperEasy:
                gap = 3f;
                break;
            case Difficulty.Easy:
                gap = 2.75f;
                break;
            case Difficulty.Medium:
                gap = 2.5f;
                break;
            case Difficulty.AlmostHard:
                gap = 2f;
                break;
            case Difficulty.Hard:
                gap = 1.5f;
                break;
            case Difficulty.SuperHard:
                gap = 1f;
                break;
        }
    }
}
