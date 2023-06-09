using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public float gridSizeX = 1f;
    public float gridSizeY = 1f;
    [SerializeField] public int maxSteps = 3;

    private bool isMoving;
    public Vector3 origPos, targetPos;
    private float timeToMove = 0.2f;
    [SerializeField] private int stepsTaken = 0;

    private static GridMovement currentMoveObject;

    // Update is called once per frame
    void Update()
    {
        if (currentMoveObject != null && currentMoveObject != this)
            return; 

        if (Input.GetKey(KeyCode.W) && !isMoving && stepsTaken < maxSteps)
            StartCoroutine(MovePlayer(Vector3.up));

        if (Input.GetKey(KeyCode.A) && !isMoving && stepsTaken < maxSteps)
            StartCoroutine(MovePlayer(Vector3.left));

        if (Input.GetKey(KeyCode.S) && !isMoving && stepsTaken < maxSteps)
            StartCoroutine(MovePlayer(Vector3.down));

        if (Input.GetKey(KeyCode.D) && !isMoving && stepsTaken < maxSteps)
            StartCoroutine(MovePlayer(Vector3.right));
    }

    public IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;
        currentMoveObject = this;

        float elapsedTime = 0;

        origPos = transform.position;
        targetPos = origPos + new Vector3(direction.x * gridSizeX, direction.y * gridSizeY, 0f);

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
        currentMoveObject = null; 
        stepsTaken++;
    }
}