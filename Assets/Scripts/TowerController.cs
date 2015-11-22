using UnityEngine;
using System.Collections;

public class TowerController : MonoBehaviour
{
    public GameObject[] towerPieces;
    private GameObject player;
    private int currentPieceBeingHitInt = 0;
    public int piece = 0;
    public float currentLerpTime = 0f;
    public float lerpTime = 1f;
    private Vector3[] dropStartPos;
    private bool isDropping = false;

    public float dropSpeed = 1f;

    void Awake()
    {
        
        // Get references
        player = GameObject.FindGameObjectWithTag("Player");
        GameObject[] towerPiecesTemp = GameObject.FindGameObjectsWithTag("TowerPiece");
        towerPieces = new GameObject[towerPiecesTemp.Length];
        for (int i = 0; i < towerPiecesTemp.Length; i++)
        {
            for (int u = 0; u < towerPiecesTemp.Length; u++)
            {
                if (towerPiecesTemp[u].GetComponent<TowerModuleController>().placeIndex == i)
                {
                    towerPieces[i] = towerPiecesTemp[u].gameObject;
                }
            }
        }
        //towerPieces[towerPieces.Length - 1] = player;
    }

    public void TakeDamage(int damage)
    {
        if (currentPieceBeingHitInt < towerPieces.Length)
        {
            // Get correct module to damage
            TowerModuleController currentPieceBeingHit = towerPieces[currentPieceBeingHitInt].GetComponent<TowerModuleController>();
            currentPieceBeingHit.health -= damage;
            currentPieceBeingHit.CheckSpriteState();

            if (currentPieceBeingHit.health <= 0f)
            {
                // Destroy code here
                currentPieceBeingHit.ModuleDestroy();

                // Here the last module is destroyed so movement will only apply to the rest of the modules
                currentPieceBeingHitInt++;
                int u = 0;
                dropStartPos = new Vector3[towerPieces.Length - currentPieceBeingHitInt + 1];
                GameObject[] dropTargets = new GameObject[dropStartPos.Length];

                if (currentPieceBeingHitInt < towerPieces.Length)
                {                   
                    for (int i = currentPieceBeingHitInt; i < towerPieces.Length; i++)
                    {
                        dropStartPos[u] = towerPieces[i].transform.position;
                        dropTargets[u] = towerPieces[i];
                        u++;
                    }              
                }
                dropStartPos[u] = player.transform.position;
                dropTargets[u] = player;

                isDropping = true;

                gameObjectsToMove = dropTargets;
                startPositions = dropStartPos;
                dropDistance = currentPieceBeingHit.dropDistance;


            }
        }
        else
        {
            player.GetComponent<PlayerState>().TakeDamage(damage);
        }
    }



    public GameObject[] gameObjectsToMove;
    Vector3[] startPositions;
    float dropDistance;

    void Update()
    {
        piece = currentPieceBeingHitInt;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(5);
        }

        if (isDropping)
        {
            currentLerpTime += dropSpeed * Time.deltaTime;
            float t = currentLerpTime / lerpTime;
            t = 1f - Mathf.Cos(t * Mathf.PI * 0.5f);

            for (int i = 0; i < gameObjectsToMove.Length; i++)
            {
                gameObjectsToMove[i].transform.position = Vector3.Lerp(startPositions[i], new Vector3(startPositions[i].x, startPositions[i].y - dropDistance, startPositions[i].z), t);
            }
            if (currentLerpTime >= 1f)
            {
                currentLerpTime = 0f;
                isDropping = false;
            }
        }
    }
    public int getpiece()
    {
        return piece;
    }
}
