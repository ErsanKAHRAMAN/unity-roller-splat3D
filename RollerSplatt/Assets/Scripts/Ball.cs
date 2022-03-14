using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    private GameManager gm;

    public Rigidbody rb;

    public Image _levelBar;

    private Vector2 _firstPos;

    private Vector2 _secondPos;

    public Vector2 _currentPos;

    public float moveSpeed;

    public float _currentGroundNumbers;




    
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();

    }



    void Update()
    {

        Swipe();
        _levelBar.fillAmount = _currentGroundNumbers / gm._groundNumbers;

        if(_levelBar.fillAmount == 1)
        {
            gm.levelUpdate();
        }
    }

    private void Swipe()
    {

        if (Input.GetMouseButtonDown(0))
        {
            _firstPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);


        }

        if (Input.GetMouseButtonUp(0))
        {
            _secondPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            _currentPos = new Vector2(

                _secondPos.x - _firstPos.x,
                _secondPos.y - _firstPos.y

                ) ;

        }


        _currentPos.Normalize(); 

        if(_currentPos.y < 0 && _currentPos.x > -0.5f && _currentPos.x < 0.5f)
        {
            //Back
            rb.velocity = Vector3.back * moveSpeed;

        }

        else if(_currentPos.y > 0 && _currentPos.x > -0.5f && _currentPos.x< 0.5f)
        {
            //Forward
            rb.velocity = Vector3.forward * moveSpeed;

        }
        else if (_currentPos.x < 0 && _currentPos.y > -0.5f && _currentPos.y < 0.5f)
        {
            //Left
            rb.velocity = Vector3.left * moveSpeed;

        }
        else if (_currentPos.x > 0 && _currentPos.y > -0.5f && _currentPos.y < 0.5f)
        {

            //Right
            rb.velocity = Vector3.right * moveSpeed;
        }






    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.GetComponent<MeshRenderer>().material.color != Color.red)
        {
            if (other.gameObject.tag == "Ground")
            {
                other.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                Constraints();
                _currentGroundNumbers++;
            }

        }
        
        
    }
    private void Constraints()
    {

        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        
    }
}
