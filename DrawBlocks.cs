using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SchemesGenerator
{
    public enum BlockType {Process, Subprocess, Solution, Input, Output, HighLoopBorder, LowLoopBorder, Terminator};
    
    public class Block
    {
        public BlockType Type { get; set; }
        public string Text { get; set; } 
        public bool HasNumber { get; private set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Number { get; set; }
        public Point Start { get; set; }
        public Block ()
        {
            Height = 75;
            Width = 125;
        }
    }
    
    public class DrawBlocks
    {
        private Graphics Canvas { get; set; }

        public void DrawTerminator(Block OpBlock)
        {
            Pen p = new Pen(System.Drawing.Color.White);
            SolidBrush b = new SolidBrush(System.Drawing.Color.White);
            Font f = new Font ("Arial",16);
            p.Width = 2;
            Canvas.DrawEllipse(p, OpBlock.Start.X - OpBlock.Height / 3, OpBlock.Start.Y, OpBlock.Height * 2 / 3, OpBlock.Height * 2 / 3);
            Canvas.FillEllipse(b, OpBlock.Start.X - OpBlock.Height / 3, OpBlock.Start.Y, OpBlock.Height*2/3, OpBlock.Height*2/3);
            Canvas.DrawEllipse(p, OpBlock.Start.X + OpBlock.Width*2/5, OpBlock.Start.Y, OpBlock.Height*2/3, OpBlock.Height*2/3);
            Canvas.FillEllipse(b, OpBlock.Start.X + OpBlock.Width*2/5, OpBlock.Start.Y, OpBlock.Height*2/3, OpBlock.Height*2/3);
            Canvas.DrawRectangle(p, OpBlock.Start.X, OpBlock.Start.Y, OpBlock.Width*3/5, OpBlock.Height*2/3);
            Canvas.FillRectangle(b, OpBlock.Start.X, OpBlock.Start.Y, OpBlock.Width*3/5, OpBlock.Height* 2/3);
            b.Color = System.Drawing.Color.Black;
            Canvas.DrawString(OpBlock.Text, f, b, OpBlock.Start.X, OpBlock.Start.Y + 10);
        }

        public void DrawProcess(Block OpBlock)
        {
            Pen p = new Pen(System.Drawing.Color.White);
            SolidBrush b = new SolidBrush(System.Drawing.Color.White);
            Font f = new Font("Arial", 16);
            Canvas.DrawRectangle(p,OpBlock.Start.X, OpBlock.Start.Y, OpBlock.Width, OpBlock.Height);
            Canvas.FillRectangle(b, OpBlock.Start.X, OpBlock.Start.Y, OpBlock.Width, OpBlock.Height);
            b.Color = System.Drawing.Color.Black;
            Canvas.DrawString(OpBlock.Text, f, b, OpBlock.Start.X+30, OpBlock.Start.Y + 30);
        }

        public void DrawSubprocess(Block OpBlock)
        {
            Pen p = new Pen(System.Drawing.Color.White);
            SolidBrush b = new SolidBrush(System.Drawing.Color.White);
            Font f = new Font("Arial", 16);
            Canvas.DrawRectangle(p, OpBlock.Start.X, OpBlock.Start.Y, OpBlock.Width, OpBlock.Height);
            Canvas.FillRectangle(b, OpBlock.Start.X, OpBlock.Start.Y, OpBlock.Width, OpBlock.Height);
            b.Color = System.Drawing.Color.Black;
            p.Color = b.Color;
            Canvas.DrawLine(p, OpBlock.Start.X + 15, OpBlock.Start.Y, OpBlock.Start.X + 15, OpBlock.Start.Y + OpBlock.Height);
            Canvas.DrawLine(p, OpBlock.Start.X + OpBlock.Width - 15, OpBlock.Start.Y, OpBlock.Start.X + OpBlock.Width - 15, OpBlock.Start.Y + OpBlock.Height);
            Canvas.DrawString(OpBlock.Text, f, b, OpBlock.Start.X + 30, OpBlock.Start.Y + 30);
        }

        public void DrawSolution(Block OpBlock)
        {
            Pen p = new Pen(System.Drawing.Color.White);
            SolidBrush b = new SolidBrush(System.Drawing.Color.White);
            Font f = new Font("Arial", 16);
            Point[] Points = new Point[5];
            Points[0].X = OpBlock.Start.X + OpBlock.Width / 2;
            Points[0].Y = OpBlock.Start.Y;
            Points[1].X = OpBlock.Start.X + OpBlock.Width;
            Points[1].Y = OpBlock.Start.Y + OpBlock.Height / 2;
            Points[2].X = Points[0].X;
            Points[2].Y = OpBlock.Start.Y + OpBlock.Height;
            Points[3].X = OpBlock.Start.X;
            Points[3].Y = Points[1].Y;
            Points[4] = Points[0];
            Canvas.DrawPolygon(p, Points);
            Canvas.FillPolygon(b, Points);
            b.Color = System.Drawing.Color.Black;
            Canvas.DrawString(OpBlock.Text, f, b, OpBlock.Start.X + 28, OpBlock.Start.Y + 28);
        }

        public void DrawHighLoopBorder(Point Start, int Number) { }
        public void DrawLowLoopBorder(Point Start, int Number) { }

        public void DrawInput(Block OpBlock) 
        {
            Pen p = new Pen(System.Drawing.Color.White);
            SolidBrush b = new SolidBrush(System.Drawing.Color.White);
            Font f = new Font("Arial", 16);
            Point[] Points = new Point[5];
            Points[0].X = OpBlock.Start.X;
            Points[0].Y = OpBlock.Start.Y + OpBlock.Height/3;
            Points[1].X = OpBlock.Start.X + OpBlock.Width;
            Points[1].Y = OpBlock.Start.Y;
            Points[2].X = OpBlock.Start.X + OpBlock.Width;
            Points[2].Y = OpBlock.Start.Y + OpBlock.Height;
            Points[3].X = OpBlock.Start.X;
            Points[3].Y = OpBlock.Start.Y + OpBlock.Height;
            Points[4] = Points[0];
            Canvas.DrawPolygon(p, Points);
            Canvas.FillPolygon(b, Points);
            b.Color = System.Drawing.Color.Black;
            Canvas.DrawString(OpBlock.Text, f, b, OpBlock.Start.X + 30, OpBlock.Start.Y + 28);
        }

        public void DrawOutput(Point Start, int Number) { }
        public void DrawLine(Point[] Points) { }

        public DrawBlocks(Graphics Graphics)
        {
            Canvas = Graphics;
        }
    }
}
