using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] _grounds;

    public float _groundNumbers;

    public int _currentLevel;

    
    void Start()
    {
        _grounds = GameObject.FindGameObjectsWithTag("Ground");

        Debug.Log("Parça Sayýsý: " + _grounds.Length);
    }

    
    void Update()
    {
        _groundNumbers = _grounds.Length;
        _currentLevel = SceneManager.GetActiveScene().buildIndex; //Mevcut level gösterir
    }


    public void levelUpdate()
    {

        SceneManager.LoadScene(_currentLevel); // mevcut sahnenin kullanýcý kaç isterse ona yükseltilebilir veya indirgeyebilir. 
    }
}
