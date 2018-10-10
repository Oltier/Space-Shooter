using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject AsteroidExplosion;
    public GameObject PlayerExplosion;

    public int ScoreValue;

    private GameController _gameController;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            _gameController = gameControllerObject.GetComponent<GameController>();
        }

        if (_gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary")) return;
        Destroy(other.gameObject);
        Destroy(gameObject);
        Instantiate(AsteroidExplosion, transform.position, transform.rotation);

        if (other.CompareTag("Player"))
        {
            Instantiate(PlayerExplosion, other.transform.position, other.transform.rotation);
            _gameController.GameOver();
        }

        _gameController.AddScore(ScoreValue);
    }
}