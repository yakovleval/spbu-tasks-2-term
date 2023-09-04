using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparseVector
{
    /// <summary>
    /// class that implements sparse vector with addition, subtraction and
    /// multiplication scalar operations
    /// </summary>
    public class SparseVector
    {
        private Dictionary<int, int> vector = new();
        public int Size { get; private set; } = 0;

        public SparseVector() { }
        public SparseVector(Dictionary<int, int> other)
        {
            int maxIndex = 0;
            foreach (var (index, value) in other)
            {
                if (index > maxIndex)
                    maxIndex = index;
                if (value != 0)
                    vector[index] = value;
            }
            Size = maxIndex;
        }
        public SparseVector(int[] other)
        {
            Size = other.Length;
            for (int i = 0; i < Size; i++)
            {
                if (other[i] != 0)
                    vector[i] = other[i];
            }
        }
        private void MultiplyByNegativeOne()
        {
            Dictionary<int, int> result = new();
            foreach (var (index, elem) in vector)
            {
                result[index] = -elem;
            }
            vector = result;
        }
        
        private int GetValueAt(int index) => vector.GetValueOrDefault(index, 0);
        private void AddValueAt(int index, int value)
        {
            vector[index] = GetValueAt(index) + value;
            if (vector[index] == 0)
                vector.Remove(index);
        }
        /// <summary>
        /// adds two vectors value by value 
        /// </summary>
        /// <param name="other">vector to add this vector with</param>
        /// <returns>result of addition</returns>
        /// <exception cref="InvalidOperationException">thrown if vectors' sizes are not equal</exception>
        public SparseVector Add(SparseVector other)
        {
            if (Size != other.Size)
                throw new InvalidOperationException("vectors' sizes differ");
            foreach (var (index, value) in vector)
            {
                other.AddValueAt(index, value);
            }
            return other;
        }
        /// <summary>
        /// subtracts <param name="other"> vector from this vector
        /// </summary>
        /// <param name="other">vector to subtract</param>
        /// <returns>result of subtraction</returns>
        /// <exception cref="InvalidOperationException">thrown if vectors' sizes are not equal</exception>
        public SparseVector Subtract(SparseVector other)
        {
            if (Size != other.Size)
                throw new InvalidOperationException("vectors' sizes differ");
            other.MultiplyByNegativeOne();
            return this.Add(other);
        }
        /// <summary>
        /// scalar multiplies two vectors 
        /// </summary>
        /// <param name="other">vector to multiply this vector with</param>
        /// <returns>result of multiplication</returns>
        /// <exception cref="InvalidOperationException">thrown if vectors' sizes are not equal</exception>
        public int ScalarMultiply(SparseVector other)
        {
            if (Size != other.Size)
                throw new InvalidOperationException("vectors' sizes differ");
            int result = 0;
            foreach (var (index, value) in vector)
            {
                result += value * other.GetValueAt(index);
            }
            return result;
        }
        /// <summary>
        /// checks if vector is zero
        /// </summary>
        /// <returns>true if vector is zero, false otherwise</returns>
        public bool IsZero() => vector.Count == 0;
        /// <summary>
        /// checks if two vectors are equal
        /// </summary>
        /// <param name="other">vector to compare this vector to</param>
        /// <returns>true if two vectors are equal, false otherwise</returns>
        public bool IsEqual(SparseVector other)
        {
            return this.Subtract(other).IsZero();
        }
    }
}
