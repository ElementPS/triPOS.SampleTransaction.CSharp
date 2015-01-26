namespace triPOS.SampleTransaction.CSharp.SignatureFiles
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Runtime.InteropServices;

    internal class Signature
    {
        #region Fields

        /// <summary>
        ///     The format selected by the user.
        /// </summary>
        private string format = string.Empty;

        /// <summary>
        ///     The maximum signature point.
        /// </summary>
        private SignaturePoint maximumSignaturePoint;

        /// <summary>
        ///     The minimum signature point.
        /// </summary>
        private SignaturePoint minimumSignaturePoint;

        /// <summary>
        ///     The signature format.
        /// </summary>
        private SignatureFormat signatureFormat;

        /// <summary>
        ///     The signature points.
        /// </summary>
        private SignaturePoint[] signaturePoints;

        #endregion

        #region Enums

        /// <summary>
        ///     The signaturePoints signatureFormat.
        /// </summary>
        public enum SignatureFormat
        {
            /// <summary>
            ///     The ASCII 3 byte.
            /// </summary>
            Ascii3Byte, 

            /// <summary>
            ///     The points big endian.
            /// </summary>
            PointsBigEndian, 

            /// <summary>
            ///     The points little endian.
            /// </summary>
            PointsLittleEndian, 
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Saves the signature to a BMP file.
        /// </summary>
        /// <param name="fileName">
        ///     The file name.
        /// </param>
        /// <param name="padding">
        ///     The padding around the signature.
        /// </param>
        public Bitmap GetSignatureBitmap(int padding)
        {
            if (this.signaturePoints != null)
            {
                var bitmap = new Bitmap((this.maximumSignaturePoint.X - this.minimumSignaturePoint.X) + (padding * 2), (this.maximumSignaturePoint.Y - this.minimumSignaturePoint.Y) + (padding * 2));

                Graphics bmpGraphics = Graphics.FromImage(bitmap);

                bmpGraphics.Clear(Color.White);

                var pen = new Pen(Color.Red, 1.8f);

                SignaturePoint lastSignaturePoint = SignaturePoint.PenUp;

                foreach (SignaturePoint signaturePoint in this.signaturePoints)
                {
                    if (!signaturePoint.IsPenUp && !lastSignaturePoint.IsPenUp)
                    {
                        int x1 = (lastSignaturePoint.X - this.minimumSignaturePoint.X) + padding;

                        int y1 = (lastSignaturePoint.Y - this.minimumSignaturePoint.Y) + padding;

                        int x2 = (signaturePoint.X - this.minimumSignaturePoint.X) + padding;

                        int y2 = (signaturePoint.Y - this.minimumSignaturePoint.Y) + padding;

                        bmpGraphics.DrawLine(pen, x1, y1, x2, y2);
                    }

                    lastSignaturePoint = signaturePoint;
                }

                return bitmap;
            }

            return null;
        }

        /// <summary>
        ///     Set the signature data.
        /// </summary>
        /// <param name="data">
        ///     The signature data.
        /// </param>
        public void SetData(byte[] data)
        {
            switch (this.signatureFormat)
            {
                case SignatureFormat.Ascii3Byte:
                    this.ConvertAscii3Byte(data);
                    break;

                case SignatureFormat.PointsLittleEndian:
                case SignatureFormat.PointsBigEndian:
                    this.ConvertPoints(data, 0);
                    break;

                default:
                    this.signaturePoints = null;
                    break;
            }
        }

        /// <summary>
        ///     Sets the signature format based on the item selected from the dropdown.
        /// </summary>
        /// <param name="formatInput">
        ///     The signature format.
        /// </param>
        public void SetFormat(string formatInput)
        {
            this.format = formatInput;

            switch (this.format)
            {
                case "Ascii3Byte":
                    this.signatureFormat = SignatureFormat.Ascii3Byte;
                    break;
                case "PointsBigEndian":
                    this.signatureFormat = SignatureFormat.PointsBigEndian;
                    break;
                case "PointsLittleEndian":
                    this.signatureFormat = SignatureFormat.PointsLittleEndian;
                    break;
                default:
                    this.signaturePoints = null;
                    break;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Converts 3 byte ASCII data to the signature points array.
        /// </summary>
        /// <param name="data">
        ///     The 3 byte ASCII data.
        /// </param>
        private void ConvertAscii3Byte(byte[] data)
        {
            this.signaturePoints = null;

            var points = new List<SignaturePoint>();

            this.minimumSignaturePoint = new SignaturePoint(short.MaxValue, short.MaxValue);

            this.maximumSignaturePoint = new SignaturePoint(short.MinValue, short.MinValue);

            SignaturePoint signaturePoint = SignaturePoint.Empty;

            for (int dataIndex = 0; dataIndex < data.Length; dataIndex++)
            {
                // pen up
                if (data[dataIndex] == 0x70)
                {
                    points.Add(SignaturePoint.PenUp);

                    signaturePoint = SignaturePoint.Empty;
                }
                else if (data[dataIndex] >= 0x60 && data[dataIndex] <= 0x6f)
                {
                    if ((data.Length - dataIndex) < 4)
                    {
                        throw new Exception("Invalid input data!");
                    }

                    signaturePoint = new SignaturePoint((short)((((data[dataIndex] - 0x60) & 0x0c) << 7) | ((data[dataIndex + 1] - 0x20) << 3) | (((data[dataIndex + 3] - 0x20) & 0x38) >> 3)), (short)((((data[dataIndex] - 0x60) & 0x03) << 9) | ((data[dataIndex + 2] - 0x20) << 3) | ((data[dataIndex + 3] - 0x20) & 0x07)));

                    // incremented to 4 at end of loop
                    dataIndex += 3;

                    if (points.Count == 0)
                    {
                        points.Add(SignaturePoint.PenUp);
                    }

                    points.Add(new SignaturePoint(signaturePoint.X, signaturePoint.Y));

                    this.SetMinMaxSignaturePoint(signaturePoint);
                }
                else
                {
                    if ((data.Length - dataIndex) < 3)
                    {
                        throw new Exception("Invalid input data!");
                    }

                    var dx = (short)(((short)(data[dataIndex] - 0x20) << 3) | (((short)(data[dataIndex + 2] - 0x20) & 0x38) >> 3));

                    // may have to sign extend offset
                    dx = (short)((short)(dx << 7) >> 7);

                    dataIndex++;

                    var dy = (short)(((short)(data[dataIndex] - 0x20) << 3) | ((short)(data[dataIndex + 1] - 0x20) & 0x07));

                    // may have to sign extend offset
                    dy = (short)((short)(dy << 7) >> 7);

                    dataIndex++;

                    signaturePoint.X += dx;

                    signaturePoint.Y += dy;

                    if (points.Count == 0)
                    {
                        points.Add(SignaturePoint.PenUp);
                    }

                    points.Add(new SignaturePoint(signaturePoint.X, signaturePoint.Y));

                    this.SetMinMaxSignaturePoint(signaturePoint);
                }
            }

            this.signaturePoints = points.ToArray();

            foreach (SignaturePoint point in this.signaturePoints)
            {
                if (!point.IsPenUp)
                {
                    point.Y = (short)(this.maximumSignaturePoint.Y - point.Y + this.minimumSignaturePoint.Y);
                }
            }
        }

        /// <summary>
        ///     Converts the points data to an array of SignaturePoints.
        /// </summary>
        /// <param name="data">
        ///     The points data.
        /// </param>
        /// <param name="startIndex">
        ///     The index within data to start the conversion.
        /// </param>
        private void ConvertPoints(byte[] data, int startIndex)
        {
            this.signaturePoints = null;

            var points = new List<SignaturePoint>();

            this.minimumSignaturePoint = new SignaturePoint(short.MaxValue, short.MaxValue);

            this.maximumSignaturePoint = new SignaturePoint(short.MinValue, short.MinValue);

            SignaturePoint signaturePoint = SignaturePoint.Empty;

            for (int dataIndex = startIndex; dataIndex < data.Length; dataIndex += Marshal.SizeOf(typeof(SignaturePoint)))
            {
                if ((data.Length - dataIndex) >= Marshal.SizeOf(typeof(SignaturePoint)))
                {
                    signaturePoint = new SignaturePoint(data, dataIndex, this.signatureFormat == SignatureFormat.PointsBigEndian);

                    points.Add(signaturePoint);

                    if (!signaturePoint.IsPenUp)
                    {
                        this.SetMinMaxSignaturePoint(signaturePoint);
                    }
                }
            }

            this.signaturePoints = points.ToArray();
        }

        /// <summary>
        ///     Sets the maximum and minimum X/Y signature points which are used to create the bounding box for the bitmap
        /// </summary>
        /// <param name="signaturePoint">The signature point to evaluate</param>
        private void SetMinMaxSignaturePoint(SignaturePoint signaturePoint)
        {
            if (signaturePoint.X > this.maximumSignaturePoint.X)
            {
                this.maximumSignaturePoint.X = signaturePoint.X;
            }

            if (signaturePoint.X < this.minimumSignaturePoint.X)
            {
                this.minimumSignaturePoint.X = signaturePoint.X;
            }

            if (signaturePoint.Y > this.maximumSignaturePoint.Y)
            {
                this.maximumSignaturePoint.Y = signaturePoint.Y;
            }

            if (signaturePoint.Y < this.minimumSignaturePoint.Y)
            {
                this.minimumSignaturePoint.Y = signaturePoint.Y;
            }
        }

        #endregion
    }
}