using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightingGame.Moves
{
    public class HitboxModel
    {
        public BoxCollider2D hitbox;
        public List<MoveFrameModel> hitboxFrames;
        public bool hasHit {get; private set;}

        public bool isActive {get; private set;}

        public void HitboxUpdate(int frameIndex)
        {
            isActive = hitboxFrames[frameIndex].isActive;
        }

        public void SetHasHit(bool hasHit)
        {
            this.hasHit = hasHit;
        }

        public bool DetectCollision(int frameIndex)
        {
            return false;
        }

        public MoveFrameModel GetFrame(int frameIndex)
        {
            return hitboxFrames[frameIndex];
        }
    }
}

