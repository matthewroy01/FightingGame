using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FightingGameInput
{
    public class InputDisplayDuo : MonoBehaviour
    {
        [SerializeField] private Image imageDirection;
        [SerializeField] private Image imageAttack;

        public void AssignImages(Sprite directionSprite, float directionSpriteAngle, List<Sprite> attackSprites)
        {
            // assign direction sprite and rotation
            imageDirection.sprite = directionSprite;
            if (directionSprite == null)
            {
                imageDirection.CrossFadeAlpha(0.0f, 0.0f, true);
            }
            imageDirection.transform.localEulerAngles = new Vector3(0.0f, 0.0f, directionSpriteAngle);

            // assign attack sprites (multiple if necessary)
            if (attackSprites == null || attackSprites.Count == 0)
            {
                imageAttack.CrossFadeAlpha(0.0f, 0.0f, true);
            }
            if (attackSprites.Count > 0)
            {
                imageAttack.sprite = attackSprites[0];
            }
            if (attackSprites.Count > 1)
            {
                for (int i = 1; i < attackSprites.Count; ++i)
                {
                    Image tmp = Instantiate(imageAttack, imageAttack.transform.parent);
                    tmp.sprite = attackSprites[i];
                }
            }
        }
    }
}