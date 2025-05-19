using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManger : MonoBehaviour
{
    public static LevelManger Instance{ get;  set; }
    private const bool showingCollider = true; 
    // Level Spwaning
    private const float distance_Before_Spwan = 100.0f;
    private const int Initial_Segment=10;
    private const int Max_Segment=15;
    private Transform CameraContainer;
    private int AmountOfActiveSegment;
    private int continiousSegment;
    private int spawanedSegmentZ;
    private int currentlevel;
    private int y1,y2,y3;

    //List
    public List<Pieace> ramp = new List<Pieace>();
    public List<Pieace> longBlock = new List<Pieace>();
    public List<Pieace> jump = new List<Pieace>();
    [HideInInspector]
    public List<Pieace> Pieces = new List<Pieace>();

    public List<Segment> AvaliableSegments = new List<Segment>();
    public List<Segment> AvaliableTransitions = new List<Segment>();
     [HideInInspector]
    public List<Segment> Segments = new List<Segment>();
    private bool isMoving = false;

    private void Awake() 
    {
        Instance = this;
        CameraContainer = Camera.main.transform; 
        currentlevel = 0;
        spawanedSegmentZ = 0;   
    }
    private void Start() 
    {
        for(int i = 0; i < Initial_Segment; i++)
        {
           GenarateSegment();
        }
    }

    private void Update()
    {
        if (spawanedSegmentZ - CameraContainer.position.z < distance_Before_Spwan)
        {
            GenarateSegment();
        }
        if (AmountOfActiveSegment >= Max_Segment)
        {
            Segments[AmountOfActiveSegment - 1].DeSpwan();
            AmountOfActiveSegment--;
        }
    }
    private void GenarateSegment()
    {
        spwanSegment();
        if(Random.Range(0f,1f) < (continiousSegment * 0.25f))
        {
            continiousSegment=0;
            SpwanTransition();
        }
        else
        {
             continiousSegment++;
        }
    }
    private void spwanSegment()
    {
        List<Segment> possibleSegments = AvaliableSegments.FindAll(x=> x.StartY1 == y1 || x.StartY2 == y2 || x.StartY3 == y3);
        int id = Random.Range(0,possibleSegments.Count);
        Segment s = GetSegment(id, false);

        y1 = s.EndY1;
        y2 = s.EndY2; 
        y3 = s.EndY3;

        s.transform.SetParent(transform);
        s.transform.localPosition = Vector3.forward * spawanedSegmentZ;

        spawanedSegmentZ+=  s.length;
        AmountOfActiveSegment++;
        s.Spwan();

    }
    private void SpwanTransition()
    {
        List<Segment> PossiableTranstion = AvaliableTransitions.FindAll(x=> x.StartY1 == y1 || x.StartY2 == y2 || x.StartY3 == y3);
        int id = Random.Range(0,PossiableTranstion.Count);
        Segment s = GetSegment(id, true);

        y1 = s.EndY1;
        y2 = s.EndY2; 
        y3 = s.EndY3;

        s.transform.SetParent(transform);
        s.transform.localPosition = Vector3.forward * spawanedSegmentZ;

        spawanedSegmentZ+=  s.length;
        AmountOfActiveSegment++;
        s.Spwan();
    }

    public Segment GetSegment(int id , bool transition)
    {
        Segment s = null;
        s = Segments.Find(x=> x.SegId == id && x.transition == transition && !x.gameObject.activeSelf);
        if(s == null)
        {
            GameObject go = Instantiate((transition)? AvaliableTransitions[id].gameObject : AvaliableSegments[id].gameObject) as GameObject;
                    s = go.GetComponent<Segment>();
            s.SegId = id;
            s.transition = transition;  
            Segments.Insert(0,s);

        }
        else
        {
            Segments.Remove(s);
            Segments.Insert(0,s);
        }
        return s;
    }
    public Pieace GetPieace(PieceType pt,int VisualIndex)
    {
      Pieace p = Pieces.Find(x=> x.Type == pt && x.VisualIndex == VisualIndex && !x.gameObject.activeSelf);
      if(p == null)
      {
        GameObject go = null;
        if(pt == PieceType.ramp)
        {
            go = ramp[VisualIndex].gameObject;
        }
        else if(pt == PieceType.longblock)
        {
            go = longBlock[VisualIndex].gameObject;
        }
        else if(pt == PieceType.jump)
        {
            go = jump[VisualIndex].gameObject;
        }
        go = Instantiate(go);
        p = go.GetComponent<Pieace>();
        Pieces.Add(p);
      }
        return p;
    }
}
