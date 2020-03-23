using UnityEngine;
using System.Collections.Generic;
public class DragObjects : MonoBehaviour
{
    private Vector3 offset;
    private float Zcord;
    private Vector3 actual_pos;
    public int ID;
    public short hookID;
    public static AudioClip musicaGameOver;
    public static AudioClip clickButtonClip;
    public struct plays
    {
        DragObjects draggedCube; 
        short IdHook;
        float x_position;

        public plays(DragObjects draggedCube, short IdHook, float x_position)
        {
            this.draggedCube = draggedCube;
            this.IdHook = IdHook;
            this.x_position = x_position;
        }

        public short getIdHook()
        {
            return this.IdHook;
        }

        public float getX_position()
        {
            return this.x_position;
        }

        public DragObjects getDraggedCube()
        {
            return this.draggedCube;
        }
    }
    public static Stack<plays> playsStack = new Stack<plays>();

    void OnMouseDown()
    {
        //posso me mover?
        actual_pos = gameObject.transform.position;
        Zcord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - getMousePosition();
    }
    private Vector3 getMousePosition()
    {
        if (RenderObjects.hooks[hookID].cubes.Peek().Equals(gameObject)) {
            //coordenadas dos pixels (x,y)
            Vector3 MousePosition = Input.mousePosition;
            //Coordenada z do Game Object da tela
            MousePosition.z = Zcord;

            return Camera.main.ScreenToWorldPoint(MousePosition);
        }
        return actual_pos;
    }

    void OnMouseDrag()
    {
        transform.position = getMousePosition() + offset;
    }

    private void OnMouseUp()
    {
        if (RenderObjects.hooks[hookID].cubes.Peek().Equals(gameObject))
        {
            double x_strip = ID * 0.25;

            if (transform.position.x >= (-0.25 - x_strip) && transform.position.x <= (0.25 + x_strip) &&
                transform.position.y >= -4 && transform.position.y <= 4 && hookID != 1)
            {
                if (RenderObjects.hooks[1].cubes.Count != 0)
                {
                    if (RenderObjects.hooks[1].cubes.Peek().GetComponent<DragObjects>().ID < this.ID)
                        transform.position = actual_pos;
                    else
                    {
                        RenderObjects.moves++;
                        StackPlays(gameObject.GetComponent<DragObjects>());
                        changePosition(gameObject.GetComponent<DragObjects>(),1, 0);
                    }
                }
                else
                {
                    RenderObjects.moves++;
                    StackPlays(gameObject.GetComponent<DragObjects>());
                    changePosition(gameObject.GetComponent<DragObjects>(),1, 0);
                }
            }
            else if (transform.position.x >= (7 - x_strip) && transform.position.x <= (8.3 + x_strip) &&
                transform.position.y >= -4 && transform.position.y <= 4 && hookID != 2)
            {
                if (RenderObjects.hooks[2].cubes.Count != 0)
                {
                    if (RenderObjects.hooks[2].cubes.Peek().GetComponent<DragObjects>().ID < this.ID)
                        transform.position = actual_pos;
                    else
                    {
                        RenderObjects.moves++;
                        StackPlays(gameObject.GetComponent<DragObjects>());
                        changePosition(gameObject.GetComponent<DragObjects>(),2, 7.5f);
                    }
                }
                else {
                    RenderObjects.moves++;
                    StackPlays(gameObject.GetComponent<DragObjects>());
                    changePosition(gameObject.GetComponent<DragObjects>(),2, 7.5f);
                }
            }
            else if (transform.position.x >= (-8.3 - x_strip) && transform.position.x <= (-6.8 + x_strip) &&
                transform.position.y >= -4 && transform.position.y <= 4 && hookID != 0)
            {
                if (RenderObjects.hooks[0].cubes.Count != 0)
                {
                    {
                        if (RenderObjects.hooks[0].cubes.Peek().GetComponent<DragObjects>().ID < this.ID)
                            transform.position = actual_pos;
                        else
                        {
                            RenderObjects.moves++;
                            StackPlays(gameObject.GetComponent<DragObjects>());
                            changePosition(gameObject.GetComponent<DragObjects>(),0, -7.5f);
                        }
                    }
                }
                else
                {
                    RenderObjects.moves++;
                    StackPlays(gameObject.GetComponent<DragObjects>());
                    changePosition(gameObject.GetComponent<DragObjects>(),0, -7.5f);                    
                }
            }
            else
                transform.position = actual_pos;
            if (RenderObjects.hooks[2].cubes.Count == LevelSelect.level)
                LoadSceneOnClick.LoadSceneWithMusic("GameOver", musicaGameOver);
        }

        if(transform.position != actual_pos)
        {
            try
            {
                gameObject.GetComponent<AudioSource>().Play();
            }
            catch (System.Exception)
            {
                gameObject.AddComponent<AudioSource>().clip = clickButtonClip;
                gameObject.GetComponent<AudioSource>().Play();
            }
        }
    }
    public static void changePosition(DragObjects GO, short newHookId, float x_position)
    {
        RenderObjects.hooks[GO.hookID].cubes.Pop();
        GO.hookID = newHookId;
        GO.transform.position = new Vector3(x_position, RenderObjects.hooks[GO.hookID].cubes.Count - 3, -0.1f);
        RenderObjects.hooks[newHookId].cubes.Push(GO.gameObject);
        GameObject.Find("StartGameGO").GetComponent<RenderObjects>().movesText.text = "Moves played: " + RenderObjects.moves.ToString();
    }

    public static void StackPlays(DragObjects GO)
    {
        plays play = new plays(GO, GO.hookID, GO.hookID * 7.5f - 7.5f);
        playsStack.Push(play);
    }
}
