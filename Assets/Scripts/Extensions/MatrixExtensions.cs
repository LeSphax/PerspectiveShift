﻿using System;
using UnityEngine;

public static class MatrixExtensions
{


    public static T[][][] ToJaggedArray<T>(this T[,,] matrix)
    {
        T[][][] jaggedArray = new T[matrix.GetLength(0)][][];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            jaggedArray[i] = new T[matrix.GetLength(1)][];

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                jaggedArray[i][j] = new T[matrix.GetLength(2)];
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    jaggedArray[i][j][k] = matrix[i, j, k];
                }
            }
        }
        return jaggedArray;
    }

    public static T[,,] ToMatrix<T>(this T[][][] jaggedArray)
    {
        if (jaggedArray.Length > 0 && jaggedArray[0].Length > 0)
        {
            T[,,] matrix = new T[jaggedArray.Length, jaggedArray[0].Length, jaggedArray[0][0].Length];
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[0].Length; j++)
                    for (int k = 0; k < jaggedArray[0].Length; k++)
                        matrix[i, j, k] = jaggedArray[i][j][k];
            }
            return matrix;
        }
        else return new T[0, 0, 0];
    }


    public static T[][] ToJaggedArray<T>(this T[,] matrix)
    {
        T[][] jaggedArray = new T[matrix.GetLength(0)][];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            jaggedArray[i] = new T[matrix.GetLength(1)];

            for (int j = 0; j < matrix.GetLength(1); j++)
                jaggedArray[i][j] = matrix[i, j];
        }
        return jaggedArray;
    }

    public static T[,] ToMatrix<T>(this T[][] jaggedArray)
    {
        if (jaggedArray.Length > 0)
        {
            T[,] matrix = new T[jaggedArray.Length, jaggedArray[0].Length];
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[0].Length; j++)
                    matrix[i, j] = jaggedArray[i][j];
            }
            return matrix;
        }
        else return new T[0, 0];
    }

    public static TileData[,] Rotate(this TileData[,] matrix, int rotation)
    {
        rotation = rotation % 360;
        int width = matrix.GetLength(0);
        int height = matrix.GetLength(1);
        switch (rotation)
        {
            case 0:
                break;
            case 90:
                matrix = Apply(matrix, height, false, width, true, (mat, y, x) => mat[x, y]);
                break;
            case 180:
                matrix = Apply(matrix, width, true, height, true, (mat, x, y) => mat[x, y]);
                break;
            case 270:
                matrix = Apply(matrix, height, true, width, false, (mat, y, x) => mat[x, y]);
                break;
            default:
                Debug.LogError("The rotation should be at a right angle");
                break;

        }
        return matrix;
    }

    public static TileData[,] Mirror(this TileData[,] matrix, int axis)
    {
        int width = matrix.GetLength(0);
        int height = matrix.GetLength(1);
        switch (axis)
        {
            case 0:
                matrix = Apply(matrix, width, true, height, false, (mat, x, y) => mat[x, y]);
                break;
            case 1:
                matrix = Apply(matrix, width, false, height, true, (mat, x, y) => mat[x, y]);
                break;
            default:
                Debug.LogError("The axis should be 0 or 1 : " + axis);
                break;

        }
        return matrix;
    }

    private static TileData[,] Apply(TileData[,] matrix, int sizeX, bool inverseX, int sizeY, bool inverseY, Func<TileData[,], int, int, TileData> getter)
    {
        TileData[,] result = new TileData[sizeX, sizeY];
        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                int iX = Functions.Inverse(x, sizeX, inverseX);
                int iY = Functions.Inverse(y, sizeY, inverseY);
                result[x, y] = getter(matrix, iX, iY);
            }
        }
        return result;
    }

    public static BallData[,] Rotate(this BallData[,] matrix, int rotation)
    {
        rotation = rotation % 360;
        int width = matrix.GetLength(0);
        int height = matrix.GetLength(1);
        switch (rotation)
        {
            case 0:
                break;
            case 90:
                matrix = Apply(matrix, height, false, width, true, (mat, y, x) => mat[x, y]);
                break;
            case 180:
                matrix = Apply(matrix, width, true, height, true, (mat, x, y) => mat[x, y]);
                break;
            case 270:
                matrix = Apply(matrix, height, true, width, false, (mat, y, x) => mat[x, y]);
                break;
            default:
                Debug.LogError("The rotation should be at a right angle " + rotation);
                break;

        }
        return matrix;
    }

    public static BallData[,] Mirror(this BallData[,] matrix, int axis)
    {
        int width = matrix.GetLength(0);
        int height = matrix.GetLength(1);
        switch (axis)
        {
            case 0:
                matrix = Apply(matrix, width, true, height, false, (mat, x, y) => mat[x, y]);
                break;
            case 1:
                matrix = Apply(matrix, width, false, height, true, (mat, x, y) => mat[x, y]);
                break;
            default:
                Debug.LogError("The axis should be 0 or 1 : " + axis);
                break;

        }
        return matrix;
    }

    private static BallData[,] Apply(BallData[,] matrix, int sizeX, bool inverseX, int sizeY, bool inverseY, Func<BallData[,], int, int, BallData> getter)
    {
        BallData[,] result = new BallData[sizeX, sizeY];
        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                int iX = Functions.Inverse(x, sizeX, inverseX);
                int iY = Functions.Inverse(y, sizeY, inverseY);
                result[x, y] = getter(matrix, iX, iY);
            }
        }
        return result;
    }

    public static T Get<T>(this T[,,] matrix, IntVector3 position)
    {
        return matrix[position.X, position.Y, position.Z];
    }

    public static void Set<T>(this T[,,] matrix, IntVector3 coords, T value)
    {
        matrix[coords.X, coords.Y, coords.Z] = value;
    }
}
