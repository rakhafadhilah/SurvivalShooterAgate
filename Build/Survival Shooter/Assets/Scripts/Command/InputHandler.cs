using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{

    public PlayerMovement playerMovement;
    public PlayerShooting playerShooting;

    public PlayerHealth player;

    Queue<BaseCommand> commands = new Queue<BaseCommand>();

    
    void FixedUpdate()
    {
        BaseCommand moveCommand = InputMovementHandling();

        if (moveCommand != null)
        {
            commands.Enqueue(moveCommand);

            moveCommand.Execute();
        }
    }   
     

    // Update is called once per frame
    void Update()
    {
        BaseCommand shootCommand = InputShootHandling();

        if(shootCommand != null)
        {
            shootCommand.Execute();
        }
    }

    BaseCommand InputMovementHandling()
    {
        //Check jika movement sesuai dengan key nya
        if (player.isDead == false)
        {
            if (Input.GetKey(KeyCode.D))
            {
                return new MoveCommand(playerMovement, 1, 0);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                return new MoveCommand(playerMovement, -1, 0);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                return new MoveCommand(playerMovement, 0, 1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                return new MoveCommand(playerMovement, 0, -1);
            }
            else if (Input.GetKey(KeyCode.Z))
            {
                //Undo movement
                return Undo();
            }
            else
            {
                return new MoveCommand(playerMovement, 0, 0);
            }
        }
        else
        {
            return new MoveCommand(playerMovement, 0, 0);
        }
    }

    BaseCommand Undo()
    {
        if (commands.Count > 0)
        {
            BaseCommand undoCommand = commands.Dequeue();
            undoCommand.UnExecute();
        }
        return null;
    }

    BaseCommand InputShootHandling()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            if (player.isDead == false)
            {
            return new ShootCommand(playerShooting);
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
        
    }

}
