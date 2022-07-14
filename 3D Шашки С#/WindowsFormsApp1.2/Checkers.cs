using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using OpenTK;
//using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;
using OpenTK.Input;

namespace WindowsFormsApp1
{
    public class Checkers
    {
        private readonly int N; // размер доски NxN
        private readonly float[] colorWhite; // цвет белых шашек
        private readonly float[] colorBlack; // цвет черных шашек
        private readonly int n; // количество точек цилиндра
        private readonly int[] textures; // текстуры
        private readonly double r; // радиус цилиндра
        private readonly double h; // высота цилиндра
        private readonly double a; // сторона доски по оси Ox длиной 2a
        private readonly double b; // сторона доски по оси Oy длиной 2b
        private readonly double c; // сторона доски по оси Oz длиной 2c
        public enum KindMove { No, Yes };

        // виды шашек
        private enum KindCell { Free, White, Black, WhiteQueen, BlackQueen};
        private KindCell[,] figure; // матрица расположения шашек
        private KindMove[,] moves; // матрица возможных ходов
        private Point chooseFigure; // выбранная шашка

        public Checkers(int N, double h, double a, double b, double c,
                float[] colorWhite, float[] colorBlack, int[] textures)
        {
            this.N = N;
            this.colorWhite = colorWhite;
            this.colorBlack = colorBlack;
            this.n = 20;
            this.textures = textures;
            this.r = a / N - 0.025;
            this.h = h;
            this.a = a;
            this.b = b;
            this.c = c;
            chooseFigure = new Point(-1, -1);

            moves = new KindMove[N, N];
            figure = new KindCell[N, N];
            for (int i = 0; i < N; ++i)
            {
                for (int j = 0; j < N; ++j)
                {
                    moves[i, j] = KindMove.No;

                    figure[i, j] = KindCell.Free;
                    if ((i + j) % 2 == 0)
                    {
                        if (i < 3)
                        {
                            figure[i, j] = KindCell.White;
                        }
                        else if (i >= N - 3)
                        {
                            figure[i, j] = KindCell.Black;
                        }
                    }
                }
            }
            //figure[5, 5] = KindCell.BlackQueen;
            //figure[2, 4] = KindCell.WhiteQueen;
            //figure[7, 5] = KindCell.Black;
        }

        // задать начальное расположение шашек
        public void Reset()
        {
            chooseFigure = new Point(-1, -1);
            for (int i = 0; i < N; ++i)
            {
                for (int j = 0; j < N; ++j)
                {
                    moves[i, j] = KindMove.No;

                    figure[i, j] = KindCell.Free;
                    if ((i + j) % 2 == 0)
                    {
                        if (i < 3)
                        {
                            figure[i, j] = KindCell.White;
                        }
                        else if (i >= N - 3)
                        {
                            figure[i, j] = KindCell.Black;
                        }
                    }
                }
            }
        }

        public KindMove[,] Moves { get { return moves; } }

