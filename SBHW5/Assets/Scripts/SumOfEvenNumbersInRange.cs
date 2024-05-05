using UnityEngine;
using UnityEngine.UI;

public class SumOfEvenNumbersInRange : MonoBehaviour
{
    [SerializeField] private Button _evenNumbersButton;

    private void Start()
    {
        _evenNumbersButton.onClick.AddListener(OnSumEvenNumbersInRange);
    }

    /// <summary>
    /// Метод обработки события OnClick кнопки "Сумма четных чисел заданного диапазона"
    /// </summary>
    private void OnSumEvenNumbersInRange()
    {
        int min = 7;
        int max = 21;
        var want = 98;
        int got = SumEvenNumbersInRange(min, max);
        string message = want == got ? "Результат верный" : $"Результат не верный, ожидается {want}";
        Debug.Log($"Сумма четных чисел в диапазоне от {min} до {max} включительно: {got} - {message}");
    }

    /// <summary>
    /// Метод вычисляет сумму четных чисел в заданноном диапазане 
    /// </summary>
    /// <param name="min">Минимальное значение диапазона</param>
    /// <param name="max">Максимальное значение диапазона</param>
    /// <returns>Сумма чисел четных чисел</returns>
    private int SumEvenNumbersInRange(int min, int max)
    {
        var sum = 0;
        for (int i = min; i < max; i++)
        {
            sum = i % 2 == 0 ? sum + i : sum;
        }
        return sum;
    }
}

