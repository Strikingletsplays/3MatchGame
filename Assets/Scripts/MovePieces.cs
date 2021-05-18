using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePieces : MonoBehaviour
{
    public static MovePieces instance;
    Match3 game; //For board

    NodePiece moving; //For moving piece
    Point newIndex; //New Index for the moving piece
    Vector2 mouseStart; //First possition click of mouse

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        game = GetComponent<Match3>();
    }

    void Update()
    {
        if (moving != null)
        {
            Vector2 dir = ((Vector2)Input.mousePosition - mouseStart); //Direction to move
            Vector2 nDir = dir.normalized; //Normilised direction vector
            Vector2 aDir = new Vector2(Mathf.Abs(dir.x), Mathf.Abs(dir.y)); //Absolute Value of direction

            newIndex = Point.clone(moving.index);
            Point add = Point.zero;

            //Move piece before flip
            if(dir.magnitude > 32) //make add either (1,0) | (-1,0) | (0,1) | (0,-1) depending ont he direction of the mouse point 
            {
                if (aDir.x > aDir.y)
                    add = (new Point((nDir.x > 0) ? 1 : -1, 0)); //Move piece on the x axis
                else if (aDir.y > aDir.x)
                    add = (new Point(0, (nDir.y > 0) ? -1 : 1)); // Move piece on the y axis
            } //if our mouse/swipe is 32 pixels away from the starting point of the mouse/swipe.
            newIndex.add(add); // This piece is moving!

            Vector2 pos = game.getPositionFromPoint(moving.index); //Possition of moving Node
            if (!newIndex.equals(moving.index)) // if node has moved
                pos += Point.mult(new Point(add.x, -add.y), 16).toVector();
            moving.MovePositionTo(pos);
        }
    }

    public void MovePiece(NodePiece piece)
    {
        if (moving != null) return; // if a piece is moving, dont move another
        moving = piece;
        mouseStart = Input.mousePosition;
    } // Set witch piece is moving on the board

    public void DropPiece()
    {
        if (moving == null) return; //if no piece is moving return
        if (!newIndex.equals(moving.index))
            game.FlipPieces(moving.index, newIndex, true); //Flip the pieces around in the game board
        else
            game.ResetPiece(moving); //Reset the piece back to original spot
        moving = null;
    } //Flip or dont Flip
}
