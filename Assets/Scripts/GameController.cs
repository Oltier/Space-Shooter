using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject Hazard;
    public Vector3 SpawnValues;

    public int HazardCount;
    public float StartWait;
    public float SpawnWait;
    public float WaveWait;

    public Text ScoreText;
    private int _score;

    public Text RestartText;
    public Text GameOverText;

    private bool _gameOver;
    private bool _restart;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
        _score = 0;
        UpdateScore();

        _gameOver = false;
        _restart = false;

        GameOverText.text = "";
        RestartText.text = "";
    }

    private void Update()
    {
        if (_restart && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(StartWait);
        while (true)
        {
            for (int i = 0; i < HazardCount; i++)
            {
                Vector3 spawnPosition =
                    new Vector3(Random.Range(-SpawnValues.x, SpawnValues.x), SpawnValues.y, SpawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(Hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(SpawnWait);
            }

            yield return new WaitForSeconds(WaveWait);

            if (_gameOver)
            {
                RestartText.text = "Press 'R' for Restart!";
                _restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScore)
    {
        _score += newScore;
        UpdateScore();
    }

    public void GameOver()
    {
        GameOverText.text = "Game Over";
        _gameOver = true;
    }

    private void UpdateScore()
    {
        ScoreText.text = "Score: " + _score;
    }
}