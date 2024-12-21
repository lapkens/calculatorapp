using System;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        private string input = string.Empty; // Текущее введенное значение
        private string operatorType = string.Empty; // Операция
        private double result = 0; // Результат вычислений

        public Form1()
        {
            InitializeComponent(); // Инициализация компонентов
            CreateCalculator(); // Создание кнопок и интерфейса
        }

        private void CreateCalculator()
        {
            // Массив с текстом кнопок
            string[] buttons = {
                "7", "8", "9", "/",
                "4", "5", "6", "*",
                "1", "2", "3", "-",
                "C", "0", "=", "+",
                "sin", "cos", "tan", "√",
                "asin", "acos", "atan", "cotan"
            };

            // Устанавливаем 4 колонки и 6 строк в TableLayoutPanel
            this.tableLayoutPanel.RowCount = 6;
            this.tableLayoutPanel.ColumnCount = 4;

            // Настраиваем высоту строк
            for (int i = 0; i < 6; i++)
                this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66F));

            // Настраиваем ширину колонок
            for (int j = 0; j < 4; j++)
                this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));

            // Создаем кнопки
            foreach (var text in buttons)
            {
                Button button = new Button
                {
                    Text = text,
                    Font = new System.Drawing.Font("Microsoft Sans Serif", 16),
                    Dock = DockStyle.Fill
                };

                // Обработчик событий для чисел
                if ("0123456789".Contains(text))
                    button.Click += ButtonNumber_Click;
                else
                    button.Click += ButtonOperator_Click;

                this.tableLayoutPanel.Controls.Add(button);
            }
        }

        private void ButtonNumber_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            input += button.Text;
            txtDisplay.Text = input;
        }

        private void ButtonOperator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string buttonText = button.Text;

            switch (buttonText)
            {
                case "=":
                    CalculateResult();
                    break;
                case "C":
                    Clear();
                    break;
                case "+":
                case "-":
                case "*":
                case "/":
                    operatorType = buttonText;
                    result = double.Parse(input);
                    input = string.Empty;
                    break;
                case "√":
                    input = Math.Sqrt(double.Parse(input)).ToString();
                    txtDisplay.Text = input;
                    break;
                case "sin":
                    input = Math.Sin(double.Parse(input)).ToString();
                    txtDisplay.Text = input;
                    break;
                case "cos":
                    input = Math.Cos(double.Parse(input)).ToString();
                    txtDisplay.Text = input;
                    break;
                case "tan":
                    input = Math.Tan(double.Parse(input)).ToString();
                    txtDisplay.Text = input;
                    break;
                case "asin":
                    input = Math.Asin(double.Parse(input)).ToString();
                    txtDisplay.Text = input;
                    break;
                case "acos":
                    input = Math.Acos(double.Parse(input)).ToString();
                    txtDisplay.Text = input;
                    break;
                case "atan":
                    input = Math.Atan(double.Parse(input)).ToString();
                    txtDisplay.Text = input;
                    break;
                case "cotan":
                    input = (1 / Math.Tan(double.Parse(input))).ToString();
                    txtDisplay.Text = input;
                    break;
            }
        }

        private void CalculateResult()
        {
            double secondOperand = double.Parse(input);

            switch (operatorType)
            {
                case "+":
                    result += secondOperand;
                    break;
                case "-":
                    result -= secondOperand;
                    break;
                case "*":
                    result *= secondOperand;
                    break;
                case "/":
                    result /= secondOperand;
                    break;
            }

            input = result.ToString();
            txtDisplay.Text = input;
            operatorType = string.Empty;
        }

        private void Clear()
        {
            input = string.Empty;
            result = 0;
            operatorType = string.Empty;
            txtDisplay.Text = input;
        }
    }
}
