using System;
using System.Collections.Generic;
using System.Diagnostics;
using Matrix.Enums;

namespace Matrix.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private OperationEnum _selectedOperation;
        public OperationEnum SelectedOperation
        {
            get { return _selectedOperation; }
            set
            {
                _selectedOperation = value;
                OnPropertyChanged("SelectedMyEnumType");
            }
        }

        public MainViewModel()
        {
            _matrixOne = new List<List<int>> { new List<int>() { 1,2,3 }, new List<int> {3,2,1 } };
            _matrixTwo = new List<List<int>> { new List<int>() { 4,5,6,5,5 }, new List<int> {0,0,0 }, new List<int> { 0, 0, 0 } };
        }

        private List<List<int>> _matrixOne;
        private List<List<int>> _matrixTwo;
        private List<List<int>> _resultMatrix;
        public string matrixOneString
        {
            get
            {
                return MatrixToString(_matrixOne);
            }
        }
        public string matrixTwoString
        {
            get
            {
                return MatrixToString(_matrixTwo);
            }
        }
        public string resultMatrixString
        {
            get
            {
                return MatrixToString(_resultMatrix);
            }
        }

        private string MatrixToString(List<List<int>> matrix)
        {
            string result = "";
            if( matrix== null ) return result;
           foreach(List<int> row in matrix)
            {
                foreach(int col in row)
                {
                    result += col.ToString() + " ";
                }
                result += Environment.NewLine;
            }
            return result;
        }

        public void LoadNewExercise()
        {
            _matrixOne = GetRandomMatrix();
            _matrixTwo = GetRandomMatrix(_matrixOne);
            _selectedOperation = OperationEnum.addition;
            
        }

        //Erstelle eine Zufallsmatrix
        private List<List<int>> GetRandomMatrix()
        {
            throw new NotImplementedException("GetRandomMatrix");
        }

        //Erstelle eine Zufallsmatrix in abhägigkeit zu einer anderen (sodass berechnungen möglich sind)
        private List<List<int>> GetRandomMatrix(List<List<int>> matrix)
        {
            throw new NotImplementedException("GetRandomMatrix");
        }

        private void Calculate()
        {
            Calculator calc = new Calculator();
            _resultMatrix = calc.Calculate(_matrixOne, _matrixTwo, _selectedOperation);
        }
      
    }
}
