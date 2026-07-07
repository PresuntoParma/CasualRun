using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelPieceBasedSetup : ScriptableObject
{

    public ArtManager.artType artType;

    public List<LevelPieceBase> levelPiecesStart;
    public List<LevelPieceBase> levelPieces;
    public List<LevelPieceBase> levelPiecesEnd;

    public int numberOfPiecesStart = 3;
    public int numberOfPieces = 5;
    public int numberOfPiecesEnd = 1;
}
