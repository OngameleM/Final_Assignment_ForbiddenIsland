using UnityEngine;

public class ExplorerMovement : MonoBehaviour
{
    public float gridSizeX = 1f;
    public float gridSizeY = 1f;
    public bool canShoreUp = true;
    public bool canMoveDiagonally = true;

    private GridMovement gridMovement;

    private void Awake()
    {
        gridMovement = GetComponent<GridMovement>();
    }

    private void Update()
    {
        if (canMoveDiagonally)
        {
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
                MoveDiagonally(Vector3.up + Vector3.left);
            else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
                MoveDiagonally(Vector3.up + Vector3.right);
            else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
                MoveDiagonally(Vector3.down + Vector3.left);
            else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
                MoveDiagonally(Vector3.down + Vector3.right);
        }

        if (canShoreUp && Input.GetKeyDown(KeyCode.Space))
        {
            ShoreUpDiagonalTiles();
        }
    }

    private void MoveDiagonally(Vector3 direction)
    {
        gridMovement.MovePlayer(direction);
    }

    private void ShoreUpDiagonalTiles()
    {
        // Implement shoring up diagonally here
    }
}