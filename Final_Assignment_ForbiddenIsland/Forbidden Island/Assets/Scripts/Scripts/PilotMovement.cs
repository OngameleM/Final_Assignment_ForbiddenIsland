using UnityEngine;

public class PilotMovement : MonoBehaviour
{
    public float gridSizeX = 1f;
    public float gridSizeY = 1f;
    public bool canMoveToAnyTile = true;

    private GridMovement gridMovement;
    private TurnSystem turnSystem;

    private void Awake()
    {
        gridMovement = GetComponent<GridMovement>();
        turnSystem = FindObjectOfType<TurnSystem>();
    }

    private void Update()
    {
        if (!turnSystem.PlayersTurn && canMoveToAnyTile && Input.GetKeyDown(KeyCode.Space))
        {
            MoveToAnyTile();
        }
    }

    private void MoveToAnyTile()
    {
        // Implement moving to any tile once per turn for 1 action
        gridMovement.MovePlayer(Input.GetAxis("Horizontal") * Vector3.right + Input.GetAxis("Vertical") * Vector3.up);
    }
}