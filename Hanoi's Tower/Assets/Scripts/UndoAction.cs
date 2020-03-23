using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoAction : MonoBehaviour
{
    public void Undo()
    {
        if (RenderObjects.moves > 0)
        {
            DragObjects.plays play = DragObjects.playsStack.Pop();
            //Debug.Log(play.getDraggedCube() + "\n" + play.getX_position() + "\n" + play.getIdHook());
            RenderObjects.moves--;
            DragObjects.changePosition(play.getDraggedCube(),play.getIdHook(), play.getX_position());
        }
    }
}
