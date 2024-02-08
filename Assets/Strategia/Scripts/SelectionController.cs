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

    // ��������� ����
    void Selection()
    {
        // ��������� ������ ��������� � �������� ������� ������
       

        if (Input.GetMouseButtonDown(0))
        {
            _start = Input.mousePosition;

            if (GlobalParametrs.playersActive != null)
            {
                foreach (GameObject player in GlobalParametrs.playersActive)
                {

                    // ���������� ����������� ������

                    player.transform.GetChild(0).GetChild(3).gameObject.SetActive(false);
                }

                // �������� ������ ������������ �������� �����

                GlobalParametrs.playersActive.Clear();
            }
        }

        //  ��������� ������� ��������� ������������ ��������� ����� 

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

        // ����������� ��������� � ���������� ������� ����������� ������� 

        if (Input.GetMouseButtonUp(0))
        {
            _selectionArea.gameObject.SetActive(false);

            foreach(GameObject player in GlobalParametrs.players)
            {
                if (rect.Contains(_camera.WorldToScreenPoint(player.transform.position)))
                {
                    
                    // ���������� ������� ������ � ������ �������� �����

                    GlobalParametrs.playersActive.Add(player);

                    // ��������� ����������� ������

                    player.transform.GetChild(0).GetChild(3).gameObject.SetActive(true);
                }
            }
        }
    }
}
