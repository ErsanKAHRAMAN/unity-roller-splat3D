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

        Debug.Log("Par�a Say�s�: " + _grounds.Length);
    }

    
    void Update()
    {
        _groundNumbers = _grounds.Length;
        _currentLevel = SceneManager.GetActiveScene().buildIndex; //Mevcut level g�sterir
    }


    public void levelUpdate()
    {

        SceneManager.LoadScene(_currentLevel); // mevcut sahnenin kullan�c� ka� isterse ona y�kseltilebilir veya indirgeyebilir. 
    }
}
