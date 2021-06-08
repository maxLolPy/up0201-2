using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace up0201
{
    class Capcha
    {
        private const string letters = "qwertyuiopasdfghjklzxcvbnm1234567890";
        private TextBlock textCapcha;
        private TextBox inputBox;
        private Canvas Canvas;
        private string result;
        public Capcha(Canvas item)
        {
            Canvas = item;
            foreach (UIElement i in item.Children)
            {
                //MessageBox.Show(i.ToString());
                if (i.ToString() == "System.Windows.Controls.TextBlock" && (i as TextBlock).Name == "capchaText")
                {
                    textCapcha = i as TextBlock;
                }
                else if (i.ToString().IndexOf("System.Windows.Controls.TextBox")>-1)
                {
                    inputBox = i as TextBox;
                }
            }
            result = this.create(textCapcha);
            textCapcha.Text = result;
        }
        private string RandomString(int Length)
        {
            Random ran = new Random();
            StringBuilder RandomString = new StringBuilder(Length - 1);
            int Position = 0;
            for (int i = 0; i < Length; i++)
            {
                Position = ran.Next(0, letters.Length - 1);
                RandomString.Append(letters[Position]);
            }
            return RandomString.ToString();
        }
        private string create(TextBlock a)
        {
            Random ran = new Random();
            for (int i = 0; i < 7; i++)
            {
                Canvas.Children.Add(new Line() { Stroke = new SolidColorBrush(Colors.Black), X1 = ran.NextDouble() * 100, Y1 = ran.NextDouble() * 40, X2 = ran.NextDouble() *100, Y2 = ran.NextDouble() * 40 });
            }
            return RandomString(6);
        }
        public int compare(int howManyErr, int maxCountErr)
        {
            int res = 0;
            if (inputBox.Text == result || howManyErr <= maxCountErr)
            {
                res = 1;
            }
            return res;
        }
        public void New()
        {
            List<UIElement> n = new List<UIElement>();
            foreach (UIElement i in Canvas.Children)
            {//System.Windows.Shepes.Line
                if (i.ToString().IndexOf("Line") > -1)
                {
                    n.Add(i);
                }
            }
            foreach (UIElement i in n)
            {
                Canvas.Children.Remove(i);
            }
            result = this.create(textCapcha);
            textCapcha.Text = result;
        }
    }
}
