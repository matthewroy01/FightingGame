using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace FightingGame.Moves
{
    public enum MoveType
    {
        Low,
        Mid,
        High
    }

    public enum MoveProperty
    {
        None,
        HitGrab,
        CommandGrab,
        Stagger,
        WallBounce,
        WallSplat,
        SoftKnockdown,
        HardKnockown,
        GroundBounce,
        Restand,
        MultiHit,
        Invincible
    }
    [System.Serializable]
    public class MoveFrameModel
    {
        public MoveType moveType;
        public List<MoveProperty> moveProperty;
        public float Damage;
        public int hitStun;
        public int blockStun;
        [Range(0.0f, 360.0f)]
        public float knockbackAngle;
        public float knockbackForce;
        public bool isActive;
    }

}
