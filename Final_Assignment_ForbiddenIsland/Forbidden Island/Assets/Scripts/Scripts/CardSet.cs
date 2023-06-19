using UnityEngine;

public class CardSet : MonoBehaviour
{
    public GameObject[] parentObjects;
    public float delay = 10f;

    private void Start()
    {
        Invoke("ActivateObjectsWithChildren", delay);
    }

    private void ActivateObjectsWithChildren()
    {
        foreach (GameObject parentObject in parentObjects)
        {
            parentObject.SetActive(true);

            foreach (Transform child in parentObject.transform)
            {
                SpriteRenderer childSpriteRenderer = child.GetComponent<SpriteRenderer>();
                if (childSpriteRenderer != null)
                {
                    childSpriteRenderer.enabled = true;
                }
            }
        }
    }
}