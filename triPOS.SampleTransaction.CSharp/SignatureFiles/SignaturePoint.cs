namespace triPOS.SampleTransaction.CSharp.SignatureFiles
{
    using System;
    using System.Drawing;
    using System.Net;
    using System.Runtime.InteropServices;

    /// <summary>
    ///     Contains the properties and methods necessary to handle signature point data
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 4)]
    public class SignaturePoint : object
    {
        /// <summary>
        ///     Pen up point.
        /// </summary>
        public static readonly SignaturePoint PenUp = new SignaturePoint(-1, -1);

        /// <summary>
        ///     Empty point.
        /// </summary>
        public static readonly SignaturePoint Empty = new SignaturePoint(0, 0);

        /// <summary>
        ///     Initializes a new instance of the <see cref="SignaturePoint" /> class.
        /// </summary>
        /// <param name="x">
        ///     The x.
        /// </param>
        /// <param name="y">
        ///     The y.
        /// </param>
        public SignaturePoint(short x, short y)
        {
            this.X = x;

            this.Y = y;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SignaturePoint" /> class.
        /// </summary>
        /// <param name="x">
        ///     The x.
        /// </param>
        /// <param name="y">
        ///     The y.
        /// </param>
        public SignaturePoint(int x, int y)
            : this((short)x, (short)y)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SignaturePoint" /> class.
        /// </summary>
        /// <param name="point">
        ///     The point.
        /// </param>
        public SignaturePoint(SignaturePoint point)
            : this(point.X, point.Y)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SignaturePoint" /> class.
        /// </summary>
        /// <param name="data">
        ///     The data.
        /// </param>
        /// <param name="index">
        ///     The index.
        /// </param>
        /// <param name="bigEndian">
        ///     The big endian.
        /// </param>
        public SignaturePoint(byte[] data, int index, bool bigEndian)
            : this((SignaturePoint)ByteArrayToStructure(data, index, typeof(SignaturePoint)))
        {
            if (bigEndian)
            {
                this.X = IPAddress.NetworkToHostOrder(this.X);

                this.Y = IPAddress.NetworkToHostOrder(this.Y);
            }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SignaturePoint" /> class.
        /// </summary>
        public SignaturePoint()
            : this(Empty)
        {
        }

        /// <summary>
        ///     Gets or sets the x.
        /// </summary>
        public short X { get; set; }

        /// <summary>
        ///     Gets or sets the y.
        /// </summary>
        public short Y { get; set; }

        /// <summary>
        ///     Gets the point.
        /// </summary>
        public Point Point
        {
            get
            {
                return new Point(this.X, this.Y);
            }
        }

        /// <summary>
        ///     Gets a value indicating whether is pen up.
        /// </summary>
        public bool IsPenUp
        {
            get
            {
                return this.Equals(PenUp);
            }
        }

        /// <summary>
        ///     Gets a value indicating whether is empty.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return this.Equals(Empty);
            }
        }

        /// <summary>
        ///     Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">
        ///     The object to compare with the current object.
        /// </param>
        /// <returns>
        ///     true if the specified object is equal to the current object; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            return ((SignaturePoint)obj).X == this.X && ((SignaturePoint)obj).Y == this.Y;
        }

        /// <summary>
        ///     Gets the hash code.
        /// </summary>
        /// <returns>
        ///     The hash code.
        /// </returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        ///     The to string.
        /// </summary>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        public override string ToString()
        {
            return "{" + this.X + "," + this.Y + "}";
        }

        /// <summary>
        ///     The byte array to structure.
        /// </summary>
        /// <param name="source">
        ///     The source.
        /// </param>
        /// <param name="sourceIndex">
        ///     The source index.
        /// </param>
        /// <param name="destinationType">
        ///     The destination type.
        /// </param>
        /// <param name="length">
        ///     The length.
        /// </param>
        /// <returns>
        ///     The <see cref="object" />.
        /// </returns>
        private static object ByteArrayToStructure(byte[] source, int sourceIndex, Type destinationType, int length = 0)
        {
            if (length <= 0)
            {
                length = Marshal.SizeOf(destinationType);
            }

            IntPtr unmanagedMemory = Marshal.AllocHGlobal(length);

            Marshal.Copy(source, sourceIndex, unmanagedMemory, length);

            object returnValue = Marshal.PtrToStructure(unmanagedMemory, destinationType);

            Marshal.FreeHGlobal(unmanagedMemory);

            return returnValue;
        }
    }
}