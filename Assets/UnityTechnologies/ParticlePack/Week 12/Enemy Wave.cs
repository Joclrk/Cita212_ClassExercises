using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWave", menuName = "Scriptable Objects/EnemyWave")]
public class EnemyWave : ScriptableObject
{
    [SerializeField] Transform DemoWave; //position of the wave spawn
    public Transform[] DemoPoints()
    {
        Transform[] DemoMovePoint = new Transform[DemoWave.childCount];
        for (int Index = 0; Index < DemoWave.childCount; Index++) //identify how many points are in the wave and assign them to the array (Index is chosen number in the array)
        {
            DemoMovePoint[Index] = DemoWave.GetChild(Index);

        }
        return DemoMovePoint;
    }

}
