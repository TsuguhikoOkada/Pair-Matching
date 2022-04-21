using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureManager : MonoBehaviour
{
    public Picture _picturePrefab;

    public Transform _picSpawnPosition;

    public Vector2 _startPosition = new Vector2(-2.15f, 3.62f);

    [HideInInspector] public List<Picture> _pictureList;

    Vector2 _offSet = new Vector2(1.5f, 1.52f);


    void Start()
    {
        SpawnPictureMesh(4, 5, _startPosition, _offSet, false);

        MovePicture(4,5,_startPosition, _offSet);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPictureMesh(int rows , int columns , Vector2 pos , Vector2 offSet , bool scaleDown)
    {
        for (int col = 0; col < columns; col++)
        {
            for (int row = 0; row < rows; row++)
            {
                var tempPicture = (Picture)Instantiate(_picturePrefab, _picSpawnPosition.position, _picSpawnPosition.transform.rotation);

                tempPicture.name = tempPicture.name + 'c' + col + 'r' + row;

                _pictureList.Add(tempPicture);
            }
        }
    }

    void MovePicture(int rows , int columns , Vector2 pos , Vector2 offSet)
    {
        var index = 0;

        for (int col = 0; col < columns; col++)
        {
            for (int row = 0; row < rows; row++)
            {
                var targetPosition = new Vector3((pos.x + (offSet.x * row)), (pos.y - (offSet.y * col)), 0.0f);

                StartCoroutine(MoveToPosition(targetPosition, _pictureList[index]));

                index++;
            }
        }
    }

    IEnumerator MoveToPosition(Vector3 target , Picture obj)
    {
        var randomDis = 7;

        while(obj.transform.position != target)
        {
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, target, randomDis * Time.deltaTime);

            yield return 0;
        }
    }
}