        // нарисовать шашку в виде цилиндра
        private void DrawCylinder(int i0, int j0, KindCell kind, bool isInverseCrown)
        {
            double eps = h / 10;
            double dx = -a + a / N + 2.0 / N * j0;
            double dy = -b + b / N + 2.0 / N * i0;
            float[] color;
            if (kind == KindCell.White || kind == KindCell.WhiteQueen)
            {
                color = colorWhite;
            }
            else
            {
                color = colorBlack;
            }
            GL.Color3(color);

            // боковая поверхность
            GL.Begin(BeginMode.QuadStrip);
            for (int i = 0; i <= n; ++i)
            {
                double angle = 2 * Math.PI / n * i;
                double x = r * Math.Cos(angle) + dx;
                double y = r * Math.Sin(angle) + dy;

                GL.Normal3(x - dx, y - dy, 0.0f);

                GL.Vertex3(x, y, c);
                GL.Vertex3(x, y, c + h - eps);
            }
            GL.End();

            GL.Color3(Color.Black);
            GL.Begin(BeginMode.QuadStrip);
            for (int i = 0; i <= n; ++i)
            {
                double angle = 2 * Math.PI / n * i;
                double x = r * Math.Cos(angle) + dx;
                double y = r * Math.Sin(angle) + dy;

                GL.Normal3(0.0f, 0.0f, 1.0f);

                GL.Vertex3(x, y, c + h - eps);
                GL.Vertex3(x, y, c + h);
            }
            GL.End();

            GL.Color3(color);
            if (kind == KindCell.WhiteQueen || kind == KindCell.BlackQueen)
            {
                GL.Enable(EnableCap.Texture2D);
                GL.Color3(Color.Transparent);
                if (kind == KindCell.WhiteQueen)
                {
                    GL.BindTexture(TextureTarget.Texture2D, textures[0]);
                }
                else
                {
                    GL.BindTexture(TextureTarget.Texture2D, textures[1]);
                }
            }

            // основание цилиндра
            GL.Begin(BeginMode.TriangleFan);
            GL.Normal3(0.0f, 0.0f, 1.0f);
            GL.TexCoord2(0.5f, 0.5f);
            GL.Vertex3(dx, dy, c + h);
            for (int i = 0; i <= n; ++i)
            {
                double angle = 2 * Math.PI / n * i;
                double x = r * Math.Cos(angle) + dx;
                double y = r * Math.Sin(angle) + dy;

                int sign = isInverseCrown ? 1 : -1;

                GL.TexCoord2((Math.Cos(angle) + 1) / 2, (sign * Math.Sin(angle) + 1) / 2);
                GL.Vertex3(x, y, c + h);
            }
            GL.End();
            if (kind == KindCell.WhiteQueen || kind == KindCell.BlackQueen)
            {
                GL.Disable(EnableCap.Texture2D);
            }
        }

        public void Draw(bool isInverseQueen)
        {
            for (int i = 0; i < N; ++i)
            {
                for (int j = 0; j < N; ++j)
                {
                    if ((i + j) % 2 == 0 && figure[i, j] != KindCell.Free)
                    {
                        DrawCylinder(i, j, figure[i, j], isInverseQueen);
                    }
                }
            }
        }

        private void ClearMoves()
        {
            for (int i = 0; i < N; ++i)
            {
                for (int j = 0; j < N; ++j)
                {
                    moves[i, j] = KindMove.No;
                }
            }
        }

        public bool IsSelect()
        {
            return chooseFigure.X == -1;
        }
        public int IsWhiteOrBlack(int i, int j)
        {
            switch (figure[i, j])
            {
                case KindCell.White:
                case KindCell.WhiteQueen:
                    return 0;
                case KindCell.Black:
                case KindCell.BlackQueen:
                    return 1;
                default:
                    return -1;
            }
        }

        private bool TestCutQueen(KindCell test1, KindCell test2, int a, int b,
                bool isDo, ref int j0, ref bool isCut)
        {
            // если пока еще не встретили вражескую шашку
            if (j0 == -1)
            {
                // все же встретили вражескую шашку
                if (figure[a, b] == test1 || figure[a, b] == test2)
                {
                    // запоминаем ее положение
                    j0 = b;
                }
                // иначе если встретили свою, выходим
                else if (figure[a, b] != KindCell.Free)
                {
                    return false;
                }
            }
            // если до этого встречали вражескую шашку и находимся на свободной,
            // пометим ее
            else if (figure[a, b] == KindCell.Free)
            {
                if (isDo)
                {
                    moves[a, b] = KindMove.Yes;
                }
                isCut = true;
            }
            // если до этого встречали вражескую шашку и встретили другую шашку,
            // выходим
            else
            {
                return false;
            }
            return true;
        }

