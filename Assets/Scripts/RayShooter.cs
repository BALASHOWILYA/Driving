using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{

    private Camera _camera;


    // Start is called before the first frame update
    void Start()
    {
        // Camera cam = gameObject.GetComponent<Camera>();
        _camera = GetComponent<Camera>();
        // Скрываем указатель мыши в центре экрана
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                //Получаем объект, в который попал луч
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                //Проверяем  наличие у этого объекта компонента ReactiveTarget
                if (target != null) {
                    //вызов метода для мишени
                    target.ReactToHit();
                    
                }
                else
                {
                    //Запуск сопрограммы в ответ на попадание.
                    StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }
    }

    private void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        //Команда GUI.Label()  отображает на экране символ.
        GUI.Label(new Rect(posX,
            posY, size, size), "*");
    }

    //Сопрограммы пользуются функциями IEnumerator.
    private IEnumerator SphereIndicator(Vector3 pos)
    {

        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        sphere.GetComponent<MeshRenderer>().material.color = Color.yellow;
 
        //Ключевое слово yield указывает сопрограмме, когда следует остановиться.
        yield return new WaitForSeconds(3f);
        //Удаляем этот GameObject  и очищаем память.
        Destroy(sphere);
    }
}
