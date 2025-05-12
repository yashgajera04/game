using UnityEngine;
using UnityEngine.EventSystems;

public class scoringsides : MonoBehaviour
{
    public  EventTrigger.TriggerEvent ScoreTrigger;

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        ballmove ball = collision.gameObject.GetComponent<ballmove>();
        if (ball != null)
        {
            BaseEventData edata = new BaseEventData(EventSystem.current);
            this.ScoreTrigger.Invoke(edata);
        }
    }
}
