using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Food;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    public float speed = 6;
    private bool _testing = false;

    public GameObject SnakeBody;
    //public List<Transform> BodySnake;
    public IList BodySnake = new List<Transform>();
    private CharacterController _controller;

    public void AddTile()
    {
        //Vector3 Position = transform.position;
        if (BodySnake.Count > 0)
        {
            Vector3 Position = transform.position;
            Position = transform.position; //BodySnake[BodySnake.Count - 1].
            Position.y += 10f;
            Instantiate(SnakeBody, Position, Quaternion.identity);
            
            BodySnake.Add(SnakeBody);

        }
    }

    private void Start()
    {
        BodySnake.Clear();
        for (int i = 0; i < 5; i++)
            AddTile();
        _controller = GetComponent<CharacterController>();

    }


    void Update()
    {
        SnakeStap();

        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(speed * Time.deltaTime * horizontal, 0, 0);
        _testing = true;
        _controller.Move(transform.forward * speed * Time.deltaTime);

    }

    void SnakeStap()
    {
        if (BodySnake.Count > 0)
        {
            //BodySnake[0].transform.position = transform.position;
            for (int BodyIndex = BodySnake.Count - 1; BodyIndex > 0; BodyIndex--)
                BodySnake[BodyIndex] = BodySnake[BodyIndex - 1]; //transform.position

        }
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (_testing)
        {
            if (hit.collider.TryGetComponent<Food>(out var Food))
            {
                Food.Eating();
                AddTile();
            }
            /*else
            {
                SceneManager.LoadScene("GameOver");
            }

            _testing = false;
            */
        }
    }
}
    
    
   /* public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (_testing)
        {
            if (hit.collider.TryGetComponent<Food>(out var Eat))
            {
                Eat.Eating();
                AddTile();
            }
            else
            {
                SceneManager.LoadScene("GameOver");
            }

            _testing = false;
        } 
    }
    */





       

