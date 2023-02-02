using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    
    private int[,] squares = new int[10, 10];

    
    private const int EMPTY = 0;
    private const int WHITE = 1;
    private const int BLACK = -1;

    private int currentPlayer = WHITE;

    
    private Camera camera_object;
    private RaycastHit hit;

    //prefabs
    public GameObject whiteStone;
    public GameObject blackStone;

    // Start is called before the first frame update
    void Start()
    {
        
        camera_object = GameObject.Find("Main Camera").GetComponent<Camera>();

        
        InitializeArray();

        
        DebugArray();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            
            Ray ray = camera_object.ScreenPointToRay(Input.mousePosition);

            
            if (Physics.Raycast(ray, out hit))
            {
                
                int x = (int)hit.collider.gameObject.transform.position.x;
                int z = (int)hit.collider.gameObject.transform.position.z;

                
                if(squares[z,x] == EMPTY)
                {
                
                    if(currentPlayer == WHITE)
                    {
                        
                        squares[z, x] = WHITE;

                        
                        GameObject stone = Instantiate(whiteStone);
                        stone.transform.position = hit.collider.gameObject.transform.position;

                    
                        currentPlayer = BLACK;
                    }
    
                    else if(currentPlayer == BLACK)
                    {
                        
                        squares[z, x] = BLACK;

                        
                        GameObject stone = Instantiate(blackStone);
                        stone.transform.position = hit.collider.gameObject.transform.position;

                
                        currentPlayer = WHITE;
                    }
                }
            }
        }
    }
    
    private void InitializeArray()
    {
        
        for (int i = 0; i < 10;i++)
        {
            for (int j = 0; j < 10;j++)
            {
    
                squares[i, j] = EMPTY;
            }
        }
    }


    private void DebugArray()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Debug.Log("(i,j) = (" + i + "," + j + ") = " + squares[i, j]);
            }
        }
    }
}