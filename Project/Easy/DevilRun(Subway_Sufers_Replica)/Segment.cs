using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour
{
    public int SegId{ get; set; }
    public bool transition;

    public int length;
    public int StartY1, StartY2, StartY3;
    public int EndY1, EndY2, EndY3;

    private Pieace[] pieces;

    private void Awake() 
    {
        pieces = gameObject.GetComponentsInChildren<Pieace>();    
    }
    public void Spwan()
    {
        gameObject.SetActive(true);
    }
    public void DeSpwan()
    {
        gameObject.SetActive(false);
    }
}
