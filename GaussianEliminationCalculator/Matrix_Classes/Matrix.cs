using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GaussianEliminationCalculator.Form1;

namespace GaussianEliminationCalculator.Matrix_Classes
{
    public class Matrix
    {
        public int rows;
        public int columns;

        public Number[,] matrixArray;

        public Matrix(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            matrixArray = new Number[rows, columns];
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    matrixArray[row, column] = new Number(0, 1);
                }
            }
        }

        public void PopulateMatrix(List<List<Number>> rowList)
        {
            for (int row = 0; row < rowList.Count; row++)
            {
                for (int column = 0; column < rowList[0].Count; column++)
                {
                    matrixArray[row, column] = rowList[row][column];
                }
            }
        }

        public void ConvertToIdentityMatrix()
        {
            for (int row = 0; row < rows; row++)
            {
                matrixArray[row, row] = new Number(1, 1);
            }
        }

        public void SetElement(Number value, int row, int column)
        {
            matrixArray[row, column] = value;
        }

        public string MatrixToString()
        {
            string newLine = Environment.NewLine;
            string output = "";
            for(int row = 0; row < rows; row++)
            {
                for(int column = 0; column < columns; column++)
                {
                    output += matrixArray[row, column].NumberToString();
                    if(column != columns - 1)
                    {
                        output += "\t";
                    }
                    else
                    {
                        output += newLine + newLine;
                    }
                }
            }

            return output;
        }
    }
}
