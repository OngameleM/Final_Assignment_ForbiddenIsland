using UnityEngine;

public class DiverMovement : MonoBehaviour
{
    public float gridSizeX = 1f;
    public float gridSizeY = 1f;
    public bool canMoveThroughMissingAndFloodedTiles = true;

    private GridMovement gridMovement;

    private void Awake()
    {
        gridMovement = GetComponent<GridMovement>();
    }

    private void Update()
    {
        if (canMoveThroughMissingAndFloodedTiles && Input.GetKeyDown(KeyCode.Space))
        {
            MoveThroughMissingAndFloodedTiles();
        }
    }

    private void MoveThroughMissingAndFloodedTiles()
    {
        // Implement moving through one or more adjacent missing and/or flooded tiles for 1 action
        gridMovement.MovePlayer(Input.GetAxis("Horizontal") * Vector3.right + Input.GetAxis("Vertical") * Vector3.up);
    }
}