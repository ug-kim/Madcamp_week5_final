﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static int gridWidth = 10;
    public static int gridHeight = 20;

    public static Transform[,] grid = new Transform[gridWidth, gridHeight];

    public int scoreOneLine = 200;
    public int scoreTwoLine = 500;
    public int scoreThreeLine = 1000;
    public int scoreFourLine = 2000;

    public AudioClip clearedLineSound;

    public Text hud_score;

    private int numberOfRowsThisTurn = 0;

    private AudioSource audioSource;

    public static int currentScore = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnNextTetronemo();
        ResetScore();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        UpdateScore();

        UpdateUI();
    }

    public void UpdateUI ()
    {
        hud_score.text = currentScore.ToString();
    }

    public void ResetScore()
    {        
        currentScore = 0;
        hud_score.text = currentScore.ToString();
    }

    public void UpdateScore ()
    {
        if (numberOfRowsThisTurn > 0)
        {
            if (numberOfRowsThisTurn == 1)
            {
                ClearedOneLine();

            } else if (numberOfRowsThisTurn == 2)
            {
                ClearedTwoLines();

            } else if (numberOfRowsThisTurn == 3)
            {
                ClearedThreeLines();

            } else if (numberOfRowsThisTurn == 4)
            {
                ClearedFourLines();

            }

            numberOfRowsThisTurn = 0;

            PlayLineClearedSound();
        }
    }

    public void ClearedOneLine ()
    {
        currentScore += scoreOneLine;
    }

    public void ClearedTwoLines()
    {
        currentScore += scoreTwoLine;
    }

    public void ClearedThreeLines ()
    {
        currentScore += scoreThreeLine;
    }

    public void ClearedFourLines ()
    {
        currentScore += scoreFourLine;
    }

    public void PlayLineClearedSound()
    {
        audioSource.PlayOneShot(clearedLineSound);
    }
    
    public bool CheckIsAboveGrid (Tetronemo tetronemo)
    {
        for (int x = 0; x < gridWidth; ++x)
        {
            foreach (Transform nemo in tetronemo.transform)
            {
                Vector2 pos = Round(nemo.position);
                if (pos.y > gridHeight - 1)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool IsFullRowAt (int y)
    {
        for(int x = 0; x < gridWidth; ++x)
        {
            if (grid[x, y] == null)
            {
                return false;
            }
        }

        // Since we found a full row, we increment the full row variable
        numberOfRowsThisTurn++;

        return true;
    }

    public void DeleteNemoAt (int y)
    {
        for (int x = 0; x < gridWidth; ++x)
        {
            Destroy (grid[x, y].gameObject);
            grid[x, y] = null;
        }
    }

    public void MoveRowDown (int y)
    {
        for (int x = 0; x < gridWidth; ++x)
        {
            if(grid[x, y] != null)
            {
                grid[x, y-1] = grid[x, y];
                grid[x, y] = null;
                grid[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    public void MoveAllRowsDown (int y)
    {
        for (int i = y; i < gridHeight; ++i)
        {
            MoveRowDown(i);
        }
    }

    public void DeleteRow ()
    {
        for (int y = 0; y < gridHeight; ++y)
        {
            if (IsFullRowAt(y))
            {
                DeleteNemoAt(y);
                MoveAllRowsDown(y + 1);
                --y;
            }
        }
    }

    public void UpdateGrid (Tetronemo tetronemo)
    {
        for (int y = 0; y < gridHeight; ++y)
        {
            for (int x = 0; x < gridWidth; ++x)
            {
                if (grid[x, y] != null)
                {
                    if (grid[x, y].parent == tetronemo.transform)
                    {
                        grid[x, y] = null;
                    }
                }
            }
        }

        foreach (Transform nemo in tetronemo.transform)
        {
            Vector2 pos = Round(nemo.position);
            if (pos.y < gridHeight)
            {
                grid[(int)pos.x, (int)pos.y] = nemo;
            }
        }
    }

    public Transform GetTransformAtGridPosition (Vector2 pos)
    {
        if (pos.y > gridHeight -1)
        {
            return null;

        } else
        {
            return grid[(int)pos.x, (int)pos.y];
        }
    }

    public void SpawnNextTetronemo ()
    {
        GameObject nextTetronemo = (GameObject)Instantiate(Resources.Load(GetRandomTetronemo(), typeof(GameObject)), new Vector2(5.0f, 20.0f), Quaternion.identity);
    }

    public bool CheckIsInsideGrid (Vector2 pos)
    {
        return ((int)pos.x >= 0 && (int)pos.x < gridWidth && (int)pos.y >= 0);
    }

    public Vector2 Round (Vector2 pos)
    {
        return new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y));
    }

    string GetRandomTetronemo ()
    {
        int randomTetronemo = Random.Range(1, 8);

        string randomTetronemoName = "Prefabs/Tetronemo_T";

        switch (randomTetronemo)
        {
            case 1:
                randomTetronemoName = "Prefabs/Tetronemo_T";
                break;
            case 2:
                randomTetronemoName = "Prefabs/Tetronemo_Long";
                break;
            case 3:
                randomTetronemoName = "Prefabs/Tetronemo_Square";
                break;
            case 4:
                randomTetronemoName = "Prefabs/Tetronemo_J";
                break;
            case 5:
                randomTetronemoName = "Prefabs/Tetronemo_L";
                break;
            case 6:
                randomTetronemoName = "Prefabs/Tetronemo_S";
                break;
            case 7:
                randomTetronemoName = "Prefabs/Tetronemo_Z";
                break;          
        }

        return randomTetronemoName;
        
    }

    public void GameOver()
    {
        SceneManager.LoadScene("tetrisEnd");
    }

}
