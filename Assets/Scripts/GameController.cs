using System.Collections;
using UnityEngine;
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

    private void Start()
    {
        StartCoroutine(SpawnWaves());
        _score = 0;
        UpdateScore();
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
        }
    }

    public void AddScore(int newScore)
    {
        _score += newScore;
        UpdateScore();
    }

    private void UpdateScore()
    {
        ScoreText.text = "Score: " + _score;
    }
}