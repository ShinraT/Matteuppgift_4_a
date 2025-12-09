using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Matteuppgift_4_a
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D pixel;
        public Vector4 row1;
        public Vector4 row2;
        public Vector4 row3;
        public Vector4 row4;
        public Matrix rotation;
        public Vector4 mittPunkt;
        public Vector4 p1, p2, p3, p4;
        public List<Vector4> punkter;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferHeight = 500;
            graphics.PreferredBackBufferWidth = 500;
            graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            punkter = new List<Vector4>();
            mittPunkt = new Vector4(250, 250, 1, 1); // Mitten
            p1 = new Vector4(300, 200, 1, 1); // Uppe höger
            p2 = new Vector4(200, 200, 1, 1); // Uppe vänster
            p3 = new Vector4(200, 300, 1, 1); // Nere vänster
            p4 = new Vector4(300, 300, 1, 1); // Nere höger
            punkter.Add(mittPunkt);
            punkter.Add(p1);
            punkter.Add(p2);
            punkter.Add(p3);
            punkter.Add(p4);

            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData(new[] { Color.White });
        }
        public float GraderTillRadianer(float grader) // Uträkning för att ändra grader till radianer. För att kunna använda det i kod.
        {
            return grader * (MathF.PI / 180);
        }

        public Matrix GenerateRotationMatrix(float grader)
        {
            float rad = GraderTillRadianer((float)grader);
            row1 = new Vector4((float)Math.Cos(rad), (float)-Math.Sin(rad), 0, 0);
            row2 = new Vector4((float)Math.Sin(rad), (float)Math.Cos(rad), 0, 0);
            row3 = new Vector4(0, 0, 1, 0);
            row4 = new Vector4(0, 0, 0, 1);
            rotation = new Matrix(row1, row2, row3, row4);
            return rotation;

        }

        public void Rotera(float grader)
        {
            Matrix rotation = GenerateRotationMatrix(grader);

            for (int i = 0; i < punkter.Count; i++)
            {
                punkter[i] = RoteraPunkterna(punkter[i], rotation);
            }
        }

        public static Vector4 RoteraPunkterna(Vector4 p, Matrix m)
        {
            return new Vector4(
                p.X * m.M11 + p.Y * m.M12 + p.Z * m.M13 + p.W * m.M14,
                p.X * m.M21 + p.Y * m.M22 + p.Z * m.M23 + p.W * m.M24,
                p.X * m.M31 + p.Y * m.M32 + p.Z * m.M33 + p.W * m.M34,
                p.X * m.M41 + p.Y * m.M42 + p.Z * m.M43 + p.W * m.M44
            );
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            foreach(var pos in punkter)
            {
                spriteBatch.Draw(pixel, new Vector2(pos.X, pos.Y), null, Color.BlanchedAlmond, 0f, Vector2.Zero, new Vector2(5f, 5f), SpriteEffects.None, 0f);
            }
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
