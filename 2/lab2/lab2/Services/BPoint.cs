using lab2.Models;
using System;

namespace lab2.Services
{
    class BPoint : Contracts.IObserver<MessageModel>
    {
        public static int X { get; private set; }
        public static int Y { get; private set; }

        const int DIAMETER = 22;

        public void Update(MessageModel message)
        {
            X = message.X;
            Y = message.Y;

            const int priority = 6;
            const double sensitivity = 0.1;
            const int speed = 10;
            
            int width = Playground.ActiveForm.Width, height = Playground.ActiveForm.Height;
            if (message.X == X)
                message.X++;
            if (message.Y == Y)
                message.Y++;

            DoublePoint[] vectors = new DoublePoint[5]
            {
                 new DoublePoint( 1.0 / X, 1.0 / Y),
                 new DoublePoint( 1.0 / X, 1.0 / (Y - height + DIAMETER)),
                 new DoublePoint( 1.0 / (X - width + DIAMETER), 1.0 / (Y - height + DIAMETER)),
                 new DoublePoint( 1.0 / (X - width + DIAMETER), 1.0 / Y),
                 new DoublePoint( 1.0 / (X - message.X) * priority, 1.0 / (Y - message.Y) * priority)
            };

            double temp, maxPriority = 0;
            int k = 0, m;
            for (int i = 0; i < 4; ++i)
            {
                if ((temp = Math.Sqrt(Math.Pow(vectors[i].X, 2) + Math.Pow(vectors[i].Y, 2))) > maxPriority)
                {
                    maxPriority = temp;
                    k = i;
                }
            }

            vectors[k].X *= priority;
            vectors[k].Y *= priority;
            if (k - 2 < 0)
            {
                m = k + 2;
            }
            else
            {
                m = k - 2;
            }

            vectors[m].X = vectors[m].Y = 0;

            DoublePoint resultVector = new DoublePoint();
            for (int i = 0; i < 5; ++i)
            {
                resultVector.X += vectors[i].X;
                resultVector.Y += vectors[i].Y;
            }
            temp = Math.Max(Math.Abs(resultVector.X), Math.Abs(resultVector.Y));
            int currentSpeed;
            if (temp < sensitivity)
                currentSpeed = (int)((temp / sensitivity) * speed);
            else
                currentSpeed = speed;
            X += (int)(resultVector.X / temp * currentSpeed);
            Y += (int)(resultVector.Y / temp * currentSpeed);
            CheckBorders();
        }

        private void CheckBorders()
        {
            if (X < 0)
                X = 1;
            if (X > Playground.ActiveForm.Width - DIAMETER)
                X = Playground.ActiveForm.Width - DIAMETER - 1;
            if (Y < 0)
                Y = 1;
            if (Y > Playground.ActiveForm.Height - DIAMETER)
                Y = Playground.ActiveForm.Height - DIAMETER - 1;
        }
    }
}
