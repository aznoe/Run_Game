using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public LevelPiece[] levelPieces;
    public Transform _camera;
    public int drawDistance;

    public float pieceLength;
    public int speed;

    Queue<GameObject> activePieces = new Queue<GameObject>();
    List<int> probabilityList = new List<int>();

    int currentCamStep = 0;
    int lastCamStep = 0;


    void Start()
    {
        BuildProbabilityList();

        //spawnstarting level pieces
        for (int i = 0; i < drawDistance; i++)
        {
            SpawnNewLevelPiece();
        }
        currentCamStep = (int)(_camera.transform.position.x / pieceLength);
        lastCamStep = currentCamStep;

    }


    private void Update()
    {
        _camera.transform.position = Vector2.MoveTowards(_camera.transform.position, _camera.transform.position + Vector3.left, Time.deltaTime * speed);

        currentCamStep = (int)(_camera.transform.position.x / pieceLength);
        if (currentCamStep != lastCamStep)
        {
            lastCamStep = currentCamStep;
            DespawnLevelPiece();
            SpawnNewLevelPiece();
        }



    }


    void SpawnNewLevelPiece()
    {
        int pieceIndex = probabilityList[Random.Range(0, probabilityList.Count)];
        GameObject newLevelPieces = Instantiate(levelPieces[pieceIndex].prefab, new Vector3((currentCamStep + activePieces.Count) * pieceLength, 0f, 1f), Quaternion.identity);
        activePieces.Enqueue(newLevelPieces);

    }

    void DespawnLevelPiece()
    {
        GameObject oldLevelPiece = activePieces.Dequeue();
        Destroy(oldLevelPiece);


    }


    void BuildProbabilityList()
    {
        int index = 0;
        foreach (LevelPiece piece in levelPieces)
        {
            for(int i = 0; i< piece.probability; i++)
            {
                probabilityList.Add(index);

            }

            index++;

        }


    }


}



[System.Serializable]
public class LevelPiece
{
    public string name;
    public GameObject prefab;
    public int probability;

}
