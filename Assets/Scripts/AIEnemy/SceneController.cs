using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    //��������������� ���������� ��� ����� � ��������-�������� 
    [SerializeField] private GameObject enemyPrefab;
    //�������� ���������� ��� �������� �� ����������� ����� � �����
    private GameObject _enemy;

    // Update is called once per frame
    void Update()
    {
        int ManyEnemy = Random.Range(0, 10);
        //��������� ������ �����, ������ ���� ����� � ����� �����������
        if (_enemy != null) { return; }
        //�����, ���������� ������-������
        for (int i = 0; i < ManyEnemy; i++)
        {
            
            _enemy = Instantiate(enemyPrefab) as GameObject;
            _enemy.transform.position = new Vector3(0, 1, 0);
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
        }
    }
}
