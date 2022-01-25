using UnityEngine;

public class Hook : MonoBehaviour
{
    [SerializeField] private GameController gameController;

    private HookMoves hookMoves;

    private void Start()
    {
        hookMoves = transform.parent.GetComponent<HookMoves>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name.Contains("Edge"))
        {
            hookMoves.PullBack();
            return;
        }

        if (!col.CompareTag("Item")) return;
        col.GetComponent<AudioSource>().Play();

        var itemTransform = col.transform;
        var item = itemTransform.GetComponent<Item>();
        if (item == null) return;

        hookMoves.PullBack(itemTransform);
        if (item.isBonusTime)
        {
            gameController.BonusTime(5);
        }
        else if (item.isBomb)
        {
            gameController.MinusTime(-5);
        }
        else
        {
            gameController.IncreaseScore(item.value);
        }
    }
}