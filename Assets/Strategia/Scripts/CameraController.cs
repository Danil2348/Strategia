using UnityEngine;

public class CameraController : MonoBehaviour, IMoveble, IRotation
{
    [SerializeField] byte speed = 10;

    void Update()
    {
        Rotation();
        Move();
    }

    //�������� ������. �������� �� Y ��� �� ������� �����������, � �� X �� ���������
    public void Rotation()
    {
        if (Input.GetMouseButton(1))
        {
            transform.Rotate(new Vector3(0f, Input.GetAxis("Mouse X") * speed, 0f), Space.World);
            transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * speed, 0f, 0f));
        }
    }

    //������������ ������

    public void Move()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Mouse ScrollWheel") * -20, Input.GetAxis("Vertical"))*Time.deltaTime* speed*10;
        if (move != Vector3.zero)
        {
            transform.Translate(move);

            // ����������� ������������ ������

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0, 500), Mathf.Clamp(transform.position.y, 20, 140), Mathf.Clamp(transform.position.z, 0, 500));
        }
    }
}
