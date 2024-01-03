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
            // ��������� �������� ��� �������� �����
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
                    label3.Text = "��� ��������� �������";
                }
                else if (Hb < 6.5)
                {
                    label3.Text = "HbA1c �������������� ���������";
                    ProcessNGValue();
                }
                else
                {
                    label3.Text = "�������� ������";
                    ProcessIMTValue();
                }
            }
            else
            {
                label3.Text = "������� ���������� �������� HbA1c";
            }
        }

        private void ProcessNGValue()
        {
            double NG;

            if (double.TryParse(textBox2.Text, out NG))
            {
                if (NG < 100)
                {
                    label5.Text = "��� ��������� �������";
                    label5.Text = "��������� ������ ��������� ����� �������,\n��������� ����� �����,\n������� �������� �����.\n����� ������ ����� � HbA1c ����� ���";
                }
                else if (100 <= NG && NG < 125)
                {
                    label5.Text = "��������� ������ ��������� ����� �������,\n��������� ����� �����,\n������� �������� �����.\n����� ������ ����� � HbA1c ����� ���";
                }
                else if (NG >= 125)
                {
                    label5.Text = "�������� ������";
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
                    label12.Text = "��� ��������������� � ��������";
                    ProcessAutoantiNoValue();
                }
                else if (IMT > 25)
                {
                    label12.Text = "��������";
                    ProcessCpIValue();
                }
            }
        }

        private void ProcessAutoantiNoValue()
        {
            if (radioButton5.Checked)
            {
                label16.Text = "��� 1 - �������� ������";
                panel7.Visible = false;
            }
            else if (radioButton6.Checked)
            {
                label16.Text = "������� �������� ��������";
                panel7.Visible = true;
            }
        }

        private void ProcessCInsulValue()
        {
            if (radioButton7.Checked)
            {
                label16.Text = "��� 2 - �������� ������";
            }
            else if (radioButton8.Checked)
            {
                label16.Text = "����-�����������";
            }
        }

        private void ProcessCpIValue()
        {
            if (radioButton1.Checked)
            {
                label16.Text = "��� 2 - �������� ������";
                panel5.Visible = false;
            }
            else if (radioButton2.Checked)
            {
                label16.Text = "������� �������� �����������";
                panel5.Visible = true;
            }
        }

        private void ProcessAutoantiYesValue()
        {
            if (radioButton3.Checked)
            {
                label16.Text = "��� 1 - �������� ������";
            }
            else if (radioButton4.Checked)
            {
                label16.Text = "����-�����������";
            }

        }
    }
}
