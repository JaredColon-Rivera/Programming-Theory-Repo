using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour
{

    public MainManager instance;

    public int _health;
    public int _score;
    [SerializeField]
    private Text healthText;

    [SerializeField]
    private Text scoreText;

    void Start()
    {
        _health = 5;
        _score = 0;
        healthText.text = $"Health: {_health}";
        scoreText.text = $"Score: {_score}";
    }

    private void Update()
    {
        if(_health <= 0)
        {
            instance.GameOver();
        }
    }

    public void Hurt(int damage)
    {
        _health -= damage;
        healthText.text = $"Health: {_health}";
        Debug.Log("Health: " + _health);
    }

    public void ScorePoint(int score)
    {
        _score += score;
        scoreText.text = $"Score: {_score}";
    }

   
}
