using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering;

public class LevelManager : MonoBehaviour
{
    public Transform container;

    public List<GameObject> levels;
    public List<LevelPieceBasedSetup> levelPieceBasedSetups;


    private List<LevelPieceBase> spawnedPieces = new List<LevelPieceBase>();
    private LevelPieceBasedSetup currSetup;


    public GameObject currentLevel;
    
    private int index;

    [Header("Animation")]
    public float scaleDuration;
    public float scaleTimeBetweenPieces;
    public Ease ease;

    private void Start()
    {
        //SpawnLevel();
        CreateLevelPieces();
    }

    private void SpawnLevel()
    {
        if (currentLevel != null)
        {
            Destroy(currentLevel);
            index++;
            if (index >= levels.Count)
            {
                ResetLevelIndex();
            }
        }


        currentLevel = Instantiate(levels[index], container);
        currentLevel.transform.localPosition = Vector3.zero;
    }

    #region

    private void CreateLevelPieces()
    {
        
        CleanSpawnedPieces();

        if (currSetup != null)
        {
            Destroy(currSetup);
            index++;
            if (index >= levelPieceBasedSetups.Count)
            {
                ResetLevelIndex();
            }
        }

        index = Random.Range(0, levelPieceBasedSetups.Count);
        currSetup = levelPieceBasedSetups[index];

        for (int i = 0; i < currSetup.numberOfPiecesStart; i++)
        {
            CreateLevelPiece(currSetup.levelPiecesStart);
        }
        for (int i = 0; i < currSetup.numberOfPieces; i++)
        {
            CreateLevelPiece(currSetup.levelPieces);
        }
        for (int i = 0; i < currSetup.numberOfPiecesEnd; i++)
        {
            CreateLevelPiece(currSetup.levelPiecesEnd);
        }

        ColorManager.Instance.ChangeColorByType(currSetup.artType);
        StartCoroutine(ScalePieceByTime());
    }

    private void CleanSpawnedPieces()
    {
        for (int i = spawnedPieces.Count - 1; i >= 0; i--)
        {
            Destroy(spawnedPieces[i].gameObject);
        }

        spawnedPieces.Clear();
    }

    IEnumerator ScalePieceByTime()
    {
        foreach (var p in spawnedPieces)
        {
            p.transform.localScale = Vector3.zero;
        }

        yield return null;

        for (int i = 0; i < spawnedPieces.Count; i++)
        {
            spawnedPieces[i].transform.DOScale(1, scaleDuration).SetEase(ease);
            yield return new WaitForSeconds(scaleTimeBetweenPieces);
        }
    }

    private void CreateLevelPiece(List<LevelPieceBase> list)
    {
        var piece = list[Random.Range(0, list.Count)];
        var spawnedPiece = Instantiate(piece, container);

        if (spawnedPieces.Count > 0)
        {
            var lastPiece = spawnedPieces[spawnedPieces.Count - 1];
            spawnedPiece.transform.position = lastPiece.endPiece.position;
        }

        foreach (var p in spawnedPiece.GetComponentsInChildren<ArtPiece>())
        {
            p.ChangePiece(ArtManager.Instance.GetSetupByType(currSetup.artType).gameObject);
        }

        spawnedPieces.Add(spawnedPiece);
    }

    #endregion

    private void ResetLevelIndex()
    {
        index = 0;
    }

}
