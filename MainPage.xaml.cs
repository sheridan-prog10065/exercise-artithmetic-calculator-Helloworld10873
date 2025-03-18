//using AndroidX.ConstraintLayout.Motion.Widget;

using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MathOperators;

public partial class MainPage : ContentPage
{

    private ObservableCollection<string> _expList;
    public MainPage()
    {
        InitializeComponent();
        _expList = new ObservableCollection<string>();
        _lstExpHistory.ItemsSource = _expList;
    }

    private void OnCalculate(object sender, EventArgs e)
    {
        //get the input to the arithmetic operation
        double leftOperand = double.Parse(_txtLeftOp.Text);
        double rightOperand = double.Parse(_txtRightOp.Text);
        char operation = ((string)_pckOperand.SelectedItem)[0]; //cast to string is possible because SelectedItem is an object

        //perform the arithmetic operation and obtain the result
        double result = PerformArithmeticOperation(operation, leftOperand, rightOperand);
        
        //Display the arithmetic calculation to the user. Show the work
        string expression = $"{leftOperand} {operation} {rightOperand} = {result}";
        
        //remember the expression
        _expList.Add(expression);
        
        _txtMathExp.Text = expression;
    }

    private double PerformArithmeticOperation(char operation, double leftOperand, double rightOperand)
    {
        switch (operation)
        {
            case '+':
                return PerformAddition(leftOperand, rightOperand);
                
            case '-':
                return PerformSubtraction(leftOperand, rightOperand);
                
            case '*':
                return PerformMultiplication(leftOperand, rightOperand);
           
            case '/':
                return PerformDivision(leftOperand, rightOperand);
               
            case '%' :
                return PerformRemainder(leftOperand, rightOperand);
            
            default:
                Debug.Assert(false, "Unknown operand. Cannot perform");
                return 0;
        }
    }
    private double PerformAddition(double leftOperand, double rightOperand)
    {
        return (leftOperand + rightOperand);
    } 
    private double PerformSubtraction(double leftOperand, double rightOperand)
    {
        return (leftOperand - rightOperand);
    }
    private double PerformMultiplication(double leftOperand, double rightOperand)
    {
        return (leftOperand * rightOperand);
    }
    private double PerformDivision(double leftOperand, double rightOperand)
    {
        string divOp = _pckOperand.SelectedItem as string; //another way of casting used for objects
        if (divOp.Contains("Int", StringComparison.OrdinalIgnoreCase))
        {
            //int division
            return (int)leftOperand / (int)rightOperand;
        }
        else
        {
            //real division
            return leftOperand / rightOperand;
        }
    }
    private double PerformRemainder(double leftOperand, double rightOperand)
    {
        return (leftOperand % rightOperand);
    }

}