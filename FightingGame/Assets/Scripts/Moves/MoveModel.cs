using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Moves
{
    public class MoveModel : MonoBehaviour
    {
        private int currentFrame = 0;
        public string moveName;
        public int minFrames;
        public int maxFrames; 
        public List<HitboxModel> moveHitboxes;
        public List<HitboxModel> hitboxCollisions {get; private set;}

        public void FrameUpdate()
        {
            // Reset the hitboxCollisions for this frame
            hitboxCollisions.Clear();
            
            // Update all of the hitboxes in the move
            for (int i = 0; i < moveHitboxes.Count; i++)
            {
                moveHitboxes[i].HitboxUpdate(currentFrame);
            }

            // Check all of the hitboxes on their current frames to see if they hit
            for (int i = 0; i < moveHitboxes.Count; i++)
            {
                if (moveHitboxes[i].DetectCollision(currentFrame))
                {
                    hitboxCollisions.Add(moveHitboxes[i]);
                }
            }

            currentFrame++;
        }

        public void ResetMove()
        {
            currentFrame = 0;
            hitboxCollisions.Clear();
        }
    }
}


