using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDestinationHandler : MonoBehaviour
{
    [SerializeField] private int hpDecreaseAmount = 1;
    AIMove move;

    private void Start()
    {
        move = GetComponent<AIMove>();
        // λΉνμ±ν
        move.OnFinalDestinationArrived += () => {
            ActiveEnemyManager.Instance.Remove(move.gameObject);
            GameManager.Instance.Hp -= hpDecreaseAmount;
        };

    }
}
