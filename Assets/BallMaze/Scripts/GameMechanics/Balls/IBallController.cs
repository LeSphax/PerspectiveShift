﻿using BallMaze.Inputs;
using UnityEngine;
namespace BallMaze.GameMechanics
{
    public delegate void EmptyEventHandler();

    public interface IBallController
    {

        event EmptyEventHandler FinishedAnimating;

        void Move(Direction direction);

        void MoveBack(int oldPosX, int oldPosY);
        bool IsEmpty();

        void InitObjectiveType(ObjectiveType type);
        void Init(int x, int y, Board model);

        Vector2 GetPosition();

        void Destroy();

        void FillObjective();
        void UnFillObjective();
        bool IsMoving();
        ObjectiveType GetObjectiveType();
        void SetMesh(GameObject mesh);
    }
}