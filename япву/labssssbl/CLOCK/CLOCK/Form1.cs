using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CLOCK
{
    public partial class Form1 : Form
    {


        int cx = 175, cy = 175; // центр картинки
        int secHand = 100, minHand = 90, hrHand = 75; //длина стрелок в пикселях
        Timer t = new Timer();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            t.Interval = 1000; //таймер в миллисекундах
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();
        }

        private int[] msCoord(int timeAmount, int length)//просчитываем координыты конца стрелки (секундная/минутная т.к. по 60)
        {
            int[] coord = new int[2];
            timeAmount *= 6;

            if (timeAmount >= 0 && timeAmount <= 180)
            {
                coord[0] = cx + (int)(length * Math.Sin(Math.PI * timeAmount / 180));
                coord[1] = cy - Convert.ToInt32(length * Math.Cos(Math.PI * timeAmount / 180));
            }
            else
            {
                coord[0] = cx - Convert.ToInt32(length * (-Math.Sin(Math.PI * timeAmount / 180)));
                coord[1] = cy - Convert.ToInt32(length * Math.Cos(Math.PI * timeAmount / 180));
            }
            return coord;
        }
        private int[] hrCoord(int hourValue, int minValue, int length)
        {
            int[] coord = new int[2];
            int value = Convert.ToInt32(30*hourValue+0.58*minValue);

            if (value >= 0 && value <= 180)
            {
                coord[0] = cx + Convert.ToInt32(length * Math.Sin(Math.PI * value / 180));
                coord[1] = cy - Convert.ToInt32(length * Math.Cos(Math.PI * value / 180));
            }
            else
            {
                coord[0] = cx - Convert.ToInt32(length * (-Math.Sin(Math.PI * value / 180)));
                coord[1] = cy - Convert.ToInt32(length * Math.Cos(Math.PI * value / 180));
            }

            return coord;
        }
        private void t_Tick(object sender, EventArgs e)
        {
            // время сейчас
            int sec = DateTime.Now.Second;
            int min = DateTime.Now.Minute;
            int hour = DateTime.Now.Hour;

            int[] handCoord = new int[2];

            Graphics g = pictureBox1.CreateGraphics();

            // Стираем предыдущее положения секундной стрелки
            handCoord = msCoord(sec, secHand + 4);
            g.DrawLine(new Pen(Color.White, 45f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));//(хар-ка линии/нач значение/конечное значение)

            // Стираем предыдущее положение минутной стрелки
            handCoord = msCoord(min, minHand + 4);
            g.DrawLine(new Pen(Color.White, 40f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));

            // Стираем предыдущее положение часовой стрелки
            handCoord = hrCoord(hour % 12, min, hrHand + 4);
            g.DrawLine(new Pen(Color.White, 20f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));

            //Отрисовка стрелки часов.
            handCoord = hrCoord(hour % 12, min, hrHand);
            g.DrawLine(new Pen(Color.DarkBlue, 6f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));


            //Отрисовка минутной стрелки
            handCoord = msCoord(min, minHand);
            g.DrawLine(new Pen(Color.DarkBlue, 4f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));

            // Отрисовка секундной стрелки.
            handCoord = msCoord(sec, secHand);
            g.DrawLine(new Pen(Color.DarkBlue, 4f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));
        }
    }
}
