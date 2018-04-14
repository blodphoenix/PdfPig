﻿namespace UglyToad.PdfPig.Geometry
{
    using System;

    internal struct PdfRectangle
    {
        public PdfPoint TopLeft { get; }

        public PdfPoint BottomRight { get; }

        public PdfPoint TopRight { get; }

        public PdfPoint BottomLeft { get; }

        public decimal Width { get; }

        public decimal Height { get; }

        public decimal Area { get; }

        public decimal Left => TopLeft.X;
        public decimal Top => TopLeft.Y;
        public decimal Right => BottomRight.X;
        public decimal Bottom => BottomRight.Y;

        public PdfRectangle(PdfPoint point1, PdfPoint point2) : this(point1.X, point1.Y, point2.X, point2.Y) { }
        public PdfRectangle(short x1, short y1, short x2, short y2) : this((decimal) x1, y1, x2, y2) { }
        public PdfRectangle(decimal x1, decimal y1, decimal x2, decimal y2)
        {
            var bottom = Math.Min(y1, y2);
            var top = Math.Max(y1, y2);

            var left = Math.Min(x1, x2);
            var right = Math.Max(x1, x2);

            TopLeft = new PdfPoint(left, top);
            TopRight = new PdfPoint(right, top);

            BottomLeft = new PdfPoint(left, bottom);
            BottomRight = new PdfPoint(right, bottom);

            Width = right - left;
            Height = top - bottom;
            Area = Width * Height;
        }

        public override string ToString()
        {
            return $"[{TopLeft}, {BottomRight}]";
        }
    }
}
