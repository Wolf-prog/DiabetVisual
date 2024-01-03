using System;
using System.Windows.Forms;

namespace DiabetVisual
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AttachEventHandlers();
        }

        private void AttachEventHandlers()
        {
            button1.Click += ProcessButtonOrRadioButtonClick;
            button2.Click += ProcessButtonOrRadioButtonClick;
            button9.Click += ProcessButtonOrRadioButtonClick;
            radioButton1.Click += ProcessButtonOrRadioButtonClick;
            radioButton2.Click += ProcessButtonOrRadioButtonClick;
            radioButton3.Click += ProcessButtonOrRadioButtonClick;
            radioButton4.Click += ProcessButtonOrRadioButtonClick;
            radioButton5.Click += ProcessButtonOrRadioButtonClick;
            radioButton6.Click += ProcessButtonOrRadioButtonClick;
            radioButton7.Click += ProcessButtonOrRadioButtonClick;
            radioButton8.Click += ProcessButtonOrRadioButtonClick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Начальные значения при загрузке формы
        }

        private void ProcessButtonOrRadioButtonClick(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (button == button1)
                {
                    ProcessHbValue();
                }
                else if (button == button2)
                {
                    ProcessNGValue();
                }
                else if (button == button9)
                {
                    ProcessIMTValue();
                }
            }
            else if (sender is RadioButton radioButton)
            {
                if (radioButton == radioButton1 || radioButton == radioButton2)
                {
                    ProcessCpIValue();
                }
                else if (radioButton == radioButton3 || radioButton == radioButton4)
                {
                    ProcessAutoantiYesValue();
                }
                else if (radioButton == radioButton5 || radioButton == radioButton6)
                {
                    ProcessAutoantiNoValue();
                }
                else if (radioButton == radioButton7 || radioButton == radioButton8)
                {
                    ProcessCInsulValue();
                }
            }
        }

        private void ProcessHbValue()
        {
            double Hb;

            if (double.TryParse(textBox1.Text, out Hb))
            {
                if (Hb < 5.7)
                {
                    label3.Text = "Нет сахарного диабета";
                }
                else if (Hb < 6.5)
                {
                    label3.Text = "HbA1c незначительное повышение";
                    ProcessNGValue();
                }
                else
                {
                    label3.Text = "Сахарный диабет";
                    ProcessIMTValue();
                }
            }
            else
            {
                label3.Text = "Введите корректное значение HbA1c";
            }
        }

        private void ProcessNGValue()
        {
            double NG;

            if (double.TryParse(textBox2.Text, out NG))
            {
                if (NG < 100)
                {
                    label5.Text = "Нет сахарного диабета";
                    label5.Text = "Выяснение причин повышения риска диабета,\nизменение стиля жизни,\nлечение факторов риска.\nНовая оценка риска и HbA1c через год";
                }
                else if (100 <= NG && NG < 125)
                {
                    label5.Text = "Выяснение причин повышения риска диабета,\nизменение стиля жизни,\nлечение факторов риска.\nНовая оценка риска и HbA1c через год";
                }
                else if (NG >= 125)
                {
                    label5.Text = "Сахарный диабет";
                    ProcessIMTValue();
                }
            }
        }

        private void ProcessIMTValue()
        {
            double weight, height, IMT;

            if (double.TryParse(textBox3.Text, out weight) && double.TryParse(textBox4.Text, out height))
            {
                IMT = weight / Math.Pow(height / 100, 2);
                if (IMT <= 25)
                {
                    label12.Text = "Нет предостережений к ожирению";
                    ProcessAutoantiNoValue();
                }
                else if (IMT > 25)
                {
                    label12.Text = "Ожирение";
                    ProcessCpIValue();
                }
            }
        }

        private void ProcessAutoantiNoValue()
        {
            if (radioButton5.Checked)
            {
                label16.Text = "Тип 1 - Сахарный диабет";
                panel7.Visible = false;
            }
            else if (radioButton6.Checked)
            {
                label16.Text = "Введите значение Инсулина";
                panel7.Visible = true;
            }
        }

        private void ProcessCInsulValue()
        {
            if (radioButton7.Checked)
            {
                label16.Text = "Тип 2 - Сахарный диабет";
            }
            else if (radioButton8.Checked)
            {
                label16.Text = "МОДИ-диагностика";
            }
        }

        private void ProcessCpIValue()
        {
            if (radioButton1.Checked)
            {
                label16.Text = "Тип 2 - Сахарный диабет";
                panel5.Visible = false;
            }
            else if (radioButton2.Checked)
            {
                label16.Text = "Введите значение Аутоантител";
                panel5.Visible = true;
            }
        }

        private void ProcessAutoantiYesValue()
        {
            if (radioButton3.Checked)
            {
                label16.Text = "Тип 1 - Сахарный диабет";
            }
            else if (radioButton4.Checked)
            {
                label16.Text = "МОДИ-диагностика";
            }

        }
    }
}