        private bool SimpleMoveQueen(int i, int j, bool isDo)
        {
            bool isMove = false;
            for (int b = j + 1; b < N; ++b)
            {
                int a = b + i - j;
                if (a >= 0 && a < N)
                {
                    if (figure[a, b] == KindCell.Free)
                    {
                        isMove = true;
                        if (isDo)
                        {
                            moves[a, b] = KindMove.Yes;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            for (int b = j + 1; b < N; ++b)
            {
                int a = -b + i + j;
                if (a >= 0 && a < N)
                {
                    if (figure[a, b] == KindCell.Free)
                    {
                        isMove = true;
                        if (isDo)
                        {
                            moves[a, b] = KindMove.Yes;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            for (int b = j - 1; b >= 0; --b)
            {
                int a = b + i - j;
                if (a >= 0 && a < N)
                {
                    if (figure[a, b] == KindCell.Free)
                    {
                        isMove = true;
                        if (isDo)
                        {
                            moves[a, b] = KindMove.Yes;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            for (int b = j - 1; b >= 0; --b)
            {
                int a = -b + i + j;
                if (a >= 0 && a < N)
                {
                    if (figure[a, b] == KindCell.Free)
                    {
                        isMove = true;
                        if (isDo)
                        {
                            moves[a, b] = KindMove.Yes;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return isMove;
        }

        private bool SimpleMove(int i, int j, bool isDo)
        {
            bool isMove = false;
            if (figure[i, j] == KindCell.White && i + 1 < N && j - 1 >= 0 &&
                    figure[i + 1, j - 1] == KindCell.Free)
            {
                isMove = true;
                if (isDo)
                {
                    moves[i + 1, j - 1] = KindMove.Yes;
                }
            }
            if (figure[i, j] == KindCell.White && i + 1 < N && j + 1 < N &&
                    figure[i + 1, j + 1] == KindCell.Free)
            {
                isMove = true;
                if (isDo)
                {
                    moves[i + 1, j + 1] = KindMove.Yes;
                }
            }

            if (figure[i, j] == KindCell.Black && i - 1 >= 0 && j - 1 >= 0 &&
                    figure[i - 1, j - 1] == KindCell.Free)
            {
                isMove = true;
                if (isDo)
                {
                    moves[i - 1, j - 1] = KindMove.Yes;
                }
            }
            if (figure[i, j] == KindCell.Black && i - 1 >= 0 && j + 1 < N &&
                    figure[i - 1, j + 1] == KindCell.Free)
            {
                isMove = true;
                if (isDo)
                {
                    moves[i - 1, j + 1] = KindMove.Yes;
                }
            }
            return isMove;
        }

        // есть ли у шашки цвета kind (i,j) возможность рубить
        private bool TestCut(KindCell kind, int i, int j, bool isDo)
        {
            KindCell test1, test2;
            bool isCut = false;
            if (kind == KindCell.White || kind == KindCell.WhiteQueen)
            {
                test1 = KindCell.Black;
                test2 = KindCell.BlackQueen;
            }
            else
            {
                test1 = KindCell.White;
                test2 = KindCell.WhiteQueen;
            }

            // отдельно обработаем дамки
            if (kind == KindCell.WhiteQueen || kind == KindCell.BlackQueen)
            {
                int j0 = -1;
                for (int b = j + 1; b < N; ++b)
                {
                    int a = b + i - j;
                    if (a >= 0 && a < N)
                    {
                        if (!TestCutQueen(test1, test2, a, b, isDo, ref j0, ref isCut))
                        {
                            break;
                        }
                    }
                }

                j0 = -1;
                for (int b = j - 1; b >= 0; --b)
                {
                    int a = b + i - j;
                    if (a >= 0 && a < N)
                    {
                        if (!TestCutQueen(test1, test2, a, b, isDo, ref j0, ref isCut))
                        {
                            break;
                        }
                    }
                }

                j0 = -1;
                for (int b = j + 1; b < N; ++b)
                {
                    int a = -b + i + j;
                    if (a >= 0 && a < N)
                    {
                        if (!TestCutQueen(test1, test2, a, b, isDo, ref j0, ref isCut))
                        {
                            break;
                        }
                    }
                }

                j0 = -1;
                for (int b = j - 1; b >= 0; --b)
                {
                    int a = -b + i + j;
                    if (a >= 0 && a < N)
                    {
                        if (!TestCutQueen(test1, test2, a, b, isDo, ref j0, ref isCut))
                        {
                            break;
                        }
                    }
                }
                return isCut;
            }

            
            if (i + 1 < N && j - 1 >= 0 && (figure[i + 1, j - 1] == test1 ||
                    figure[i + 1, j - 1] == test2) &&
                    i + 2 < N && j - 2 >= 0 && figure[i + 2, j - 2] == KindCell.Free)
            {
                if (isDo)
                {
                    moves[i + 2, j - 2] = KindMove.Yes;
                }
                isCut = true;
            }

            if (i + 1 < N && j + 1 < N && (figure[i + 1, j + 1] == test1 ||
                    figure[i + 1, j + 1] == test2) &&
                    i + 2 < N && j + 2 < N && figure[i + 2, j + 2] == KindCell.Free)
            {
                if (isDo)
                {
                    moves[i + 2, j + 2] = KindMove.Yes;
                }
                isCut = true;
            }

            if (i - 1 >= 0 && j - 1 >= 0 && (figure[i - 1, j - 1] == test1 ||
                    figure[i - 1, j - 1] == test2) &&
                    i - 2 >= 0 && j - 2 >= 0 && figure[i - 2, j - 2] == KindCell.Free)
            {
                if (isDo)
                {
                    moves[i - 2, j - 2] = KindMove.Yes;
                }
                isCut = true;
            }

            if (i - 1 >= 0 && j + 1 < N && (figure[i - 1, j + 1] == test1 ||
                    figure[i - 1, j + 1] == test2) &&
                    i - 2 >= 0 && j + 2 < N && figure[i - 2, j + 2] == KindCell.Free)
            {
                if (isDo)
                {
                    moves[i - 2, j + 2] = KindMove.Yes;
                }
                isCut = true;
            }
            return isCut;
        }

        // есть ли у какой-либо шашки цвета kind возможность рубить
        private bool TestAllCut(KindCell kind)
        {
            KindCell partner = KindCell.White;
            switch (kind)
            {
                case KindCell.White:
                    partner = KindCell.WhiteQueen;
                    break;
                case KindCell.Black:
                    partner = KindCell.BlackQueen;
                    break;
                case KindCell.BlackQueen:
                    partner = KindCell.Black;
                    break;
            }
            for (int i = 0; i < N; ++i)
            {
                for (int j = 0; j < N; ++j)
                {
                    if ((i + j) % 2 == 0 && (figure[i, j] == kind ||
                            figure[i, j] == partner) &&
                            TestCut(figure[i, j], i, j, false))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void IsCutMove(int i, int j, out Point p3)
        {
            p3 = new Point(-1, -1);
            Point p1 = new Point(chooseFigure.Y, chooseFigure.X);
            Point p2 = new Point(i, j);
            KindCell test1 = KindCell.Black;
            KindCell test2 = KindCell.BlackQueen;
            if (figure[p1.X, p1.Y] == KindCell.Black ||
                    figure[p1.X, p1.Y] == KindCell.BlackQueen)
            {
                test1 = KindCell.White;
                test2 = KindCell.WhiteQueen;
            }
            if (p1.X < p2.X && p1.Y < p2.Y)
            {
                for (int b = p1.Y + 1; b < p2.Y; ++b)
                {
                    int a = b + p1.X - p1.Y;
                    if (a < 0 || a >= N)
                    {
                        continue;
                    }
                    if (figure[a, b] == test1 || figure[a, b] == test2)
                    {
                        p3 = new Point(a, b);
                        break;
                    }
                    else if (figure[a, b] != KindCell.Free)
                    {
                        break;
                    }
                }
            }
            else if (p1.X < p2.X && p1.Y > p2.Y)
            {
                for (int b = p1.Y - 1; b > p2.Y; --b)
                {
                    int a = -b + p1.Y + p1.X;
                    if (a < 0 || a >= N)
                    {
                        continue;
                    }
                    if (figure[a, b] == test1 || figure[a, b] == test2)
                    {
                        p3 = new Point(a, b);
                        break;
                    }
                    else if (figure[a, b] != KindCell.Free)
                    {
                        break;
                    }
                }
            }
            else if (p1.X > p2.X && p1.Y < p2.Y)
            {
                for (int b = p1.Y + 1; b < p2.Y; ++b)
                {
                    int a = -b + p1.Y + p1.X;
                    if (a < 0 || a >= N)
                    {
                        continue;
                    }
                    if (figure[a, b] == test1 || figure[a, b] == test2)
                    {
                        p3 = new Point(a, b);
                        break;
                    }
                    else if (figure[a, b] != KindCell.Free)
                    {
                        break;
                    }
                }
            }
            else if (p1.X > p2.X && p1.Y > p2.Y)
            {
                for (int b = p1.Y - 1; b > p2.Y; --b)
                {
                    int a = b + p1.X - p1.Y;
                    if (a < 0 || a >= N)
                    {
                        continue;
                    }
                    if (figure[a, b] == test1 || figure[a, b] == test2)
                    {
                        p3 = new Point(a, b);
                        break;
                    }
                    else if (figure[a, b] != KindCell.Free)
                    {
                        break;
                    }
                }
            }
        }

        public int ClickCell(Point cell)
        {
            int i = cell.Y;
            int j = cell.X;
            int count = 0;
            // шашка не была выбрана
            if (chooseFigure.X == -1)
            {
                // если шашка не была выбрана и выбрана пустая клетка, то выходим
                if (figure[i, j] == KindCell.Free)
                {
                    return -1;
                }

                bool isCut = TestCut(figure[i, j], i, j, true);

                // если шашка не рубит
                if (!isCut)
                {
                    // если есть возможность рубить у других шашек, выходим
                    if (TestAllCut(figure[i, j]))
                    {
                        return -1;
                    }

                    bool isMove = (figure[i, j] == KindCell.WhiteQueen || figure[i, j] == KindCell.BlackQueen) ?
                        SimpleMoveQueen(i, j, true) : SimpleMove(i, j, true);

                    // если ходов нет, выходим
                    if (!isMove)
                    {
                        return -1;
                    }
                }

                chooseFigure = new Point(j, i);
                moves[i, j] = KindMove.Yes;
            }
            // если шашка была выбрана
            else
            {
                // если шашка была выбрана и выбрана пустая клетка
                // не означающая ход, то выходим
                if (figure[i, j] == KindCell.Free && moves[i, j] == KindMove.No)
                {
                    return -1;
                }
                // если щелкнули по уже выбранной шашке, тогда сбрасываем выбор и выходим
                if (i == chooseFigure.Y && j == chooseFigure.X)
                {
                    ClearMoves();
                    chooseFigure.Y = -1;
                    chooseFigure.X = -1;
                    return -1;
                }
                else if (IsWhiteOrBlack(i, j) == IsWhiteOrBlack(chooseFigure.Y, chooseFigure.X))
                {
                    ClearMoves();
                    chooseFigure.Y = -1;
                    chooseFigure.X = -1;
                    ClickCell(new Point(j, i));
                    return -1;
                }
                // на другие шашки не обращаем внимания
                else if (figure[i, j] != KindCell.Free)
                {
                    return -1;
                }

                Point p3;
                IsCutMove(i, j, out p3);

                // сделаем ход
                figure[i, j] = figure[chooseFigure.Y, chooseFigure.X];
                figure[chooseFigure.Y, chooseFigure.X] = KindCell.Free;

                // белая пешка стала дамкой
                if (figure[i, j] == KindCell.White && i == N - 1)
                {
                    figure[i, j] = KindCell.WhiteQueen;
                }

                // черная пешка стала дамкой
                if (figure[i, j] == KindCell.Black && i == 0)
                {
                    figure[i, j] = KindCell.BlackQueen;
                }

                // рубим
                if (p3.X != -1)
                {
                    figure[p3.X, p3.Y] = KindCell.Free;
                    // если есть возможность рубить дальше, сообщим об этом
                    if (TestCut(figure[i, j], i, j, false))
                    {
                        ClearMoves();
                        chooseFigure = new Point(-1, -1);
                        ClickCell(new Point(j, i));
                        count = 2;
                        return count;
                    }
                    else
                    {
                        count = 1;
                    }
                }
                
                ClearMoves();
                chooseFigure = new Point(-1, -1);
            }
            return count;
        }

        public bool ExistMove(bool isWhite)
        {
            
            KindCell k1 = KindCell.White, k2 = KindCell.WhiteQueen;
            if (!isWhite)
            {
                k1 = KindCell.Black;
                k2 = KindCell.BlackQueen;
            }
            if (TestAllCut(k1))
            {
                return true;
            }
            for (int i = 0; i < N; ++i)
            {
                for (int j = 0; j < N; ++j)
                {
                    if ((i + j) % 2 == 0 && (figure[i, j] == k1 && SimpleMove(i, j, false) ||
                        figure[i, j] == k2 && SimpleMoveQueen(i, j, false)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
