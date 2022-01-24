using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FightingGameInput
{
    public class InputDisplay : MonoBehaviour
    {
        private InputManager inputManager;
        private StickManager axisManager;

        [Header("Input Sprites")]
        [SerializeField] private Sprite straightArrow;
        [SerializeField] private Sprite diagonalArrow;
        [SerializeField] private Sprite lightAttack;
        [SerializeField] private Sprite heavyAttack;

        [Header("Input Duo")]
        [SerializeField] private LayoutGroup layoutGroup;
        [SerializeField] private InputDisplayDuo duoPrefab;
        private Queue<InputDisplayDuo> duoList = new Queue<InputDisplayDuo>();

        private InputData inputData;

        private void Awake()
        {
            inputManager = FindObjectOfType<InputManager>();
            axisManager = FindObjectOfType<StickManager>();

            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            inputManager.performedLightAttack.AddListener(DisplayLightAttack);
            inputManager.performedHeavyAttack.AddListener(DisplayHeavyAttack);
            axisManager.performedLeftStick.AddListener(DisplayDirection);
        }

        private void DisplayLightAttack()
        {
            if (inputData == null)
            {
                inputData = new InputData();
            }
            inputData.AddAttackSprite(lightAttack);
            GetDisplayDirection();
        }

        private void DisplayHeavyAttack()
        {
            if (inputData == null)
            {
                inputData = new InputData();
            }
            inputData.AddAttackSprite(heavyAttack);
            GetDisplayDirection();
        }

        private void DisplayDirection()
        {
            if (inputData == null)
            {
                inputData = new InputData();
            }
            GetDisplayDirection();
        }

        private void GetDisplayDirection()
        {
            InputDirection direction = axisManager.GetDirection();

            switch(direction)
            {
                case InputDirection.r:
                {
                    inputData.SetDirectionSpriteData(straightArrow, 0.0f);
                    break;
                }
                case InputDirection.ur:
                {
                    inputData.SetDirectionSpriteData(diagonalArrow, 0.0f);
                    break;
                }
                case InputDirection.u:
                {
                    inputData.SetDirectionSpriteData(straightArrow, 90.0f);
                    break;
                }
                case InputDirection.ul:
                {
                    inputData.SetDirectionSpriteData(diagonalArrow, 90.0f);
                    break;
                }
                case InputDirection.l:
                {
                    inputData.SetDirectionSpriteData(straightArrow, 180.0f);
                    break;
                }
                case InputDirection.dl:
                {
                    inputData.SetDirectionSpriteData(diagonalArrow, 180.0f);
                    break;
                }
                case InputDirection.d:
                {
                    inputData.SetDirectionSpriteData(straightArrow, 270.0f);
                    break;
                }
                case InputDirection.dr:
                {
                    inputData.SetDirectionSpriteData(diagonalArrow, 270.0f);
                    break;
                }
                default:
                {
                    inputData.SetDirectionSpriteData(null, 0.0f);
                    break;
                }
            }
        }

        private void LateUpdate()
        {
            if (inputData != null)
            {
                if (inputData.directionSprite == null && (inputData.attackSprites == null || inputData.attackSprites.Count == 0))
                {
                    inputData = null;
                    return;
                }
                else
                {
                    SpawnDuo();
                }
            }

            inputData = null;
        }

        private InputDisplayDuo SpawnDuo()
        {
            InputDisplayDuo tmp = Instantiate(duoPrefab, layoutGroup.transform);
            tmp.transform.SetAsFirstSibling();
            if (layoutGroup.transform.childCount > 11.0f)
            {
                Destroy(layoutGroup.transform.GetChild(layoutGroup.transform.childCount - 1).gameObject);
            }
            tmp.AssignImages(inputData.directionSprite, inputData.directionSpriteAngle, inputData.attackSprites);
            return tmp;
        }
    }

    public class InputData
    {
        public Sprite directionSprite;
        public float directionSpriteAngle;
        public List<Sprite> attackSprites = new List<Sprite>();

        public void AddAttackSprite(Sprite _sprite)
        {
            attackSprites.Add(_sprite);
        }

        public void SetDirectionSpriteData(Sprite _directionSprite, float _directionSpriteAngle)
        {
            directionSprite = _directionSprite;
            directionSpriteAngle = _directionSpriteAngle;
        }
    }
}