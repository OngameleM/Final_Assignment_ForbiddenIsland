using UnityEngine;

public class NavigatorMovement : MonoBehaviour
{
    public float gridSizeX = 1f;
    public float gridSizeY = 1f;
    public bool canMoveToOtherPlayers = true;
    public int maxAdjacentTiles = 2;

    private GridMovement gridMovement;

    private void Awake()
    {
        gridMovement = GetComponent<GridMovement>();
    }

    private void Update()
    {
        if (canMoveToOtherPlayers && Input.GetKeyDown(KeyCode.Space))
        {
            MoveToAdjacentTiles();
        }
    }

    private void MoveToAdjacentTiles()
    {
        // Implement moving to other players up to 2 adjacent tiles per action
        gridMovement.MovePlayer(Input.GetAxis("Horizontal") * Vector3.right + Input.GetAxis("Vertical") * Vector3.up);
    }
}