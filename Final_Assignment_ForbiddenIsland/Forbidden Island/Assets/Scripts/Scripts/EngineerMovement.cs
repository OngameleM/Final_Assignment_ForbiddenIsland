using UnityEngine;

public class EngineerMovement : MonoBehaviour
{
    public float gridSizeX = 1f;
    public float gridSizeY = 1f;
    public int maxShoreUpActions = 2;

    private GridMovement gridMovement;
    private TurnSystem turnSystem;
    private int shoreUpActionsTaken = 0;

    private void Awake()
    {
        gridMovement = GetComponent<GridMovement>();
        turnSystem = FindObjectOfType<TurnSystem>();
    }

    private void Update()
    {
        if (turnSystem.PlayersTurn && shoreUpActionsTaken < maxShoreUpActions && Input.GetKeyDown(KeyCode.Space))
        {
            ShoreUpTiles();
        }
    }

    private void ShoreUpTiles()
    {
        // Implement shoring up 2 tiles for 1 action
        gridMovement.MovePlayer(Input.GetAxis("Horizontal") * Vector3.right + Input.GetAxis("Vertical") * Vector3.up);
        shoreUpActionsTaken++;
    }
}