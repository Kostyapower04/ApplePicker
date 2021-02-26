using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Эта строка подключает библиотеку для работы с ГИП

public class Basket : MonoBehaviour    
{
    [Header("Set Dynamically")]
    public Text scoreGT;

    // Start is called before the first frame update
    void Start()
    {
    // Получить ссылку на игровой объект ScoreCounter
    GameObject scoreGO = GameObject.Find("ScoreCounter");

    // Получить компонент Text этого игрового объекта
    scoreGT = scoreGO.GetComponent<Text>();

    // Установить начально число очков равным 0
    scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        // Получить текущие координаты указателя мыши на экране из Input
        Vector3 mousepos2D = Input.mousePosition;

        // Координата Z определяет, как далеко в трёхмерном пространстве находится указатель мыши
        mousepos2D.z = -Camera.main.transform.position.z;

        // Преобразовать точку на двумерной плоскости экрана в трёхмерные координаты игры
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousepos2D);

        // Переметить корзину вдоль оси X в координату X указателя мыши
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
    void OnCollisionEnter(Collision coll)
    {
        // Отыскать яблоко, попавшее в эту корзину
        GameObject collidedWith = coll.gameObject;

        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);

        // Преобразовать текст в scoreGT в целое число
        int score = int.Parse(scoreGT.text);

        // Добавить очки за пойманное яблоко
        score += 100;

        // Преобразовать число очков обратно в строку и вывести её на экран
        scoreGT.text = score.ToString();
        // Запомнить высшее достижение
        if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
}
