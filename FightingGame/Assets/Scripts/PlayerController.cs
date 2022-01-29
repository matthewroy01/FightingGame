using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private List<Collider2D> hurtBoxes = new List<Collider2D>();

    private ContactFilter2D contactFilter2D;

    private void Awake()
    {
        contactFilter2D.NoFilter();
    }

    public void CheckGetHit(List<BoxCollider2D> incomingHitboxes)
    {
        List<Collider2D> collisions = new List<Collider2D>();

        for (int i = 0; i < hurtBoxes.Count; ++i)
        {
            Physics2D.OverlapBox(hurtBoxes[i].transform.position, hurtBoxes[i].bounds.extents, 0.0f, contactFilter2D, collisions);

            for (int j = 0; j < incomingHitboxes.Count; ++j)
            {
                if (collisions.Contains(incomingHitboxes[j]))
                {
                    GetHit();
                }
            }
        }
    }

    private void GetHit()
    {

    }
}