using GaussianEliminationCalculator.Matrix_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GaussianEliminationCalculator
{
    public partial class Form1 : Form
    {
        Matrix matrix;
        Matrix vector;
        FractionParser parser;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Put in default input matrix
        }

        private void resetButton_matrixInput_Click(object sender, EventArgs e)
        {
            matrixInput_Textbox.Text = "";
            vectorInput_TextBox.Text = "";
            matrixOutput_Textbox.Text = "";
            vectorOutput_textbox.Text = "";
        }

        private void solveButton_Click(object sender, EventArgs e)
        {
            matrixOutput_Textbox.Text = "";
            vectorOutput_textbox.Text = "";

            // Parse input into data usable by Matrix class.
            try
            {
                ParseMatrixInput();
                ParseVectorInput();
            }
            catch
            {
                matrixOutput_Textbox.Text = "ERROR - Invalid input.";
            }

            //Validate input
            try
            {
                //Matrix A - Check if Squre Matrix.
                if (matrix.rows != matrix.columns)
                {
                    matrixOutput_Textbox.Text = "ERROR - Invalid input.";
                    return;
                }

                //Vector b - Check if dimensions are valid.
                if (matrix.rows != vector.rows)
                {
                    vectorOutput_textbox.Text = "ERROR - Invalid input.";
                    return;
                }
            }
            catch
            {
                matrixOutput_Textbox.Text = "ERROR - Invalid input.";
            }

            // Store input here.
            string outputMatrix = "";
            string outputVector = "";

            try
            {
                // Get output from Gaussian Elimination.
                MatrixOps.GaussianElimination(matrix, vector, ref outputMatrix, ref outputVector);

                // Print output into the output text boxes.
                matrixOutput_Textbox.Text = outputMatrix;
                vectorOutput_textbox.Text = outputVector;
            }
            catch
            {
                matrixOutput_Textbox.Text = "ERROR - Invalid input.";
            }
        }

        private void ParseMatrixInput()
        {
            parser = new FractionParser();

            List<string> rawStringRowsData = matrixInput_Textbox.Lines.ToList();
            List<List<Number>> matrixData_RowList = parser.GetFractionListsFromText(rawStringRowsData);

            if (matrixData_RowList.Count == 0)
            {
                return;
            }

            int rows = matrixData_RowList.Count;
            int columns = matrixData_RowList[0].Count;
            matrix = new Matrix(rows, columns);
            matrix.rows = rows;
            matrix.columns = columns;
            matrix.PopulateMatrix(matrixData_RowList);
        }

        private void ParseVectorInput()
        {
            parser = new FractionParser();

            List<string> rawStringRowsData = vectorInput_TextBox.Lines.ToList();
            List<List<Number>> matrixData_RowList = parser.GetFractionListsFromText(rawStringRowsData);

            if (matrixData_RowList.Count == 0)
            {
                return;
            }

            int rows = matrixData_RowList.Count;
            int columns = matrixData_RowList[0].Count;
            vector = new Matrix(rows, columns);
            vector.rows = rows;
            vector.columns = columns;
            vector.PopulateMatrix(matrixData_RowList);
        }

        public class FractionParser
        {
            public List<List<Number>> GetFractionListsFromText(List<string> matrixText)
            {
                matrixText = CleanMatrix(matrixText);

                List<List<Number>> Rows = new List<List<Number>>();

                for (int i = 0; i < matrixText.Count; i++)
                {
                    List<Number> numberList = new List<Number>();

                    List<string> rowText = matrixText[i].Split(",".ToCharArray()).ToList();


                    for (int k = 0; k < rowText.Count; k++)
                    {
                        if (!string.IsNullOrWhiteSpace(rowText[k]))
                        {
                            rowText[k] = rowText[k].Trim();
                            Number number = new Number();
                            if (rowText[k].Contains("/"))
                            {
                                List<string> fraction = rowText[k].Split("/".ToCharArray()).ToList();

                                if (fraction.Count == 2)
                                {
                                    number.Numerator = ConvertToLong(fraction[0]);
                                    number.Denominator = ConvertToLong(fraction[1]);
                                }
                            }
                            else
                            {
                                number.Numerator = ConvertToLong(rowText[k]);
                                number.Denominator = 1;
                            }

                            numberList.Add(number);
                        }
                    }

                    Rows.Add(numberList);
                }

                return Rows;
            }

            private long ConvertToLong(string textNumber)
            {
                long number = 0;

                if (Int64.TryParse(textNumber, out number))
                {

                }

                return number;
            }

            private List<string> CleanMatrix(List<string> matrixText)
            {
                if (matrixText != null)
                {
                    if (matrixText.Count > 0)
                    {
                        for (int i = 0; i < matrixText.Count; i++)
                        {
                            if (!string.IsNullOrWhiteSpace(matrixText[i]))
                            {
                                matrixText[i] = matrixText[i].Trim();

                                if (matrixText[i].EndsWith(","))
                                {
                                    if (matrixText[i].Length > 0)
                                    {
                                        matrixText[i] = matrixText[i].Remove(matrixText[i].Length - 1, 1);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    matrixText = new List<string>();
                }
                return matrixText;

            }
        }

        public class Number
        {
            public Number()
            {
                Numerator = 0;
                Denominator = 0;

            }

            public Number(long numerator, long denominator)
            {
                Numerator = numerator;
                Denominator = denominator;

            }

            public Number Clone()
            {
                CleanNumber();
                Number temp = new Number();
                temp.Numerator = Numerator;
                temp.Denominator = Denominator;
                return temp;
            }

            public double GetDouble()
            {
                CleanNumber();
                return Convert.ToDouble(Numerator) / Convert.ToDouble(Denominator);
            }

            public string NumberToString()
            {
                CleanNumber();
                string output = "";
                if (Denominator == 1)
                {
                    output = Numerator.ToString();
                }
                else if (Numerator == 0)
                {
                    output = Numerator.ToString();
                }
                else
                {
                    output = Numerator.ToString() + "/" + Denominator.ToString();
                }


                return output;
            }

            public static Number operator -(Number A, Number B)

            {
                Number a = A.Clone();
                Number b = B.Clone();

                Number temp = new Number();
                MakeDenominatorsSame(a, b);

                temp.Numerator = a.Numerator - b.Numerator;
                temp.Denominator = a.Denominator;

                Simplify(temp);
                return temp;
            }

            private static void Simplify(Number a)
            {
                if (a.Numerator != 0)
                {
                    EuclidAlgorithm euclidAlgorithm = new EuclidAlgorithm();
                    long GCD = euclidAlgorithm.GetGCD(a.Numerator, a.Denominator);
                    a.Numerator = a.Numerator / GCD;
                    a.Denominator = a.Denominator / GCD;
                }
            }

            private static void MakeDenominatorsSame(Number a, Number b)
            {

                if (a.Denominator != b.Denominator)
                {
                    Number A = a.Clone();
                    Number B = b.Clone();

                    a.Denominator = A.Denominator * B.Denominator;
                    a.Numerator = A.Numerator * B.Denominator;
                    b.Denominator = A.Denominator * B.Denominator;
                    b.Numerator = B.Numerator * A.Denominator;
                }
            }

            public static Number operator +(Number a, Number b)
            {
                Number temp = new Number();
                MakeDenominatorsSame(a, b);

                temp.Numerator = a.Numerator + b.Numerator;
                temp.Denominator = a.Denominator;

                Simplify(temp);
                return temp;
            }

            public static Number operator *(Number a, Number b)
            {
                Number temp = new Number();

                temp.Numerator = a.Numerator * b.Numerator;
                temp.Denominator = a.Denominator * b.Denominator;

                Simplify(temp);
                return temp;
            }

            public static Number operator /(Number a, Number b)
            {
                Number temp = new Number();

                temp.Numerator = a.Numerator * b.Denominator;
                temp.Denominator = a.Denominator * b.Numerator;

                Simplify(temp);
                return temp;
            }

            //top part of fraction
            public long Numerator { get; set; }

            //bottom part of fraction
            public long Denominator { get; set; }

            public bool Boxed = false;

            public void CleanNumber()
            {
                if (Denominator < 0)
                {
                    Denominator = Denominator * -1;
                    Numerator = Numerator * -1;
                }
            }
        }

        public class EuclidAlgorithm
        {

            public long GetGCD(long A, long B)
            {
                if (A < B)
                {
                    long temp = A;
                    A = B;
                    B = temp;
                }

                long GCD = 1;
                long quotient = A / B;
                long remainder = A % B;
                long NewA = B;
                long NewB = remainder;

                GCD = GetGCD_RecursiveStep(NewA, NewB, ref remainder);


                return GCD;
            }

            private long GetGCD_RecursiveStep(long A, long B, ref long remainder)
            {
                if (remainder == 0)
                {
                    return A;
                }
                else
                {
                    long quotient = A / B;
                    remainder = A % B;
                    //A = B * (quotient) + remainder;
                    A = B;
                    B = remainder;

                    return GetGCD_RecursiveStep(A, B, ref remainder);
                }
            }

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void resetButton_matrixInput_Click_1(object sender, EventArgs e)
        {
            matrixOutput_Textbox.Text = "";
            matrixInput_Textbox.Text = "";
            vectorOutput_textbox.Text = "";
            vectorInput_TextBox.Text = "";
        }
    }
}
