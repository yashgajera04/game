using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpwaner : MonoBehaviour
{
    private PieceType Type;
    private Pieace CurrentPiece;

    private void Spwan()
    {
        CurrentPiece = LevelManger.Instance.GetPieace(Type,0);
        CurrentPiece.gameObject.SetActive(true);
        CurrentPiece.transform.SetParent(transform, false);
    }
    private void DeSpwan()
    {
        CurrentPiece.gameObject.SetActive(false);
    }
}
