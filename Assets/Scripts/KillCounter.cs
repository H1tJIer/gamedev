using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour, IUserInterface
{
    #region Serialize Fields
    [SerializeField]
    private Text _text = null;
    #endregion

    #region Private Fields
    private int counter = 0;
    private int normalFontSize = 35;
    private int maxFontSize = 45;

    private GameController gameController; // добавили GameController
    #endregion

    #region Public Methods
    public void Init()
    {
        SetText(); // Покажем стартовое значение
        Zombie.onDie += SetText; // Подписка на событие

#pragma warning disable CS0618 // Type or member is obsolete

        gameController = FindObjectOfType<GameController>(); // Найдём GameController в сцене
#pragma warning restore CS0618 // Type or member is obsolete

    }

    public void Deinit()
    {
        Zombie.onDie -= SetText;
    }
    #endregion

    #region Private Methods
    private void SetText()
    {
        _text.text = $"{Localization.ENEMY_KILLED} {counter++}";

        // 🔥 Уведомляем GameController об убийстве
        if (gameController != null)
        {
            gameController.RegisterKill();
        }

        StartCoroutine(growEffect());

        IEnumerator growEffect()
        {
            int fontSize = normalFontSize;

            while (fontSize < maxFontSize)
                yield return grow(1);

            while (fontSize > normalFontSize)
                yield return grow(-1);

            IEnumerator grow(int value)
            {
                fontSize += value;
                _text.fontSize = fontSize;

                yield return new WaitForFixedUpdate();
            }
        }
    }
    #endregion
}
