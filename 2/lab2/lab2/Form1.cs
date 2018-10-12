using lab2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lab2.Services;

namespace lab2
{
    public partial class Playground : Form
    {
        public Playground()
        {
            InitializeComponent();
            Contracts.IObservable observable = new Observable();
            Contracts.IObserver<MessageModel> observer = new BPoint();
            observable.AddObserver(observer);
        }

        private const int LEFT = 37;
        private const int REIGHT = 39;
        private const int TOP = 38;
        private const int BOTTOM = 40;
        const int diameter = 22;


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case LEFT:
                {
                    APoint.Left -= 5;
                    break;
                }
                case REIGHT:
                {
                    APoint.Left += 5;
                    break;
                }
                case TOP:
                {
                    APoint.Top -= 5;
                    break;
                }
                case BOTTOM:
                {
                    APoint.Top += 5;
                    break;
                }
            }
            BPoint.Left = lab2.Services.BPoint.X;
            BPoint.Top = lab2.Services.BPoint.Y;
            CheckPlayerBorders();
        }

        private void CheckPlayerBorders()
        {
            if (APoint.Left < 0)
                APoint.Left = 1;
            if (APoint.Left > Playground.ActiveForm.Width - diameter)
                APoint.Left = Playground.ActiveForm.Width - diameter - 1;
            if (APoint.Top < 0)
                APoint.Top = 1;
            if (APoint.Top > Playground.ActiveForm.Height - diameter)
                APoint.Top = Playground.ActiveForm.Height - diameter - 1;
        }
    }
}
