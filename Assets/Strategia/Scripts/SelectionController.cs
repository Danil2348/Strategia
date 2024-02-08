using System.Collections.Generic;
using UnityEngine;

public class SelectionController : MonoBehaviour
{
    [SerializeField] RectTransform _selectionArea;
    [SerializeField] Camera _camera;
    Rect rect;
    Vector2 _start;
    void Update()
    {
        Selection();
    }

    // Выделение зоны
    void Selection()
    {
        // установка начала выделения и очищение массива юнитов
       

        if (Input.GetMouseButtonDown(0))
        {
            _start = Input.mousePosition;

            if (GlobalParametrs.playersActive != null)
            {
                foreach (GameObject player in GlobalParametrs.playersActive)
                {

                    // отключение отображение иконки

                    player.transform.GetChild(0).GetChild(3).gameObject.SetActive(false);
                }

                // очищение списка существующих активных машин

                GlobalParametrs.playersActive.Clear();
            }
        }

        //  изменение размера выделения относительно положения мышки 

        if (Input.GetMouseButton(0))
        {

            Vector2 max = Vector2.Max(_start, Input.mousePosition);
            Vector2 min = Vector2.Min(_start, Input.mousePosition);

            Vector2 size = max - min;

            if (size.magnitude > 20)
            {
                _selectionArea.gameObject.SetActive(true);
                _selectionArea.anchoredPosition = min;
                _selectionArea.sizeDelta = size;
            }

            rect = new Rect(min, size);
        }

        // прекращения выделения и заполнение массива выделенными юнитами 

        if (Input.GetMouseButtonUp(0))
        {
            _selectionArea.gameObject.SetActive(false);

            foreach(GameObject player in GlobalParametrs.players)
            {
                if (rect.Contains(_camera.WorldToScreenPoint(player.transform.position)))
                {
                    
                    // добавление союзной машины в список активных машин

                    GlobalParametrs.playersActive.Add(player);

                    // включение отображение иконки

                    player.transform.GetChild(0).GetChild(3).gameObject.SetActive(true);
                }
            }
        }
    }
}
