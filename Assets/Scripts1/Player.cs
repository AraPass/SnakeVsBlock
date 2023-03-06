using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static Food;
using static Game;
using static UnityEditor.Progress;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    public float speed = 6;
    private bool _testing = false;
    

    private GameObject SnakeBody;

    public GameObject Head;
    public GameObject Tail;
    private GameObject circle;
   
    public float CircleD;
    public GameObject wall_out;
    private List<Transform> tails = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();

    
    
    public List<GameObject> tailsCLONE = new List<GameObject>();
    
   



    public IList BodySnake = new List<Transform>();
    private CharacterController _controller;

    public int Lenght = 1;
    public TextMeshPro PointText;

    private bool methodoff;

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
        circle = Instantiate(Tail, positions[positions.Count - 1], Quaternion.identity, Head.transform);
        tailsCLONE.Add(circle);
        tails.Add(circle.transform);
        positions.Add(circle.transform.position);
        
    }


   /* public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Wall")
        {
            Destroy(collision.gameObject);
        }
    }
   */
    public void DeleteCircle()


    {

        
        tailsCLONE.Remove(circle); 
        tails.Remove(circle.transform);
        positions.Remove(circle.transform.position);
        Destroy(circle.gameObject);
        //Destroy(circle.gameObject);
        

        //for (int i = 0; i < tails.Count; i--)
        //Destroy(Tail.gameObject);

        //GameObject fuckchild = transform.Find("Tail (Clone)").gameObject;
        
       /* if (fuckchild != null)
        {
            Destroy(fuckchild);
        }
       */
       /* if (transform.name == "Tail (Clone)")
        {
            
            Destroy(this);
        }
       */
         //GameObject circle = Instantiate(Tail, positions[positions.Count - 1], Quaternion.identity, Head);
        

        /*if (circle.childCount < tails.Count)
         //for (int i = 0; i < circle.childCount; i--)
         {

                  //tails.Remove(circle);
                  //positions.Remove(circle.position);
                  Destroy(gameObject);
              }
             */
        //GetComponent<Player>().tails.Clear();
        //GetComponent<Player>().positions.Clear();
        //Transform circle = Instantiate(Tail, positions[positions.Count - 1], Quaternion.identity, Head);

        /* for (int i = 0; i > tails.Count; i--)
             {
             tails.Clear();
                 //Destroy(transform.GetChild(i--).gameObject);
             }

         */



    }

    private void Start()
    {
        //BodySnake.Clear();
        for (int i = 0; i < 5; i++) AddTile();
        
        positions.Add(Tail.transform.position);
        

        _controller = GetComponent<CharacterController>();

        PointText.SetText(Lenght.ToString());
    }    



    void FixedUpdate()
    {
        SnakeStap();

        float horizontal = Input.GetAxis("Horizontal");
        //transform.Rotate(speed * Time.deltaTime * horizontal, 0, 0);
        _testing = true;
        _controller.Move(transform.forward * speed * Time.deltaTime);

        float dist = ((Vector3)Head.transform.position - positions[0]).magnitude;
        if (dist > CircleD)
        {
            Vector3 direct = ((Vector3)Head.transform.position - positions[0]).normalized;

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
                Lenght++;
                PointText.SetText(Lenght.ToString());
            }
            
            if (hit.collider.TryGetComponent<Wall>(out var wall))
            {
                if (Lenght <= wall.wallcount1)
                {
                    Debug.Log("game over");
                    if (methodoff == false) AddTile();
                    GetComponent<Controls>().enabled = false;
                    _controller.enabled = false;
                    
                    ReloadLevel();
                }
                else
                {
                    DeleteCircle();
                    Lenght = Lenght - wall.wallcount1;
                    PointText.SetText(Lenght.ToString());
                    wall.SnakeDestroy();

                }
                //Lenght--;
               // PointText.SetText(Lenght.ToString());
                //wall.SnakeDestroy();
                //Debug.Log("game over");
                //if(methodoff == false) AddTile();
                //GetComponent<Controls>().enabled = false;
                //_controller.enabled = false;
                //GetComponent<Game>().ReloadLevel();
                //ReloadLevel();
                //SceneManager.LoadScene(1);
            }

            if (hit.collider.TryGetComponent<Finish>(out var finish))
            {
                //Lenght = 0;
                //PointText.SetText(Lenght.ToString());
                Debug.Log("you win");
                if (methodoff == false) AddTile();
                GetComponent<Controls>().enabled = false;
                _controller.enabled = false;


                ReloadLevel();
                //SceneManager.LoadScene(1);
            }

            _testing = false;
            
        }
    }

     public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    private const string LevelIndexKey = "LevelIndex";
    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }
    
    //private const string LevelIndexKey = "LevelIndex";
}





       

