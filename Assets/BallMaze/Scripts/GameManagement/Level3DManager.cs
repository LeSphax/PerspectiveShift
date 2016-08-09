﻿using BallMaze.Data;
using BallMaze.Extensions;
using BallMaze.GameMechanics;
using BallMaze.Inputs;
using UnityEngine;

namespace BallMaze.GameManagement
{
    class Level3DManager : LevelManager
    {

        public GameObject levelPrefab;

        private GameObject currentSlice;
        private InputManager inputManager;


        void Awake()
        {
            inputManager = GetComponent<InputManager>();
        }


        public void CreateSlice(BoardData data)
        {
            Destroy(currentSlice);
            currentSlice = this.InstantiateAsChildren(levelPrefab);
            Board boardModel = currentSlice.GetComponent<Board>();
            boardModel.SetData(data);

            inputManager.SetBoard(boardModel);
        }

        internal override void LevelFinished()
        {
            Debug.Log("Need to implement LevelFinished");
        }

        internal override void NotifyFilledObjective(ObjectiveType objectiveEntered)
        {
            Debug.Log("Need to implement NotifyFilledObjective");
        }

        internal override void NotifyUnFilledObjective(ObjectiveType objectiveType)
        {
            Debug.Log("Need to implement NotifyUnFilledObjective");
        }

        internal override void SetObjectiveOrder(ObjectiveType firstObjective)
        {
            Debug.Log("Need to implement SetObjectiveOrder");
        }
    }
}