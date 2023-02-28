using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static Food;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    public float speed = 6;
    private bool _testing = false;
    

    private GameObject SnakeBody;

    public Transform Head;
    public Transform Tail;
    public float CircleD;
    private List<Transform> tails = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();

    public IList BodySnake = new List<Transform>();
    private CharacterController _controller;

    public void AddTile()
    {
        Vector3 Position = transform.position;
        if (BodySnake.Count > 0)
        {
            //Vector3 Position = transform.position;
            Position = (Vector3)BodySnake[BodySnake.Count - 1]; //BodySnake[BodySnake.Count - 1].transform.position
            Position.y += 10f;
            //Instantiate(SnakeBody, Position, Quaternion.identity);
            
            //BodySnake.Add(SnakeBody);

        }
        //Instantiate(Tail, Position, Quaternion.identity);
    }

    public void AddCircle()
    {
        Transform circle = Instantiate(Tail, positions[positions.Count - 1], Quaternion.identity, Head);
        tails.Add(circle);
        positions.Add(circle.position);
    }

    private void Start()
    {
        //BodySnake.Clear();
        for (int i = 0; i < 5; i++) AddTile();
        
        positions.Add(Tail.position);
        
        _controller = GetComponent<CharacterController>();
    }    



    void FixedUpdate()
    {
        SnakeStap();

        float horizontal = Input.GetAxis("Horizontal");
        //transform.Rotate(speed * Time.deltaTime * horizontal, 0, 0);
        _testing = true;
        _controller.Move(transform.forward * speed * Time.deltaTime);

        float dist = ((Vector3)Head.position - positions[0]).magnitude;
        if (dist > CircleD)
        {
            Vector3 direct = ((Vector3)Head.position - positions[0]).normalized;

            //positions.Insert(0, Head.position);
            positions.Insert(0, positions[0] + direct * CircleD);
            positions.RemoveAt(positions.Count - 1);

            dist -= CircleD;
        }
        
        for (int j = 0; j < tails.Count; j++)
        {
            tails[j].position = Vector3.Lerp(positions[j + 1], positions[j], dist / CircleD);
        }
    }

    void SnakeStap()
    {
        if (BodySnake.Count > 0)
        {
           //odySnake[0] = transform.position;
            for (int BodyIndex = BodySnake.Count - 1; BodyIndex > 0; BodyIndex--)
                BodySnake[BodyIndex] = BodySnake[BodyIndex - 1]; //transform.position

        }
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (_testing)
        {
            if (hit.collider.TryGetComponent<Food>(out var Eat))
            {
                Eat.Eating();
                AddTile();
                AddCircle();
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





       

