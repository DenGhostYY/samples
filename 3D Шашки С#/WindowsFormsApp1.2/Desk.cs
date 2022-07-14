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
    public class Desk
    {
        private readonly float a;
        private readonly float b;
        private readonly float c;
        private readonly float N;
		private readonly int iTexture;
		private Point chooseCell;

		public Desk(float a, float b, float c, int N, int iTexture)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.N = N;
			this.iTexture = iTexture;
			chooseCell = new Point(-1, -1);
        }

        public void Draw(Checkers.KindMove[,] moves)
        {
			// Рисуем 6 граней
			// Передняя грань
			for (int i = 0; i < N; ++i)
			{
				for (int j = 0; j < N; ++j)
				{
					if ((i + j) % 2 != 0)
					{
						GL.Color3(1.0f, 1.0f, 1.0f); // белая клетка
					}
					else
					{
						GL.Color3(0.0f, 0.0f, 0.0f); // черная клетка

                        if (moves[i, j] == Checkers.KindMove.Yes)
                        {
                            GL.Color3(1.0f, 1.0f, 0.0f); // желтая клетка
                        }

                        if (chooseCell.X == j && chooseCell.Y == i)
						{
							GL.Color3(0.0f, 0.0f, 1.0f); // синяя клетка
						}
					}
					float x = -a + 2 * a / N * j;
					float y = -b + 2 * b / N * i;
					float dx = 2 * a / N;
					float dy = 2 * b / N;
					GL.Begin(PrimitiveType.Quads);

					GL.Normal3(0.0f, 0.0f, 1.0f);

					GL.Vertex3(x, y, c); // Нижняя левая точка

					GL.Vertex3(x + dx, y, c); // Нижняя правая точка

					GL.Vertex3(x + dx, y + dy, c); // Верхняя правая точка

					GL.Vertex3(x, y + dy, c); // Верхняя левая точка
					GL.End();
				}
			}
			GL.Enable(EnableCap.Texture2D);
			GL.Color3(Color.Transparent);
			// Задняя грань
			GL.BindTexture(TextureTarget.Texture2D, iTexture);
			GL.Begin(PrimitiveType.Quads);

			GL.Normal3(0.0f, 0.0f, -1.0f);

			GL.TexCoord2(1.0f, 0.0f);
			GL.Vertex3(-a, -b, -c); // Нижняя правая точка

			GL.TexCoord2(1.0f, 1.0f);
			GL.Vertex3(-a, b, -c); // Верхняя правая точка

			GL.TexCoord2(0.0f, 1.0f);
			GL.Vertex3(a, b, -c); // Верхняя левая точка

			GL.TexCoord2(0.0f, 0.0f);
			GL.Vertex3(a, -b, -c); // Нижняя левая точка
			GL.End();

			// Верхняя грань
			GL.BindTexture(TextureTarget.Texture2D, iTexture);
			GL.Begin(PrimitiveType.Quads);

			GL.Normal3(0.0f, 1.0f, 0.0f);

			GL.TexCoord2(0.0f, 1.0f);
			GL.Vertex3(-a, b, -c); // Верхняя левая точка

			GL.TexCoord2(1.0f, 1.0f);
			GL.Vertex3(-a, b, c); // Нижняя левая точка

			GL.TexCoord2(1.0f, 0.0f);
			GL.Vertex3(a, b, c); // Нижняя правая точка

			GL.TexCoord2(0.0f, 0.0f);
			GL.Vertex3(a, b, -c); // Верхняя правая точка
			GL.End();

			// Нижняя грань
			GL.BindTexture(TextureTarget.Texture2D, iTexture);
			GL.Begin(PrimitiveType.Quads);

			GL.Normal3(0.0f, -1.0f, 0.0f);

			GL.TexCoord2(1.0f, 0.0f);
			GL.Vertex3(-a, -b, -c); // Верхняя правая точка

			GL.TexCoord2(1.0f, 1.0f);
			GL.Vertex3(a, -b, -c); // Верхняя левая точка

			GL.TexCoord2(0.0f, 1.0f);
			GL.Vertex3(a, -b, c); // Нижняя левая точка

			GL.TexCoord2(0.0f, 0.0f);
			GL.Vertex3(-a, -b, c); // Нижняя правая точка
			GL.End();

			// Правая грань
			GL.BindTexture(TextureTarget.Texture2D, iTexture);
			GL.Begin(PrimitiveType.Quads);

			GL.Normal3(1.0f, 0.0f, 0.0f);

			GL.TexCoord2(1.0f, 0.0f);
			GL.Vertex3(a, -b, -c); // Нижняя правая точка

			GL.TexCoord2(1.0f, 1.0f);
			GL.Vertex3(a, b, -c); // Верхняя правая точка

			GL.TexCoord2(0.0f, 1.0f);
			GL.Vertex3(a, b, c); // Верхняя левая точка

			GL.TexCoord2(0.0f, 0.0f);
			GL.Vertex3(a, -b, c); // Нижняя левая точка
			GL.End();

			// Левая грань
			GL.BindTexture(TextureTarget.Texture2D, iTexture);
			GL.Begin(PrimitiveType.Quads);

			GL.Normal3(-1.0f, 0.0f, 0.0f);

			GL.TexCoord2(0.0f, 0.0f);
			GL.Vertex3(-a, -b, -c); // Нижняя левая точка

			GL.TexCoord2(1.0f, 0.0f);
			GL.Vertex3(-a, -b, c); // Нижняя правая точка

			GL.TexCoord2(1.0f, 1.0f);
			GL.Vertex3(-a, b, c); // Верхняя правая точка

			GL.TexCoord2(0.0f, 1.0f);
			GL.Vertex3(-a, b, -c); // Верхняя левая точка
			GL.End(); // Done Drawing The Cube

			GL.Disable(EnableCap.Texture2D);
		}

		static private double[] GetSpaceCoord(int winX, int winY)
		{
			int[] vp = new int[4];
			double[] mMatrix = new double[16],
				pMatrix = new double[16];
			float zt = 0.0f;

			GL.GetInteger(GetPName.Viewport, vp);
			winY = vp[3] - winY;

			GL.GetDouble(GetPName.ModelviewMatrix, mMatrix);
			GL.GetDouble(GetPName.ProjectionMatrix, pMatrix);
			GL.ReadPixels(winX, winY, 1, 1, PixelFormat.DepthComponent,
				PixelType.Float, ref zt);

			double x, y, z;
			Tao.OpenGl.Glu.gluUnProject(winX, winY, zt, mMatrix, pMatrix, vp, out x, out y, out z);
			double[] result = new double[3] { x, y, z };
			return result;
		}

		public void SelectCell(int winX, int winY, out Point p)
		{
			double[] spaceCoord = GetSpaceCoord(winX, winY);
			double x = spaceCoord[0];
			double y = spaceCoord[1];
			for (int i = 0; i < N; ++i)
			{
				for (int j = 0; j < N; ++j)
				{
					if ((i + j) % 2 == 0)
					{
						double x1 = -a + 2 * a / N * j;
						double y1 = -b + 2 * b / N * i;
						double dx = 2 * a / N;
						double dy = 2 * b / N;
						if (x1 < x && x < x1 + dx && y1 < y && y < y1 + dy)
						{
							chooseCell.Y = i;
							chooseCell.X = j;
							p = new Point(chooseCell.X, chooseCell.Y);
							return;
						}
					}
				}
			}
			chooseCell.Y = -1;
			chooseCell.X = -1;
			p = new Point(-1, -1);
		}
	}
}
