using UnityEngine;

public class Corzinha : MonoBehaviour
{
    public static void pintarCubos(int ID, GameObject GO)
    {
        GO.GetComponent<MeshRenderer>().material.color = new Color(ID*0.32f - 0.32f, 0.15f*(ID-1) - ((ID-1)*(ID-1))/600f
            , 0.255f - (ID * 0.32f) - 0.32f);
        
    }

}
