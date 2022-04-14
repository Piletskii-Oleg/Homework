namespace SparseVector;

/// <summary>
/// Class that represents a sparse vector.
/// </summary>
public class Vector
{
    private readonly Dictionary<int, int> values;

    /// <summary>
    /// Initializes a new instance of the <see cref="Vector"/> class.
    /// </summary>
    /// <param name="capacity">Length of the vector.</param>
    public Vector(long capacity)
    {
        this.Capacity = capacity;
        this.values = new Dictionary<int, int>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Vector"/> class.
    /// </summary>
    /// <param name="array">Array based on which a vector is created.</param>
    public Vector(int[] array)
    {
        this.Capacity = array.Length;
        this.values = new Dictionary<int, int>();
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] != 0)
            {
                this.values.Add(i, array[i]);
            }
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Vector"/> class.
    /// </summary>
    /// <param name="list">List based on which a vector is created.</param>
    public Vector(List<int> list)
    {
        this.Capacity = list.Count;
        this.values = new Dictionary<int, int>();
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] != 0)
            {
                this.values.Add(i, list[i]);
            }
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Vector"/> class by copying a vector.
    /// </summary>
    /// <param name="vector">Vector to copy.</param>
    public Vector(Vector vector)
    {
        this.Capacity = vector.Capacity;
        this.values = vector.values;
    }

    /// <summary>
    /// Gets capacity of the vector.
    /// </summary>
    public long Capacity { get; private set; }

    /// <summary>
    /// Gets amount of the non-zero values in the vector.
    /// </summary>
    public int Count { get => this.values.Count; }

    /// <summary>
    /// Gets value of the vector stored at the index.
    /// </summary>
    /// <param name="index">Index at which value is stored.</param>
    /// <returns>Value at the index.</returns>
    public int this[int index]
    {
        get => this.values[index];
    }

    /// <summary>
    /// Calculates dot product of two vectors.
    /// </summary>
    /// <param name="vector">One vector of the dot product.</param>
    /// <param name="anotherVector">Another vector of the dot product.</param>
    /// <returns>Dot product.</returns>
    /// <exception cref="ArgumentException">Throws if vectors were not of the same size.</exception>
    public static int DotProduct(Vector vector, Vector anotherVector)
    {
        if (anotherVector.Capacity != vector.Capacity)
        {
            throw new ArgumentException("Vector was not of correct size", nameof(anotherVector));
        }

        int result = 0;
        foreach (var item in anotherVector.values.Keys)
        {
            if (vector.values.ContainsKey(item))
            {
                result += vector.values[item] * anotherVector.values[item];
            }
        }

        return result;
    }

    /// <summary>
    /// Checks whether the vector is null vector.
    /// </summary>
    /// <param name="vector">Vector that is checked.</param>
    /// <returns>True if it is null vector and false otherwise.</returns>
    public static bool IsNullVector(Vector vector)
    {
        return !vector.values.Any();
    }

    /// <summary>
    /// Adds another vector to the current one.
    /// </summary>
    /// <param name="anotherVector">A vector contents of which will be added.</param>
    /// <exception cref="ArgumentException">Throws if vectors were not of the same size.</exception>
    public void Add(Vector anotherVector)
    {
        if (anotherVector.Capacity != this.Capacity)
        {
            throw new ArgumentException("Vector was not of correct size", nameof(anotherVector));
        }

        foreach (var item in anotherVector.values.Keys)
        {
            if (this.values.ContainsKey(item))
            {
                this.values[item] += anotherVector.values[item];
            }
            else
            {
                this.values.Add(item, anotherVector.values[item]);
            }

            if (this.values[item] == 0)
            {
                this.values.Remove(item);
            }
        }
    }

    /// <summary>
    /// Subtracts values of a vector from the current one.
    /// </summary>
    /// <param name="anotherVector">A vector contents of which will be subtracted.</param>
    /// <exception cref="ArgumentException">Throws if vectors were not of the same size.</exception>
    public void Subtract(Vector anotherVector)
    {
        if (anotherVector.Capacity != this.Capacity)
        {
            throw new ArgumentException("Vector was not of correct size", nameof(anotherVector));
        }

        foreach (var item in anotherVector.values.Keys)
        {
            if (this.values.ContainsKey(item))
            {
                this.values[item] -= anotherVector.values[item];
            }
            else
            {
                this.values.Add(item, -anotherVector.values[item]);
            }

            if (this.values[item] == 0)
            {
                this.values.Remove(item);
            }
        }
    }

    /// <summary>
    /// Checks whether the vector that called the method is null vector.
    /// </summary>
    /// <returns>True if it is null vector and false otherwise.</returns>
    public bool IsNullVector()
    {
        return !this.values.Any();
    }
}
