using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        GM.Instance.RemoveFallingAlpha(other.gameObject, true);
        GM.Instance.LoseLife();
    }
}