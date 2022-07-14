using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;
using OpenTK.Input;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		// углы вращения
		private float xrot = -40f;
		private float yrot = 0;
		private float zrot = 0;

		private const float MIN_ZOOM = 2.0f;
		private const float MAX_ZOOM = 15.0f;
		private float zoom = 3.0f; // текущее приближение
		private const float vZoom = 0.25f; // скорость изменения зума

		// ближняя и дальняя плоскости отсечения
		private const float zNear = 1.0f;
		private const float zFar = 100.0f;

		private const float phi = 45.0f; // угол перспективной проекции

		// скорость вращения
		private float dAngle = 1.5f;

		private const int nTextures = 3;
		private int[] textures = new int[nTextures];

		// размер доски
		private const int N = 8;

		// координаты выбранной клетки доски
		private Point chooseCell = new Point(-1, -1);

		// true - если сейчас ход белых,
		// false - если сейчас ход черных
		private bool isWhiteMove = true;

		private Desk desk;
		private Checkers figures;

		public Form1()
		{
			InitializeComponent();

			glControl1.MouseWheel += new MouseEventHandler(GlControl1_MouseWheel);
		}

		private void LoadTexture(Bitmap bmp)
		{
			BitmapData data = bmp.LockBits(
				new Rectangle(0, 0, bmp.Width, bmp.Height),
				ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
			GL.TexImage2D(TextureTarget.Texture2D, 0,
				PixelInternalFormat.Rgb, data.Width, data.Height, 0,
				OpenTK.Graphics.OpenGL.PixelFormat.Bgr,
				PixelType.UnsignedByte, data.Scan0);
			bmp.UnlockBits(data);
		}

		private void LoadTexture()
		{
			GL.GenTextures(nTextures, textures);

			Bitmap map = new Bitmap("images\\tree.bmp");
			GL.BindTexture(TextureTarget.Texture2D, textures[0]);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter,
				(int)TextureMinFilter.Linear);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter,
				(int)TextureMagFilter.Linear);
			LoadTexture(map);

			map = new Bitmap("images\\whiteCrown.bmp");
			GL.BindTexture(TextureTarget.Texture2D, textures[1]);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter,
				(int)TextureMinFilter.Linear);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter,
				(int)TextureMagFilter.Linear);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS,
				(int)TextureWrapMode.ClampToBorder);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT,
				(int)TextureWrapMode.ClampToBorder);
			float[] borderColor = new float[3] { 0.0f, 0.0f, 0.0f };
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureBorderColor,
				borderColor);
			LoadTexture(map);

			map = new Bitmap("images\\blackCrown.bmp");
			GL.BindTexture(TextureTarget.Texture2D, textures[2]);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter,
				(int)TextureMinFilter.Linear);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter,
				(int)TextureMagFilter.Linear);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS,
				(int)TextureWrapMode.ClampToBorder);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT,
				(int)TextureWrapMode.ClampToBorder);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureBorderColor,
				borderColor);
			LoadTexture(map);
		}

		private void glControl1_Load(object sender, EventArgs e)
		{

			GL.Color3(1.0f, 1.0f, 1.0f);
			GL.ClearColor(140.0f / 255, 203f / 255, 0.0f, 203.0f / 255);

			GL.ClearDepth(1.0);
			GL.DepthFunc(DepthFunction.Less);
			GL.Enable(EnableCap.DepthTest);

			GL.MatrixMode(MatrixMode.Projection);
			GL.LoadIdentity();
			Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(
				MathHelper.DegreesToRadians(phi),
				glControl1.AspectRatio, zNear, zFar);
			GL.LoadMatrix(ref projection);
			GL.MatrixMode(MatrixMode.Modelview);

			LoadTexture();

			GL.Enable(EnableCap.Lighting);
			GL.Enable(EnableCap.Light0);
			GL.Enable(EnableCap.ColorMaterial);
			GL.Enable(EnableCap.Normalize);
			
			desk = new Desk(1.0f, 1.0f, 0.125f, N, textures[0]);
			figures = new Checkers(N, 0.08, 1.0, 1.0, 0.125, new float[3] { 1.0f, 1.0f, 1.0f },
				new float[3] { 1.0f, 0.0f, 0.0f }, new int[2] { textures[1], textures[2] });
		}

		private void GlControl1_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			float delt = e.Delta * 1.0f / SystemInformation.MouseWheelScrollDelta * vZoom;
			if (zoom + delt < MAX_ZOOM && zoom + delt > MIN_ZOOM)
			{
				zoom += delt;
				glControl1.Invalidate();
			}
		}

		private void glControl1_Resize(object sender, EventArgs e)
		{
			if (glControl1.Height == 0)
				glControl1.Height = 1;
			GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
			GL.MatrixMode(MatrixMode.Projection);
			GL.LoadIdentity();
			Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(
				MathHelper.DegreesToRadians(phi),
				glControl1.AspectRatio, zNear, zFar);
			GL.LoadMatrix(ref projection);
			GL.MatrixMode(MatrixMode.Modelview);
		}

		private void glControl1_Paint(object sender, PaintEventArgs e)
		{
			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
			GL.LoadIdentity();
			GL.Translate(0.0, 0.0, -zoom);
			GL.Rotate(xrot, 1.0, 0.0, 0.0);
			GL.Rotate(yrot, 0.0, 1.0, 0.0);
			GL.Rotate(zrot, 0.0, 0.0, 1.0);

			desk.Draw(figures.Moves);
			figures.Draw(zrot > 90 && zrot < 270);

			GL.Flush();
			GL.Finish();

			glControl1.SwapBuffers();
		}

		private void glControl1_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Escape:
					Close();
					break;
				case Keys.Down:
					xrot += dAngle;
					break;
				case Keys.Up:
					xrot -= dAngle;
					break;
				case Keys.Left:
					yrot -= dAngle;
					break;
				case Keys.Right:
					yrot += dAngle;
					break;
			}
			glControl1.Invalidate();
		}

		private void glControl1_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (chooseCell.X != -1)
			{
				int res = figures.IsWhiteOrBlack(chooseCell.Y, chooseCell.X);
				if (figures.IsSelect() && res != -1 &&
						(res == 0 && isWhiteMove || res == 1 && !isWhiteMove))
                {
					figures.ClickCell(chooseCell);
					glControl1.Invalidate();
				}
				else if (!figures.IsSelect())
                {
					int code = figures.ClickCell(chooseCell);
					// если ход состоялся
					if (code >= 0)
                    {
						if (code >= 1)
                        {
							if (isWhiteMove)
                            {
								scoreSecondGamer.Text = (int.Parse(scoreSecondGamer.Text) - 1).
									ToString();
								if (scoreSecondGamer.Text == "0")
                                {
									glControl1.Invalidate();
									MessageBox.Show("Игрок " + nameFirstGamer.Text +
										" выиграл", "Игра закончилась");
									ResetGame();
									ChangeNames();
									return;
								}
                            }
							else
                            {
								scoreFirstGamer.Text = (int.Parse(scoreFirstGamer.Text) - 1).ToString();
								if (scoreFirstGamer.Text == "0")
								{
									glControl1.Invalidate();
									MessageBox.Show("Игрок " + nameSecondGamer.Text +
										" выиграл", "Игра закончилась");
									ResetGame();
									ChangeNames();
									return;
								}
							}
                        }
						bool isMove = figures.ExistMove(!isWhiteMove);
						if (!isMove)
                        {
							glControl1.Invalidate();
							if (isWhiteMove)
							{
								MessageBox.Show("Игрок " + nameFirstGamer.Text +
									" выиграл. У игрока " + nameSecondGamer.Text +
									" нет возможности ходить.", "Игра закончилась");
							}
							else
                            {
								MessageBox.Show("Игрок " + nameSecondGamer.Text +
									" выиграл. У игрока " + nameFirstGamer.Text +
									" нет возможности ходить.", "Игра закончилась");
							}
							ResetGame();
							ChangeNames();
							return;
						}
						// если code == 2, то есть возможность рубить дальше
						if (code != 2)
                        {
							isWhiteMove = !isWhiteMove;
							if (isWhiteMove)
                            {
								whoMove.Text = "Сейчас ходят белые";
                            }
							else
                            {
								whoMove.Text = "Сейчас ходят черные";
							}
						}
					}
					glControl1.Invalidate();
				}
			}
		}

		private void glControl1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			char key = e.KeyChar;
			if (key == 'd' || key == 'D' || key == 'в' || key == 'В')
			{
				zrot += dAngle;
			}
			if (key == 'a' || key == 'A' || key == 'ф' || key == 'Ф')
			{
				zrot -= dAngle;
			}
			if (zrot < 0 || zrot > 360)
			{
				zrot = (int)zrot % 360;
				if (zrot < 0)
                {
					zrot += 360;
                }
			}
			glControl1.Invalidate();
		}

		private void glControl1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Down:
				case Keys.Up:
				case Keys.Left:
				case Keys.Right:
					e.IsInputKey = true;
					break;
			}
		}

        private void glControl1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
			desk.SelectCell(e.X, e.Y, out chooseCell);
			glControl1.Invalidate();
		}

		private void ChangeNames()
        {
			string t = nameFirstGamer.Text;
			nameFirstGamer.Text = nameSecondGamer.Text;
			nameSecondGamer.Text = t;
			MessageBox.Show("Игроки меняются цветами шашек", "Сообщение");
        }

		private void ResetGame()
        {
			figures.Reset();
			scoreFirstGamer.Text = scoreSecondGamer.Text = "12";
			whoMove.Text = "Сейчас ходят белые";
			isWhiteMove = true;
		}
        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
			ResetGame();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
			MessageBox.Show("Автор программы" + Environment.NewLine +
							"Чумаков Денис Павлович" + Environment.NewLine +
							"den.chumakov.98@mail.ru" + Environment.NewLine +
							"2021", "О программе");
        }

        private void правилаИгрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
			System.Diagnostics.Process.Start("rules.html");
		}

        private void изменитьИменаToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Form2 form2 = new Form2();
			form2.NameFirstGamer = nameFirstGamer.Text;
			form2.NameSecondGamer = nameSecondGamer.Text;
			DialogResult res = form2.ShowDialog();
			if (res == DialogResult.OK)
            {
				nameFirstGamer.Text = form2.NameFirstGamer;
				nameSecondGamer.Text = form2.NameSecondGamer;
            }
        }

        private void reverseDeskButton_Click(object sender, EventArgs e)
        {
			zrot = ((int)zrot - 180) % 360;
			if (zrot < 0)
            {
				zrot += 360;
            }
			glControl1.Focus();
			glControl1.Invalidate();
		}
    }
}
