using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Matteuppgift_4_a
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        public Vector4 row1;
        public Vector4 row2;
        public Vector4 row3;
        public Vector4 row4;
        public Matrix rotation;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            GenerateRotationMatrix(35f);
            
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
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
