using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PieceType
{
    none= -1,
    ramp=0,
    longblock=2,
    jump=4,

}
public class Pieace : MonoBehaviour
{
    public PieceType Type;
    public int VisualIndex;
}
