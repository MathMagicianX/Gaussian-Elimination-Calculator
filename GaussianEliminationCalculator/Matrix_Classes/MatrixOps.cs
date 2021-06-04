using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GaussianEliminationCalculator.Matrix_Classes;
using static GaussianEliminationCalculator.Form1;

namespace GaussianEliminationCalculator.Matrix_Classes
{
    public static class MatrixOps
    {
        private static Matrix L_Matrix;
        private static Matrix LU_Matrix;
        private static Matrix vectorSolution;
        private static Matrix augmentedMatrix;
        
        public static void GaussianElimination(Matrix matrix_A, Matrix vector_b, ref string matrixOutput, ref string vectorOutput)
        {
            augmentedMatrix = InitializeOutputMatrix(matrix_A, vector_b);

            L_Matrix = new Matrix(matrix_A.rows, matrix_A.columns);
            L_Matrix.ConvertToIdentityMatrix();

            //Each int[] should only contain 2 numbers that correspond to (row,column).
            List<MatrixLocation> pivotIndexes = new List<MatrixLocation>();
            
            //Forward Elimination
            int column = 0;
            //Loop through each row, selecting a new pivot then eliminating as needed:
            for (int row = 0; row < augmentedMatrix.rows; row++)
            {
                MatrixLocation currentLocation = new MatrixLocation(row, row);

                if (augmentedMatrix.matrixArray[row, row].GetDouble() == 0)
                {
                    matrixOutput = "ERROR - 0 located on a pivot during elimination!";
                    return;
                }
                else
                {
                    pivotIndexes.Add(currentLocation);
                    //Perform elimination.
                    //Calculate all new rows below pivot.
                    ForwardEliminationStep(augmentedMatrix, L_Matrix, currentLocation.row, currentLocation.column);               
                    column++;
                }
            }

            // Create L/U matrix
            LU_Matrix = MakeLUMatrix(augmentedMatrix, L_Matrix);
            matrixOutput = LU_Matrix.MatrixToString();



            //Backward Elimination -- To obtain the solution.
            column = augmentedMatrix.columns - 2;
            //Loop through each row, selecting a new pivot then eliminating as needed:
            for (int row = augmentedMatrix.rows - 1; row >= 0; row--)
            {
                MatrixLocation currentLocation = new MatrixLocation(row, column);

                //Perform elimination.
                //Calculate all new rows above pivot.
                BackwardEliminationStep(augmentedMatrix, currentLocation.row, currentLocation.column);
                column--;
            }

            MultiplyInverseDiagonal(augmentedMatrix, pivotIndexes);
            vectorSolution = GetVectorSolution(augmentedMatrix);
            vectorOutput = vectorSolution.MatrixToString();
        }

        private static void ForwardEliminationStep(Matrix matrix, Matrix L_Matrix, int pivotRow, int pivotColumn)
        {
            //Eliminating elements BELOW pivot.
            int currentRow = pivotRow + 1;
            int eliminationColumn = pivotColumn;
            for (int row = currentRow; row < matrix.rows; row++)
            {
                //Calculate coefficient for the subtracting row.
                Number coefficient = matrix.matrixArray[row, pivotColumn] / matrix.matrixArray[pivotRow, pivotColumn];
                
               
               
                //Process the new row!  This means we are calculating new row and replacing elements as we go!
                for (int column = 0; column < matrix.columns; column++)
                {
                    matrix.matrixArray[row, column] = matrix.matrixArray[row, column] - (coefficient * matrix.matrixArray[pivotRow, column]);
                }
           
          

                //Modify L-Matrix
                L_Matrix.matrixArray[row, eliminationColumn] = coefficient;
            }
        }

        private static void BackwardEliminationStep(Matrix matrix, int pivotRow, int pivotColumn)
        {
            //Eliminating elements Above pivot.
            int currentRow = pivotRow - 1;
            for (int row = currentRow; row >= 0; row--)
            {
                //Calculate coefficient for the subtracting row.
                if (matrix.matrixArray[pivotRow, pivotColumn].Numerator != 0)
                {


                    Number coefficient = matrix.matrixArray[row, pivotColumn] / matrix.matrixArray[pivotRow, pivotColumn];

                  

                    //Process the new row!  This means we are calculating new row and replacing elements as we go!
                    for (int column = 0; column < matrix.columns; column++)
                    {
                        matrix.matrixArray[row, column] = matrix.matrixArray[row, column] - (coefficient * matrix.matrixArray[pivotRow, column]);
                    }
                }

               
            }
        }

        private static void MultiplyInverseDiagonal(Matrix matrix, List<MatrixLocation> pivotLocations)
        {
            for(int i = 0; i < pivotLocations.Count; i++)
            {
                int pivotRow = pivotLocations[i].row;
                int pivotColumn = pivotLocations[i].column;
                Number value = matrix.matrixArray[pivotRow, pivotColumn];
                Number one = new Number(1, 1);
                Number inverseCoefficient = one / value;

                for (int column = 0; column < matrix.columns; column++)
                {
                    matrix.matrixArray[pivotRow, column] = matrix.matrixArray[pivotRow, column] * inverseCoefficient;
                }
            }
        }

        private static Matrix MakeLUMatrix(Matrix augmentedMatrix, Matrix L_Matrix)
        {
            Matrix LU_Matrix = new Matrix(L_Matrix.rows, L_Matrix.columns);
           
            for(int row = 0; row < augmentedMatrix.rows; row++)
            {
                for(int column = 0; column < augmentedMatrix.columns - 1; column++)
                {
                    LU_Matrix.matrixArray[row, column] = augmentedMatrix.matrixArray[row, column];
                }
            }
            
            int rowStart = 0;
            for (int column = 0; column < augmentedMatrix.columns - 1; column++)
            {
                rowStart++;
                for (int row = rowStart; row < augmentedMatrix.rows; row++)
                {
                    LU_Matrix.matrixArray[row, column] = L_Matrix.matrixArray[row, column];
                }
            }

            return LU_Matrix;
        }

        private static Matrix GetVectorSolution(Matrix augmentedMatrix)
        {
            Matrix solutionMatrix = new Matrix(augmentedMatrix.rows, 1);
            for(int row = 0; row < augmentedMatrix.rows; row++)
            {
                solutionMatrix.matrixArray[row, 0] = augmentedMatrix.matrixArray[row, augmentedMatrix.columns - 1];
            }

            return solutionMatrix;
        }
        
        private static Matrix InitializeOutputMatrix(Matrix matrix_A, Matrix vector_B)
        {
            int rows = matrix_A.rows;
            int columns = matrix_A.columns + vector_B.columns;
            Matrix outputMatrix = new Matrix(rows, columns);

            // Get elements from matrix A
            for (int row = 0; row < matrix_A.rows; row++)
            {
                for (int column = 0; column < matrix_A.columns; column++)
                {
                    outputMatrix.SetElement(matrix_A.matrixArray[row, column], row, column);
                }
            }

            // Get elements from vector B
            for (int row = 0; row < vector_B.rows; row++)
            {
                for (int column = 0; column < vector_B.columns; column++)
                {
                    outputMatrix.SetElement(vector_B.matrixArray[row, column], row, outputMatrix.columns - 1);
                }
            }

            return outputMatrix;
        }
    }

    public class MatrixLocation
    {
        public int row;
        public int column;

        public MatrixLocation(int row, int column)
        {
            this.row = row;
            this.column = column;
        }
    }
}
