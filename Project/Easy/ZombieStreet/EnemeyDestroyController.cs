using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyDestroyController : MonoBehaviour
{
  public void Destroy(float delay)
  {
    Destroy(gameObject, delay);
  }
}
